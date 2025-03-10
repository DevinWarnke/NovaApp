using Avalonia.Controls;

namespace NovaApp.Main;

public partial class MainView : UserControl
{
	public MainView()
	{
		InitializeComponent();
		DataContext = new MainViewModel();
	}
}