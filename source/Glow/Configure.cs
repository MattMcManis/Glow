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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Runtime.InteropServices;
using System.Text;
using ViewModel;

namespace Glow
{
    public class Configure
    {
        public static string theme;

        /// <summary>
        /// Config File Reader
        /// </summary>
        /// License MIT
        // https://code.msdn.microsoft.com/windowsdesktop/Reading-and-Writing-Values-85084b6a
        public partial class ConfigFile
        {
            public static ConfigFile cfg;
            public static ConfigFile conf;

            public string path { get; private set; }


            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(string section, string key,
            string defaultValue, StringBuilder value, int size, string filePath);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            static extern int GetPrivateProfileString(string section, string key, string defaultValue,
                [In, Out] char[] value, int size, string filePath);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern int GetPrivateProfileSection(string section, IntPtr keyValue,
            int size, string filePath);

            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool WritePrivateProfileString(string section, string key,
                string value, string filePath);

            public static int capacity = 512;

            public ConfigFile(string configPath)
            {
                path = configPath;
            }

            public bool Write(string section, string key, string value)
            {
                bool result = WritePrivateProfileString(section, key, value, path);
                return result;
            }

            public string Read(string section, string key)
            {
                var value = new StringBuilder(capacity);
                GetPrivateProfileString(section, key, string.Empty, value, value.Capacity, path);
                return value.ToString();
            }
        }


        /// <summary>
        /// Read glow.conf file
        /// </summary>
        public static void ReadGlowConf(string directory,
                                        string filename,
                                        List<Action> actionsToRead)
        {
            // Failed Imports
            List<string> listFailedImports = new List<string>();

            // -------------------------
            // Start Cofig File Read
            // -------------------------
            //ConfigFile conf = null;

            try
            {
                // Check if glow.conf file exists in %AppData%\Glow\
                if (File.Exists(Path.Combine(directory, filename)))
                {
                    ConfigFile.conf = new ConfigFile(Path.Combine(directory, filename));

                    //MessageBox.Show(MainWindow.glowConfFile); //debug

                    // Write each action in the list
                    foreach (Action Read in actionsToRead)
                    {
                        Read();
                    }
                }
            }

            // Error Loading glow.conf
            //
            catch
            {
                // Check if glow.conf has a valid path
                if (MainWindow.IsValidPath(MainWindow.glowConfFile) == false)
                {
                    return;
                }

                // Delete glow.conf and Restart
                // Check if glow.conf Exists
                if (File.Exists(MainWindow.glowConfFile))
                {
                    // Yes/No Dialog Confirmation
                    //
                    MessageBoxResult result = MessageBox.Show(
                        "Could not load glow.conf. \n\nDelete config and reload defaults?",
                        "Error",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error);
                    switch (result)
                    {
                        // Create
                        case MessageBoxResult.Yes:
                            File.Delete(MainWindow.glowConfFile);

                            // Reload Control Defaults
                            // 

                            // Restart Program
                            Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                            break;

                        // Use Default
                        case MessageBoxResult.No:
                            // Force Shutdown
                            //System.Windows.Forms.Application.ExitThread();
                            //Environment.Exit(0);
                            Application.Current.Shutdown();
                            return;
                    }
                }
                // If glow.conf Not Found
                else
                {
                    MessageBox.Show("No previous glow.conf file found.",
                                    "Notice",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    return;
                }
            }
        }


        /// <summary>
        /// Write glow.conf
        /// </summary>
        public static void WriteGlowConf(string directory,
                                         string filename,
                                         List<Action> actionsToWrite
                                         )
        {
            // -------------------------
            // Check if Directory Exists
            // -------------------------
            if (!Directory.Exists(directory))
            {
                try
                {
                    // Create Config Directory
                    Directory.CreateDirectory(directory);
                }
                catch
                {
                    MessageBox.Show("Could not create config folder " + directory + ".\n\nMay require Administrator privileges.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }

            // -------------------------
            // Save glow.conf file
            // -------------------------
            if (Directory.Exists(directory))
            {
                //MessageBox.Show(path); //debug

                // Access
                if (MainWindow.hasWriteAccessToFolder(directory) == true)
                {
                    //ConfigFile conf = null;

                    try
                    {
                        // Start glow.conf File Write
                        Configure.ConfigFile.conf = new ConfigFile(Path.Combine(directory, filename));

                        // Write each action in the list
                        foreach (Action Write in actionsToWrite)
                        {
                            Write();
                        }
                    }
                    // Error
                    catch
                    {
                        MessageBox.Show("Could not save " + filename + " to " + directory/*MainWindow.glowConfDir*//*path*/,
                                        "Error",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }
                }
                // Denied
                else
                {
                    MessageBox.Show("User does not have write access to " + directory/*MainWindow.glowConfDir*/,
                                    "Notice",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }


    }
}
