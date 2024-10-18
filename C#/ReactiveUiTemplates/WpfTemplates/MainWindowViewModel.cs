using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Windows;
using WpfTemplates.DependencyInjection.Factories;

namespace WpfTemplates;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    private readonly IViewModelFactory _viewModelFactory;

    public RoutingState Router { get; } = new RoutingState();

    public ReactiveCommand<Unit, Unit> ExitAppCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ToggleWindowStateCommand { get; set; }
    public ReactiveCommand<Unit, WindowState> MinimizeWindowCommand { get; set; }
    public ReactiveCommand<Type, IRoutableViewModel?> Navigate { get; private set; }

    public MainWindowViewModel(IViewModelFactory viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;

        Navigate = ReactiveCommand.CreateFromObservable<Type, IRoutableViewModel?>(vmType =>
        {
            var currentViewModel = Router.NavigationStack.LastOrDefault();
            return currentViewModel?.GetType() != vmType
                ? Router.NavigateAndReset.Execute(_viewModelFactory.CreateRoutableViewModel(vmType))
                : Observable.Empty(currentViewModel);
        });

        MaximizeButtonStyle = GetStyleFromResourceDictionary("TitlebarMaximizeButton", "TitleBar.xaml")!;

        ExitAppCommand = ReactiveCommand.Create(Application.Current.Shutdown);

        ToggleWindowStateCommand = ReactiveCommand.Create(() =>
        {
            if (MainWindowState == WindowState.Maximized)
            {
                MainWindowState = WindowState.Normal;
            }
            else
            {
                MainWindowState = WindowState.Maximized;
            }
        });
        MinimizeWindowCommand = ReactiveCommand.Create(() => MainWindowState = WindowState.Minimized);
    }

    [Reactive]
    public WindowState MainWindowState { get; set; }
    [Reactive]
    public Style MaximizeButtonStyle { get; set; }

    public Style? GetStyleFromResourceDictionary(string styleName, string resourceDictionaryName)
    {
        var titleBarResources = new ResourceDictionary();
        titleBarResources.Source = new Uri($"/{Assembly.GetEntryAssembly()!.GetName().Name};component/Resources/{resourceDictionaryName}",
                        UriKind.RelativeOrAbsolute);
        return titleBarResources[styleName] as Style;
    }
}
