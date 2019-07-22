using System.Threading.Tasks;
using Abp.Application.Services;
using Notes.WebApi.Authorization.Accounts.Dto;

namespace Notes.WebApi.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
