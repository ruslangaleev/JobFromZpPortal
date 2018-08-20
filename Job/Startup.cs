using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Job.Data.Repositories.Interfaces;
using Job.Data.Repositories.Logic;
using Job.Services.Clients.Interfaces;
using Job.Services.Clients.Logic;
using Job.Services.Services.Interfaces;
using Job.Services.Services.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Job
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IVacancyManager, VacancyManager>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IZpClient, ZpClient>();
            services.AddScoped<IVersionRepository, VersionRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
