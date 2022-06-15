using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace NetCoreSpa;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        var coreWebView2Environment = await CoreWebView2Environment.CreateAsync(userDataFolder: Path.GetTempPath());
        await WebView.EnsureCoreWebView2Async(coreWebView2Environment);
        WebView.CoreWebView2.Navigate("http://localhost:16000/");
    }
}