using Avalonia.Controls;
using NovaApp.ViewModels;

namespace NovaApp.Pages;
public partial class ExplorerPage : UserControl
{
    public ExplorerPage()
    {
        InitializeComponent();
        DataContext = new ExplorerPageViewModel();
    }
}
