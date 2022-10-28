using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveUiDemo.ViewModels;

public class MainViewModel : ReactiveObject
{
    [Reactive]
    public string WelcomeMessage { get; set; }

    public MainViewModel()
    {
        WelcomeMessage = "Welcome to .NET MAUI!";
    }
}