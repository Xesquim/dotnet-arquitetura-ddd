using Api.Domain.Interfaces.Services.City;
using Api.Domain.Interfaces.Services.Security;
using Api.Domain.Interfaces.Services.Si;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.ZipCode;
using Api.Service.Services.City;
using Api.Service.Services.Security;
using Api.Service.Services.Si;
using Api.Service.Services.User;
using Api.Service.Services.ZipCode;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IEncryptService, EncryptService>();
            serviceCollection.AddTransient<ISiService, SiService>();
            serviceCollection.AddTransient<ICityService, CityService>();
            serviceCollection.AddTransient<IZipCodeService, ZipCodeService>();
        }
    }
}
