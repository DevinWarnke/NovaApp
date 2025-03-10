using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovaApp.Common;

namespace NovaApp.Pages.ExplorerPage.Explorer;

// File Search View Model
// Controls the UI elements and displays data
// ToDo: Better comments and documentation
// ToDo: Remove entirely??
// ToDo: Implement File Search visual elements
// ToDo: Implement File Search logic
// ToDo: Implement File Search methods

public partial class FileSearchViewModel : ViewModelBase
{
    [ObservableProperty] private string currentFolder;
    [ObservableProperty] private string fileMask;
    [ObservableProperty] private string searchText;
    [ObservableProperty] private string statusFolder;
    [ObservableProperty] private ObservableCollection<string> searchResults;
    
    [ObservableProperty] private bool idkWhatThisIs = true;
    [ObservableProperty] private bool isChecked = true;
    [ObservableProperty] private bool isOnlyTopDirectory = true;
    [ObservableProperty] private bool isSearching = true;
    
    [RelayCommand] private void StartSearch() {
        
    }
    
    [RelayCommand] private void CancelSearch() {
        
    }
}