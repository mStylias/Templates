using ReactiveUI;
using WpfTemplates.DependencyInjection.Factories;

namespace WpfTemplates.Modules.Settings;

public class SettingsViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment => nameof(SettingsViewModel);
    public IScreen HostScreen { get; }

    public SettingsViewModel(IScreenFactory screenFactory)
    {
        HostScreen = screenFactory.GetMainWindowViewModel();
    }
}
