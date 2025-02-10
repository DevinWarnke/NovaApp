using Avalonia.Controls;
using NovaApp.ViewModels;

namespace NovaApp.Pages;
public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
        DataContext = new SettingsPageViewModel();
    }
}
