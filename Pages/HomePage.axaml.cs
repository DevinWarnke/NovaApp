using Avalonia.Controls;
using NovaApp.ViewModels;

namespace NovaApp.Pages;
public partial class HomePage : UserControl
{
    public HomePage()
    {
        InitializeComponent();
        DataContext = new HomePageViewModel();
    }
}
