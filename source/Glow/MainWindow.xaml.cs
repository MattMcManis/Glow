/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017 Matt McManis
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
using System;
using System.IO;
using System.Windows;
using System.Configuration;
using Glow.Properties;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Drawing.Text;
using System.Drawing;

namespace Glow
{
    public partial class MainWindow : Window
    {
        // -------------------------
        // Version
        // -------------------------
        // Current Version
        public static Version currentVersion;
        // GitHub Latest Version
        public static Version latestVersion;
        // Beta, Stable
        public static string currentBuildPhase = "alpha";
        public static string latestBuildPhase;
        public static string[] splitVersionBuildPhase;

        public string TitleVersion
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // -------------------------
        // System
        // -------------------------
        // Paths
        public static string appDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\"; //Glow.exe directory
        public static string userDir = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%").TrimEnd('\\') + @"\";
        public static string mpvDir = string.Empty;
        public static string configDir = userDir + @"AppData\Roaming\mpv\"; //mpv config directory
        public static string profilesDir = appDir + @"profiles\"; //custom ini profiles

        // -------------------------
        // Fonts
        // -------------------------
        public static List<string> fonts = new List<string>();
        public static InstalledFontCollection installedFonts = new InstalledFontCollection();
        // Bind ComboBox Fonts Items
        public List<string> FontItems
        {
            get { return fonts; }
            set { fonts = value; }
        }

        // Font Selected Item
        public string FontSelectedItem { get; set; }


        // -------------------------
        // Bind Custom Profiles
        // -------------------------
        public static List<string> _profilesItems = new List<string>();
        public List<string> ProfilesItems
        {
            get { return _profilesItems; }
            set { _profilesItems = value; }
        }

        // Selected Item
        public string ProfileSelectedItem { get; set; }


        // -------------------------
        // Bind Audio Language Items
        // -------------------------
        public static List<string> listAudioLang = Languages.listLanguages;

        public static ObservableCollection<string> _audioLangItems = new ObservableCollection<string>(listAudioLang);
        public static ObservableCollection<string> AudioLanguageItems
        {
            get { return _audioLangItems; }
            set { _audioLangItems = value; }
        }

        // -------------------------
        // Bind Subtitle Language Items
        // -------------------------
        public static List<string> listSubtitlesLang = Languages.listLanguages;

        public static ObservableCollection<string> _subsLangItems = new ObservableCollection<string>(listSubtitlesLang);
        public static ObservableCollection<string> SubtitlesLanguageItems
        {
            get { return _subsLangItems; }
            set { _subsLangItems = value; }
        }


        // -------------------------
        // Variables
        // -------------------------
        // Lock
        public static bool ready = true;



        /// <summary>
        ///     MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            this.MinWidth = 712;
            this.MinHeight = 400;

            // -------------------------
            // Set Current Version to Assembly Version
            // -------------------------
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string assemblyVersion = fvi.FileVersion;
            currentVersion = new Version(assemblyVersion);

            // -------------------------
            // Title + Version
            // -------------------------
            TitleVersion = "Glow ~ mpv Configurator (" + Convert.ToString(currentVersion) + "-" + currentBuildPhase + ")";
            DataContext = this;

            // -------------------------
            // Prevent Loading Corrupt App.Config
            // -------------------------
            try
            {
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            }
            catch (ConfigurationErrorsException ex)
            {
                string filename = ex.Filename;

                if (File.Exists(filename) == true)
                {
                    File.Delete(filename);
                    Settings.Default.Upgrade();
                }
                else
                {

                }
            }

            // --------------------------------------------------
            // Load Saved Settings
            // --------------------------------------------------
            // Window Position
            // First time use
            if (Convert.ToDouble(Settings.Default["Left"]) == 0 && Convert.ToDouble(Settings.Default["Top"]) == 0)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            // Load Saved
            else
            { 
                this.Top = Settings.Default.Top;
                this.Left = Settings.Default.Left;
                this.Height = Settings.Default.Height;
                this.Width = Settings.Default.Width;

                if (Settings.Default.Maximized)
                {
                    WindowState = WindowState.Maximized;
                }
            }

