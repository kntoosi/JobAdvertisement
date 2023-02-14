using CrouseServiceAdvertisement.Configuration;
using CrouseServiceAdvertisement.Data;
using CrouseServiceAdvertisement.Interfaces;
using CrouseServiceAdvertisement.MiddleWares;
using CrouseServiceAdvertisement.Services;
using CrouseServiceEmployment.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CrouseServiceAdvertisement
{
    public class Startup
    {


        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CrouseAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CrouseCVApp"));
            });
            services.AddDbContext<CrouseDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CrouseCV"));
            });

            services.AddAuthentication()
                .AddJwtBearer("crouse_services", jwt =>
                {
                    RSA rsa = RSA.Create();
                    rsa.ImportSubjectPublicKeyInfo(
                        source: Convert.FromBase64String(Configuration["Jwt:Keys:services"]),
                        bytesRead: out int _
                    );

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                        ValidateLifetime = true,
                        ValidIssuer = CrConsts.IdentityService,
                        ValidAudience = CrConsts.CrouseServices,
                        IssuerSigningKey = new RsaSecurityKey(rsa),

                        NameClaimType = CrouseClaimTypes.uid,
                        RoleClaimType = CrouseClaimTypes.role
                    };
                })
                .AddJwtBearer("crouse_website", jwt =>
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Keys:website"]));

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                        ValidateLifetime = true,
                        ValidIssuer = CrConsts.CrouseWebsite,
                        ValidAudience = CrConsts.CrouseServices,
                        IssuerSigningKey = securityKey,

                        NameClaimType = CrouseClaimTypes.uid,
                        RoleClaimType = CrouseClaimTypes.role
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("crouse_services", "crouse_website")
                    .Build();

                options.AddPolicy("AdsAdd", option => { option.RequireClaim("EmploymentAdvertisement.Permissions", "Add"); });
                options.AddPolicy("AdsEdit", option => { option.RequireClaim("EmploymentAdvertisement.Permissions", "Edit"); });
                options.AddPolicy("AdsSearch", option => { option.RequireClaim("EmploymentAdvertisement.Permissions", "Search"); });
            });

            services.AddSingleton<IInitializeService, InitializeService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();

            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Crouse-Services API", Description = "سرویس آگهی استخدام", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                    System.Array.Empty<string>()
                }
                }
                );
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsEducationOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsForeignLangOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsMasterDetailsOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsSkillsOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsWrkBenefitOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsOutputEntity>>();
                c.DocumentFilter<SwaggerModelDocumentFilter<CrouseServiceAdvertisement.Models.AdsOutputEntity>>();

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestStartLogger();
            app.UseSerilogRequestLogging();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crouse-Services API");
            });

            app.UseRequestFinishLogger();
        }
    }
}
