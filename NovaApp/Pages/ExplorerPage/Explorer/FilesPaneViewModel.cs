using Avalonia.Media;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using MsBox.Avalonia.Enums;
using NovaApp.Common;
using NovaApp.Main;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Avalonia.Collections;

namespace NovaApp.Pages.ExplorerPage.Explorer;

// File Pane View Model
// Controls the UI elements and displays data
// ToDo: Move file access methods to Model class to make this for purely displaying data
// ToDo: Better comments and documentation
// ToDo: Separate NavigateTo into smaller methods
// ToDo: Check directory and file permissions
// ToDo: Add file and directory operations
// ToDo: Calculate Folder Sizes and move certain toggles to the Options Model

public partial class FilesPaneViewModel : ViewModelBase {

    public FilesPaneViewModel() {
        DriveList = new ObservableCollection<DriveInfo>(DriveInfo.GetDrives());
        SelectedDrive ??= DriveList.FirstOrDefault(d => d?.ToString() == @"C:\") ?? throw new FileNotFoundException(@"C:\");
        CurrentDirectory ??= @"C:\";
        CurrentDirectoryInfo = new DirectoryInfo(CurrentDirectory);
    }
    
    //Drives
    [ObservableProperty] public partial ObservableCollection<DriveInfo> DriveList { get; set; }
    [ObservableProperty] public partial DriveInfo SelectedDrive { get; set; }

    //Files
    [ObservableProperty] public partial IFileEntry? CurrentItem { get; set; }
    [ObservableProperty] public partial string CurrentDirectory { get; set; }
    [ObservableProperty] public partial DirectoryInfo CurrentDirectoryInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<IFileEntry> ExplorerList { get; set; } = [];

    //Search
    [ObservableProperty] private partial string SearchString { get; set; } = "";
    
    //Sorting
    [ObservableProperty] public partial Utilities.SortingBy Sorting { get; set; }
    [ObservableProperty] public partial bool Ascending { get; set; }
    
    //Other
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(GridBorderBrush))] public partial bool IsSelected { get; set; }
    public Brush GridBorderBrush => IsSelected ? new SolidColorBrush(Colors.LightSkyBlue) : new SolidColorBrush(Colors.Transparent);
    
    //Settings
    [ObservableProperty] public partial bool ShowFolderSizes { get; set; } = true;
    [ObservableProperty] public partial bool ShowHiddenFiles { get; set; } = false;
    [ObservableProperty] public partial bool ShowSystemFiles { get; set; } = false;
    [ObservableProperty] public partial bool ShowDebugTags { get; set; } = false;
    
    //Methods
    private void NavigateTo(string path) {
        // Set the current directory and directory info
        CurrentDirectory = path;
        CurrentDirectoryInfo = new DirectoryInfo(path);
        
        // Check if directory exists
        if (string.IsNullOrWhiteSpace(path) || !CurrentDirectoryInfo.Exists) {
            Console.WriteLine(@"Directory not found: " + path);
            Console.WriteLine(@"Exists: " + CurrentDirectoryInfo.Exists);
            Console.WriteLine(@"Is Null Or White Space: " + string.IsNullOrWhiteSpace(path));
            throw new DirectoryNotFoundException(path);
        }
        
        // Reset current item and directory info
        CurrentItem = null;
        ExplorerList.Clear();
        
        // Add directories and files to the list
        ExplorerList.Add(CurrentDirectoryInfo.EnumerateDirectories(SearchString).Select(f => new DirectoryEntry(f.Attributes, f.Name, f.FullName, @"File folder", f.FullName, null, f.CreationTime, f.LastWriteTime, f)));
        ExplorerList.Add(CurrentDirectoryInfo.EnumerateFiles(SearchString).Select(f => new FileEntry(f.Attributes, f.Name, f.FullName, f.Extension, f.FullName, f.Length, f.CreationTime, f.LastWriteTime, f)));
        
        // Debug Tag Visibility
        if (!ShowDebugTags) return;
        
        for (int i = 0; i < ExplorerList.Count; i++) {
            string debugTags = "";

            if (ExplorerList[i].Attributes.HasFlag(FileAttributes.Hidden))
                debugTags += ShowHiddenFiles ? " (Showing Hidden) " : " (Hiding Hidden) ";

            if (ExplorerList[i].Attributes.HasFlag(FileAttributes.System))
                debugTags += ShowSystemFiles ? " (Showing System) " : " (Hiding System) ";

            ExplorerList[i].Name = string.IsNullOrEmpty(debugTags) ? "(Public) " + ExplorerList[i].Name :  (debugTags + ExplorerList[i].Name).Trim();
        }
    }
    
    //Actions
    partial void OnSelectedDriveChanged(DriveInfo value) {
        // Check if the drive is null (should never happen)
        if (value == null)
            throw new NullReferenceException();
        
        // Call explorer update method
        NavigateTo(value.Name);
    }
    
    [RelayCommand] private static void View() {
        
    }

    [RelayCommand] private static void Edit(Action<ButtonResult, object?>? resultAction) {
        
    }
    
    [RelayCommand] private static void Execute(string? command) {
        
    }
    
    public static void Tapped(object sender, object parameter) {

        
    }
    
    public static void SortingStarted(object sender, object parameter) {
        
    }
    
    public static void CellPointerPressed(object sender, object parameter) {
        
    }
    
    public void DoubleTapped(object sender, object parameter) {
        // Check if the current item is a directory
        if (CurrentItem is DirectoryEntry directory)
            NavigateTo(directory.Path); // Navigate to the directory
        
    }

    public static void BeginningEdit(object sender, object parameter) {

    }
    
    public static void SelectionChanged(object sender, object parameter) {
        
    }

    
}