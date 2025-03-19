using Avalonia.Controls;

namespace NovaApp.Pages.HostPage;

// Host Page
// Initializes the Host Page, sets the DataContext to the ViewModel


public partial class HostPage : UserControl
{
	public HostPage()
	{
		InitializeComponent();
		DataContext = new HostPageViewModel();
	}
}