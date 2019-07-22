using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Notes.WebApi.Application.Blogs.Dto;
using Notes.WebApi.Application.Dtos;
using Notes.WebApi.Authorization;
using Notes.WebApi.Core.Blogs;

namespace Notes.WebApi.Blogs
{
    public class TagAppService : WebApiAppServiceBase, ITagAppService
    {
        private readonly IRepository<Tag, long> _tagRepository;

        public TagAppService(IRepository<Tag, long> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> GetTagByIdAsync(long tagId)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag);
            //AbpSession.UserId
            var tag = await _tagRepository.FirstOrDefaultAsync(p => p.Id == tagId && p.CreatorUserId == AbpSession.UserId);

            return Mapper.Map<TagDto>(tag);
        }

        //public async Task<bool> CreateTagAsync(CreateTagDto input)
        //{
        //    PermissionChecker.Authorize(PermissionNames.Page_Tag_Add);

        //    var obj = await _tagRepository.FirstOrDefaultAsync(p => p.Title == input.Title && p.CreatorUserId == AbpSession.UserId);
        //    if (obj != null)
        //    {
        //        CheckErrors(IdentityResult.Failed(new IdentityError() { Code = "308", Description = L("CreateTagError") }));
        //    }
        //    //Tag tag = new Tag();
        //    //tag.Title = input.Title;
        //    var tag = Mapper.Map<Tag>(input);
        //    //var task = ObjectMapper.Map<Tag>(input);
        //    return await _tagRepository.InsertAndGetIdAsync(tag) > 0;
        //}


        public async Task<IdentityResult> CreateTagAsync(CreateTagDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag_Add);

            var obj = await _tagRepository.FirstOrDefaultAsync(p => p.Title == input.Title && p.CreatorUserId == AbpSession.UserId);
            if (obj != null)
            {

                return IdentityResult.Failed(new IdentityError() { Code = "308", Description = L("CreateTagError") });
            }
            //Tag tag = new Tag();
            //tag.Title = input.Title;
            var tag = Mapper.Map<Tag>(input);
            //var task = ObjectMapper.Map<Tag>(input);
            if (await _tagRepository.InsertAndGetIdAsync(tag) > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError() { Code = "500", Description = L("CreateTagError") });

        }
        //[AbpAuthorize(PermissionNames.Page_Tag_Delete)]
        public async Task<bool> DeleteTagAsync(DeleteTagDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag_Delete);

            await _tagRepository.DeleteAsync(input.Id);
            return true;
        }

        //[AbpAuthorize(PermissionNames.Page_Tag_Update)]
        public async Task<bool> UpdateTagAsync(UpdateTagDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag_Update);

            var tag = await _tagRepository.GetAsync(input.Id);
            if (tag != null)
            {
                tag = input.MapTo(tag);//修改必须要
                await _tagRepository.UpdateAsync(tag);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public async Task<IList<TagDto>> GetAllTagsAsync()
        //{
        //    PermissionChecker.Authorize(PermissionNames.Page_Tag);
        //    var tags = await _tagRepository.GetAllListAsync(p => p.CreatorUserId == AbpSession.UserId);
        //    return Mapper.Map<IList<TagDto>>(tags);
        //}

        public async Task<ListResultDto<TagDto>> GetAllTagsAsync()
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag);
            var tags = await _tagRepository.GetAllListAsync(p => p.CreatorUserId == AbpSession.UserId);
            //return Mapper.Map<IList<TagDto>>(tags);
            //return new  ListResultDto<TagDto>(Mapper.Map<IList<TagDto>>(tags));
            return new ListResultDto<TagDto>(ObjectMapper.Map<List<TagDto>>(tags));
        }

        public async Task<PagedResultDto<TagDto>> GetAllTagsByPageAsync(PagedAndFilteredInputDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag);
            if (string.IsNullOrEmpty(input.Filter))
            {
                int count = await _tagRepository.CountAsync(p => p.CreatorUserId == AbpSession.UserId);
                var list = _tagRepository.GetAll().Where(p => p.CreatorUserId == AbpSession.UserId).PageBy(input).ToList();
                return new PagedResultDto<TagDto>(count, Mapper.Map<List<TagDto>>(list));
            }
            else
            {
                int count = await _tagRepository.CountAsync(p => p.CreatorUserId == AbpSession.UserId && p.Title.Contains(input.Filter));
                var list = _tagRepository.GetAll().Where(p => p.CreatorUserId == AbpSession.UserId && p.Title.Contains(input.Filter)).PageBy(input).ToList();
                return new PagedResultDto<TagDto>(count, Mapper.Map<List<TagDto>>(list));
            }
        }


        //[AbpAuthorize(PermissionNames.Page_Tag)]
        public async Task<PagedResultDto<TagDto>> GetTagsByPageAsync(PagedAndFilteredInputDto input)
        {
            PermissionChecker.Authorize(PermissionNames.Page_Tag);
            int count = await _tagRepository.CountAsync(p => p.Title.Contains(input.Filter));
            var list = _tagRepository.GetAll().PageBy(input).ToList();
            //list.MapTo<List<TagDto>>();
            return new PagedResultDto<TagDto>(count, Mapper.Map<List<TagDto>>(list));
        }
    }
}
