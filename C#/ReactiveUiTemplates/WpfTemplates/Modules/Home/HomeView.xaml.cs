using ReactiveUI;

namespace WpfTemplates.Modules.Home;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = ViewModel = new HomeViewModel();
    }
}
