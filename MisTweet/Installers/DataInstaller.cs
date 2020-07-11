using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MisTweet.Data;
using MisTweet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<MisTweetsDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("MisTweetsDBConnection")));

            services.AddScoped<IPostService, PostSqlService>();
        }
    }
}
