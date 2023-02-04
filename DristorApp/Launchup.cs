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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DristorApp.Repositories.CartRepository;
using DristorApp.Repositories.CouponRepository;
using DristorApp.UserManagementService;
using System.Collections.Generic;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DristorApp", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddDbContext<AppDbContext>(options =>
                       options.UseNpgsql(
                           Configuration.GetConnectionString("DristorDbConnection")
                           )
                       );


            //var sqlConnectionString = Configuration.GetConnectionString("DristorDbConnection");
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseNpgsql(
            //        sqlConnectionString,
            //        b => b.MigrationsAssembly("DritstorApp")
            //    )
            //);



            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt:Secret").Value)),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddScoped<IProductRepository, ImplProductRepository>();
            services.AddScoped<IUserRepository, ImplUserRepository>();
            services.AddScoped<IRepository<Token, string>, ImplRepository<Token, string>>();
            services.AddScoped<IRepository<Address, int>, ImplRepository<Address, int>>();
            services.AddScoped<IRoleRepository, ImplRoleRepository>();

            services.AddScoped<IRepository<Ingredient, int>, ImplRepository<Ingredient, int>>();
            services.AddScoped<IRepository<ProductVariant, int>, ImplRepository<ProductVariant, int>>();
            services.AddScoped<IOrderRepository, ImplOrderRepository>();
            services.AddScoped<IRepository<OrderStatusUpdate, int>, ImplRepository<OrderStatusUpdate, int>>();
            services.AddScoped<ICouponRepository, ImplCouponRepository>();
            services.AddScoped<IUserManagementService, ImplUserManagementService>();
            services.AddScoped<ICartItemRepository, ImplCartItemRepository>();
            services.AddScoped<IRepository<OrderItem, int>, ImplRepository<OrderItem, int>>();
            System.Diagnostics.Debug.WriteLine("Launchup ConfigureServices ");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            System.Diagnostics.Debug.WriteLine("Launchup env.IsDevelopment() " + env.IsDevelopment());
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
            CreateRoles(app.ApplicationServices);

        }
        private void CreateRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();
            System.Diagnostics.Debug.WriteLine("CreateRoles roleManager " + (roleManager is null));
            if (roleManager is null)
            {
                throw new Exception("Role manager not configured.");
            }

            var roles = Configuration.GetSection("Identity:DefaultRoles").Get<List<string>>();
            System.Diagnostics.Debug.WriteLine("start CreateRoles roles " + roles);
            roles.ForEach(element => System.Diagnostics.Debug.WriteLine("current CreateRoles element " + element));
            //roles.ForEach(Console.WriteLine);
            System.Diagnostics.Debug.WriteLine("end CreateRoles roles " + roles);

            foreach (var role in roles)
            {
                var isRoleExisted = roleManager.RoleExistsAsync(role).Result;
                System.Diagnostics.Debug.WriteLine("CreateRoles isRoleExisted " + isRoleExisted);
                if (isRoleExisted) continue;

                var result = roleManager.CreateAsync(new Role { Name = role }).Result;
                System.Diagnostics.Debug.WriteLine("CreateRoles result.Succeeded " + result.Succeeded);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join('\n', result.Errors));
                }
            }
        }
    }
}

