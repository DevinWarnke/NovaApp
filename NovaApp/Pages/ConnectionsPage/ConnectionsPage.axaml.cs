using Avalonia.Controls;

namespace NovaApp.Pages.ConnectionsPage;

// Connections Page
// Initializes the Connections Page, sets the DataContext to the ViewModel

public partial class ConnectionsPage : UserControl
{
	public ConnectionsPage()
	{
		InitializeComponent();
		DataContext = new ConnectionsPageViewModel();
	}
}