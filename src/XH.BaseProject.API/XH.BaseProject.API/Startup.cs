using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using XH.BaseProject.API.Contants;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Infastructure;
using XH.BaseProject.Infastructure.Database;

namespace XH.BaseProject.API
{
    public class Startup
    {
        private readonly string connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.connectionString = Configuration.GetConnectionString("BaseContext");
        }

        public IConfiguration Configuration { get; }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            // config swagger
            services.AddSwaggerGen(c=>
            {
             c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseProject", Version = "v1", Description = "Project By XH" });
             c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
             {
                 Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                 Name = "Authorization",
                 In = ParameterLocation.Header,
                 Type = SecuritySchemeType.ApiKey,
                 Scheme = "Bearer"
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
            }          
            );
            // config apiversionning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            //config authentication jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[JwtTokenConstants.SecretKey]));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidIssuer = Configuration[JwtTokenConstants.Issuer],
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration[JwtTokenConstants.Audience],
                        IssuerSigningKey = credentials.Key,// new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[JwtTokenConstants.SecretKey])),
                        ClockSkew = TimeSpan.Zero,
                        SaveSigninToken = true,
                    };
                });

            AplicationStartup.Initialize(Configuration, services,connectionString);
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            //builder.RegisterAssemblyModules(typeof(RepositoryInjectModule).Assembly);
            builder.RegisterModule(new DataAccessModule(connectionString));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "API BaseProject"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"BaseProject service. Now {DateTime.Now.ToString()}");
                });
            });
        }
    }
}
