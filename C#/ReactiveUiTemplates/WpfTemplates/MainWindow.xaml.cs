using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Reactive.Disposables;

namespace WpfTemplates;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;

        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.Router, v => v.RoutedViewHost.Router)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.GoToHomeView, v => v.NavigateToHomeButton)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.GoToSettingsView, v => v.NavigateToSettingsButton)
                .DisposeWith(disposables);
        });
    }
}
