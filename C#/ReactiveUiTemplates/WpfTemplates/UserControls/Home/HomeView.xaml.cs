using ReactiveUI;
using Splat;

namespace WpfTemplates.UserControls.Home;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = ViewModel = new HomeViewModel();
    }
}
