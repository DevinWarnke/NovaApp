using FluentAvalonia.UI.Windowing;

namespace NovaApp.Pages.ExplorerPage.Explorer
{
    public partial class OptionsWindow : AppWindow
    {
        public OptionsWindow()
        {
            InitializeComponent();
            DataContext = new OptionsWindowViewModel();
        }	  
    }
}