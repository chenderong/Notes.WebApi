using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Notes.WebApi.Application.Dtos;
using Notes.WebApi.Blogs.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Blogs
{
   public interface IBlogAppService: IApplicationService
    {
        Task<BlogDto> GetBlogByIdAsync(long TagId);
        Task<bool> CreateBlogAsync(CreateBlogDto input);

        Task<bool> DeleteBlogAsync(DeleteBlogDto input);

        Task<IList<BlogDto>> GetAllTagsAsync();

        Task<PagedResultDto<BlogDto>> GetAllBlogsByPageAsync(PagedAndFilteredInputDto input);


        Task<bool> UpdateBlogAsync(UpdateBlogDto input);

        Task<PagedResultDto<BlogDto>> GetBlogsByPageAsync(PagedAndFilteredInputDto input);
    }
}
