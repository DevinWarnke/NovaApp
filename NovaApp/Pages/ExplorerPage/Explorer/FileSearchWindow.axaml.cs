using FluentAvalonia.UI.Windowing;

namespace NovaApp.Pages.ExplorerPage.Explorer;

// File Search Window
// Initializes the File Search Window, sets the DataContext to the ViewModel

public partial class FileSearchWindow : AppWindow
{
    public FileSearchWindow()
    {
        InitializeComponent();
        DataContext = new FileSearchViewModel();
    }	  
}