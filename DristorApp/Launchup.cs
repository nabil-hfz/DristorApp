using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.OrderRepository;
using DristorApp.Repositories.ProductRepository;
using DristorApp.Repositories.Roles;
using Microsoft.Extensions.DependencyInjection;
using DristorApp.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

namespace DristorApp
{
	public class Launchup
	{
        public IConfiguration Configuration { get; }

        public Launchup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // DI here
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DristorApp", Version = "v1" });
           
            });

            services.AddDbContext<AppDbContext>(options =>
                       options.UseNpgsql(
                           Configuration.GetConnectionString("DristorDbConnection")
                           )
                       );


            services.AddScoped<IProductRepository, ImplProductRepository>();
            services.AddScoped<IUserRepository, ImplUserRepository>();
            services.AddScoped<IRepository<Token, string>, ImplRepository<Token, string>>();
            services.AddScoped<IRepository<Address, int>, ImplRepository<Address, int>>();
            services.AddScoped<IRoleRepository, ImplRoleRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DristorApp v1"));
            }


            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200")
            );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}

