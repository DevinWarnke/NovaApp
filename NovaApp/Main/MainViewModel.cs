using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using NovaApp.Common;
using NovaApp.Pages.ConnectionsPage;
using NovaApp.Pages.ErrorPage;
using NovaApp.Pages.ExplorerPage;
using NovaApp.Pages.HostPage;
using NovaApp.Pages.SettingsPage;

namespace NovaApp.Main;

public partial class MainViewModel : ViewModelBase
{
	
	//Bind the Content of NavigationView to property.
	[ObservableProperty] private object? currentPage;

	//Bind the SelectedPage of NavigationView to property.
	[ObservableProperty]
	private NavigationViewItem selectedPage;

	//Dictionary of pages.
	private readonly Dictionary<string, object?> _pageList = new Dictionary<string, object?>
	{
		{"Connections", new ConnectionsPage()},
		{"Explorer", new ExplorerPage()},
		{"Host", new HostPage()},
		{"Settings", new SettingsPage()},
		{"Error", new ErrorPage()}
	};

	// Add event that gets triggered after SelectedPage is changed.
	partial void OnSelectedPageChanged(NavigationViewItem value)
	{
		// Console.WriteLine($"Selected page: {value}");
		
		//If _pageList contains key then set CurrentPage to the new page, otherwise set Curr entPage to ErrorPage.
		CurrentPage = (_pageList.ContainsKey(value.ToString()) ? _pageList[value.ToString()] : _pageList["Error"]);
	}
}