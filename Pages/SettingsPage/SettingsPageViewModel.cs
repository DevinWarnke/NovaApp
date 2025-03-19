using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using NovaApp.Common;

namespace NovaApp.Pages.SettingsPage;

// Settings Page View Model 
// Controls the UI elements and displays data
// ToDo: Better comments and documentation
// ToDo: Implement page, or combine with Explorer Options Popout??

public partial class SettingsPageViewModel : ViewModelBase {
    //App General Data
    [ObservableProperty] public partial string AppName { get; set; } = "NovaNdwf";
    [ObservableProperty] public partial string AppVersion { get; set; } = "v0.0.2";
    [ObservableProperty] public partial string AvaloniaVersion { get; set; } = typeof(Application).Assembly.GetName().Version?.ToString();
    
    //App Display Data
    [ObservableProperty] public partial string[] AppThemes { get; set; } = ["Fluent"];
    [ObservableProperty] public partial string[] AppColorThemes { get; set; } = ["System", "Dark", "Light"];
    [ObservableProperty] public partial Color[] AppAccentColors { get; set; } = [];
    [ObservableProperty] public partial string[] AppAccentColorSelections { get; set; } = ["Automatic", "Custom"];
    
    //Display Settings
    [ObservableProperty] public partial string AppTheme { get; set; } = "Fluent";
    [ObservableProperty] public partial string AppColorTheme { get; set; } = "Dark";
    [ObservableProperty] public partial Color AppAccentColor { get; set; }
    [ObservableProperty] public partial string AppAccentColorSelection { get; set; } = "Automatic";
    
    // File Settings
    [ObservableProperty] public partial bool DoConfirmDeleteNonEmpty { get; set; } = true;
    [ObservableProperty] public partial bool ShowFolderSizes { get; set; } = true;
    [ObservableProperty] public partial bool ShowHiddenFiles { get; set; } = true;
    [ObservableProperty] public partial bool ShowSystemFiles { get; set; } = true;
    
    // Debug Settings
    [ObservableProperty] public partial bool ShowDebugTags { get; set; } = true;
}

