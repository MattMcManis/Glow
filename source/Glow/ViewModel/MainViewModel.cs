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
using System.Windows;

namespace ViewModel
{
    public class Main : INotifyPropertyChanged
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
        ///     Main Model Main
        /// </summary>
        public Main()
        {
            // -------------------------
            // Defaults
            // -------------------------
            Window_Width = 712;
            Window_Height = 400;

            Presets_Items = new ObservableCollection<string>(Main.presets_Default_Items);
            Presets_SelectedItem = "Default";
        }


        // -------------------------
        // Window Top
        // -------------------------
        // Value
        private double _Window_Position_Top = 0;
        public double Window_Position_Top
        {
            get { return _Window_Position_Top; }
            set
            {
                if (_Window_Position_Top == value)
                {
                    return;
                }

                _Window_Position_Top = value;
                OnPropertyChanged("Window_Position_Top");
            }
        }

        // -------------------------
        // Window Left
        // -------------------------
        private double _Window_Position_Left = 0;
        public double Window_Position_Left
        {
            get { return _Window_Position_Left; }
            set
            {
                if (_Window_Position_Left == value)
                {
                    return;
                }

                _Window_Position_Left = value;
                OnPropertyChanged("Window_Position_Left");
            }
        }

        // -------------------------
        // Window Width
        // -------------------------
        // Value
        private double _Window_Width;
        public double Window_Width
        {
            get { return _Window_Width; }
            set
            {
                if (_Window_Width == value)
                {
                    return;
                }

                _Window_Width = value;
                OnPropertyChanged("Window_Width");
            }
        }

        // -------------------------
        // Window Height
        // -------------------------
        // Value
        private double _Window_Height;
        public double Window_Height
        {
            get { return _Window_Height; }
            set
            {
                if (_Window_Height == value)
                {
                    return;
                }

                _Window_Height = value;
                OnPropertyChanged("Window_Height");
            }
        }

        // -------------------------
        // Window Maximized
        // -------------------------
        // Value
        private bool _Window_IsMaximized = true;
        public bool Window_IsMaximized
        {
            get { return _Window_IsMaximized; }
            set
            {
                if (_Window_IsMaximized == value)
                {
                    return;
                }

                _Window_IsMaximized = value;
                OnPropertyChanged("Window_IsMaximized");
            }
        }


        // -------------------------
        // Window State
        // -------------------------
        // Value
        private WindowState _Window_State = WindowState.Normal;
        public WindowState Window_State
        {
            get { return _Window_State; }
            set
            {
                if (_Window_State == value)
                {
                    return;
                }

                _Window_State = value;
                OnPropertyChanged("Window_State");
            }
        }


        // -------------------------
        // Window Title
        // -------------------------
        // Text
        private string _TitleVersion;
        public string TitleVersion
        {
            get { return _TitleVersion; }
            set
            {
                if (value != _TitleVersion)
                {
                    _TitleVersion = value;
                    OnPropertyChanged("TitleVersion");
                }
            }
        }


        // -------------------------
        // Fonts
        // -------------------------
        private static List<string> _Fonts_Items = new List<string>();
        public InstalledFontCollection installedFonts = new InstalledFontCollection();
        public List<string> Fonts_Items
        {
            get { return _Fonts_Items; }
            set
            {
                _Fonts_Items = value;
                OnPropertyChanged("Fonts_Items");
            }
        }

        public static string Fonts_SelectedItem { get; set; }


        // --------------------------------------------------
        // Info
        // --------------------------------------------------
        // Text
        private string _Info_Text = string.Empty;
        public string Info_Text
        {
            get { return _Info_Text; }
            set
            {
                if (_Info_Text == value)
                {
                    return;
                }

                _Info_Text = value;
                OnPropertyChanged("Info_Text");
            }
        }

        // -------------------------
        // Presets
        // -------------------------
        // Item Source
        public static List<string> presets_Default_Items = new List<string>()
        {
            "Default",
            "Ultra",
            "High",
            "Medium",
            "Low",
            // Debug
        };

        // Item Source
        public ObservableCollection<string> _Presets_Items = new ObservableCollection<string>();

        public ObservableCollection<string> Presets_Items
        {
            get { return _Presets_Items; }
            set
            {
                _Presets_Items = value;
                OnPropertyChanged("Presets_Items");
            }
        }