            SettingsWindow Settingswindow = new SettingsWindow(this);

            // Theme
            SettingsWindow.LoadTheme(Settingswindow);
            // mpv Path
            SettingsWindow.LoadMpvPath(Settingswindow);
            // Config Path
            SettingsWindow.LoadConfigPath(Settingswindow);
            // Profiles Path
            SettingsWindow.LoadProfilesPath(Settingswindow);


            // --------------------------------------------------
            // Load Fonts
            // --------------------------------------------------
            foreach (FontFamily font in installedFonts.Families)
            {
                if (!string.IsNullOrEmpty(font.Name)) {
                    fonts.Add(font.Name);
                }
            }

            // --------------------------------------------------
            // Control Defaults
            // --------------------------------------------------
            // Font
            cboProfile.SelectedItem = "Default";
            FontSelectedItem = "Segoe UI";

            // --------------------------------------------------
            // Custom Profiles
            // --------------------------------------------------
            // Load Custom INI's
            Profiles.GetCustomProfiles();
            // Default Selected Item
            ProfileSelectedItem = ProfilesItems[0];
        }


        /// <summary>
        ///     Close / Exit (Method)
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            // Force Exit All Executables
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        // Save Window Position, Width, Height
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //Settings.Default.Save();

            if (WindowState == WindowState.Maximized)
            {
                // Use the RestoreBounds as the current values will be 0, 0 and the size of the screen
                Settings.Default.Top = RestoreBounds.Top;
                Settings.Default.Left = RestoreBounds.Left;
                Settings.Default.Height = RestoreBounds.Height;
                Settings.Default.Width = RestoreBounds.Width;
                Settings.Default.Maximized = true;
            }
            else
            {
                Settings.Default.Top = this.Top;
                Settings.Default.Left = this.Left;
                Settings.Default.Height = this.Height;
                Settings.Default.Width = this.Width;
                Settings.Default.Maximized = false;
            }

