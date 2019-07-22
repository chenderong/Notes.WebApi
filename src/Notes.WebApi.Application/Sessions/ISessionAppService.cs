using System.Threading.Tasks;
using Abp.Application.Services;
using Notes.WebApi.Sessions.Dto;

namespace Notes.WebApi.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
