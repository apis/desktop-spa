using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            // builder.Services.AddReverseProxy();
            builder.Services.AddControllersWithViews();
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

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapReverseProxy();
            // });


            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/weatherforecast"),
                appBuilder =>
                {
                    appBuilder.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = "ClientApp";

                        if (app.Environment.IsDevelopment())
                            spa.UseReactDevelopmentServer(npmScript: "start");
                        // spa.UseProxyToSpaDevelopmentServer("http://localhost:5000/");
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