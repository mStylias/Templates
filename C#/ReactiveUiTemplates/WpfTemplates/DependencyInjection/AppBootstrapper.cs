using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace WpfTemplates.DependencyInjection;

public class AppBootstrapper
{
    public IHost AppHost { get; private set; }

    public AppBootstrapper()
    {
        AppHost = Host.CreateDefaultBuilder()
           .ConfigureServices((hostContext, services) =>
           {
               // Override splat internal DI with Microsoft built-in dependency injection
               services.UseMicrosoftDependencyResolver();
               Locator.CurrentMutable.InitializeSplat();
               Locator.CurrentMutable.InitializeReactiveUI();

               // Configure the rest of the Dependency Injection
               ConfigureServices(services);
           })
           .Build();

        AppHost.Services.UseMicrosoftDependencyResolver();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Add Main Window and Routing
        services.AddSingleton<MainWindow>(sp => new MainWindow { ViewModel = sp.GetRequiredService<MainWindowViewModel>() });
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<IScreen, MainWindowViewModel>(sp => sp.GetRequiredService<MainWindowViewModel>());

        // Add Views and ViewModels
        services.AddViews();
        services.AddViewModels();
    }
}
