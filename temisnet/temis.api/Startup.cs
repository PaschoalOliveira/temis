using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Core.Services.Service;
using temis.data.Data;
using temis.Data.Repositories;
using System.Reflection;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using temis.Api.Models.DTO;
using temis.Api.Models.DTO.MemberDto;
using temis.api.Requests;
using System.Diagnostics.CodeAnalysis;
using temis.Api.Middleware;
using Elmah.Io.AspNetCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace temis.api
{
    [ExcludeFromCodeCoverageAttribute]
    public class Startup
    {
        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["MySQLConnection:MySQLConnectionString"];

            services.AddStackExchangeRedisCache(options => options.Configuration = this.Configuration.GetConnectionString("redisServerUrl"));

            services.AddDbContext<TemisContext>((options) => options.UseMySql(connectionString));
            services.AddHealthChecks().AddDbContextCheck<TemisContext>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IJudgmentRepository, JudgmentRepository>();
            services.AddScoped<IJudgmentService, JudgmentService>();

            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddControllers();

            services.AddCors(options =>
                {
                    options.AddPolicy("AnyOrigin", builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod();
                    });
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "temis.api",
                    Version = "v1",
                    Description = "Coder Trainee Training with ASP.NET 3.1",

                    Contact = new OpenApiContact
                    {
                        Name = "Coder Trainee Training with ASP.NET 3.1 - Repository",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/PaschoalOliveira/temis/tree/feature/dotnet"),
                    }
                });

                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
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
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>() }
                 });

            });

            var key = Encoding.ASCII.GetBytes(Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            /*   var config = new MapperConfiguration(cfg => {
                   cfg.AddMaps( new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly } );
               });
               IMapper mapper = config.CreateMapper(); */

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDto>();
                cfg.CreateMap<Judgment, JudgmentDto>();
                cfg.CreateMap<Process, ProcessDto>();
                cfg.CreateMap<Process, CreateProcessRequest>();
                cfg.CreateMap<CreateProcessRequest, Process>();
                cfg.CreateMap<PageResponse<Process>, PageProcessDto>();

            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddMemoryCache();
            services.AddControllers().AddXmlDataContractSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "temis.api v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "temis.api v2");
                });
            }
            app.UseCors("AnyOrigin");

          //  app.UseHealthChecks("/status");

            app.UseHealthChecks("/check", new HealthCheckOptions()
            {
                ResponseWriter = WriteResponse,
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            //  app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/v1/process"), appBuilder =>
            {
                appBuilder.UseMiddleware<RequestLoggingMiddleware>();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static Task WriteResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";
            var json = new JObject(
                new JProperty("HealthCheck", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JObject(pair.Value.Data.Select(p => new JProperty(p.Key, p.Value)))))))));

            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }
    }
}
