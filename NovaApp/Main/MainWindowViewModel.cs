using Avalonia;
using NovaApp.Common;

namespace NovaApp.Main;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {

    }
    
    private void SetLanguage()
    {
        //var cultureName = OptionsModel.Instance.Language;
        //var culture = new CultureInfo(cultureName);
        //Thread.CurrentThread.CurrentCulture = culture;
        //Thread.CurrentThread.CurrentUICulture = culture;
    }
    
    private void SetTheme()
    {
        if (Application.Current != null)
        {
            //Application.Current.RequestedThemeVariant = OptionsModel.Instance.IsDarkThemeEnabled ? ThemeVariant.Dark : ThemeVariant.Light;
            //Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        }
    }
}