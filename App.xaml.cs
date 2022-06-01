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
            builder.Services.AddControllersWithViews();
            builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            builder.WebHost.UseUrls("http://localhost:16000", "https://localhost:16001");

            var app = builder.Build();

            app.UseSpaStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (app.Environment.IsDevelopment()) 
                    spa.UseReactDevelopmentServer(npmScript: "start");
            });

            app.Run();
        });
    }
}