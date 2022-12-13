using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace WpfTemplates.UserControls.Settings;

public class SettingsViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment => nameof(SettingsViewModel);
    public IScreen HostScreen { get; }

    public SettingsViewModel(IScreen hostScreen = null)
    {
        HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>()!;
    }
}
