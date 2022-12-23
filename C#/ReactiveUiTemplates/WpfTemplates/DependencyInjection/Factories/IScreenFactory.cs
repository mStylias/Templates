using ReactiveUI;

namespace WpfTemplates.DependencyInjection.Factories;

public interface IScreenFactory
{
    IScreen GetMainMenuViewModel();
    IScreen GetMainWindowViewModel();
}