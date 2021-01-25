using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TOTVSChallenge.API.DependencyGroups;
using System.IO;
using FluentValidation.AspNetCore;
using TOTVSChallenge.Respository.Database.Context;
using Microsoft.EntityFrameworkCore;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Respository.Database.Transacions;
using TOTVSChallenge.API.Middleware;
using TOTVSChallenge.Domain.Helpers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

namespace TOTVSChallenge.API
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(new[] {"http://localhost:4200" })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            

            services.AddControllers();

            services.AddMvc()
            .AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .AddFluentValidation(config =>
                config.RegisterValidatorsFromAssemblyContaining<Startup>());

            var connection = Configuration["SqliteConnection:SqliteConnectionString"];

            services.AddDbContext<TOTVSChallengeContext>(opt =>
                opt.UseSqlite(connection)
            );

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<TOTVSChallengeContext, TOTVSChallengeContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            new string[] {}
                    }
                });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            ApplicationServiceDependencies.ConfigureServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TOTVS Challenge API V1");
                c.RoutePrefix = string.Empty;
            });

            

            //app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();
            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseMvc();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
