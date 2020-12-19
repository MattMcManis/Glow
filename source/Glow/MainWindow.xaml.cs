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
using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Text;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Net;
using ViewModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        public static string currentBuildPhase = "beta";
        public static string latestBuildPhase;
        public static string[] splitVersionBuildPhase;

        public string TitleVersion
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // System
        public readonly static string appRootDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\"; // Glow.exe directory

        public readonly static string commonProgramFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles).TrimEnd('\\') + @"\";
        public readonly static string commonProgramFilesX86Dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86).TrimEnd('\\') + @"\";
        public readonly static string programFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).TrimEnd('\\') + @"\";
        public readonly static string programFilesX86Dir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).TrimEnd('\\') + @"\";
        public readonly static string programFilesX64Dir = @"C:\Program Files\";

        public readonly static string programDataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).TrimEnd('\\') + @"\";
        public readonly static string appDataLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).TrimEnd('\\') + @"\";
        public readonly static string appDataRoamingDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\') + @"\";
        public readonly static string tempDir = Path.GetTempPath(); // Windows AppData Temp Directory

        public readonly static string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).TrimEnd('\\') + @"\";
        public readonly static string documentsDir = userProfile + @"Documents\"; // C:\Users\Example\Documents\
        public readonly static string videosDir = userProfile + @"Videos\"; // C:\Users\Example\Videos\
        public readonly static string downloadDir = userProfile + @"Downloads\"; // C:\Users\Example\Downloads\

        // Conf
        //public readonly static string confAppRootPath = appRootDir + "glow.conf";
        //public readonly static string confAppDataLocalPath = appDataLocalDir + @"Glow\glow.conf";
        //public readonly static string confAppDataRoamingPath = appDataRoamingDir + @"Glow\glow.conf";
        public readonly static string glowConfDir = appDataRoamingDir + @"Glow\"; // %AppData%\Glow\
        public readonly static string glowConfFile = Path.Combine(glowConfDir, "glow.conf"); // %AppData%\Glow\glow.conf

        // Log
        //public readonly static string logAppRootPath = appRootDir + "glow.log";
        //public readonly static string logAppDataLocalPath = appDataLocalDir + @"Glow\glow.log";
        //public readonly static string logAppDataRoamingPath = appDataRoamingDir + @"Glow\glow.log";
        public readonly static string glowLogFile = Path.Combine(glowConfDir, "glow.log"); // %AppData%\Glow\glow.log

        // Presets
        public static string presetsDir = glowConfDir + @"presets\"; // Custom User ini presets
        //public static string presetsDir = appRootDir + @"presets\"; // Custom User ini presets // old

        // Programs
        public static string mpvDir = string.Empty; // mpv.exe path
        public static string mpvConfigDir = appDataRoamingDir + @"mpv\";


        /// <summary>
        ///     MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // -------------------------
            // Set Current Version to Assembly Version
            // -------------------------
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string assemblyVersion = fvi.FileVersion;
            currentVersion = new Version(assemblyVersion);


            MinWidth = VM.MainView.Window_Width;
            MinHeight = VM.MainView.Window_Height;

            // -------------------------
            // Title + Version
            // -------------------------
            VM.MainView.TitleVersion = "Glow ~ mpv Configurator (" + Convert.ToString(currentVersion) + "-" + currentBuildPhase + ")";

            // --------------------------------------------------
            // Load Fonts
            // --------------------------------------------------
            foreach (FontFamily font in VM.MainView.installedFonts.Families)
            {
                if (!string.IsNullOrEmpty(font.Name))
                {
                    //ViewModel.fonts.Add(font.Name);
                    VM.MainView.Fonts_Items.Add(font.Name);
                }
            }

            // Add default to fonts list
            VM.MainView.Fonts_Items.Insert(0, "default");

            VM.SubtitlesView.Font_Items = VM.MainView.Fonts_Items;
            VM.DisplayView.OSD_Font_Items = VM.MainView.Fonts_Items;

            // --------------------------------------------------
            // Control Defaults
            // --------------------------------------------------
            // Tooltip Duration
            ToolTipService.ShowDurationProperty.OverrideMetadata(
                typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));

            // --------------------------------------------------
            // Presets
            // --------------------------------------------------
            // Load Custom Preset INI's
            Presets.LoadCustomPresets();

            // -------------------------
            // glow.conf actions to read
            // -------------------------
            List<Action> actionsToRead = new List<Action>
            {
                new Action(() =>
                {
                    // -------------------------
                    // Main Window
                    // -------------------------
                    // Window Position Top
                    double top;
                    double.TryParse(Configure.ConfigFile.conf.Read("Main Window", "Window_Position_Top"), out top);
                    this.Top = top;

                    // Window Position Left
                    double left;
                    double.TryParse(Configure.ConfigFile.conf.Read("Main Window", "Window_Position_Left"), out left);
                    this.Left = left;

                    // Window Maximized
                    bool mainwindow_WindowState_Maximized;
                    bool.TryParse(Configure.ConfigFile.conf.Read("Main Window", "WindowState_Maximized").ToLower(), out mainwindow_WindowState_Maximized);
                    if (mainwindow_WindowState_Maximized == true)
                    {
                        //VM.MainView.Window_State = WindowState.Maximized;
                        this.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        //VM.MainView.Window_State = WindowState.Normal;
                        this.WindowState = WindowState.Normal;
                    }

                    // Window Width
                    double width;
                    double.TryParse(Configure.ConfigFile.conf.Read("Main Window", "Window_Width"), out width);
                    this.Width = width;

                    // Window Height
                    double height;
                    double.TryParse(Configure.ConfigFile.conf.Read("Main Window", "Window_Height"), out height);
                    this.Height = height;

                    // -------------------------
                    // Settings
                    // -------------------------
                    // mpv Path
                    string mpvPath_Text = Configure.ConfigFile.conf.Read("Settings", "mpvPath_Text");
                    if (!string.IsNullOrWhiteSpace(mpvPath_Text))
                    {
                        VM.ConfigureView.mpvPath_Text = mpvPath_Text;
                    }

                    // mpv Config Path
                    string mpvConfigPath_Text = Configure.ConfigFile.conf.Read("Settings", "mpvConfigPath_Text");
                    if (!string.IsNullOrWhiteSpace(mpvConfigPath_Text))
                    {
                        VM.ConfigureView.mpvConfigPath_Text = mpvConfigPath_Text;
                    }

                    // Presets Path
                    string presetsPath_Text = Configure.ConfigFile.conf.Read("Settings", "PresetsPath_Text");
                    if (!string.IsNullOrWhiteSpace(presetsPath_Text))
                    {
                        VM.ConfigureView.PresetsPath_Text = presetsPath_Text;
                    }

                    // Theme
                    string theme_SelectedItem = Configure.ConfigFile.conf.Read("Settings", "Theme_SelectedItem");
                    if (!string.IsNullOrWhiteSpace(theme_SelectedItem))
                    {
                        VM.ConfigureView.Theme_SelectedItem = theme_SelectedItem;
                    }

                    // Updates
                    bool updateAutoCheck_IsChecked;
                    bool.TryParse(Configure.ConfigFile.conf.Read("Settings", "UpdateAutoCheck_IsChecked").ToLower(), out updateAutoCheck_IsChecked);
                    VM.ConfigureView.UpdateAutoCheck_IsChecked = updateAutoCheck_IsChecked;
                }),
            };

            // -------------------------
            // Read glow.conf
            // -------------------------
            if (File.Exists(glowConfFile))
            {
                Configure.ReadGlowConf(glowConfDir,  // Directory: %AppData%\Glow\
                                       "glow.conf",  // Filename
                                       actionsToRead // Actions to read
                                      );
            }

            // -------------------------
            // Window Position Center
            // -------------------------
            if ((this.Top.ToString() == "NaN" && this.Left.ToString() == "NaN") ||
                (this.Top == 0 && this.Top == 0)
               )
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            // -------------------------
            // Theme
            // -------------------------
            //SetTheme();
            try
            {
                // Default
                if (string.IsNullOrEmpty(VM.ConfigureView.Theme_SelectedItem/*Configure.theme*/))
                {
                    VM.ConfigureView.Theme_SelectedItem = "Glow";
                }

                // Load selected theme from glow.conf
                else
                {
                    App.Current.Resources.MergedDictionaries.Clear();
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = new Uri("Themes/" + "Theme" + VM.ConfigureView.Theme_SelectedItem/*Configure.theme*/ + ".xaml", UriKind.RelativeOrAbsolute)
                    });
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///    Window Loaded
        /// </summary>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;

            // -------------------------
            // Check for Available Updates
            // -------------------------
            Task.Factory.StartNew(() =>
            {
                UpdateAvailableCheck();
            });

            // -------------------------
            // Load Text Color Previews 
            // -------------------------
            PreviewOSD_FontColor(this);
            PreviewOSDBorderColor(this);
            PreviewOSDShadowColor(this);
            PreviewFontColor(this);
            PreviewBorderColor(this);
            PreviewShadowColor(this);

            // -------------------------
            // glow.conf initialize
            // Create a default config file to be populated
            // -------------------------
            // Create only if file does not already exist
            //if (!File.Exists(glowConfFile))
            //{
            //    // glow.conf actions to write
            //    List<Action> actionsToWrite = new List<Action>
            //    {
            //        new Action(() =>
            //        {
            //            // -------------------------
            //            // Main Window
            //            // -------------------------
            //            // Window Position Top
            //            Configure.ConfigFile.conf.Write("Main Window", "Window_Position_Top", this.Top.ToString());
            //            // Window Position Left
            //            Configure.ConfigFile.conf.Write("Main Window", "Window_Position_Left", this.Left.ToString());
            //            // Window Width
            //            Configure.ConfigFile.conf.Write("Main Window", "Window_Width", this.Width.ToString());
            //            // Window Height
            //            Configure.ConfigFile.conf.Write("Main Window", "Window_Height", this.Height.ToString());
            //            // Window Maximized
            //            Configure.ConfigFile.conf.Write("Main Window", "WindowState_Maximized", "false");

            //            // -------------------------
            //            // Settings
            //            // -------------------------
            //            // mpv Path
            //            Configure.ConfigFile.conf.Write("Settings", "mpvPath_Text", VM.ConfigureView.mpvPath_Text);
            //            // mpv Config Path
            //            Configure.ConfigFile.conf.Write("Settings", "mpvConfigPath_Text", VM.ConfigureView.mpvConfigPath_Text);
            //            // Presets Path
            //            Configure.ConfigFile.conf.Write("Settings", "PresetsPath_Text", VM.ConfigureView.PresetsPath_Text);
            //            // Theme
            //            Configure.ConfigFile.conf.Write("Settings", "Theme_SelectedItem", VM.ConfigureView.Theme_SelectedItem);
            //            // Updates
            //            Configure.ConfigFile.conf.Write("Settings", "UpdateAutoCheck_IsChecked", VM.ConfigureView.UpdateAutoCheck_IsChecked.ToString().ToLower());
            //        }),
            //    };

            //    // -------------------------
            //    // Save glow.conf
            //    // -------------------------
            //    Configure.WriteGlowConf(glowConfDir,   // Directory: %AppData%\Glow\
            //                            "glow.conf",   // Filename
            //                            actionsToWrite // Actions to write
            //                           );
            //}
        }


        /// <summary>
        /// Window Closing
        /// </summary>
        void Window_Closing(object sender, CancelEventArgs e)
        {
            // -------------------------
            // Export glow.conf
            // -------------------------
            try
            {
                // -------------------------
                // Create Glow folder if missing
                // -------------------------
                if (!Directory.Exists(glowConfDir))
                {
                    Directory.CreateDirectory(glowConfDir);
                }

                // -------------------------
                // Save Config
                // -------------------------
                SaveConfOnExit(glowConfDir);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString(),
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }

            // Exit
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Export Write Config (Method)
        /// </summary>
        public void SaveConfOnExit(string path)
        {
            // -------------------------
            // Save glow.conf
            // -------------------------
            Configure.ConfigFile conf = null;

            try
            {
                conf = new Configure.ConfigFile(glowConfFile);

                // -------------------------
                // Window
                // -------------------------
                // Window
                double top;
                double.TryParse(conf.Read("Main Window", "Window_Position_Top"), out top);
                double left;
                double.TryParse(conf.Read("Main Window", "Window_Position_Left"), out left);
                double width;
                double.TryParse(conf.Read("Main Window", "Window_Width"), out width);
                double height;
                double.TryParse(conf.Read("Main Window", "Window_Height"), out height);

                // -------------------------
                // Settings
                // -------------------------
                // Updates
                bool settings_UpdateAutoCheck_IsChecked = true;
                bool.TryParse(conf.Read("Settings", "UpdateAutoCheck_IsChecked").ToLower(), out settings_UpdateAutoCheck_IsChecked);

                // -------------------------
                // Save only if changes have been made
                // -------------------------
                if (// Main Window
                    this.Top != top ||
                    this.Left != left ||
                    this.Width != width ||
                    this.Height != height ||

                    VM.ConfigureView.mpvPath_Text != conf.Read("Settings", "mpvPath_Text") ||
                    VM.ConfigureView.mpvConfigPath_Text != conf.Read("Settings", "mpvConfigPath_Text") ||
                    VM.ConfigureView.PresetsPath_Text != conf.Read("Settings", "PresetsPath_Text") ||
                    VM.ConfigureView.Theme_SelectedItem != conf.Read("Settings", "Theme_SelectedItem") ||
                    VM.ConfigureView.UpdateAutoCheck_IsChecked != settings_UpdateAutoCheck_IsChecked
                    )
                {
                    // -------------------------
                    // glow.conf actions to write
                    // -------------------------
                    List<Action> actionsToWrite = new List<Action>
                    {
                        // -------------------------
                        // Main Window
                        // -------------------------
                        new Action(() =>
                        {
                            // -------------------------
                            // Main Window
                            // -------------------------
                            // Window Position Top
                            Configure.ConfigFile.conf.Write("Main Window", "Window_Position_Top", this.Top.ToString());
                            // Window Position Left
                            Configure.ConfigFile.conf.Write("Main Window", "Window_Position_Left", this.Left.ToString());
                            // Window Width
                            Configure.ConfigFile.conf.Write("Main Window", "Window_Width", this.Width.ToString());
                            // Window Height
                            Configure.ConfigFile.conf.Write("Main Window", "Window_Height", this.Height.ToString());
                            // Window Maximized
                            if (this.WindowState == WindowState.Maximized)
                            {
                                Configure.ConfigFile.conf.Write("Main Window", "WindowState_Maximized", "true");
                            }
                            else
                            {
                                Configure.ConfigFile.conf.Write("Main Window", "WindowState_Maximized", "false");
                            }

                            // -------------------------
                            // Settings
                            // -------------------------
                            // mpv Path
                            Configure.ConfigFile.conf.Write("Settings", "mpvPath_Text", VM.ConfigureView.mpvPath_Text);

                            // mpv Config Path
                            Configure.ConfigFile.conf.Write("Settings", "mpvConfigPath_Text", VM.ConfigureView.mpvConfigPath_Text);

                            // Presets Path
                            Configure.ConfigFile.conf.Write("Settings", "PresetsPath_Text", VM.ConfigureView.PresetsPath_Text);

                            // Theme
                            Configure.ConfigFile.conf.Write("Settings", "Theme_SelectedItem", VM.ConfigureView.Theme_SelectedItem);

                            // Update Auto-Check
                            Configure.ConfigFile.conf.Write("Settings", "UpdateAutoCheck_IsChecked", VM.ConfigureView.UpdateAutoCheck_IsChecked.ToString().ToLower());
                        }),

                        //new Action(() => { ; }),
                    };

                    // -------------------------
                    // Save Config
                    // -------------------------
                    Configure.WriteGlowConf(glowConfDir,   // Directory: %AppData%\Glow\
                                            "glow.conf",   // Filename
                                            actionsToWrite // Actions to write
                                           );

                    //MessageBox.Show("Saved"); //debug
                }
            }
            catch
            {
                MessageBox.Show("Could not read glow.conf on exit.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }


        /// <summary>
        ///     Check For Internet Connection
        /// </summary>
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckForInternetConnection()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        /// <summary>
        ///    Update Available Check
        /// </summary>
        public void UpdateAvailableCheck()
        {
            if (CheckForInternetConnection() == true)
            {
                if (VM.ConfigureView.UpdateAutoCheck_IsChecked == true)
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    WebClient wc = new WebClient();
                    // UserAgent Header
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Glow ~ mpv Configurator (https://github.com/MattMcManis/Glow)" + " v" + MainWindow.currentVersion + "-" + MainWindow.currentBuildPhase + " Self-Update");
                    //wc.Headers.Add("Accept-Encoding", "gzip,deflate"); //error

                    wc.Proxy = null;

                    // -------------------------
                    // Parse GitHub .version file
                    // -------------------------
                    string parseLatestVersion = string.Empty;

                    try
                    {
                        parseLatestVersion = wc.DownloadString("https://raw.githubusercontent.com/MattMcManis/Glow/master/.version");
                    }
                    catch
                    {
                        return;
                    }

                    // -------------------------
                    // Split Version & Build Phase by dash
                    // -------------------------
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
                            return;
                        }

                        // Check if Stellar is the Latest Version
                        // Update Available
                        if (latestVersion > currentVersion)
                        {
                            //updateAvailable = " ~ Update Available: " + "(" + Convert.ToString(latestVersion) + "-" + latestBuildPhase + ")";

                            Dispatcher.Invoke(new Action(delegate
                            {
                                TitleVersion = "Glow ~ mpv Configurator (" + Convert.ToString(currentVersion) + "-" + currentBuildPhase + ")"
                                            + " ~ Update Available: " + "(" + Convert.ToString(latestVersion) + "-" + latestBuildPhase + ")";
                            }));
                        }
                        // Update Not Available
                        else if (latestVersion <= currentVersion)
                        {
                            return;
                        }
                    }
                }
            }

            // Internet Connection Failed
            else
            {
                MessageBox.Show("Could not detect Internet Connection.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                return;
            }
        }


        /// <summary>
        ///    Is Valid Windows Path
        /// </summary>
        /// <remarks>
        ///     Check for Invalid Characters
        /// </remarks>
        public static bool IsValidPath(string path)
        {
            if (!string.IsNullOrEmpty(path) &&
                !string.IsNullOrWhiteSpace(path))
            {
                // Not Valid
                string invalidChars = new string(Path.GetInvalidPathChars());
                Regex regex = new Regex("[" + Regex.Escape(invalidChars) + "]");

                if (regex.IsMatch(path)) { return false; };
            }

            // Empty
            else
            {
                return false;
            }

            // Is Valid
            return true;
        }


        /// <summary>
        /// Folder Write Access Check (Method)
        /// </summary>
        public static bool hasWriteAccessToFolder(string path)
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }


        /// <summary>
        ///    File Renamer (Method)
        /// </summary>
        public static String SaveFileRenamer(string directory, string fileName, string ext)
        {
            string output = Path.Combine(directory, fileName + ext);

            string outputNewFileName = string.Empty;

            int count = 1;

            if (File.Exists(output))
            {
                while (File.Exists(output))
                {
                    outputNewFileName = string.Format("{0}({1})", fileName + " ", count++);
                    output = Path.Combine(directory, outputNewFileName + ext);
                }
            }
            else
            {
                // stay default
                outputNewFileName = fileName;
            }

            return outputNewFileName;
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


        /// <summary>
        /// Allow Only Alpha Numeric
        /// </summary>
        public static void AllowOnlyAlphaNumeric(KeyEventArgs e)
        {
            // Disallow Symbols
            if ((Keyboard.IsKeyDown(Key.LeftShift) && e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (Keyboard.IsKeyDown(Key.RightShift) && e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (Keyboard.IsKeyDown(Key.LeftShift) && e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                (Keyboard.IsKeyDown(Key.RightShift) && e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                )
            {
                e.Handled = true;
            }

            // Allow Numbers, Letters, Ctrl Shortcuts
            else if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||
                e.Key >= Key.A && e.Key <= Key.Z ||
                (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Z) ||
                (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.Z) ||
                (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.A) ||
                (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.A) ||
                (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.X) ||
                (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.X) ||
                (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.C) ||
                (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.C) ||
                (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.V) ||
                (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.V) ||
                e.Key == Key.Delete ||
                e.Key == Key.Back
                )
            {
                e.Handled = false;
            }

            // All other keys
            else
            {
                e.Handled = true;
            }
        }



        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Controls
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

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
        private Boolean IsConfigureWindowOpened = false;
        private void buttonConfigure_Click(object sender, RoutedEventArgs e)
        {
            // Detect which screen we're on
            var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);

            // Start Window
            ConfigureWindow configureWindow = new ConfigureWindow(/*this*//*, vm*/);

            // Keep Window on Top
            configureWindow.Owner = GetWindow(this);

            // Only allow 1 Window instance
            if (IsConfigureWindowOpened) return;
            configureWindow.ContentRendered += delegate { IsConfigureWindowOpened = true; };
            configureWindow.Closed += delegate { IsConfigureWindowOpened = false; };

            // Position Relative to MainWindow
            configureWindow.Left = Math.Max((this.Left + (this.Width - configureWindow.Width) / 2), thisScreen.WorkingArea.Left);
            configureWindow.Top = Math.Max((this.Top + (this.Height - configureWindow.Height) / 2), thisScreen.WorkingArea.Top);

            // Open Window
            configureWindow.ShowDialog();
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
                    MessageBox.Show("GitHub version file not found.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);

                    return;
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
                        MessageBox.Show("Error reading version.",
                                       "Error",
                                       MessageBoxButton.OK,
                                       MessageBoxImage.Error);

                        return;
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
                        MessageBox.Show("This version is up to date.",
                                       "Notice",
                                       MessageBoxButton.OK,
                                       MessageBoxImage.Information);

                        return;
                    }
                    // Unknown
                    else // null
                    {
                        MessageBox.Show("Could not find download. Try updating manually.",
                                        "Error",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);

                        return;
                    }
                }
                // Version is Null
                else
                {
                    MessageBox.Show("GitHub version file returned empty.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);

                    return;

                }
            }
            else
            {
                MessageBox.Show("Could not detect Internet Connection.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

                return;
            }
        }

        /// <summary>
        ///    Open Config Directory
        /// </summary>
        private void buttonConfigDir_Click(object sender, RoutedEventArgs e)
        {
            // Check if Config Directory exists
            // If not, create it
            if (!string.IsNullOrWhiteSpace(VM.ConfigureView.mpvConfigPath_Text)) // Empty check
            {
                if (!Directory.Exists(VM.ConfigureView.mpvConfigPath_Text))
                {
                    // Yes/No Dialog Confirmation
                    //
                    MessageBoxResult resultOpen = MessageBox.Show("Config Folder does not exist. Automatically create it?",
                                                                  "Directory Not Found",
                                                                  MessageBoxButton.YesNo,
                                                                  MessageBoxImage.Information);
                    switch (resultOpen)
                    {
                        // Create
                        case MessageBoxResult.Yes:
                            try
                            {
                                Directory.CreateDirectory(VM.ConfigureView.mpvConfigPath_Text);
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

                // Open Config Directory if it exists
                if (Directory.Exists(VM.ConfigureView.mpvConfigPath_Text))
                {
                    Process.Start("explorer.exe", VM.ConfigureView.mpvConfigPath_Text);
                }
            }
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
            // Check if Config Directory exists
            bool exists = Directory.Exists(VM.ConfigureView.mpvConfigPath_Text);
            // If not, create it
            if (!exists)
            {
                // Yes/No Dialog Confirmation
                //
                MessageBoxResult resultSave = MessageBox.Show(
                    "Config Folder does not exist. Automatically create it?",
                    "Directory Not Found",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);
                switch (resultSave)
                {
                    // Create
                    case MessageBoxResult.Yes:
                        try
                        {
                            Directory.CreateDirectory(VM.ConfigureView.mpvConfigPath_Text);
                        }
                        catch
                        {
                            MessageBox.Show(
                                "Could not create Config folder. May require Administrator privileges.",
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

            // Open 'Save File'
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();

            saveFile.InitialDirectory = VM.ConfigureView.mpvConfigPath_Text;
            saveFile.RestoreDirectory = true;
            saveFile.Filter = "Config Files (*.conf)|*.conf";
            saveFile.DefaultExt = "";
            saveFile.FileName = "mpv.conf";

            // Process dialog box
            if (saveFile.ShowDialog() == true)
            {
                // Check for Save Error
                try
                {
                    // Save document
                    File.WriteAllText(saveFile.FileName, ConfigRichTextBox(), Encoding.UTF8);
                }
                catch
                {
                    MessageBox.Show("Problem Saving Config to " + "\"" + VM.ConfigureView.mpvConfigPath_Text + "\"" + ". May require Administrator Privileges.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }


        /// <summary>
        ///     Subtitle Color Picker
        /// </summary>
        private Boolean IsColorPickerWindowOpened = false;

        /// <summary>
        ///     Open Color Picker Window
        /// </summary>
        // Passing the TextBox Keyword will identify which TextBox to return the number to
        public void OpenColorPickerWindow(string textBoxKey)
        {
            // Detect which screen we're on
            var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);

            // Start Window
            ColorPickerWindow colorPickerWindow = new ColorPickerWindow(this, textBoxKey);

            // Keep Window on Top
            colorPickerWindow.Owner = GetWindow(this);

            // Only allow 1 Window instance
            if (IsColorPickerWindowOpened) return;
            colorPickerWindow.ContentRendered += delegate { IsColorPickerWindowOpened = true; };
            colorPickerWindow.Closed += delegate { IsColorPickerWindowOpened = false; };

            // Position Relative to MainWindow
            colorPickerWindow.Left = Math.Max((this.Left + (this.Width - colorPickerWindow.Width) / 2), thisScreen.WorkingArea.Left);
            colorPickerWindow.Top = Math.Max((this.Top + (this.Height - colorPickerWindow.Height) / 2), thisScreen.WorkingArea.Top);

            // Open Window
            colorPickerWindow.ShowDialog();
        }


        /// <summary>
        ///    Preset
        /// </summary>
        private void cboPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presets.Preset(this);

            //MessageBox.Show(vm.Presets_SelectedItem); //deubg
        }

        /// <summary>
        ///    Export Preset
        /// </summary>
        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            // Check if Presets Directory exists
            // If not, create it
            if (!Directory.Exists(VM.ConfigureView.PresetsPath_Text))
            {
                // Yes/No Dialog Confirmation
                //
                MessageBoxResult resultExport = MessageBox.Show("Presets Folder does not exist. Automatically create it?",
                                                                "Directory Not Found",
                                                                MessageBoxButton.YesNo,
                                                                MessageBoxImage.Information);
                switch (resultExport)
                {
                    // Create
                    case MessageBoxResult.Yes:
                        try
                        {
                            Directory.CreateDirectory(VM.ConfigureView.PresetsPath_Text);
                        }
                        catch
                        {
                            MessageBox.Show("Could not create Presets folder. May require Administrator privileges.",
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

            // Open 'Save File'
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();

            // Defaults
            saveFile.InitialDirectory = VM.ConfigureView.PresetsPath_Text;
            saveFile.RestoreDirectory = true;
            saveFile.Filter = "Initialization Files (*.ini)|*.ini";
            saveFile.DefaultExt = "ini";
            saveFile.FileName = "preset.ini";

            // Show save file dialog box
            //Nullable<bool> result = saveFile.ShowDialog();

            // Process dialog box
            if (saveFile.ShowDialog() == true)
            {
                // Set Input Dir, Name, Ext
                string presetDir = Path.GetDirectoryName(saveFile.FileName).TrimEnd('\\') + @"\";
                //string inputFileName = Path.GetFileName(saveFile.FileName);
                string presetFileName = Path.GetFileNameWithoutExtension(saveFile.FileName);
                string presetExt = Path.GetExtension(saveFile.FileName);
                //string preset = presetDir + presetFileName + presetExt;
                string preset = Path.Combine(presetDir, presetFileName + presetExt);

                // Overwriting doesn't work properly with INI Writer
                // Delete File instead before saving new
                if (File.Exists(preset))
                {
                    try
                    {
                        File.Delete(preset);
                    }
                    catch
                    {

                    }
                }

                // Export ini file
                Presets.ExportPreset(this, preset);

                Presets.PresetsReset();

                // Refresh Presets ComboBox
                Presets.LoadCustomPresets();

                //ViewModel vm = this.DataContext as ViewModel;
                //VM.ConfigureView.Preset_ItemsSource = VM.ConfigureView.Presets_Items;
                //cboPreset_ItemsSource = ViewModel._presetsItems;

                // Select the Preset
                VM.MainView.Presets_SelectedItem = presetFileName;
            }
        }

        /// <summary>
        /// Delete Preset - Button
        /// </summary>
        private void btnDeletePreset_Click(object sender, RoutedEventArgs e)
        {
            // -------------------------
            // Set Preset Dir, Name, Ext
            // -------------------------
            string presetsDir = Path.GetDirectoryName(VM.ConfigureView.PresetsPath_Text).TrimEnd('\\') + @"\";
            string presetFileName = Path.GetFileNameWithoutExtension(VM.MainView.Presets_SelectedItem);
            string presetExt = Path.GetExtension(".ini");
            string preset = Path.Combine(presetsDir, presetFileName + presetExt);
            //string preset = presetsDir + presetFileName + presetExt;

            // -------------------------
            // Get Selected Preset Type
            // -------------------------
            //string type = VM.MainView.Presets_Items.FirstOrDefault(item => item.Name == VM.MainView.Presets_SelectedItem)?.Type;

            // -------------------------
            // Delete
            // -------------------------
            if (VM.MainView.Presets_SelectedItem != "Default" &&
                VM.MainView.Presets_SelectedItem != "Ultra" &&
                VM.MainView.Presets_SelectedItem != "High" &&
                VM.MainView.Presets_SelectedItem != "Medium" &&
                VM.MainView.Presets_SelectedItem != "Low"
                )
            {
                // Yes/No Dialog Confirmation
                //
                MessageBoxResult resultExport = MessageBox.Show("Delete " + presetFileName + "?",
                                                                "Delete Confirm",
                                                                MessageBoxButton.YesNo,
                                                                MessageBoxImage.Information);
                switch (resultExport)
                {
                    // Yes
                    case MessageBoxResult.Yes:

                        // Delete
                        if (File.Exists(preset))
                        {
                            try
                            {
                                File.Delete(preset);
                            }
                            catch
                            {
                                MessageBox.Show("Could not delete Custom Preset. May be missing or requires Administrator Privileges.",
                                                "Error",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Error);
                            }

                            // Set the Index
                            //var selectedIndex = VM.MainView.Presets_SelectedIndex;

                            //// Select Default Item
                            //VM.MainView.Presets_SelectedItem = "Default";

                            // Delete from Items Source
                            // (needs to be after SelectedItem change to prevent error reloading)
                            //try
                            //{
                            //    VM.MainView.Presets_Items.RemoveAt(VM.MainView.Presets_SelectedIndex/*selectedIndex*/);
                            //}
                            //catch
                            //{

                            //}

                            // Presets Reset
                            Presets.PresetsReset();

                            // Select Default Item
                            VM.MainView.Presets_SelectedItem = "Default";

                            // Load Custom Presets
                            // Refresh Presets ComboBox
                            Presets.LoadCustomPresets();
                        }
                        else
                        {
                            MessageBox.Show("The Custom Preset does not exist.",
                                            "Notice",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Warning);
                        }

                        break;

                    // No
                    case MessageBoxResult.No:
                        MessageBox.Show("Only Custom Presets can be deleted.",
                                        "Notice",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                        break;
                }
            }

            // -------------------------
            // Not Custom
            // -------------------------
            else
            {
                MessageBox.Show("This is not a Custom Preset.",
                                "Notice",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }


        /// <summary>
        ///    Import Preset
        /// </summary>
        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            // Check if presets directory exists
            // If not, create it
            //Directory.CreateDirectory(presetsDir);

            // Open 'Select File'
            Microsoft.Win32.OpenFileDialog selectFile = new Microsoft.Win32.OpenFileDialog();

            // Defaults
            selectFile.InitialDirectory = VM.ConfigureView.PresetsPath_Text;
            selectFile.RestoreDirectory = true;
            selectFile.Filter = "ini file (*.ini)|*.ini";

            // Process dialog box
            if (selectFile.ShowDialog() == true)
            {
                // Set Input Dir, Name, Ext
                string inputDir = Path.GetDirectoryName(selectFile.FileName).TrimEnd('\\') + @"\";
                string inputFileName = Path.GetFileNameWithoutExtension(selectFile.FileName);
                string inputExt = Path.GetExtension(selectFile.FileName);
                string input = inputDir + inputFileName + inputExt;

                // Import ini file
                Presets.ImportPreset(this, input);
            }
            else
            {
                // Reload Presets ComboBox Custom Presets after any manual changes may have been made
                // such as deleting an .ini through the dialog box
                Presets.LoadCustomPresets();
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
            p.Inlines.Add(new Run(Generate.Generator.Config()));
            rtbConfig.EndChange();
        }
    }

}
