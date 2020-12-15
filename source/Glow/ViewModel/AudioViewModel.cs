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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Text;

namespace ViewModel
{
    public class Audio : INotifyPropertyChanged
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
        public Audio()
        {
            // -------------------------
            // Defaults
            // -------------------------
            AudioDriver_SelectedItem = "default";
            AudioLoadFiles_SelectedItem = "default";
            Channels_SelectedItem = "default";
            Volume_Value = 0;
            VolumeMax_Value = 0;
            Normalize_SelectedItem = "default";
            ScaleTempo_SelectedItem = "default";
        }


        // ----------------------------------------------------------------------------------------------------
        // Audio
        // ----------------------------------------------------------------------------------------------------

        // -------------------------
        // Audio Driver
        // -------------------------
        // Item Source
        private List<string> _AudioDriver_Items = new List<string>()
        {
            "default",
            "wasapi",
            "oss",
            "jack",
            "openal",
            "pulse",
            "sdl",
            "pcm",
            "rsound",
            "null",
        };
        public List<string> AudioDriver_Items
        {
            get { return _AudioDriver_Items; }
            set
            {
                _AudioDriver_Items = value;
                OnPropertyChanged("AudioDriver_Items");
            }
        }

        // Selected Item
        private string _AudioDriver_SelectedItem { get; set; }
        public string AudioDriver_SelectedItem
        {
            get { return _AudioDriver_SelectedItem; }
            set
            {
                if (_AudioDriver_SelectedItem == value)
                {
                    return;
                }

                _AudioDriver_SelectedItem = value;
                OnPropertyChanged("AudioDriver_SelectedItem");
            }
        }

        // Controls Enable
        private bool _AudioDriver_IsEnabled = true;
        public bool AudioDriver_IsEnabled
        {
            get { return _AudioDriver_IsEnabled; }
            set
            {
                if (_AudioDriver_IsEnabled == value)
                {
                    return;
                }

                _AudioDriver_IsEnabled = value;
                OnPropertyChanged("AudioDriver_IsEnabled");
            }
        }


        // -------------------------
        // Audio Load Files
        // -------------------------
        // Item Source
        private List<string> _AudioLoadFiles_Items = new List<string>()
        {
            "default",
            "no",
            "exact",
            "fuzzy",
            "all",
        };
        public List<string> AudioLoadFiles_Items
        {
            get { return _AudioLoadFiles_Items; }
            set
            {
                _AudioLoadFiles_Items = value;
                OnPropertyChanged("AudioLoadFiles_Items");
            }
        }

        // Selected Item
        private string _AudioLoadFiles_SelectedItem { get; set; }
        public string AudioLoadFiles_SelectedItem
        {
            get { return _AudioLoadFiles_SelectedItem; }
            set
            {
                if (_AudioLoadFiles_SelectedItem == value)
                {
                    return;
                }

                _AudioLoadFiles_SelectedItem = value;
                OnPropertyChanged("AudioLoadFiles_SelectedItem");
            }
        }

        // Controls Enable
        private bool _AudioLoadFiles_IsEnabled = true;
        public bool AudioLoadFiles_IsEnabled
        {
            get { return _AudioLoadFiles_IsEnabled; }
            set
            {
                if (_AudioLoadFiles_IsEnabled == value)
                {
                    return;
                }

                _AudioLoadFiles_IsEnabled = value;
                OnPropertyChanged("AudioLoadFiles_IsEnabled");
            }
        }


        // -------------------------
        // Channels
        // -------------------------
        // Item Source
        private List<string> _Channels_Items = new List<string>()
        {
            "default",
            "auto-safe",
            "auto",
            "stereo",
            "5.1",
            "7.1",
        };
        public List<string> Channels_Items
        {
            get { return _Channels_Items; }
            set
            {
                _Channels_Items = value;
                OnPropertyChanged("Channels_Items");
            }
        }

