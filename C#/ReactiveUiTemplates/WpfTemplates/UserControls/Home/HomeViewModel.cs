using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;

namespace WpfTemplates.UserControls.Home;

public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment => nameof(HomeViewModel);
    public IScreen HostScreen { get; }

    [Reactive]
    public string Message { get; set; }

    public HomeViewModel(IScreen hostScreen = null)
    {
        HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>()!;
        MessageBus.Current.Listen<string>("Message").Subscribe(m => Message = m);
    }
}
