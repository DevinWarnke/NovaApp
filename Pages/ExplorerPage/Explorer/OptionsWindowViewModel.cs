using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovaApp.Common;

namespace NovaApp.Pages.ExplorerPage.Explorer;

public partial class OptionsWindowViewModel : ObservableObject {
    [ObservableProperty] public partial bool IsOnlyOneInstanceAllowed { get; set; } = Settings.IsOnlyOneInstanceAllowed;
    [ObservableProperty] public partial bool DoConfirmDeleteNonEmpty { get; set; } = Settings.DoConfirmDeleteNonEmpty;
    [ObservableProperty] public partial bool IsDarkThemeEnabled { get; set; } = Settings.IsDarkThemeEnabled;
    [ObservableProperty] public partial bool ShowFolderSizes { get; set; } = Settings.ShowFolderSizes;
    [ObservableProperty] public partial bool ShowHiddenFiles { get; set; } = Settings.ShowHiddenFiles;
    [ObservableProperty] public partial bool ShowSystemFiles { get; set; } = Settings.ShowSystemFiles;
    [ObservableProperty] public partial bool ShowDebugTags { get; set; } = Settings.ShowDebugTags;

    [RelayCommand] private void Ok() {}
    [RelayCommand] private void Cancel() {}
}