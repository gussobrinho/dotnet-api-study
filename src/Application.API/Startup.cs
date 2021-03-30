using API.Infrastructure.Authentication;
using API.Infrastructure.Authentication.Security;
using API.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures[0], supportedCultures[0]),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            services.AddHttpContextAccessor();

            services.AddSwaggerGen()
                .Configure<SwaggerGenOptions>(c =>
                {
                    var security = new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Id = "Bearer Token", Type = ReferenceType.SecurityScheme }
                    };
                    c.AddSecurityDefinition("Bearer Token", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.\n\n" +
                                      "Example: Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IktpQTdUSXNG",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                    Configuration.Bind("Swagger:SwaggerGenOptions", c);
                })
                .Configure<SwaggerUIOptions>(c => this.Configuration.Bind("Swagger:SwaggerUIOptions", c));

            services.AddBootstrapperIoC(this.Configuration);

            //services.AddAuthorization();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //var signingConfigurations = new SigningConfigurations();
            //services.AddSingleton(signingConfigurations);

            //var tokenConfigurations = new TokenConfigurations();
            //new ConfigureFromConfigurationOptions<TokenConfigurations>(
            //    Configuration.GetSection("TokenConfigurations"))
            //        .Configure(tokenConfigurations);
            //services.AddSingleton(tokenConfigurations);

            //services.AddAuthentication(authOptions =>
            //{
            //    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(bearerOptions =>
            //{
            //    var paramsValidation = bearerOptions.TokenValidationParameters;
            //    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
            //    paramsValidation.ValidAudience = tokenConfigurations.Audience;
            //    paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
            //    paramsValidation.ValidateIssuerSigningKey = true;
            //    paramsValidation.ValidateLifetime = true;
            //    paramsValidation.ClockSkew = TimeSpan.Zero;
            //});

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader().WithExposedHeaders("X-Pagination")
                                                                     ));

        }
    }
}
