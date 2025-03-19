using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovaApp.Common;

namespace NovaApp.Pages.ConnectionsPage;

// File Pane View Model
// Controls the UI elements and displays data
// ToDo: Better comments and documentation
// ToDo: Move Server methods to Model class to make this for purely displaying data
// ToDo: Separate Server into Common class
// ToDo: Add server operations
// ToDo: Reorganize and clean up code
// ToDo: Server status checks and UI updates
// ToDo: Decide if Connecting / Saving should even be separate (Probably not, saving by default makes more sense)
// ToDo: All of this is a mess, needs a lot of work

public partial class ConnectionsPageViewModel : ViewModelBase {
	public partial class Server(string name, string hostname, int port, string username, string password, string type) : ObservableObject {
		[ObservableProperty] private string status = "Offline";
		[ObservableProperty] private string name = name;
		[ObservableProperty] private string hostName = hostname;
		[ObservableProperty] private int port = port;
		[ObservableProperty] private string username = username;
		[ObservableProperty] private string password = password;
		[ObservableProperty] private string type = type;
	}
	
	[ObservableProperty] private ObservableCollection<Server> serverList = [
		new("CTest", "Test.com", 22, "Username", "Password", "SFTP")
	];
	private readonly Collection<Server> _savedServerList = [];
	private readonly Collection<string> _serverTypeString = ["SFTP", "FTP"];
	
	[ObservableProperty] private string addStatus = "";  
	[ObservableProperty] private string addName = "";
	[ObservableProperty] private string addHostName = "";
	[ObservableProperty] private int addPort = 22;
	[ObservableProperty] private string addUsername = "";
	[ObservableProperty] private string addPassword = "";
	[ObservableProperty] private int addType = 0;

	public void MissingInput(string input)
	{
		
	}

	private Server CreateServer(string serverName, string hostName, int port, string username, string password, int type)
	{
		if (serverName is null || serverName.Length == 0)
		{
			Console.WriteLine(@"No ServerName provided");
			serverName = "New Server " + ServerList.Count;
		}
		if (hostName is null || hostName.Length == 0)
		{
			Console.WriteLine(@"No Hostname provided");
			return null;
		}
		if (port < 1 || port > 65535)
		{
			Console.WriteLine(@"Invalid port number");
			port = Math.Clamp(port, 1, 65535);
			return null;
		}
		if (username is null || username.Length == 0)
		{
			Console.WriteLine(@"No Username provided");
			username = "Anonymous";
		}
		if (password is null || password.Length == 0)
		{
			Console.WriteLine(@"No Password provided");
		}
		
		return new Server(serverName, hostName, port, username, password, _serverTypeString[type]);
	}

	public bool AddServer(Server server, bool save)
	{
		if (server == null) return false;
		ServerList.Add(server);
		if (save) _savedServerList.Add(server);
		return true;
	}

	[RelayCommand]
	private void Add(bool save)
	{
	   AddServer(CreateServer(AddName, AddHostName, AddPort, AddUsername, AddPassword, AddType), save);
	}
}
	