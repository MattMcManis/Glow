/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017-2020 Matt McManis
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
using ViewModel;
using System.ComponentModel;

namespace Glow
{
    /// <summary>
    /// Interaction logic for ConfigureWindow.xaml
    /// </summary>
    public partial class ConfigureWindow : Window
    {
        //private MainWindow mainwindow;
        //private static MainWindow mainwindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        public static string failedImportMessage;

        public ConfigureWindow()
        {
            InitializeComponent();

            //this.mainwindow = mainwindow;

            // Set Min/Max Width/Height to prevent Tablets maximizing
            this.MinWidth = 450;
            this.MinHeight = 200;
            this.MaxWidth = 450;
            this.MaxHeight = 200;

            // --------------------------------------------------
            // Load Update Auto Check Text
            // --------------------------------------------------
            switch (VM.ConfigureView.UpdateAutoCheck_IsChecked)
            {
                case true:
                    VM.ConfigureView.UpdateAutoCheck_Text = "On";

                    break;
                case false:
                    VM.ConfigureView.UpdateAutoCheck_Text = "Off";
                    break;
            }
        }

        /// <summary>
        /// Window Loaded
        /// </summary>
        void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        /// <summary>
        /// Window Closing
        /// </summary>
        void Window_Closing(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        ///    Settings Path Select
        /// </summary>
        public static void SettingsSelectPath(string pathType)
        {
            // Open Folder Browser
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            // Popup Folder Browse Window
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                switch (pathType)
                {
                    case "mpvPath":
                        VM.ConfigureView.mpvPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                        break;

                    case "configPath":
                        VM.ConfigureView.mpvConfigPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                        break;

                    case "presetsPath":
                        VM.ConfigureView.PresetsPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
                        break;
                }
            }
        }


