using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfTemplates.DependencyInjection;

namespace WpfTemplates;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        AppBootstrapper appBootstrapper = new AppBootstrapper();
        var window = appBootstrapper.AppHost.Services.GetRequiredService<MainWindow>();
        window.Show();
    }
}
