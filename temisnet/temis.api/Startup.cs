using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using temis.Core.DTO;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;
using temis.Core.Services.Service;
using temis.data.Data;
using temis.Data.Repositories;

namespace temis.api
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
            string connectionString = "Server=151.106.96.101;Port=3306;Database=u590093429_temis;Uid=u590093429_temisuser;Pwd=TemisUser1;convert zero datetime=True;";
            services.AddDbContext<TemisContext>((options) => options.UseMySql(connectionString));

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IJudgmentRepository, JudgmentRepository>();
            services.AddScoped<IJudgmentService, JudgmentService>();

            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IProcessService, ProcessService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "temis.api", 
                    Version = "v1" ,
                    Description = "Coder Trainee Training with ASP.NET 3.1",
                    Contact = new OpenApiContact
                    {
                        Name = "Coder Trainee Training with ASP.NET 3.1 - Repository",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/PaschoalOliveira/temis/tree/feature/dotnet"),
                    }
                });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDto>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().AddXmlDataContractSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "temis.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
