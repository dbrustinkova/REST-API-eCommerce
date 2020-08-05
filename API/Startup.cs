using AppGr8.WebApiECommerce.DataAccess;
using AppGr8.WebApiECommerce.DataAccess.MockData;
using AppGr8.WebApiECommerce.DataAccess.Repositories;
using AppGr8.WebApiECommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Text;

namespace AppGr8.WebApiECommerce.Api
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var tokenKey = "AppSettings:Token";
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<ProductService>();
            services.AddScoped<IProductRepository, ProductsRepository>();

            services.AddScoped<OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey));

            var connectionString = configuration.GetConnectionString("ProductsDB");
            services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));


            services.AddSwaggerExamplesFromAssemblyOf<Startup>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rest API Task - eCommerce",
                    Version = "v1",
                    Description = "Junior Backend Developer"
                });
                options.IgnoreObsoleteActions();
                options.ExampleFilters();
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] { }
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest API Task v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Migrate(app);
        }

        private static async void Migrate(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var dataContext = services.GetRequiredService<DataContext>();
                await dataContext.Database.MigrateAsync();
                await Seed.SeedProducts(dataContext);
                await Seed.SeedUsers(dataContext);
                await Seed.SeedOrders(dataContext);
                await CurrencyExchangeService.ExecuteJsonAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
