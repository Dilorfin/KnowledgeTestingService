using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace KnowledgeTestingService.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.ResolveDalDependencies(Configuration.GetConnectionString("KnowledgeTestingService"));
            services.ResolveIdentityDependencies(
                Configuration.GetConnectionString("KnowledgeTestingAuth"),
                Configuration["JWT:SigningKey"],
                Configuration["JWT:EncryptionKey"]
            );
            services.ResolveServicesDependencies();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../../Client/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
                .WithOrigins(Configuration["SpaHost"])
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../../Client";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer(Configuration["SpaHost"]);
                }
            });
        }
    }
}
