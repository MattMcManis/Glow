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
using Glow;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Text;

namespace ViewModel
{
    public class Configure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string prop)
        {
            //PropertyChangedEventHandler handler = PropertyChanged;
            //handler(this, new PropertyChangedEventArgs(name));

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        ///     View Model Main
        /// </summary>
        public Configure()
        {
            // -------------------------
            // Defaults
            // -------------------------
            mpvPath_Text = string.Empty;
            mpvConfigPath_Text = MainWindow.mpvConfigDir;
            PresetsPath_Text = MainWindow.presetsDir;
            UpdateAutoCheck_IsChecked = true;
            Theme_SelectedItem = "Glow";
        }


        // -------------------------
        // mpv Path
        // -------------------------
        // Text
        private string _mpvPath_Text;
        public string mpvPath_Text
        {
            get { return _mpvPath_Text; }
            set
            {
                if (_mpvPath_Text == value)
                {
                    return;
                }

                _mpvPath_Text = value;
                OnPropertyChanged("mpvPath_Text");
            }
        }

        // Controls Enable
        private bool _mpvPath_IsEnabled = true;
        public bool mpvPath_IsEnabled
        {
            get { return _mpvPath_IsEnabled; }
            set
            {
                if (_mpvPath_IsEnabled == value)
                {
                    return;
                }

                _mpvPath_IsEnabled = value;
                OnPropertyChanged("mpvPath_IsEnabled");
            }
        }


        // -------------------------
        // mpv Config Path
        // -------------------------
        // Text
        private string _mpvConfigPath_Text;
        public string mpvConfigPath_Text
        {
            get { return _mpvConfigPath_Text; }
            set
            {
                if (_mpvConfigPath_Text == value)
                {
                    return;
                }

                _mpvConfigPath_Text = value;
                OnPropertyChanged("mpvConfigPath_Text");
            }
        }

        // Controls Enable
        private bool _mpvConfigPath_IsEnabled = true;
        public bool mpvConfigPath_IsEnabled
        {
            get { return _mpvConfigPath_IsEnabled; }
            set
            {
                if (_mpvConfigPath_IsEnabled == value)
                {
                    return;
                }

                _mpvConfigPath_IsEnabled = value;
                OnPropertyChanged("mpvConfigPath_IsEnabled");
            }
        }


        // -------------------------
        // Presets Path
        // -------------------------
        // Text
        private string _PresetsPath_Text;
        public string PresetsPath_Text
        {
            get { return _PresetsPath_Text; }
            set
            {
                if (_PresetsPath_Text == value)
                {
                    return;
                }

                _PresetsPath_Text = value;
                OnPropertyChanged("PresetsPath_Text");
            }
        }

        // Controls Enable
        private bool _PresetsPath_IsEnabled = true;
        public bool PresetsPath_IsEnabled
        {
            get { return _PresetsPath_IsEnabled; }
            set
            {
                if (_PresetsPath_IsEnabled == value)
                {
                    return;
                }

                _PresetsPath_IsEnabled = value;
                OnPropertyChanged("PresetsPath_IsEnabled");
            }
        }


        // -------------------------
        // Update Auto Check
        // -------------------------
        // Checked
        private bool _UpdateAutoCheck_IsChecked;
        public bool UpdateAutoCheck_IsChecked
        {
            get { return _UpdateAutoCheck_IsChecked; }
            set
            {
                if (_UpdateAutoCheck_IsChecked != value)
                {
                    _UpdateAutoCheck_IsChecked = value;
                    OnPropertyChanged("UpdateAutoCheck_IsChecked");
                }
            }
        }

        // -------------------------
        // Presets Path
        // -------------------------
        // Text
        private string _UpdateAutoCheck_Text;
        public string UpdateAutoCheck_Text
        {
            get { return _UpdateAutoCheck_Text; }
            set
            {
                if (_UpdateAutoCheck_Text == value)
                {
                    return;
                }

                _UpdateAutoCheck_Text = value;
                OnPropertyChanged("UpdateAutoCheck_Text");
            }
        }

        // Controls Enable
        private bool _UpdateAutoCheck_IsEnabled = true;
        public bool UpdateAutoCheck_IsEnabled
        {
            get { return _UpdateAutoCheck_IsEnabled; }
            set
            {
                if (_UpdateAutoCheck_IsEnabled == value)
                {
                    return;
                }

                _UpdateAutoCheck_IsEnabled = value;
                OnPropertyChanged("UpdateAutoCheck_IsEnabled");
            }
        }


        // -------------------------
        // Theme
        // -------------------------
        // Item Source
        private List<string> _Theme_Items = new List<string>()
        {
            "Glow",
            "System"
        };
        public List<string> Theme_Items
        {
            get { return _Theme_Items; }
            set
            {
                _Theme_Items = value;
                OnPropertyChanged("Theme_Items");
            }
        }

        // Selected Item
        private string _Theme_SelectedItem { get; set; }
        public string Theme_SelectedItem
        {
            get { return _Theme_SelectedItem; }
            set
            {
                if (_Theme_SelectedItem == value)
                {
                    return;
                }

                _Theme_SelectedItem = value;
                OnPropertyChanged("Theme_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Theme_IsEnabled = true;
        public bool Theme_IsEnabled
        {
            get { return _Theme_IsEnabled; }
            set
            {
                if (_Theme_IsEnabled == value)
                {
                    return;
                }

                _Theme_IsEnabled = value;
                OnPropertyChanged("Theme_IsEnabled");
            }
        }


    }
}
