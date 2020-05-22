using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using MonsterApi.Data;
using MonsterApi.Data.Repositories;
using MonsterApi.Models;
using System.Linq;
using System.Text;
using System;

namespace MonsterApi
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
            services.AddDbContext<MonsterContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("MonsterContext"), options => options.EnableRetryOnFailure()));

            services.AddScoped<MonsterDataInitializer>();
            services.AddScoped<IMonsterRepository, MonsterRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>(cfg => cfg.User.RequireUniqueEmail = true).AddEntityFrameworkStores<MonsterContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;

                //--Don't want to annoy users too much
                options.Password.RequireNonAlphanumeric = false;
                
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            // Register the Swagger services
            services.AddSwaggerDocument();
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Monster API";
                c.Version = "v1";
                c.Description = "The Monster API documentation description";
                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme 
                { 
                    Type = OpenApiSecuritySchemeType.ApiKey, 
                    Name = "Authorization", 
                    In = OpenApiSecurityApiKeyLocation.Header, 
                    Description = "Type into the textbox: Bearer {your JWT token}." 
                }); 
                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            services.AddCors(options =>
            options.AddPolicy("AllowAllOrigins", builder =>
            builder.AllowAnyOrigin()));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MonsterDataInitializer monsterDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            monsterDataInitializer.InitializeData().Wait();
            app.UseCors("AllowAllOrigins");

            app.UseAuthentication();
        }
    }
}
