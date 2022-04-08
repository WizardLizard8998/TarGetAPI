using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarGetAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace TarGetAPI
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

           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TarGetAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });


            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
            });



            services.AddDbContext<CartContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<CartDetailsContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<CategoryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<CityContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<CustomerContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<DistrictContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<ProducersContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<ProductsContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<UserAccountContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            


            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TarGetAPI v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
