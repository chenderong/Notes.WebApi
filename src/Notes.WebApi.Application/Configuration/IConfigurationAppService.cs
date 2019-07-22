using System.Threading.Tasks;
using Notes.WebApi.Configuration.Dto;

namespace Notes.WebApi.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