        // Selected Item
        private string _Channels_SelectedItem { get; set; }
        public string Channels_SelectedItem
        {
            get { return _Channels_SelectedItem; }
            set
            {
                if (_Channels_SelectedItem == value)
                {
                    return;
                }

                _Channels_SelectedItem = value;
                OnPropertyChanged("Channels_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Channels_IsEnabled = true;
        public bool Channels_IsEnabled
        {
            get { return _Channels_IsEnabled; }
            set
            {
                if (_Channels_IsEnabled == value)
                {
                    return;
                }

                _Channels_IsEnabled = value;
                OnPropertyChanged("Channels_IsEnabled");
            }
        }


        // -------------------------
        // Volume
        // -------------------------
        // Value
        private double _Volume_Value = 0;
        public double Volume_Value
        {
            get { return _Volume_Value; }
            set
            {
                if (_Volume_Value == value)
                {
                    return;
                }

                _Volume_Value = value;
                OnPropertyChanged("Volume_Value");
            }
        }

        // Text
        private string _Volume_Text;
        public string Volume_Text
        {
            get { return _Volume_Text; }
            set
            {
                if (_Volume_Text == value)
                {
                    return;
                }

                _Volume_Text = value;
                OnPropertyChanged("Volume_Text");
            }
        }

        // Controls Enable
        private bool _Volume_IsEnabled = true;
        public bool Volume_IsEnabled
        {
            get { return _Volume_IsEnabled; }
            set
            {
                if (_Volume_IsEnabled == value)
                {
                    return;
                }

                _Volume_IsEnabled = value;
                OnPropertyChanged("Volume_IsEnabled");
            }
        }


        // -------------------------
        // Volume Max
        // -------------------------
        // Value
        private double _VolumeMax_Value = 0;
        public double VolumeMax_Value
        {
            get { return _VolumeMax_Value; }
            set
            {
                if (_VolumeMax_Value == value)
                {
                    return;
                }

                _VolumeMax_Value = value;
                OnPropertyChanged("VolumeMax_Value");
            }
        }

        // Text
        private string _VolumeMax_Text;
        public string VolumeMax_Text
        {
            get { return _VolumeMax_Text; }
            set
            {
                if (_VolumeMax_Text == value)
                {
                    return;
                }

                _VolumeMax_Text = value;
                OnPropertyChanged("VolumeMax_Text");
            }
        }

        // Controls Enable
        private bool _VolumeMax_IsEnabled = true;
        public bool VolumeMax_IsEnabled
        {
            get { return _VolumeMax_IsEnabled; }
            set
            {
                if (_VolumeMax_IsEnabled == value)
                {
                    return;
                }

                _VolumeMax_IsEnabled = value;
                OnPropertyChanged("VolumeMax_IsEnabled");
            }
        }


        // -------------------------
        // Normalize
        // -------------------------
        // Item Source
        private List<string> _Normalize_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Normalize_Items
        {
            get { return _Normalize_Items; }
            set
            {
                _Normalize_Items = value;
                OnPropertyChanged("Normalize_Items");
            }
        }

        // Selected Item
        private string _Normalize_SelectedItem { get; set; }
        public string Normalize_SelectedItem
        {
            get { return _Normalize_SelectedItem; }
            set
            {
                if (_Normalize_SelectedItem == value)
                {
                    return;
                }

                _Normalize_SelectedItem = value;
                OnPropertyChanged("Normalize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Normalize_IsEnabled = true;
        public bool Normalize_IsEnabled
        {
            get { return _Normalize_IsEnabled; }
            set
            {
                if (_Normalize_IsEnabled == value)
                {
                    return;
                }

                _Normalize_IsEnabled = value;
                OnPropertyChanged("Normalize_IsEnabled");
            }
        }


        // -------------------------
        // Scale Tempo
        // -------------------------
        // Item Source
        private List<string> _ScaleTempo_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> ScaleTempo_Items
        {
            get { return _ScaleTempo_Items; }
            set
            {
                _ScaleTempo_Items = value;
                OnPropertyChanged("ScaleTempo_Items");
            }
        }

        // Selected Item
        private string _ScaleTempo_SelectedItem { get; set; }
        public string ScaleTempo_SelectedItem
        {
            get { return _ScaleTempo_SelectedItem; }
            set
            {
                if (_ScaleTempo_SelectedItem == value)
                {
                    return;
                }

                _ScaleTempo_SelectedItem = value;
                OnPropertyChanged("ScaleTempo_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ScaleTempo_IsEnabled = true;
        public bool ScaleTempo_IsEnabled
        {
            get { return _ScaleTempo_IsEnabled; }
            set
            {
                if (_ScaleTempo_IsEnabled == value)
                {
                    return;
                }

                _ScaleTempo_IsEnabled = value;
                OnPropertyChanged("ScaleTempo_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Language Priority ListView
        // --------------------------------------------------
        //public static ObservableCollection<string> LanguagePriority_LoadDefaults()
        //{
        //    ObservableCollection<string> items = new ObservableCollection<string>(MainWindow.LanguagePriority_Defaults);

        //    return items;
        //}

        // Items Source
        private ObservableCollection<string> _LanguagePriority_ListView_Items = new ObservableCollection<string>(ViewModel.Main.listLanguages);//LanguagePriority_LoadDefaults();
        public ObservableCollection<string> LanguagePriority_ListView_Items
        {
            get { return _LanguagePriority_ListView_Items; }
            set
            {
                _LanguagePriority_ListView_Items = value;
                OnPropertyChanged("LanguagePriority_ListView_Items");
            }
        }
        // Selected Items
        private List<string> _LanguagePriority_ListView_SelectedItems = new List<string>();
        public List<string> LanguagePriority_ListView_SelectedItems
        {
            get { return _LanguagePriority_ListView_SelectedItems; }
            set
            {
                _LanguagePriority_ListView_SelectedItems = value;
                OnPropertyChanged("LanguagePriority_ListView_SelectedItems");
            }
        }
        // Selected Index
        private int _LanguagePriority_ListView_SelectedIndex { get; set; }
        public int LanguagePriority_ListView_SelectedIndex
        {
            get { return _LanguagePriority_ListView_SelectedIndex; }
            set
            {
                if (_LanguagePriority_ListView_SelectedIndex == value)
                {
                    return;
                }

                _LanguagePriority_ListView_SelectedIndex = value;
                OnPropertyChanged("LanguagePriority_ListView_SelectedIndex");
            }
        }
        private double _LanguagePriority_ListView_Opacity { get; set; }
        public double LanguagePriority_ListView_Opacity
        {
            get { return _LanguagePriority_ListView_Opacity; }
            set
            {
                if (_LanguagePriority_ListView_Opacity == value)
                {
                    return;
                }

                _LanguagePriority_ListView_Opacity = value;
                OnPropertyChanged("LanguagePriority_ListView_Opacity");
            }
        }
        // Controls Enable
        public bool _LanguagePriority_ListView_IsEnabled = true;
        public bool LanguagePriority_ListView_IsEnabled
        {
            get { return _LanguagePriority_ListView_IsEnabled; }
            set
            {
                if (_LanguagePriority_ListView_IsEnabled == value)
                {
                    return;
                }

                _LanguagePriority_ListView_IsEnabled = value;
                OnPropertyChanged("LanguagePriority_ListView_IsEnabled");
            }
        }

    }
}
