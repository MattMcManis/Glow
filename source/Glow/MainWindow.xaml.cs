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
        public static string configDir = userDir + @"AppData\Roaming\mpv\"; //mpv config directory

        // Fonts
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
        // Bind Audio Language Items
        // -------------------------
        private static List<string> listAudioLang = Languages.listLanguages;

        public static ObservableCollection<string> _audioLangItems = new ObservableCollection<string>(listAudioLang);
        public static ObservableCollection<string> AudioLanguageItems
        {
            get { return _audioLangItems; }
            set { _audioLangItems = value; }
        }

        // -------------------------
        // Bind Subtitle Language Items
        // -------------------------
        private static List<string> listSubtitleLang = Languages.listLanguages;

        public static ObservableCollection<string> _subLangItems = new ObservableCollection<string>(listSubtitleLang);
        public static ObservableCollection<string> SubtitleLanguageItems
        {
            get { return _subLangItems; }
            set { _subLangItems = value; }
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

            this.MinWidth = 775;
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
            if (Convert.ToDouble(Settings.Default["Left"]) == 0
                || Convert.ToDouble(Settings.Default["Top"]) == 0)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

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
            cboPreset.SelectedItem = "Default";
            FontSelectedItem = "Arial";
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

        // Save Window Position
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Settings.Default.Save();
        }



        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Methods
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
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
        ///    Deband
        /// </summary>
        private void cboDeband_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enabled
            if ((string)cboDeband.SelectedItem == "yes")
            {
                tbxDebandGrain.IsEnabled = true;
            }
            // Diabled
            else if ((string)cboDeband.SelectedItem == "no")
            {
                tbxDebandGrain.IsEnabled = false;
                tbxDebandGrain.Text = "";
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
            var selectedIndex = this.listViewAudioLanguages.SelectedIndex;

            if (selectedIndex > 0)
            {
                var itemToMoveUp = AudioLanguageItems[selectedIndex];
                AudioLanguageItems.RemoveAt(selectedIndex);
                AudioLanguageItems.Insert(selectedIndex - 1, itemToMoveUp);
                this.listViewAudioLanguages.SelectedIndex = selectedIndex - 1;
            }
        }
        /// <summary>
        ///    Audio Language Down
        /// </summary>
        private void buttonAudioLanguageDown_Click(object sender, RoutedEventArgs e)
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
                tbxSubtitlesShadowOffset.Text = "";
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
            var selectedIndex = this.listViewSubtitleLanguages.SelectedIndex;

            if (selectedIndex > 0)
            {
                var itemToMoveUp = SubtitleLanguageItems[selectedIndex];
                SubtitleLanguageItems.RemoveAt(selectedIndex);
                SubtitleLanguageItems.Insert(selectedIndex - 1, itemToMoveUp);
                this.listViewSubtitleLanguages.SelectedIndex = selectedIndex - 1;
            }
        }
        /// <summary>
        ///    Subtitle Language Down
        /// </summary>
        private void buttonSubtitleLanguageDown_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = this.listViewSubtitleLanguages.SelectedIndex;

            if (selectedIndex + 1 < SubtitleLanguageItems.Count)
            {
                var itemToMoveDown = SubtitleLanguageItems[selectedIndex];
                SubtitleLanguageItems.RemoveAt(selectedIndex);
                SubtitleLanguageItems.Insert(selectedIndex + 1, itemToMoveDown);
                this.listViewSubtitleLanguages.SelectedIndex = selectedIndex + 1;
            }
        }
        /// <summary>
        ///    Subtitle Select All
        /// </summary>
        private void buttonSubtitleLanguageSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitleLanguages.SelectAll();
        }
        /// <summary>
        ///    Subtitle Deselect All
        /// </summary>
        private void buttonSubtitleLanguageDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitleLanguages.SelectedIndex = -1;
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
            ComboBoxItem selectedItem = (ComboBoxItem)(cboOSDFontShadowColor.SelectedValue);
            string selected = (string)(selectedItem.Content);

            // Disable
            if (selected == "None")
            {
                // slider
                slOSDShadowOffset.IsEnabled = false;
                tbxOSDShadowOffset.IsEnabled = false;
                // textbox
                tbxOSDShadowOffset.Text = "";
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
        ///    Update Button
        /// </summary>
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

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
            // Check if mpv config dir exists
            // If not, create it
            Directory.CreateDirectory(configDir);


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
                    MessageBox.Show("Error Saving Output Log to " + "\"" + configDir + "\"" + ". May require Administrator Privileges.");
                }
            }
        }


        /// <summary>
        ///    Preset
        /// </summary>
        private void cboPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presets.Preset(this);
        }


        /// <summary>
        ///     Generate
        /// </summary>
        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Write Config to RichTextBox
            Paragraph p = new Paragraph();

            rtbConfig.Document = new FlowDocument(p);
            rtbConfig.BeginChange();
            p.Inlines.Add(new Run(Generate.GenerateConfig(this)));
            rtbConfig.EndChange();
        }


    }
}
