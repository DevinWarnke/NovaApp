using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NovaApp.Common;

public class Settings {
    public static bool IsOnlyOneInstanceAllowed { get; set; } = true;
    public static bool DoConfirmDeleteNonEmpty { get; set; } = true;
    public static bool IsDarkThemeEnabled { get; set; } = true;
    public static bool ShowFolderSizes { get; set; } = true;
    public static bool ShowHiddenFiles { get; set; } = true;
    public static bool ShowSystemFiles { get; set; } = true;
    public static bool ShowDebugTags { get; set; } = true;
    
    public static bool SettingTest { get; set; } = true;

    private Settings()
    {
        Console.WriteLine("EEEEEEEE");
    }

    
    public void LoadSettings() {
        Console.WriteLine();  
    }

    public void SaveSettings() {
        
    }
}