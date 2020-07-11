
namespace MisTweet.Installers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MisTweet.Services;

    public class MockSingInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IPostService, PostServiceMock>();
        }
    }
}
