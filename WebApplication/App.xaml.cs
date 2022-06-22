using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebBackend;

namespace NetCoreSpa;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void OnStartup(object sender, StartupEventArgs eventArgs)
    {
        Task.Run(() =>
        {
            var builder = WebApplication.CreateBuilder();
            var assembly = typeof(WeatherForecast).Assembly; // Could be any type from external assembly
            builder.Services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
            builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "web-frontend/dist"; });
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
                        spa.Options.SourcePath = "web-frontend";

                        if (app.Environment.IsDevelopment())
                        {
                            spa.UseProxyToSpaDevelopmentServer("http://localhost:8081/");
                        }
                        else
                        {
                            appBuilder.UseSpaStaticFiles();
                        }
                    });
                }
            );

            app.Run();
        });
    }
}