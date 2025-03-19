using Avalonia.Controls;

namespace NovaApp.Pages.SettingsPage;

// Settings Page
// Initializes the Settings Page, sets the DataContext to the ViewModel

public partial class SettingsPage : UserControl
{
	public SettingsPage() {
		InitializeComponent();
		DataContext = new SettingsPageViewModel();
	}
}
