using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovaApp.Common;

namespace NovaApp.Pages.ExplorerPage.Explorer;

public partial class OptionsWindowViewModel : ViewModelBase
{
    public OptionsWindowViewModel()
    {
        Console.WriteLine(@"OWVM");
    }

    [ObservableProperty] private string displayName;

    [ObservableProperty] private ObservableCollection<object> availableCultures;
    [ObservableProperty] private ObservableCollection<object> listerPlugins;
    [ObservableProperty] private object selectedCulture;
    [ObservableProperty] private object selectedPlugin;
    
    [ObservableProperty] private bool allowOnlyOneInstance;
    [ObservableProperty] private bool confirmationWhenDeleteNonEmpty;
    [ObservableProperty] private bool isCommandLineDisplayed;
    [ObservableProperty] private bool isCurrentDirectoryDisplayed;
    [ObservableProperty] private bool isDarkThemeEnabled;
    [ObservableProperty] private bool isFunctionKeysDisplayed;
    [ObservableProperty] private bool isHiddenSystemFilesDisplayed;
    [ObservableProperty] private bool saveSettingsOnExit;
    [ObservableProperty] private bool saveWindowPositionSize;

    [RelayCommand] private void AddFile() {}
    [RelayCommand] private void RemoveFile() {}
    [RelayCommand] private void Ok() {}
    [RelayCommand] private void Cancel() {}

}