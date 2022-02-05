using classbook.dl.Interfaces;
using classbook.dl.Repositories;
using classbook.dl.Repositories.InMemoryRepos;
using classbook.dl.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace classbook
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

            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IStudentRepository, StudentInMemoryRepository>();
            services.AddSingleton<IGradeRepository, GradesInMemoryRepository>();
            services.AddSingleton<ITeacherRepository, TeacherInMemoryRepository>();

            services.AddSingleton<ITeacherService, TeacherService>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddSingleton<IGradeService, GradesService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "classbook", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "classbook v1"));
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