/*
 * This file is part of SmartCommander.
 *
 * Copyright (C) 2022 Anna Novikova
 *
 * Licensed under the GNU General Public License version 3 or later.
 * See the full license in the COPYING file or at <https://www.gnu.org/licenses/>.
 *
 * Originally obtained from: https://github.com/anovik/SmartCommander
 *
 * Modified by Devin Warnke on
 * Changes: Modified to work with .NET Community Toolkit instead of ReactiveUI.
 * Modified to fit style of Nova App design and theming.
 * Removed all backend code of SmartCommander, replaced with all personally written code.
 */

// Options Window Model
// Contains all the options data
// ToDo: Better comments and documentation

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Environment;

namespace NovaApp.Pages.ExplorerPage.Explorer
{
	public class OptionsWindowModel
	{
		public static OptionsWindowModel Instance { get; } = new OptionsWindowModel();
		static string _settingsDir = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "NovaApp");
		static string _settingsPath = Path.Combine(_settingsDir, "settings.json");
		static OptionsWindowModel()
		{
			Directory.CreateDirectory(_settingsDir);
			if (File.Exists(_settingsPath))
			{ 
				var options = JsonConvert.DeserializeObject<OptionsWindowModel>(File.ReadAllText(_settingsPath));
				if (options != null)
				{
					Instance = options;
				}
			}
		}
		public void Save() => File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(this, Formatting.Indented));


		public bool IsCurrentDirectoryDisplayed { get; set; } = true;

		public bool IsFunctionKeysDisplayed { get; set; } = true;

		public bool IsCommandLineDisplayed { get; set; } = true;

		public bool SaveWindowPositionSize { get; set; } = true;

		public bool IsHiddenSystemFilesDisplayed { get; set; }

		public bool SaveSettingsOnExit { get; set; } = true;

		public bool ConfirmationWhenDeleteNonEmpty { get; set; } = true;

		public double Top { get; set; } = -1;

		public double Left { get; set; } = -1;

		public double Width { get; set; } = -1;

		public double Height { get; set; } = -1;

		public bool IsMaximized { get; set; }

		public string LeftPanePath { get; set; } = "";

		public string RightPanePath { get; set; } = "";

		public bool IsDarkThemeEnabled { get; set; }
		public bool AllowOnlyOneInstance { get; set; } = true;
		public string Language { get; set; } = "en-US";

		public List<string> ListerPlugins { get; set; }= new List<string>();
	}
}