        /// <summary>
        ///    mpv Path
        /// </summary>
        private void textBoxMpvPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath("mpvPath");
        }
        private void lblMpvPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VM.ConfigureView.mpvPath_Text))
            {
                return;
            }

            Process.Start("explorer.exe", VM.ConfigureView.mpvPath_Text);
        }

        /// <summary>
        ///    Revert mpv Path
        /// </summary>
        private void buttonMpvPathRevert_Click(object sender, RoutedEventArgs e)
        {
            VM.ConfigureView.mpvPath_Text = string.Empty;
        }


        /// <summary>
        ///    Config Path
        /// </summary>
        private void textBoxConfigPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath("configPath");
        }
        private void lblConfigPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VM.ConfigureView.mpvConfigPath_Text))
            {
                return;
            }

            Process.Start("explorer.exe", VM.ConfigureView.mpvConfigPath_Text);
        }

        /// <summary>
        ///    Revert Confg Path
        /// </summary>
        private void buttonConfigPathRevert_Click(object sender, RoutedEventArgs e)
        {
            VM.ConfigureView.mpvConfigPath_Text = MainWindow.mpvConfigDir;
        }


        /// <summary>
        ///    Presets Path
        /// </summary>
        private void textBoxPresetsPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Folder Browser
            SettingsSelectPath("presetsPath");
        }
        private void lblPresetsPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VM.ConfigureView.PresetsPath_Text))
            {
                return;
            }

            Process.Start("explorer.exe", VM.ConfigureView.PresetsPath_Text);
        }

        /// <summary>
        ///    Revert Presets Path
        /// </summary>
        private void buttonPresetsPathRevert_Click(object sender, RoutedEventArgs e)
        {
            VM.ConfigureView.PresetsPath_Text = MainWindow.glowConfDir + @"presets\";
            //VM.ConfigureView.PresetsPath_Text = MainWindow.appRootDir + @"presets\";
        }


        /// <summary>
        ///    Updates Auto Check - Checked
        /// </summary>
        private void tglUpdateAutoCheck_Checked(object sender, RoutedEventArgs e)
        {
            // Update Toggle Text
            VM.ConfigureView.UpdateAutoCheck_Text = "On";
        }
        /// <summary>
        ///    Updates Auto Check - Unchecked
        /// </summary>
        private void tglUpdateAutoCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            // Update Toggle Text
            VM.ConfigureView.UpdateAutoCheck_Text = "Off";
        }


        /// <summary>
        ///    Theme
        /// </summary>
        private void themeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Configure.theme = VM.ConfigureView.Theme_SelectedItem;

            // Change Theme Resource
            App.Current.Resources.MergedDictionaries.Clear();
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("Themes/" + "Theme" + VM.ConfigureView.Theme_SelectedItem/*Configure.theme*/ + ".xaml", UriKind.RelativeOrAbsolute)
            });
        }


        /// <summary>
        ///    Reset Settings
        /// </summary>
        private void buttonClearAllSavedSettings_Click(object sender, RoutedEventArgs e)
        {
            //// Revert mpv Path
            //Paths.mpvDir = string.Empty;
            //textBoxMpvPath_Text = Paths.mpvDir;

            //// Revert Config Path
            //Paths.configDir = Paths.userDir + @"AppData\Roaming\mpv\";
            //textBoxConfigPath_Text = Paths.configDir;

            //// Revert Presets Path
            //Paths.presetsDir = Paths.appDir + @"presets\";
            //textBoxPresetsPath_Text = Paths.presetsDir;

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
            // Show Yes No Window
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                "Delete " + MainWindow.glowConfFile, "Delete Directory Confirm", 
                System.Windows.Forms.MessageBoxButtons.YesNo);

            // Yes
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (File.Exists(Path.Combine(MainWindow.glowConfFile)))
                {
                    try
                    {
                        File.Delete(MainWindow.glowConfFile);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.ToString(),
                                        "Error",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }

                    // Set Defaults
                    VM.ConfigureView.mpvPath_Text = string.Empty;
                    VM.ConfigureView.mpvConfigPath_Text = MainWindow.mpvConfigDir;
                    VM.ConfigureView.PresetsPath_Text = MainWindow.glowConfDir + @"presets\";
                    VM.ConfigureView.UpdateAutoCheck_IsChecked = true;
                    VM.ConfigureView.Theme_SelectedItem = "Glow";

                    // Restart Program
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            // No
            else if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                //do nothing
            }

            //string appDataPath = MainWindow.appDataRoamingDir + @"Glow\";

            //// Check if Directory Exists
            //if (Directory.Exists(appDataPath))
            //{
            //    // Show Yes No Window
            //    System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
            //        "Delete " + appDataPath, "Delete Directory Confirm", System.Windows.Forms.MessageBoxButtons.YesNo);
            //    // Yes
            //    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        using (Process delete = new Process())
            //        {
            //            delete.StartInfo.UseShellExecute = false;
            //            delete.StartInfo.CreateNoWindow = false;
            //            delete.StartInfo.RedirectStandardOutput = true;
            //            delete.StartInfo.FileName = "cmd.exe";
            //            delete.StartInfo.Arguments = "/c RD /Q /S " + "\"" + appDataPath;
            //            delete.Start();
            //            delete.WaitForExit();
            //            //delete.Close();
            //        }

            //        //Directory.Delete(appDataPath);

            //        // Restart Program
            //        Process.Start(Application.ResourceAssembly.Location);
            //        Application.Current.Shutdown();
            //    }
            //    // No
            //    else if (dialogResult == System.Windows.Forms.DialogResult.No)
            //    {
            //        //do nothing
            //    }
            //}

            //// If Glow Folder Not Found
            //else
            //{
            //    MessageBox.Show("No Previous Settings Found.",
            //                    "Notice",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Warning);
            //}
        }

        private void labelSavedSettings_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MainWindow.glowConfDir))
            {
                return;
            }

            Process.Start("explorer.exe", MainWindow.glowConfDir);
        }

    }
}
