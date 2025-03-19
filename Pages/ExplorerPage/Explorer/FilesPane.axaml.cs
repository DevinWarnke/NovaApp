using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace NovaApp.Pages.ExplorerPage.Explorer;

// File Pane
// Initializes the File Pane, sets the DataContext to the ViewModel and creates events that are triggered when the pane is loaded and unloaded

public partial class FilesPane : UserControl
{
	public FilesPane()
	{
		InitializeComponent();
		DataContext = new FilesPaneViewModel();
	}
	
	private new void Loaded(object? sender, RoutedEventArgs e)
	{

	}

	private new void Unloaded(object? sender, RoutedEventArgs routedEventArgs) {

	}
}
