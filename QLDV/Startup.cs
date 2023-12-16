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
using QLDV.Interfaces;
using QLDV.Models;
using QLDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV
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
            services.AddDbContext<HeThongContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("MyDB"));
            }
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QLDV", Version = "v1" });
            });
            services.AddScoped<LoaiDonViInterface, LoaiDonViRepository>();
            services.AddScoped<DonViInterface, DonViRepository>();
            services.AddScoped<CanBoInterface, CanBoRepository>();
            services.AddScoped<NhomTBInterface, NhomTBRepository>();
            services.AddScoped<LoaiTBInterface, LoaiTBRepository>();
            services.AddScoped<ThietBiInterface, ThietBiRepository>();
            services.AddScoped<HocVienInterface, HocVienRepository>();
            services.AddScoped<KHHLInterface, KHHLRepository>();






            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials(); // Nếu cần sử dụng cookie hoặc thông tin xác thực
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QLDV v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowLocalhost3000"); // Áp dụng cấu hình CORS
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
