using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkillOrgBE.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkillOrgBE.API.Services;

namespace SkillOrgBE
{
    public class Startup
    {

        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>{
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );                //.AllowCredentials());
            });

            services
            .AddMvc(option => option.EnableEndpointRouting = false)
            .AddNewtonsoftJson();
            var testConnectionString = _config["connectionStrings:latenightdb"];
            services.AddDbContext<LnDBContext>(o =>
            {
                o.UseSqlServer(testConnectionString);
            });
            services.AddScoped<ILnRepository, LnRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");   

            }
            else{
                app.UseExceptionHandler();
            }

            app.UseMvc();
            app.UseStatusCodePages();

        }
    }
}
