using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Convention.API.Middleware;
using Convention.API.Security;
using Convention.BLL;
using Convention.BLL.Infrastructure.Helpers;
using Convention.DAL;
using Convention.Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Convention.API
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

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });

            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.ConventionManager,
                    AddScopeRequirementsToPolicy(PermissionScope.ConventionCreate));
                options.AddPolicy(Policies.SpeakerManager,
                    AddScopeRequirementsToPolicy(PermissionScope.SpeakerApprove, PermissionScope.SpeakerRemove));
                options.AddPolicy(Policies.TalkCreator, AddScopeRequirementsToPolicy(PermissionScope.TalkCreate));
                options.AddPolicy(Policies.TalkManager,
                    AddScopeRequirementsToPolicy(PermissionScope.TalkApprove, PermissionScope.TalkRemove));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Convention.API", Version = "v1"});
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.AddHttpContextAccessor();
            services.AddBllServices(Configuration);
            services.AddSqlDbServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors("Default");

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Convention.API v1"); });

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static Action<AuthorizationPolicyBuilder> AddScopeRequirementsToPolicy(PermissionScope scope)
        {
            return policy => policy.Requirements.Add(new ScopeRequirement(EnumHelper.GetEnumDescription(scope)));
        }

        private static Action<AuthorizationPolicyBuilder> AddScopeRequirementsToPolicy(params PermissionScope[] scopes)
        {
            return policy =>
                policy.Requirements.Add(
                    new MultipleScopeRequirements(scopes.Select(m => EnumHelper.GetEnumDescription(m)).ToArray()));
        }

        public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();


                var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
        
            }
        }
    }
}