using Avalonia;
using FluentAvalonia.UI.Windowing;

namespace NovaApp.Main;

public partial class MainWindow : AppWindow
{
	public MainWindow()
	{
		InitializeComponent();
		DataContext = new MainWindowViewModel();
		this.AttachDevTools();
	}
}