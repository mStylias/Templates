using ReactiveUI;

namespace WpfTemplates.UserControls.Settings;
public partial class SettingsView : ReactiveUserControl<SettingsViewModel>
{
    public SettingsView()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }
}
