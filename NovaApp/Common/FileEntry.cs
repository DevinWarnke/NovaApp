using System;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NovaApp.Common;

// File Entry Interface
// An interface to allow for singular collections of files and directories
// ToDo: Support for network drives and hosts

public interface IFileEntry {
    public string Type { get; }
    public FileAttributes Attributes { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public string Icon { get; set; }
    public long? Size { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public object Info { get; set; }
}

public partial class DirectoryEntry(FileAttributes attributes, string name, string path, string extension, string icon, long? size, DateTime datecreated, DateTime datemodified, DirectoryInfo info) : ObservableObject, IFileEntry {
    public string Type => "Directory";
    [ObservableProperty] public partial FileAttributes Attributes { get; set; } = attributes;
    [ObservableProperty] public partial string Name { get; set; } = name;
    [ObservableProperty] public partial string Path { get; set; } = path;
    [ObservableProperty] public partial string Extension { get; set; } = extension;
    [ObservableProperty] public partial string Icon { get; set; } = icon;
    [ObservableProperty] public partial long? Size { get; set; } = size;
    [ObservableProperty] public partial DateTime DateCreated { get; set; } = datecreated;
    [ObservableProperty] public partial DateTime DateModified { get; set; } = datemodified;
    [ObservableProperty] public partial object Info { get; set; } = info;
}

public partial class FileEntry(FileAttributes attributes, string name, string path, string extension, string icon, long? size, DateTime datecreated, DateTime datemodified, FileInfo info) : ObservableObject, IFileEntry {
    public string Type => "File";
    [ObservableProperty] public partial FileAttributes Attributes { get; set; } = attributes;
    [ObservableProperty] public partial string Name { get; set; } = name;
    [ObservableProperty] public partial string Path { get; set; } = path;
    [ObservableProperty] public partial string Extension { get; set; } = extension;
    [ObservableProperty] public partial string Icon { get; set; } = icon;
    [ObservableProperty] public partial long? Size { get; set; } = size;
    [ObservableProperty] public partial DateTime DateCreated { get; set; } = datecreated;
    [ObservableProperty] public partial DateTime DateModified { get; set; } = datemodified;
    [ObservableProperty] public partial object Info { get; set; } = info;
}