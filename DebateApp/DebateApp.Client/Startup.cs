using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//thing
namespace DebateApp.Client
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "debate",
                    template: "Debate/{username}/{password}",
                    defaults: new { controller = "Debate", action = "DebateIndex"}
                    
                );

                routes.MapRoute(
                    name: "myprofile",
                    template: "Debate/DebateIndex/{username}/{password}",
                    defaults: new { controller = "Debate", action = "MyProfile"}
                );

                routes.MapRoute(
                    name: "default",
                    template: "{*url}",
                    defaults: new { controller = "Login", action = "Login"}
                );
            });
        }
    }
}
