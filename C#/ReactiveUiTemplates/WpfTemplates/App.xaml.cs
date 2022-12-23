using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfTemplates.DependencyInjection;
using WpfTemplates.Modules.Home;

namespace WpfTemplates;

public partial class App : Application
{
    public AppBootstrapper Bootstrapper { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        Bootstrapper = new AppBootstrapper();
        var services = Bootstrapper.AppHost.Services;

        var window = services.GetRequiredService<MainWindow>();
        window.Show();

        var router = services.GetRequiredService<MainWindowViewModel>().Router;
        router.Navigate.Execute(services.GetRequiredService<HomeViewModel>());
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await Bootstrapper.AppHost.StopAsync();

        base.OnExit(e);
    }
}
