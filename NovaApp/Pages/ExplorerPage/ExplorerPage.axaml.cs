using Avalonia.Controls;

namespace NovaApp.Pages.ExplorerPage;

// Explorer Page
// Initializes the Explorer Page, sets the DataContext to the ViewModel and creates events that are triggered when the pane is loaded and unloaded

public partial class ExplorerPage : UserControl
{
	public ExplorerPage()
	{
		InitializeComponent();
		DataContext = new ExplorerPageViewModel();
	}
}
