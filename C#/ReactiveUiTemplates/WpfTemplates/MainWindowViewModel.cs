using ReactiveUI;
using System;
using System.Reactive;
using WpfTemplates.UserControls.Home;
using WpfTemplates.UserControls.Settings;

namespace WpfTemplates;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public ReactiveCommand<Unit, IRoutableViewModel> GoToHomeView { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToSettingsView { get; }

    public RoutingState Router { get; } = new RoutingState();

    public MainWindowViewModel()
    {
        GoToHomeView = ReactiveCommand.CreateFromObservable(() =>
        {
            var navResult = Router.Navigate.Execute(new HomeViewModel());
            MessageBus.Current.SendMessage($"Time shown: ({DateTime.Now})", "Message");
            return navResult;
        });
        GoToSettingsView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SettingsViewModel()));
    }
}
