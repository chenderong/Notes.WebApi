using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Notes.WebApi.MultiTenancy.Dto;

namespace Notes.WebApi.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

