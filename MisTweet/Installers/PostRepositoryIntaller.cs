using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MisTweet.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Installers
{
    public class PostRepositoryIntaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PostRepository>();
        }
    }
}
