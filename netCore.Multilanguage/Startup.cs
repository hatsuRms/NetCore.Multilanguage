using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace netCore.Multilanguage
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //set the resource path
            services.AddLocalization(path =>
            {
                path.ResourcesPath = "Resources";
            });

            services.AddMvc().
                AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).//add compatibility of the languages files
                AddDataAnnotationsLocalization(); //add compatibility with validation messages

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //adding cultures languages.
            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("es") };
            //setting language supports and initialization of a language
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            //use language
            app.UseRequestLocalization(localizationOptions);


            app.UseStaticFiles();
            app.UseMvc(routers => {
                routers.MapRoute(name: "Default",
                     template: "{controller=Home}/{action=Index}"
                    );
            });
        }
    }
}
