using AFirmasi.MyNotes.Business;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebApiService
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
            services.AddDbContext<MyNotesDbContext>(
        options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("AFirmasi.MyNotes.WebApiService")));
            services.AddTransient<INoteService, NoteManager>();
            services.AddTransient<INoteRepository, NoteDal>();
            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            SeedDatabase.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
