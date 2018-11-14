/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017, 2018 Matt McManis
http://github.com/MattMcManis/Glow
http://glowmpv.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */
using Glow.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Glow
{
    /// <summary>
    /// Interaction logic for ConfigureWindow.xaml
    /// </summary>
    public partial class ConfigureWindow : Window
    {
        private MainWindow mainwindow;
        //private static MainWindow mainwindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        public static string failedImportMessage;

        public ConfigureWindow(MainWindow mainwindow, ViewModel vm)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;

            // Set Min/Max Width/Height to prevent Tablets maximizing
            this.MinWidth = 450;
            this.MinHeight = 200;
            this.MaxWidth = 450;
            this.MaxHeight = 200;

            // -----------------------------------------------------------------
            /// <summary>
            ///     Control Binding
            /// </summary>
            // -----------------------------------------------------------------
            DataContext = vm;

            // --------------------------------------------------
            // Load Update Auto Check Text
            // --------------------------------------------------
            if (vm.UpdateAutoCheck_IsChecked == true)
            {
                vm.UpdateAutoCheck_Text = "On";
            }
            else if (vm.UpdateAutoCheck_IsChecked == false)
            {
                vm.UpdateAutoCheck_Text = "Off";
            }
        }


        // -----------------------------------------------
        // Load Control Defaults
        // -----------------------------------------------
        public static void LoadDefaults(MainWindow mainwindow, ViewModel vm)
        {
            // Main Window
            mainwindow.Top = 0;
            mainwindow.Left = 0;
            mainwindow.Width = 712;
            mainwindow.Height = 400;
            mainwindow.WindowState = WindowState.Normal;
            vm.mpvPath_Text = string.Empty;
            vm.mpvConfigPath_Text = Paths.mpvConfigDir;
            vm.ProfilesPath_Text = Paths.profilesDir;
            vm.Profiles_SelectedItem = "Default";
            vm.Theme_SelectedItem = "Glow";
            vm.UpdateAutoCheck_IsChecked = true;
        }


        /// <summary>
        ///    INI Reader
        /// </summary>
        /*
        * Source: GitHub Sn0wCrack
        * https://gist.github.com/Sn0wCrack/5891612
        */
        public partial class INIFile
        {
            public string path { get; private set; }

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIFile(string INIPath)
            {
                path = INIPath;
            }
            public void Write(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

            public string Read(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
                return temp.ToString();
            }
        }


        /// <summary>
        ///    Settings Path Select
        /// </summary>
        public static void SettingsSelectPath(ViewModel vm, /*SettingsWindow settingswindow, */string pathType)
        {
            // Open Folder Browser
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            // Popup Folder Browse Window
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // -------------------------
                // mpv Path
                // -------------------------
                if (pathType == "mpvPath")
                {
                    vm.mpvPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                }

                // -------------------------
                // Config Path
                // -------------------------
                else if (pathType == "configPath")
                {
                    vm.mpvConfigPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                }

                // -------------------------
                // Profiles Path
                // -------------------------
                else if (pathType == "profilesPath")
                {
                    vm.ProfilesPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                }
            }
        }


        /// <summary>
        ///    mpv Path
        /// </summary>
        private void textBoxMpvPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Folder Browser
            SettingsSelectPath(vm, "mpvPath");
        }

        /// <summary>
        ///    Revert mpv Path
        /// </summary>
        private void buttonMpvPathRevert_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            vm.mpvPath_Text = string.Empty;
        }


        /// <summary>
        ///    Config Path
        /// </summary>
        private void textBoxConfigPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Folder Browser
            SettingsSelectPath(vm, "configPath");
        }

        /// <summary>
        ///    Revert Confg Path
        /// </summary>
        private void buttonConfigPathRevert_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            vm.mpvConfigPath_Text = Paths.userDir + @"AppData\Roaming\mpv\";
        }


        /// <summary>
        ///    Profiles Path
        /// </summary>
        private void textBoxProfilesPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Folder Browser
            SettingsSelectPath(vm, "profilesPath");
        }

        /// <summary>
        ///    Revert Profiles Path
        /// </summary>
        private void buttonProfilesPathRevert_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            vm.ProfilesPath_Text = Paths.appDir + @"profiles\";
        }


        /// <summary>
        ///    Updates Auto Check - Checked
        /// </summary>
        private void tglUpdateAutoCheck_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Update Toggle Text
            vm.UpdateAutoCheck_Text = "On";
        }
        /// <summary>
        ///    Updates Auto Check - Unchecked
        /// </summary>
        private void tglUpdateAutoCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Update Toggle Text
            vm.UpdateAutoCheck_Text = "Off";
        }


        /// <summary>
        ///    Theme
        /// </summary>
        private void themeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel vm = mainwindow.DataContext as ViewModel;

            // Change Theme Resource
            App.Current.Resources.MergedDictionaries.Clear();
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("Theme" + vm.Theme_SelectedItem.Replace(" ", string.Empty) + ".xaml", UriKind.RelativeOrAbsolute)
            });
        }


        /// <summary>
        ///    Reset Settings
        /// </summary>
        private void buttonClearAllSavedSettings_Click(object sender, RoutedEventArgs e)
        {
            //// Revert mpv Path
            //Paths.mpvDir = string.Empty;
            //textBoxMpvPath.Text = Paths.mpvDir;

            //// Revert Config Path
            //Paths.configDir = Paths.userDir + @"AppData\Roaming\mpv\";
            //textBoxConfigPath.Text = Paths.configDir;

            //// Revert Profiles Path
            //Paths.profilesDir = Paths.appDir + @"profiles\";
            //textBoxProfilesPath.Text = Paths.profilesDir;

            //// Save Current Window Location
            //// Prevents MainWindow from moving to Top 0 Left 0 while running
            //double left = mainwindow.Left;
            //double top = mainwindow.Top;

            //// Reset AppData Settings
            //Settings.Default.Reset();
            //Settings.Default.Reload();

            //// Set Window Location
            //mainwindow.Left = left;
            //mainwindow.Top = top;
        }

        /// <summary>
        ///    Delete Settings
        /// </summary>
        private void buttonDeleteSettings_Click(object sender, RoutedEventArgs e)
        {
            string appDataPath = Paths.userDir + @"AppData\Local\Glow\";

            // Check if Directory Exists
            if (Directory.Exists(appDataPath))
            {
                // Show Yes No Window
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                    "Delete " + appDataPath, "Delete Directory Confirm", System.Windows.Forms.MessageBoxButtons.YesNo);
                // Yes
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    using (Process delete = new Process())
                    {
                        delete.StartInfo.UseShellExecute = false;
                        delete.StartInfo.CreateNoWindow = false;
                        delete.StartInfo.RedirectStandardOutput = true;
                        delete.StartInfo.FileName = "cmd.exe";
                        delete.StartInfo.Arguments = "/c RD /Q /S " + "\"" + appDataPath;
                        delete.Start();
                        delete.WaitForExit();
                        //delete.Close();
                    }

                    //Directory.Delete(appDataPath);

                    // Restart Program
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                // No
                else if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    //do nothing
                }
            }

            // If Glow Folder Not Found
            else
            {
                MessageBox.Show("No Previous Settings Found.",
                                "Notice",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }


        /// <summary>
        ///    Export Glow config.ini
        /// </summary>
        public static void ExportConfig(MainWindow mainwindow, ViewModel vm)
        {
            // Check if Directory Exists
            if (!Directory.Exists(Paths.configINIDir))
            {
                // Yes/No Dialog Confirmation
                //
                MessageBoxResult resultExport = MessageBox.Show("Config Folder does not exist. Automatically create it?",
                                                                "Directory Not Found",
                                                                MessageBoxButton.YesNo,
                                                                MessageBoxImage.Information);
                switch (resultExport)
                {
                    // Create
                    case MessageBoxResult.Yes:
                        try
                        {
                            Directory.CreateDirectory(Paths.configINIDir);
                        }
                        catch
                        {
                            MessageBox.Show("Could not create Config folder. May require Administrator privileges.",
                                            "Error",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Error);
                        }
                        break;
                    // Use Default
                    case MessageBoxResult.No:
                        break;
                }
            }

            // Save config.ini file if directory exists
            else if (Directory.Exists(Paths.configINIDir))
            {
                // Start INI File Write
                ConfigureWindow.INIFile inif = new ConfigureWindow.INIFile(Paths.configINIFile);

                // -------------------------
                // Main Window
                // -------------------------
                // Window Position Top
                inif.Write("Main Window", "Window_Position_Top", Convert.ToString(mainwindow.Top));

                // Window Position Left
                inif.Write("Main Window", "Window_Position_Left", Convert.ToString(mainwindow.Left));

                // Window Width
                inif.Write("Main Window", "Window_Width", Convert.ToString(mainwindow.Width));

                // Window Height
                inif.Write("Main Window", "Window_Height", Convert.ToString(mainwindow.Height));

                // Window Maximized
                if (mainwindow.WindowState == WindowState.Maximized)
                {
                    inif.Write("Main Window", "WindowState_Maximized", "true");
                }
                else
                {
                    inif.Write("Main Window", "WindowState_Maximized", "false");
                }

                // Profiles Selected Item
                inif.Write("Main Window", "Profiles_SelectedItem", vm.Profiles_SelectedItem);


                // -------------------------
                // Configure Window
                // -------------------------
                // mpv Path
                inif.Write("Configure Window", "mpvPath_Text", vm.mpvPath_Text);

                // mpv Config Path
                inif.Write("Configure Window", "mpvConfigPath_Text", vm.mpvConfigPath_Text);

                // Profiles Path
                inif.Write("Configure Window", "ProfilesPath_Text", vm.ProfilesPath_Text);

                // Theme
                inif.Write("Configure Window", "Theme_SelectedItem", vm.Theme_SelectedItem);

                // Update Auto Check
                inif.Write("Configure Window", "UpdateAutoCheck_IsChecked", Convert.ToString(vm.UpdateAutoCheck_IsChecked).ToLower());
            }
        }


        /// <summary>
        ///    Import Glow config.ini file
        /// </summary>
        public static void ImportConfig(MainWindow mainwindow, ViewModel vm)
        {
            try
            {
                List<string> listFailedImports = new List<string>();

                // Start INI File Read
                ConfigureWindow.INIFile inif = null;

                // -------------------------
                // Check if config.ini file exists
                // -------------------------
                if (File.Exists(Paths.configINIFile))
                {
                    inif = new ConfigureWindow.INIFile(Paths.configINIFile);

                    // -------------------------
                    // Main Window
                    // -------------------------
                    //Window Position Top
                    double? top = Double.Parse(inif.Read("Main Window", "Window_Position_Top"));
                    if (top != null)
                    {
                        mainwindow.Top = Convert.ToDouble(inif.Read("Main Window", "Window_Position_Top"));
                    }

                    // Window Position Left
                    double? left = Double.Parse(inif.Read("Main Window", "Window_Position_Left"));
                    if (left != null)
                    {
                        mainwindow.Left = Convert.ToDouble(inif.Read("Main Window", "Window_Position_Left"));
                    }

                    // Window Maximized
                    if (Convert.ToBoolean(inif.Read("Main Window", "WindowState_Maximized").ToLower()) == true)
                    {
                        mainwindow.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        mainwindow.WindowState = WindowState.Normal;
                    }

                    // Window Width
                    double? width = Double.Parse(inif.Read("Main Window", "Window_Width"));
                    if (width != null)
                    {
                        mainwindow.Width = Convert.ToDouble(inif.Read("Main Window", "Window_Width"));
                    }

                    // Window Height
                    double? height = Double.Parse(inif.Read("Main Window", "Window_Height"));
                    if (height != null)
                    {
                        mainwindow.Height = Convert.ToDouble(inif.Read("Main Window", "Window_Height"));
                    }

                    // Profiles Selected Item Path
                    //vm.Profiles_SelectedItem = inif.Read("Main Window", "Profiles_SelectedItem");


                    // -------------------------
                    // Configure Window
                    // -------------------------
                    // mpv Path
                    vm.mpvPath_Text = inif.Read("Configure Window", "mpvPath_Text");

                    // mpv Config Path
                    vm.mpvConfigPath_Text = inif.Read("Configure Window", "mpvConfigPath_Text");

                    // Profiles Path
                    vm.ProfilesPath_Text = inif.Read("Configure Window", "ProfilesPath_Text");

                    // Theme
                    string theme = inif.Read("Configure Window", "Theme_SelectedItem");
                    if (vm.Theme_Items.Contains(theme))
                        vm.Theme_SelectedItem = theme;
                    //else
                    //    listFailedImports.Add("Configure Window: Theme");

                    // Update Auto Check
                    vm.UpdateAutoCheck_IsChecked = Convert.ToBoolean(inif.Read("Configure Window", "UpdateAutoCheck_IsChecked").ToLower());
                }

                // -------------------------
                // Profile ini file does not exist
                // -------------------------
                else if (!File.Exists(Paths.configINIFile))
                {
                    MessageBox.Show("Profile does not exist.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }             


                // --------------------------------------------------
                // Failed Imports
                // --------------------------------------------------
                //if (listFailedImports.Count > 0 && listFailedImports != null)
                //{
                //    failedImportMessage = string.Join(Environment.NewLine, listFailedImports);

                //    // Detect which screen we're on
                //    var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
                //    var thisScreen = allScreens.SingleOrDefault(s => mainwindow.Left >= s.WorkingArea.Left && mainwindow.Left < s.WorkingArea.Right);

                //    // Start Window
                //    FailedImportWindow failedimportwindow = new FailedImportWindow();

                //    // Position Relative to MainWindow
                //    failedimportwindow.Left = Math.Max((mainwindow.Left + (mainwindow.Width - failedimportwindow.Width) / 2), thisScreen.WorkingArea.Left);
                //    failedimportwindow.Top = Math.Max((mainwindow.Top + (mainwindow.Height - failedimportwindow.Height) / 2), thisScreen.WorkingArea.Top);

                //    // Open Window
                //    failedimportwindow.Show();
                //}
            }

            // Error Loading config.ini
            //
            catch
            {
                // Delete config.ini and Restart
                // Check if config.ini Exists
                if (File.Exists(Paths.configINIFile))
                {
                    // Yes/No Dialog Confirmation
                    //
                    MessageBoxResult result = MessageBox.Show(
                        "Could not load config.ini. \n\nDelete config and reload defaults?",
                        "Error",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);
                    switch (result)
                    {
                        // Create
                        case MessageBoxResult.Yes:
                            File.Delete(Paths.configINIFile);

                            // Reload Control Defaults
                            LoadDefaults(mainwindow, vm);

                            // Restart Program
                            Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                            break;

                        // Use Default
                        case MessageBoxResult.No:
                            // Force Shutdown
                            System.Windows.Forms.Application.ExitThread();
                            Environment.Exit(0);
                            return;
                    }
                }
                // If config.ini Not Found
                else
                {
                    MessageBox.Show("No Previous Config File Found.",
                                    "Notice",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    return;
                }
            }
        }



    }
}
