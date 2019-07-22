using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Notes.WebApi.Application.Dtos;
using Notes.WebApi.Authorization;
using Notes.WebApi.Blogs.Dto;
using Notes.WebApi.Core.Blogs;
using System.Linq;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;
using Notes.WebApi.Extensions;

namespace Notes.WebApi.Blogs
{
    public class BlogAppService : WebApiAppServiceBase, IBlogAppService
    {

        private readonly IRepository<Blog, long> _blogRepository;
        private readonly IRepository<Tag, long> _tagRepository;
        //private readonly IRepository<BlogTag, long> _blogTagRepository;

        public BlogAppService(IRepository<Blog, long> blogRepository, IRepository<Tag, long> tagRepository)
        {
            _blogRepository = blogRepository;
            _tagRepository = tagRepository;
            //_blogTagRepository = blogTagRepository;
        }


        public async Task<bool> CreateBlogAsync(CreateBlogDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Blog_Add);
            var blog = Mapper.Map<Blog>(input);
            input.SelectTags = input.SelectTags.Distinct().ToList();
            var tags = await _tagRepository.GetAllListAsync(p => input.SelectTags.Contains(p.Id));
            if (tags.Count > 0)
            {
                blog.BlogTags = new List<BlogTag>();
                var blogTags = tags.Select(p => new BlogTag() { Tag = p });
                foreach (var iObj in blogTags)
                    blog.BlogTags.Add(iObj);
            }

            return await _blogRepository.InsertAndGetIdAsync(blog) > 0;
        }

        public async Task<bool> DeleteBlogAsync(DeleteBlogDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Blog_Delete);
            await this._blogRepository.DeleteAsync(input.Id);
            return true;
        }

        public Task<IList<BlogDto>> GetAllTagsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<BlogDto>> GetAllBlogsByPageAsync(PagedAndFilteredInputDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Blog);
           var em= AbpSession.GetUserEmail();
            int totalCount = 0;
            List<Blog> list = new List<Blog>();
            List<BlogDto> listDto = new List<BlogDto>();
            var query = this._blogRepository.GetAll();
            if (string.IsNullOrEmpty(input.Filter))
            {
                if (input.From.HasValue && input.To.HasValue)
                    query = this._blogRepository.GetAll().Include("BlogTags").Where(p => p.CreatorUserId == AbpSession.UserId && ((p.CreationTime >= input.From && p.CreationTime <= input.To) || (p.LastModificationTime >= input.From && p.LastModificationTime <= input.To)));
                else
                    query = this._blogRepository.GetAll().Include("BlogTags").Where(p => p.CreatorUserId == AbpSession.UserId);
            }
            else
            {
                query = this._blogRepository.GetAll().Include("BlogTags").Where(p => p.CreatorUserId == AbpSession.UserId && (p.Title.Contains(input.Filter) || p.Content.Contains(input.Filter) || p.KeyWords.Contains(input.Filter) || p.Summary.Contains(input.Filter)));
                if (input.From.HasValue && input.To.HasValue)
                    query = query.Where(p => (p.CreationTime >= input.From && p.CreationTime <= input.To) || (p.LastModificationTime >= input.From && p.LastModificationTime <= input.To));
            }

            totalCount = await query.CountAsync();
            list = await query.PageBy<Blog>(input).ToListAsync();
            listDto = Mapper.Map<List<BlogDto>>(list);
            foreach (var iObj in list)
            {
                if (iObj.BlogTags != null && iObj.BlogTags.Count > 0)
                {
                    var obj = listDto.FirstOrDefault(p => p.Id == iObj.Id);
                    obj.SelectTags.AddRange(iObj.BlogTags.Select(p => p.TagId));
                }
            }
            var resultList = new PagedResultDto<BlogDto>(totalCount, listDto);
            return resultList;
        }

        public Task<BlogDto> GetBlogByIdAsync(long TagId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BlogDto>> GetBlogsByPageAsync(PagedAndFilteredInputDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateBlogAsync(UpdateBlogDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Blog_Update);
            if (input.Id == 0)
            {
                return false;
            }
            input.SelectTags = input.SelectTags.Distinct().ToList();
            var blog = await _blogRepository.GetAll().Include(p => p.BlogTags).FirstOrDefaultAsync(p => p.Id == input.Id);
            if (blog != null)
            {
                if (blog.BlogTags != null && blog.BlogTags.Count > 0)
                {
                    //删除没有选择的
                    var delblogTagsList = blog.BlogTags.Where(p => !input.SelectTags.Contains(p.TagId)).ToList();
                    foreach (var iDelObj in delblogTagsList)
                        blog.BlogTags.Remove(iDelObj);

                    var blogTagsList = blog.BlogTags.Select(p => p.TagId);

                    var insertList = input.SelectTags.Where(p => !blogTagsList.Contains(p)).ToList();

                    var tags = await _tagRepository.GetAllListAsync(p => insertList.Contains(p.Id));
                    if (tags.Count > 0)
                    {
                        var blogTags = tags.Select(p => new BlogTag() { Tag = p });
                        foreach (var iObj in blogTags)
                            blog.BlogTags.Add(iObj);
                    }
                }
                else
                {
                    var tags = await _tagRepository.GetAllListAsync(p => input.SelectTags.Contains(p.Id));
                    if (tags.Count > 0)
                    {
                        blog.BlogTags = new List<BlogTag>();
                        var blogTags = tags.Select(p => new BlogTag() { Tag = p });
                        foreach (var iObj in blogTags)
                            blog.BlogTags.Add(iObj);
                    }
                }
                //var blogTagList= this._blogTagRepository.GetAll().Where(p=> input.SelectTags.Contains(p.TagId));
                blog = input.MapTo(blog);//修改必须要
                //await this._blogTagRepository.DeleteAsync(p => input.SelectTags.Contains(p.TagId));
                await _blogRepository.UpdateAsync(blog);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
