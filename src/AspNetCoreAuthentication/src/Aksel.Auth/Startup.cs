using Aksel.Models.Models.Authorization;
using Aksel.Repository;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Aksel.Service;
using Aksel.Service.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Aksel.Auth
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aksel Auth API", Version = "v1" });
            });

            AutoMapperConfiguration.Initialize();

            services.Configure<AudienceModel>(Configuration.GetSection("Audience"));

            services
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ILoginService, LoginService>();

            services.AddDbContext<AkselDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("AkselDbConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aksel Authentication API V1");
            });
        }
    }
}