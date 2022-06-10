using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebBackend;

namespace WebApplication2
{
    public class Main
    {
        public static void Start()
        {
            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder();

            var assembly = typeof(WeatherForecast).Assembly; // Could be any type from external assembly
            builder.Services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
            builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            builder.WebHost.UseUrls("http://localhost:16000");

            var app = builder.Build();


            // app.UseHttpsRedirection();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            // app.UseStatusCodePages();

            // if (app.Environment.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // else
            // {
            //     app.UseExceptionHandler("/Error");
            // }

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/weatherforecast"),
                appBuilder =>
                {
                    appBuilder.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = "ClientApp";

                        if (app.Environment.IsDevelopment())
                            // spa.UseReactDevelopmentServer(npmScript: "start");
                            spa.UseProxyToSpaDevelopmentServer("http://localhost:5000/");
                        else
                        {
                            appBuilder.UseSpaStaticFiles();
                        }
                    });
                }
            );

            app.Run();
        }
    }
}
