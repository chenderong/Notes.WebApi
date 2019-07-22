using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Identity;
using Notes.WebApi.Application.Blogs.Dto;
using Notes.WebApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Blogs
{
   public interface ITagAppService : IApplicationService
    {
        Task<TagDto> GetTagByIdAsync(long TagId);
        //Task<bool> CreateTagAsync(CreateTagDto input);
        Task<IdentityResult> CreateTagAsync(CreateTagDto input);
        
        Task<bool> DeleteTagAsync(DeleteTagDto input);
        //Task<IList<TagDto>> GetAllTagsAsync();
        Task<ListResultDto<TagDto>> GetAllTagsAsync();
     
        Task<PagedResultDto<TagDto>> GetAllTagsByPageAsync(PagedAndFilteredInputDto input);


        Task<bool> UpdateTagAsync(UpdateTagDto input);

        Task<PagedResultDto<TagDto>> GetTagsByPageAsync(PagedAndFilteredInputDto input);
    }
}