        // Selected Index
        private int _Presets_SelectedIndex { get; set; }
        public int Presets_SelectedIndex
        {
            get { return _Presets_SelectedIndex; }
            set
            {
                if (_Presets_SelectedIndex == value)
                {
                    return;
                }

                _Presets_SelectedIndex = value;
                OnPropertyChanged("Preset_SelectedIndex");
            }
        }

        // Selected Item
        private string _Presets_SelectedItem { get; set; }
        public string Presets_SelectedItem
        {
            get { return _Presets_SelectedItem; }
            set
            {
                if (_Presets_SelectedItem == value)
                {
                    return;
                }

                _Presets_SelectedItem = value;
                OnPropertyChanged("Presets_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Presets_IsEnabled = true;
        public bool Presets_IsEnabled
        {
            get { return _Presets_IsEnabled; }
            set
            {
                if (_Presets_IsEnabled == value)
                {
                    return;
                }

                _Presets_IsEnabled = value;
                OnPropertyChanged("Presets_IsEnabled");
            }
        }



        // -------------------------
        // Custom Presets
        // -------------------------
        //// Item Source
        //public static List<string> _Presets_Items = new List<string>();
        //public List<string> Presets_Items
        //{
        //    get { return _Presets_Items; }
        //    set
        //    {
        //        _Presets_Items = value;
        //        OnPropertyChanged("Presets_Items");
        //    }
        //}

        //// Selected Item
        //private string _Presets_SelectedItem { get; set; }
        //public string Presets_SelectedItem
        //{
        //    get { return _Presets_SelectedItem; }
        //    set
        //    {
        //        if (_Presets_SelectedItem == value)
        //        {
        //            return;
        //        }

        //        _Presets_SelectedItem = value;
        //        OnPropertyChanged("Presets_SelectedItem");
        //    }
        //}

        //// Controls Enable
        //private bool _Presets_IsEnabled = true;
        //public bool Presets_IsEnabled
        //{
        //    get { return _Presets_IsEnabled; }
        //    set
        //    {
        //        if (_Presets_IsEnabled == value)
        //        {
        //            return;
        //        }

        //        _Presets_IsEnabled = value;
        //        OnPropertyChanged("Presets_IsEnabled");
        //    }
        //}


        // -------------------------
        // Languages
        // -------------------------
        public static List<string> listLanguages = new List<string>()
        {
            "English",
            "Arabic",
            "Bengali",
            "Chinese",
            "Dutch",
            "Finnish",
            "French",
            "German",
            "Hindi",
            "Italian",
            "Japanese",
            "Korean",
            "Portuguese",
            "Russian",
            "Spanish",
            "Swedish",
            "Vietnamese",
        };


        // -------------------------
        // Presets
        // -------------------------
        //// Item Source
        //private List<string> _Presets_Items = new List<string>()
        //{
        //    //
        //};
        //public List<string> Presets_Items
        //{
        //    get { return _Presets_Items; }
        //    set
        //    {
        //        _Presets_Items = value;
        //        OnPropertyChanged("Presets_Items");
        //    }
        //}

        //// Selected Index
        //private int _Presets_SelectedIndex { get; set; }
        //public int Presets_SelectedIndex
        //{
        //    get { return _Presets_SelectedIndex; }
        //    set
        //    {
        //        if (_Presets_SelectedIndex == value)
        //        {
        //            return;
        //        }

        //        _Presets_SelectedIndex = value;
        //        OnPropertyChanged("Preset_SelectedIndex");
        //    }
        //}

        //// Selected Item
        //private string _Presets_SelectedItem { get; set; }
        //public string Presets_SelectedItem
        //{
        //    get { return _Presets_SelectedItem; }
        //    set
        //    {
        //        if (_Presets_SelectedItem == value)
        //        {
        //            return;
        //        }

        //        _Presets_SelectedItem = value;
        //        OnPropertyChanged("Presets_SelectedItem");
        //    }
        //}

        //// Controls Enable
        //private bool _Presets_IsEnabled = true;
        //public bool Presets_IsEnabled
        //{
        //    get { return _Presets_IsEnabled; }
        //    set
        //    {
        //        if (_Presets_IsEnabled == value)
        //        {
        //            return;
        //        }

        //        _Presets_IsEnabled = value;
        //        OnPropertyChanged("Presets_IsEnabled");
        //    }
        //}


    }
}
