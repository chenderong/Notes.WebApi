using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Notes.WebApi.Authorization;

namespace Notes.WebApi
{
    [DependsOn(
        typeof(WebApiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebApiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WebApiAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BlogsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WebApiApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