            Settings.Default.Save();
        }



        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Methods
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        /// <summary>
        ///    Config RichTextBox
        /// </summary>
        public String ConfigRichTextBox()
        {
            // Select All Text
            TextRange textRange = new TextRange(
                rtbConfig.Document.ContentStart,
                rtbConfig.Document.ContentEnd
            );

            // Remove Formatting
            textRange.ClearAllProperties();

            // Return Text
            return textRange.Text;
        }




        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Controls
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------
        // Video Controls
        // --------------------------------------------------

        /// <summary>
        ///    Video Driver
        /// </summary>
        private void cboVideoDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable OpenGL PBO

            // Enabled
            if ((string)cboVideoDriver.SelectedItem == "opengl"
                || (string)cboVideoDriver.SelectedItem == "opengl-hq")
            {
                cboOpenGLPBO.IsEnabled = true;
            }
            // Disabled
            else
            {
                cboOpenGLPBO.SelectedItem = "off";
                cboOpenGLPBO.IsEnabled = false;
            }
        }

        /// <summary>
        ///    Gamma Auto
        /// </summary>
        private void cboGammaAuto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Gamma

            // Enabled
            if ((string)cboGammaAuto.SelectedItem == "on")
            {
                // Slider
                slGamma.Value = 0;
                slGamma.IsEnabled = false;
                // TextBox
                tbxGamma.IsEnabled = false;
            }
            // Disabled
            else if ((string)cboGammaAuto.SelectedItem == "off")
            {
                // Slider
                slGamma.IsEnabled = true;
                // TextBox
                tbxGamma.IsEnabled = true;
            }
        }

        /// <summary>
        ///    Deband
        /// </summary>
        private void cboDeband_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Deband Grain

            // Enabled
            if ((string)cboDeband.SelectedItem == "yes")
            {
                tbxDebandGrain.IsEnabled = true;
            }
            // Disabled
            else if ((string)cboDeband.SelectedItem == "no")
            {
                tbxDebandGrain.IsEnabled = false;
                tbxDebandGrain.Text = "";
            }
        }

        /// <summary>
        ///    Scale
        /// </summary>
        private void cboScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Scale Antiring

            // Off
            // Turn off Scale Antiring
            if ((string)cboScale.SelectedItem == "off")
            {
                slScaleAntiring.IsEnabled = false;
                slScaleAntiring.Value = 0;
                tbxScaleAntiring.IsEnabled = false;
            }
            // On
            // Enable Scale Antiring
            else
            {
                slScaleAntiring.IsEnabled = true;
                tbxScaleAntiring.IsEnabled = true;
            }
        }

        /// <summary>
        ///    Chroma Scale
        /// </summary>
        private void cboChromaScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Chroma Scale Antiring

            // Off
            // Turn off Chroma Scale Antiring
            if ((string)cboChromaScale.SelectedItem == "off")
            {
                slChromaAntiring.IsEnabled = false;
                slChromaAntiring.Value = 0;
                tbxChromaAntiring.IsEnabled = false;
            }
            // On
            // Enable Chroma Scale Antiring
            else
            {
                slChromaAntiring.IsEnabled = true;
                tbxChromaAntiring.IsEnabled = true;
            }
        }

        /// <summary>
        ///    Downscale
        /// </summary>
        private void cboDownscale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Downscale Antiring

            // Off
            // Turn off Downscale Antiring
            if ((string)cboDownscale.SelectedItem == "off")
            {
                slDownscaleAntiring.IsEnabled = false;
                slDownscaleAntiring.Value = 0;
                tbxDownscaleAntiring.IsEnabled = false;
            }
            // On
            // Enable Downscale Antiring
            else
            {
                slDownscaleAntiring.IsEnabled = true;
                tbxDownscaleAntiring.IsEnabled = true;
            }
        }

        /// <summary>
        ///    Software Scaler
        /// </summary>
        private void cboSoftwareScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Hardware Scaling if Software Scaling is on

            // Enabled
            if ((string)cboSoftwareScaler.SelectedItem != "off")
            {
                // Sigmoid
                cboSigmoid.IsEnabled = false;

                // Scale
                cboScale.IsEnabled = false;
                slScaleAntiring.IsEnabled = false;
                slScaleAntiring.Value = 0;
                tbxScaleAntiring.IsEnabled = false;

                // Chroma
                cboChromaScale.IsEnabled = false;
                slChromaAntiring.IsEnabled = false;
                slChromaAntiring.Value = 0;
                tbxChromaAntiring.IsEnabled = false;

                // Downscale
                cboDownscale.IsEnabled = false;
                slDownscaleAntiring.IsEnabled = false;
                slDownscaleAntiring.Value = 0;
                tbxDownscaleAntiring.IsEnabled = false;
            }
            // Disabled
            else
            {
                // Sigmoid
                cboSigmoid.IsEnabled = true;

                // Scale
                cboScale.IsEnabled = true;
                slScaleAntiring.IsEnabled = true;
                tbxScaleAntiring.IsEnabled = true;

                // Chroma
                cboChromaScale.IsEnabled = true;
                slChromaAntiring.IsEnabled = true;
                tbxChromaAntiring.IsEnabled = true;

                // Downscale
                cboDownscale.IsEnabled = true;
                slDownscaleAntiring.IsEnabled = true;
                tbxDownscaleAntiring.IsEnabled = true;
            }
        }



        // --------------------------------------------------
        // Audio Controls
        // --------------------------------------------------

        /// <summary>
        ///    Audio Languages
        /// </summary>
        private void listViewAudioLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// Remove
            //foreach (string item in e.RemovedItems)
            //{
            //    Audio.listAudioLanguages.Remove(item);
            //    Audio.listAudioLanguages.TrimExcess();
            //}

            //// Add
            //foreach (string item in e.AddedItems)
            //{
            //    Audio.listAudioLanguages.Add(item);
            //}
        }

        /// <summary>
        ///    Audio Language Up
        /// </summary>
        private void buttonAudioLanguageUp_Click(object sender, RoutedEventArgs e)
        {
            if (listViewAudioLanguages.SelectedItems.Count > 0)
            {
                var selectedIndex = this.listViewAudioLanguages.SelectedIndex;

                if (selectedIndex > 0)
                {
                    var itemToMoveUp = AudioLanguageItems[selectedIndex];
                    AudioLanguageItems.RemoveAt(selectedIndex);
                    AudioLanguageItems.Insert(selectedIndex - 1, itemToMoveUp);
                    this.listViewAudioLanguages.SelectedIndex = selectedIndex - 1;
                }
            }
        }
        /// <summary>
        ///    Audio Language Down
        /// </summary>
        private void buttonAudioLanguageDown_Click(object sender, RoutedEventArgs e)
        {
            if (listViewAudioLanguages.SelectedItems.Count > 0)
            {
                var selectedIndex = this.listViewAudioLanguages.SelectedIndex;

                if (selectedIndex + 1 < AudioLanguageItems.Count)
                {
                    var itemToMoveDown = AudioLanguageItems[selectedIndex];
                    AudioLanguageItems.RemoveAt(selectedIndex);
                    AudioLanguageItems.Insert(selectedIndex + 1, itemToMoveDown);
                    this.listViewAudioLanguages.SelectedIndex = selectedIndex + 1;
                }
            }
        }
        /// <summary>
        ///    Audio Select All
        /// </summary>
        private void buttonAudioLanguageSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewAudioLanguages.SelectAll();
        }
        /// <summary>
        ///    Audio Deselect All
        /// </summary>
        private void buttonAudioLanguageDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewAudioLanguages.SelectedIndex = -1;
        }



        // --------------------------------------------------
        // Subtitle Controls
        // --------------------------------------------------

        /// <summary>
        ///    Subtitle Shadow Color
        /// </summary>
        private void cboSubtitleShadowColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get Selected Item
            ComboBoxItem selectedItem = (ComboBoxItem)(cboSubtitlesShadowColor.SelectedValue);
            string selected = (string)(selectedItem.Content);

            // Disable
            if (selected == "None")
            {
                // slider
                slSubtitlesShadowOffset.IsEnabled = false;
                // textbox
                tbxSubtitlesShadowOffset.IsEnabled = false;
                tbxSubtitlesShadowOffset.Text = "0.00";
            }
            // Enable
            else
            {
                // slider
                slSubtitlesShadowOffset.IsEnabled = true;
                // textbox
                tbxSubtitlesShadowOffset.IsEnabled = true;
            }
        }

        /// <summary>
        ///    Subtitle Languages
        /// </summary>
        private void listViewSubtitleLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        ///    Subtitle Language Up
        /// </summary>
        private void buttonSubtitleLanguageUp_Click(object sender, RoutedEventArgs e)
        {
            if (listViewSubtitlesLanguages.SelectedItems.Count > 0)
            {
                var selectedIndex = this.listViewSubtitlesLanguages.SelectedIndex;

                if (selectedIndex > 0)
                {
                    var itemToMoveUp = SubtitlesLanguageItems[selectedIndex];
                    SubtitlesLanguageItems.RemoveAt(selectedIndex);
                    SubtitlesLanguageItems.Insert(selectedIndex - 1, itemToMoveUp);
                    this.listViewSubtitlesLanguages.SelectedIndex = selectedIndex - 1;
                }
            }
        }
        /// <summary>
        ///    Subtitle Language Down
        /// </summary>
        private void buttonSubtitleLanguageDown_Click(object sender, RoutedEventArgs e)
        {
            if (listViewSubtitlesLanguages.SelectedItems.Count > 0)
            {
                var selectedIndex = this.listViewSubtitlesLanguages.SelectedIndex;

                if (selectedIndex + 1 < SubtitlesLanguageItems.Count)
                {
                    var itemToMoveDown = SubtitlesLanguageItems[selectedIndex];
                    SubtitlesLanguageItems.RemoveAt(selectedIndex);
                    SubtitlesLanguageItems.Insert(selectedIndex + 1, itemToMoveDown);
                    this.listViewSubtitlesLanguages.SelectedIndex = selectedIndex + 1;
                }
            }
        }
        /// <summary>
        ///    Subtitle Select All
        /// </summary>
        private void buttonSubtitleLanguageSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitlesLanguages.SelectAll();
        }
        /// <summary>
        ///    Subtitle Deselect All
        /// </summary>
        private void buttonSubtitleLanguageDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitlesLanguages.SelectedIndex = -1;
        }



        // --------------------------------------------------
        // OSD Controls
        // --------------------------------------------------

        /// <summary>
        ///    OSD Shadow
        /// </summary>
        private void cboOSDFontShadowColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get Selected Item
            ComboBoxItem selectedItem = (ComboBoxItem)(cboOSDShadowColor.SelectedValue);
            string selected = (string)(selectedItem.Content);

            // Disable
            if (selected == "None")
            {
                // slider
                slOSDShadowOffset.IsEnabled = false;
                tbxOSDShadowOffset.IsEnabled = false;
                // textbox
                tbxOSDShadowOffset.Text = "0.00";
            }
            // Enable
            else
            {
                // slider
                slOSDShadowOffset.IsEnabled = true;
                // textbox
                tbxOSDShadowOffset.IsEnabled = true;
            }

        }



        // --------------------------------------------------
        // Main Controls
        // --------------------------------------------------

        /// <summary>
        ///     Info Button
        /// </summary>
        private Boolean IsInfoWindowOpened = false;
        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            // Detect which screen we're on
            var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);

            // Start Window
            InfoWindow infowindow = new InfoWindow();

            // Keep Window on Top
            infowindow.Owner = GetWindow(this);

            // Only allow 1 Window instance
            if (IsInfoWindowOpened) return;
            infowindow.ContentRendered += delegate { IsInfoWindowOpened = true; };
            infowindow.Closed += delegate { IsInfoWindowOpened = false; };

            // Position Relative to MainWindow
            infowindow.Left = Math.Max((this.Left + (this.Width - infowindow.Width) / 2), thisScreen.WorkingArea.Left);
            infowindow.Top = Math.Max((this.Top + (this.Height - infowindow.Height) / 2), thisScreen.WorkingArea.Top);

            // Open Window
            infowindow.Show();
        }

        /// <summary>
        ///    Website Button
        /// </summary>
        private void buttonWebsite_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://glowmpv.github.io");
        }

        /// <summary>
        ///    Configure Window Button
        /// </summary>
        private void buttonConfigure_Click(object sender, RoutedEventArgs e)
        {
            // Detect which screen we're on
            var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);

            // Open Configure Window
            SettingsWindow Settingswindow = new SettingsWindow(this);

            // Position Relative to MainWindow
            // Keep from going off screen
            Settingswindow.Left = Math.Max((this.Left + (this.Width - Settingswindow.Width) / 2), thisScreen.WorkingArea.Left);
            Settingswindow.Top = Math.Max(this.Top - Settingswindow.Height - 12, thisScreen.WorkingArea.Top);

            // Keep Window on Top
            Settingswindow.Owner = Window.GetWindow(this);

            // Open Winndow
            Settingswindow.ShowDialog();
        }

        /// <summary>
        ///    Update Button
        /// </summary>
        private Boolean IsUpdateWindowOpened = false;
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Proceed if Internet Connection
            //
            if (UpdateWindow.CheckForInternetConnection() == true)
            {
                // Parse GitHub .version file
                //
                string parseLatestVersion = string.Empty;

                try
                {
                    parseLatestVersion = UpdateWindow.wc.DownloadString("https://raw.githubusercontent.com/MattMcManis/Glow/master/.version");
                }
                catch
                {
                    MessageBox.Show("GitHub version file not found.");
                }


                //Split Version & Build Phase by dash
                //
                if (!string.IsNullOrEmpty(parseLatestVersion)) //null check
                {
                    try
                    {
                        // Split Version and Build Phase
                        splitVersionBuildPhase = Convert.ToString(parseLatestVersion).Split('-');

                        // Set Version Number
                        latestVersion = new Version(splitVersionBuildPhase[0]); //number
                        latestBuildPhase = splitVersionBuildPhase[1]; //alpha
                    }
                    catch
                    {
                        MessageBox.Show("Error reading version.");
                    }

                    // Debug
                    //MessageBox.Show(Convert.ToString(latestVersion));
                    //MessageBox.Show(latestBuildPhase);


                    // Check if Glow is the Latest Version
                    // Update Available
                    if (latestVersion > currentVersion)
                    {
                        // Yes/No Dialog Confirmation
                        //
                        MessageBoxResult result = MessageBox.Show("v" + latestVersion + "-" + latestBuildPhase + "\n\nDownload Update?", "Update Available ", MessageBoxButton.YesNo);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                // Detect which screen we're on
                                var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
                                var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);

                                // Start Window
                                UpdateWindow updatewindow = new UpdateWindow();

                                // Keep in Front
                                updatewindow.Owner = Window.GetWindow(this);

                                // Only allow 1 Window instance
                                if (IsUpdateWindowOpened) return;
                                updatewindow.ContentRendered += delegate { IsUpdateWindowOpened = true; };
                                updatewindow.Closed += delegate { IsUpdateWindowOpened = false; };

                                // Position Relative to MainWindow
                                // Keep from going off screen
                                updatewindow.Left = Math.Max((this.Left + (this.Width - updatewindow.Width) / 2), thisScreen.WorkingArea.Left);
                                updatewindow.Top = Math.Max((this.Top + (this.Height - updatewindow.Height) / 2), thisScreen.WorkingArea.Top);

                                // Open Window
                                updatewindow.Show();
                                break;
                            case MessageBoxResult.No:
                                break;
                        }
                    }
                    // Update Not Available
                    else if (latestVersion <= currentVersion)
                    {
                        MessageBox.Show("This version is up to date.");
                    }
                    // Unknown
                    else // null
                    {
                        MessageBox.Show("Could not find download. Try updating manually.");
                    }
                }
                // Version is Null
                else
                {
                    MessageBox.Show("GitHub version file returned empty.");
                }
            }
            else
            {
                MessageBox.Show("Could not detect Internet Connection.");
            }
        }

        /// <summary>
        ///    Open Config Directory
        /// </summary>
        private void buttonConfigDir_Click(object sender, RoutedEventArgs e)
        {
            // Check if mpv config dir exists
            // If not, create it
            Directory.CreateDirectory(configDir);

            // Open Directory
            Process.Start("explorer.exe", configDir);
        }


        /// <summary>
        ///     Copy Config
        /// </summary>
        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ConfigRichTextBox(), TextDataFormat.UnicodeText);
        }


        /// <summary>
        ///     Save Config Button
        /// </summary>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if mpv config dir exists
                // If not, create it
                Directory.CreateDirectory(configDir);
            }
            catch
            {
                // program will crash if not administrator
            }

            // Open 'Save File'
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();

            saveFile.InitialDirectory = configDir;
            saveFile.RestoreDirectory = true;
            //saveFile.Filter = "Text file (*.txt)|*.txt";
            saveFile.DefaultExt = "";
            saveFile.FileName = "config";

            // Show save file dialog box
            Nullable<bool> result = saveFile.ShowDialog();

            // Process dialog box
            if (result == true)
            {
                // Check for Save Error
                try
                {
                    // Save document
                    File.WriteAllText(saveFile.FileName, ConfigRichTextBox(), Encoding.UTF8);
                }
                catch
                {
                    MessageBox.Show("Error Saving Config to " + "\"" + configDir + "\"" + ". May require Administrator Privileges.");
                }
            }
        }


        /// <summary>
        ///    Preset
        /// </summary>
        private void cboProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profiles.Profile(this);
        }

        /// <summary>
        ///    Export Preset
        /// </summary>
        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if presets directory exists
                // If not, create it
                Directory.CreateDirectory(profilesDir);
            }
            catch
            {
                // program will crash if not administrator
            }

            // Open 'Save File'
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();

            // Defaults
            saveFile.InitialDirectory = profilesDir;
            saveFile.RestoreDirectory = true;
            saveFile.Filter = "ini file (*.ini)|*.ini";
            saveFile.DefaultExt = "";
            saveFile.FileName = "profile.ini";

            // Show save file dialog box
            Nullable<bool> result = saveFile.ShowDialog();

            // Process dialog box
            if (result == true)
            {
                // Set Input Dir, Name, Ext
                string inputDir = Path.GetDirectoryName(saveFile.FileName).TrimEnd('\\') + @"\";
                //string inputFileName = Path.GetFileName(saveFile.FileName);
                string inputFileName = Path.GetFileNameWithoutExtension(saveFile.FileName);
                string inputExt = Path.GetExtension(saveFile.FileName);
                string input = inputDir + inputFileName + inputExt;
                //string input = Path.Combine(inputDir, inputFileName);

                // Overwriting doesn't work properly with INI Writer
                // Delete File instead before saving new
                if (File.Exists(input))
                {
                    File.Delete(input);
                }

                // Export ini file
                Profiles.ExportProfile(this, input);

                // Refresh Profiles ComboBox
                Profiles.GetCustomProfiles();
                cboProfile.ItemsSource = _profilesItems;
            }
        }


        /// <summary>
        ///    Import Preset
        /// </summary>
        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            // Check if presets directory exists
            // If not, create it
            Directory.CreateDirectory(profilesDir);

            // Open 'Select File'
            Microsoft.Win32.OpenFileDialog selectFile = new Microsoft.Win32.OpenFileDialog();

            // Defaults
            selectFile.InitialDirectory = profilesDir;
            selectFile.RestoreDirectory = true;
            selectFile.Filter = "ini file (*.ini)|*.ini";

            // Show select file dialog box
            Nullable<bool> result = selectFile.ShowDialog();

            // Process dialog box
            if (result == true)
            {
                // Set Input Dir, Name, Ext
                string inputDir = Path.GetDirectoryName(selectFile.FileName).TrimEnd('\\') + @"\";
                //string inputFileName = Path.GetFileName(selectFile.FileName);
                string inputFileName = Path.GetFileNameWithoutExtension(selectFile.FileName);
                string inputExt = Path.GetExtension(selectFile.FileName);
                string input = inputDir + inputFileName + inputExt;
                //string input = Path.Combine(inputDir, inputFileName);

                // Import ini file
                Profiles.ImportProfile(this, input);
            }
        }


        /// <summary>
        ///     Generate
        /// </summary>
        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Write Config to RichTextBox
            Paragraph p = new Paragraph();
            p.LineHeight = 2;

            rtbConfig.Document = new FlowDocument(p);
            rtbConfig.BeginChange();
            p.Inlines.Add(new Run(Generate.GenerateConfig(this)));
            rtbConfig.EndChange();
        }


    }
}
