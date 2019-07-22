using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Notes.WebApi.Roles.Dto;
using Notes.WebApi.Users.Dto;

namespace Notes.WebApi.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
