using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Windowing;
using NovaApp.Common;

namespace NovaApp.Pages.ExplorerPage.Explorer;

public partial class CopyMoveViewModel : ViewModelBase
{
    public CopyMoveViewModel() {
        Console.WriteLine(@"Hello World!");
    }

    [ObservableProperty] private string copyText;
    [ObservableProperty] private string directory;

    [RelayCommand] void Ok(AppWindow window) { }
    [RelayCommand] void Cancel(AppWindow window) { }
}