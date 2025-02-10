using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Labs.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using NovaApp.ViewModels;

namespace NovaApp.Pages;
public partial class ConnectionsPage : UserControl
{
    public ConnectionsPage()
    {
        InitializeComponent();
        DataContext = new ConnectionsPageViewModel();
        this.Get<DataGrid>("ServerListDataGrid");
        var serverListDataGrid = this.Get<DataGrid>("ServerListDataGrid");
        serverListDataGrid.ItemsSource = Servers.ServerList;

        //var autoEvent = new AutoResetEvent(false);
       // var stateTimer = new Timer(UpdateServerList, autoEvent, 500, 250);

    
    }

    public void UpdateServerList(object? state)
    {
        Servers.RefreshStatuses();
        var serverListDataGrid = this.Get<DataGrid>("ServerListDataGrid");
        serverListDataGrid.ItemsSource = Servers.ServerList;
    }
}

public class Server(string name, string hostname, int port, string userName, string password, string type)
{
    // Server Status: Connected, Online, Offline, No Auth
    public string Status { get; set; } = "Offline";
    
    // Server Display Name
    public string Name { get; set; } = name;

    // Server Host Name
    public string HostName { get; set; } = hostname;

    // Server Port
    public int Port { get; set; } = port;

    // Username
    public string UserName { get; set; } = userName;

    // Password
    public string Password { get; set; } = password;

    // Type??
    public string Type { get; set; } = type;

    public string GetStatus()
    {
        //Temporary Status code
        var possibleStatuses = new List<string> { "Connected", "Online", "Offline", "No Auth" };
        var randomNumber = new Random().Next(0, possibleStatuses.Count);
        Status = possibleStatuses[randomNumber];
        return possibleStatuses[randomNumber];
    }
}

public class Servers
{
    public static ObservableCollection<Server> ServerList = new()
    {
        new Server("Test Server 1", "192.168.1.1", 22, "User1", "******", "SSH"),
        new Server("Test Server 2", "192.168.1.2", 22, "User2", "******", "SFTP"),
        new Server("Test Server 3", "192.168.1.3", 22, "", "", "FTP")
    };
    
    public static void RefreshStatuses()
    {
        Console.WriteLine("Refresh Statuses");
        foreach (var server in ServerList)
        {
            server.GetStatus();
            Console.WriteLine(server.Status);
        }
    }
}