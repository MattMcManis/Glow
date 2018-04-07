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
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Glow
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainWindow mainwindow;

        public SettingsWindow(MainWindow mainwindow)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;

            // Set Min/Max Width/Height to prevent Tablets maximizing
            this.MinWidth = 450;
            this.MinHeight = 200;
            this.MaxWidth = 450;
            this.MaxHeight = 200;

            // --------------------------------------------------
            // Load From Saved Settings
            // --------------------------------------------------
            LoadTheme(this);
            LoadMpvPath(this);
            LoadConfigPath(this);
            LoadProfilesPath(this);
        }


        /// <summary>
        /// Load Theme
        /// </summary>
        public static void LoadTheme(SettingsWindow settingswindow)
        {
            // --------------------------------------------------
            // Safeguard Against Corrupt Saved Settings
            // --------------------------------------------------
            try
            {
                string theme = string.Empty;

                // --------------------------
                // First time use
                // --------------------------
                if (string.IsNullOrEmpty(Settings.Default["Theme"].ToString()))
                {
                    theme = "Glow";

                    // Set ComboBox if Configure Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.cboTheme.SelectedItem = "Glow";
                    }

                    // Save Theme for next launch
                    Settings.Default["Theme"] = theme;
                    Settings.Default.Save();

                    // Change Theme Resource
                    App.Current.Resources.MergedDictionaries.Clear();
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = new Uri("Theme" + theme + ".xaml", UriKind.RelativeOrAbsolute)
                    });
                }
                // --------------------------
                // Load Saved Settings Override
                // --------------------------
                else if (!string.IsNullOrEmpty(Settings.Default["Theme"].ToString())) // null check
                {
                    theme = Settings.Default["Theme"].ToString();

                    // Set ComboBox if Configure Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.cboTheme.SelectedItem = Settings.Default["Theme"].ToString();
                    }

                    // Change Theme Resource
                    App.Current.Resources.MergedDictionaries.Clear();
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = new Uri("Theme" + theme + ".xaml", UriKind.RelativeOrAbsolute)
                    });
                }
            }
            catch
            {

            }
        }



        /// <summary>
        /// Load mpv Path
        /// </summary>
        public static void LoadMpvPath(SettingsWindow settingswindow)
        {
            // --------------------------------------------------
            // Safeguard Against Corrupt Saved Settings
            // --------------------------------------------------
            try
            {
                // --------------------------
                // First time use
                // --------------------------
                if (string.IsNullOrEmpty(Settings.Default["mpvDir"].ToString()))
                {
                    MainWindow.mpvDir = string.Empty;

                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxMpvPath.Text = MainWindow.mpvDir;
                    }

                    // Save for next launch
                    Settings.Default["mpvDir"] = MainWindow.mpvDir;
                    Settings.Default.Save();
                }
                // --------------------------
                // Load Saved Settings Override
                // --------------------------
                else if (!string.IsNullOrEmpty(Settings.Default["mpvDir"].ToString())) // null check
                {
                    MainWindow.mpvDir = Settings.Default["mpvDir"].ToString();

                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxMpvPath.Text = Settings.Default["mpvDir"].ToString();
                    }
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// Load Config Path
        /// </summary>
        public static void LoadConfigPath(SettingsWindow settingswindow)
        {
            // --------------------------------------------------
            // Safeguard Against Corrupt Saved Settings
            // --------------------------------------------------
            try
            {
                // --------------------------
                // First time use
                // --------------------------
                if (string.IsNullOrEmpty(Settings.Default["configDir"].ToString()))
                {
                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxConfigPath.Text = MainWindow.configDir;
                    }

                    // Save for next launch
                    Settings.Default["configDir"] = MainWindow.configDir;
                    Settings.Default.Save();
                }
                // --------------------------
                // Load Saved Settings Override
                // --------------------------
                else if (!string.IsNullOrEmpty(Settings.Default["configDir"].ToString())) // null check
                {
                    MainWindow.configDir = Settings.Default["configDir"].ToString();

                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxConfigPath.Text = Settings.Default["configDir"].ToString();
                    }
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// Load Profiles Path
        /// </summary>
        public static void LoadProfilesPath(SettingsWindow settingswindow)
        {
            // --------------------------------------------------
            // Safeguard Against Corrupt Saved Settings
            // --------------------------------------------------
            try
            {
                // --------------------------
                // First time use
                // --------------------------
                if (string.IsNullOrEmpty(Settings.Default["profilesDir"].ToString()))
                {
                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxProfilesPath.Text = MainWindow.profilesDir;
                    }

                    // Save for next launch
                    Settings.Default["profilesDir"] = MainWindow.profilesDir;
                    Settings.Default.Save();
                }
                // --------------------------
                // Load Saved Settings Override
                // --------------------------
                else if (!string.IsNullOrEmpty(Settings.Default["profilesDir"].ToString())) // null check
                {
                    MainWindow.profilesDir = Settings.Default["profilesDir"].ToString();

                    // Set ComboBox if Settings Window is Open
                    if (settingswindow != null)
                    {
                        settingswindow.textBoxProfilesPath.Text = Settings.Default["profilesDir"].ToString();
                    }
                }
            }
            catch
            {

            }
        }




        /// <summary>
        ///    Settings Path Select
        /// </summary>
        public static void SettingsSelectPath(SettingsWindow settingswindow, string pathType)
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
                    settingswindow.textBoxMpvPath.Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";

                    MainWindow.mpvDir = settingswindow.textBoxMpvPath.Text;

                    // Save for next launch
                    Settings.Default["mpvDir"] = settingswindow.textBoxMpvPath.Text;
                    Settings.Default.Save();
                    Settings.Default.Reload();
                }

                // -------------------------
                // Config Path
                // -------------------------
                else if (pathType == "configPath")
                {
                    settingswindow.textBoxConfigPath.Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";

                    MainWindow.configDir = settingswindow.textBoxConfigPath.Text;

                    // Save for next launch
                    Settings.Default["configDir"] = settingswindow.textBoxConfigPath.Text;
                    Settings.Default.Save();
                    Settings.Default.Reload();
                }

                // -------------------------
                // Profiles Path
                // -------------------------
                else if (pathType == "profilesPath")
                {
                    settingswindow.textBoxProfilesPath.Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";

                    MainWindow.profilesDir = settingswindow.textBoxProfilesPath.Text;

                    // Save for next launch
                    Settings.Default["profilesDir"] = settingswindow.textBoxProfilesPath.Text;
                    Settings.Default.Save();
                    Settings.Default.Reload();
                }
            }
        }


        /// <summary>
        ///    mpv Path
        /// </summary>
        private void textBoxMpvPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath(this, "mpvPath");
        }

        /// <summary>
        ///    Revert mpv Path
        /// </summary>
        private void buttonMpvPathRevert_Click(object sender, RoutedEventArgs e)
        {
            // Set the default path
            MainWindow.mpvDir = string.Empty;

            // Display Folder Path in Textbox
            textBoxMpvPath.Text = MainWindow.mpvDir;

            // FPath path for next launch
            Settings.Default["mpvDir"] = MainWindow.mpvDir;
            Settings.Default.Save();
            Settings.Default.Reload();
        }


        /// <summary>
        ///    Config Path
        /// </summary>
        private void textBoxConfigPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath(this, "configPath");
        }

        /// <summary>
        ///    Revert Confg Path
        /// </summary>
        private void buttonConfigPathRevert_Click(object sender, RoutedEventArgs e)
        {
            // Set the default path
            MainWindow.configDir = MainWindow.userDir + @"AppData\Roaming\mpv\";

            // Display Folder Path in Textbox
            textBoxConfigPath.Text = MainWindow.configDir;

            // Path path for next launch
            Settings.Default["configDir"] = MainWindow.configDir;
            Settings.Default.Save();
            Settings.Default.Reload();
        }


        /// <summary>
        ///    Profiles Path
        /// </summary>
        private void textBoxProfilesPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath(this, "profilesPath");
        }

        /// <summary>
        ///    Revert Profiles Path
        /// </summary>
        private void buttonProfilesPathRevert_Click(object sender, RoutedEventArgs e)
        {
            // Set the default path
            MainWindow.profilesDir = MainWindow.appDir + @"profiles\";

            // Display Folder Path in Textbox
            textBoxProfilesPath.Text = MainWindow.profilesDir;

            // Path path for next launch
            Settings.Default["profilesDir"] = MainWindow.profilesDir;
            Settings.Default.Save();
            Settings.Default.Reload();
        }


        /// <summary>
        ///    Theme
        /// </summary>
        private void themeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string theme = cboTheme.SelectedItem.ToString();

            // Change Theme Resource
            App.Current.Resources.MergedDictionaries.Clear();
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("Theme" + theme + ".xaml", UriKind.RelativeOrAbsolute)
            });

            // Save Theme for next launch
            Settings.Default["Theme"] = theme;
            Settings.Default.Save();
            Settings.Default.Reload();
        }


        /// <summary>
        ///    Reset Settings
        /// </summary>
        private void buttonClearAllSavedSettings_Click(object sender, RoutedEventArgs e)
        {
            // Revert mpv Path
            MainWindow.mpvDir = string.Empty;
            textBoxMpvPath.Text = MainWindow.mpvDir;

            // Revert Config Path
            MainWindow.configDir = MainWindow.userDir + @"AppData\Roaming\mpv\";
            textBoxConfigPath.Text = MainWindow.configDir;

            // Revert Profiles Path
            MainWindow.profilesDir = MainWindow.appDir + @"profiles\";
            textBoxProfilesPath.Text = MainWindow.profilesDir;

            // Save Current Window Location
            // Prevents MainWindow from moving to Top 0 Left 0 while running
            double left = mainwindow.Left;
            double top = mainwindow.Top;

            // Reset AppData Settings
            Settings.Default.Reset();
            Settings.Default.Reload();

            // Set Window Location
            mainwindow.Left = left;
            mainwindow.Top = top;
        }

        /// <summary>
        ///    Delete Settings
        /// </summary>
        private void buttonDeleteSettings_Click(object sender, RoutedEventArgs e)
        {
            string appDataPath = MainWindow.userDir + @"AppData\Local\Glow\";

            // Check if Directory Exists
            if (Directory.Exists(appDataPath))
            {
                // Show Yes No Window
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                    "Delete " + appDataPath, "Delete Directory Confirm", System.Windows.Forms.MessageBoxButtons.YesNo);
                // Yes
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    // Delete leftover 2 Pass Logs in Program's folder and Input Files folder
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
                MessageBox.Show("No Previous Settings Found.");
            }
        }


    }
}
