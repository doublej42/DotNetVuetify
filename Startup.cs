using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using Microsoft.AspNetCore.SpaServices;

namespace DotNetVuetify
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
            services.AddRazorPages();

            //In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller}/{action=Index}/{id?}");
            // });
            app.UseRouting();
            //app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                // initialize vue cli middleware
                //TODO setup non debuggin mode https://github.com/EEParker/aspnetcore-vueclimiddleware

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy("{*path}", new SpaOptions { SourcePath = "clientapp" },
                                     npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                                     regex: "Compiled successfully");
                }
                // note: output of vue cli or quasar cli should be wwwroot
                //endpoints.MapFallbackToFile("index.html");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "clientapp";
            });
        }
    }
}
