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
    public class Display : INotifyPropertyChanged
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
        public Display()
        {
            // -------------------------
            // Defaults
            // -------------------------
            OSC_SelectedItem = "default";
            OSC_Layout_SelectedItem = "default";
            OSC_Seekbar_SelectedItem = "default";
            OSC_Scale_Value = 0;
            OSC_BarWidth_Value = 0;
            OSC_BarHeight_Value = 0;

            OSD_SelectedItem = "default";
            OSD_Fractions_SelectedItem = "default";
            OSD_Duration_Text = string.Empty;
            OSD_Level_SelectedItem = "default";

            OSD_Font_SelectedItem = "default";
            OSD_FontSize_SelectedItem = "default";
            OSD_FontColor_Text = string.Empty;
            OSD_FontBorderSize_SelectedItem = "default";
            OSD_BorderColor_Text = string.Empty;
            OSD_ShadowOffset_Value = 0;
            OSD_ShadowColor_Text = string.Empty;
        }


        // ----------------------------------------------------------------------------------------------------
        // OSC
        // ----------------------------------------------------------------------------------------------------

        // -------------------------
        // OSC On Screen Controller
        // -------------------------
        // Item Source
        private List<string> _OSC_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> OSC_Items
        {
            get { return _OSC_Items; }
            set
            {
                _OSC_Items = value;
                OnPropertyChanged("OSC_Items");
            }
        }

        // Selected Item
        private string _OSC_SelectedItem { get; set; }
        public string OSC_SelectedItem
        {
            get { return _OSC_SelectedItem; }
            set
            {
                if (_OSC_SelectedItem == value)
                {
                    return;
                }

                _OSC_SelectedItem = value;
                OnPropertyChanged("OSC_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSC_IsEnabled = true;
        public bool OSC_IsEnabled
        {
            get { return _OSC_IsEnabled; }
            set
            {
                if (_OSC_IsEnabled == value)
                {
                    return;
                }

                _OSC_IsEnabled = value;
                OnPropertyChanged("OSC_IsEnabled");
            }
        }



        // -------------------------
        // Layout
        // -------------------------
        // Item Source
        private List<string> _OSC_Layout_Items = new List<string>()
        {
            "default",
            "box",
            "slimbox",
            "bottombar",
            "topbar"
        };
        public List<string> OSC_Layout_Items
        {
            get { return _OSC_Layout_Items; }
            set
            {
                _OSC_Layout_Items = value;
                OnPropertyChanged("OSC_Layout_Items");
            }
        }

        // Selected Item
        private string _OSC_Layout_SelectedItem { get; set; }
        public string OSC_Layout_SelectedItem
        {
            get { return _OSC_Layout_SelectedItem; }
            set
            {
                if (_OSC_Layout_SelectedItem == value)
                {
                    return;
                }

                _OSC_Layout_SelectedItem = value;
                OnPropertyChanged("OSC_Layout_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSC_Layout_IsEnabled = true;
        public bool OSC_Layout_IsEnabled
        {
            get { return _OSC_Layout_IsEnabled; }
            set
            {
                if (_OSC_Layout_IsEnabled == value)
                {
                    return;
                }

                _OSC_Layout_IsEnabled = value;
                OnPropertyChanged("OSC_Layout_IsEnabled");
            }
        }


        // -------------------------
        // Seekbar
        // -------------------------
        // Item Source
        private List<string> _OSC_Seekbar_Items = new List<string>()
        {
            "default",
            "bar",
            "knob",
            "diamond"
        };
        public List<string> OSC_Seekbar_Items
        {
            get { return _OSC_Seekbar_Items; }
            set
            {
                _OSC_Seekbar_Items = value;
                OnPropertyChanged("OSC_Seekbar_Items");
            }
        }

        // Selected Item
        private string _OSC_Seekbar_SelectedItem { get; set; }
        public string OSC_Seekbar_SelectedItem
        {
            get { return _OSC_Seekbar_SelectedItem; }
            set
            {
                if (_OSC_Seekbar_SelectedItem == value)
                {
                    return;
                }

                _OSC_Seekbar_SelectedItem = value;
                OnPropertyChanged("OSC_Seekbar_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSC_Seekbar_IsEnabled = true;
        public bool OSC_Seekbar_IsEnabled
        {
            get { return _OSC_Seekbar_IsEnabled; }
            set
            {
                if (_OSC_Seekbar_IsEnabled == value)
                {
                    return;
                }

                _OSC_Seekbar_IsEnabled = value;
                OnPropertyChanged("OSC_Seekbar_IsEnabled");
            }
        }


        // -------------------------
        // OSC Duration
        // -------------------------
        // Text
        private string _OSC_Duration_Text;
        public string OSC_Duration_Text
        {
            get { return _OSC_Duration_Text; }
            set
            {
                if (_OSC_Duration_Text == value)
                {
                    return;
                }

                _OSC_Duration_Text = value;
                OnPropertyChanged("OSC_Duration_Text");
            }
        }

        // Controls Enable
        private bool _OSC_Duration_IsEnabled = true;
        public bool OSC_Duration_IsEnabled
        {
            get { return _OSC_Duration_IsEnabled; }
            set
            {
                if (_OSC_Duration_IsEnabled == value)
                {
                    return;
                }

                _OSC_Duration_IsEnabled = value;
                OnPropertyChanged("OSC_Duration_IsEnabled");
            }
        }


        // -------------------------
        // OSC Scale
        // -------------------------
        // Value
        private double _OSC_Scale_Value = 0.0;
        public double OSC_Scale_Value
        {
            get { return _OSC_Scale_Value; }
            set
            {
                if (_OSC_Scale_Value == value)
                {
                    return;
                }

                _OSC_Scale_Value = value;
                OnPropertyChanged("OSC_Scale_Value");
            }
        }

        // Text
        private string _OSC_Scale_Text;
        public string OSC_Scale_Text
        {
            get { return _OSC_Scale_Text; }
            set
            {
                if (_OSC_Scale_Text == value)
                {
                    return;
                }

                _OSC_Scale_Text = value;
                OnPropertyChanged("OSC_Scale_Text");
            }
        }

        // Controls Enable
        private bool _OSC_Scale_IsEnabled = true;
        public bool OSC_Scale_IsEnabled
        {
            get { return _OSC_Scale_IsEnabled; }
            set
            {
                if (_OSC_Scale_IsEnabled == value)
                {
                    return;
                }

                _OSC_Scale_IsEnabled = value;
                OnPropertyChanged("OSC_Scale_IsEnabled");
            }
        }


        // -------------------------
        // OSC Bar Width
        // -------------------------
        // Value
        private double _OSC_BarWidth_Value = 0.0;
        public double OSC_BarWidth_Value
        {
            get { return _OSC_BarWidth_Value; }
            set
            {
                if (_OSC_BarWidth_Value == value)
                {
                    return;
                }

                _OSC_BarWidth_Value = value;
                OnPropertyChanged("OSC_BarWidth_Value");
            }
        }

        // Text
        private string _OSC_BarWidth_Text;
        public string OSC_BarWidth_Text
        {
            get { return _OSC_BarWidth_Text; }
            set
            {
                if (_OSC_BarWidth_Text == value)
                {
                    return;
                }

                _OSC_BarWidth_Text = value;
                OnPropertyChanged("OSC_BarWidth_Text");
            }
        }

        // Controls Enable
        private bool _OSC_BarWidth_IsEnabled = true;
        public bool OSC_BarWidth_IsEnabled
        {
            get { return _OSC_BarWidth_IsEnabled; }
            set
            {
                if (_OSC_BarWidth_IsEnabled == value)
                {
                    return;
                }

                _OSC_BarWidth_IsEnabled = value;
                OnPropertyChanged("OSC_BarWidth_IsEnabled");
            }
        }


        // -------------------------
        // OSC Bar Height
        // -------------------------
        // Value
        private double _OSC_BarHeight_Value = 0.0;
        public double OSC_BarHeight_Value
        {
            get { return _OSC_BarHeight_Value; }
            set
            {
                if (_OSC_BarHeight_Value == value)
                {
                    return;
                }

                _OSC_BarHeight_Value = value;
                OnPropertyChanged("OSC_BarHeight_Value");
            }
        }

        // Text
        private string _OSC_BarHeight_Text;
        public string OSC_BarHeight_Text
        {
            get { return _OSC_BarHeight_Text; }
            set
            {
                if (_OSC_BarHeight_Text == value)
                {
                    return;
                }

                _OSC_BarHeight_Text = value;
                OnPropertyChanged("OSC_BarHeight_Text");
            }
        }

        // Controls Enable
        private bool _OSC_BarHeight_IsEnabled = true;
        public bool OSC_BarHeight_IsEnabled
        {
            get { return _OSC_BarHeight_IsEnabled; }
            set
            {
                if (_OSC_BarHeight_IsEnabled == value)
                {
                    return;
                }

                _OSC_BarHeight_IsEnabled = value;
                OnPropertyChanged("OSC_BarHeight_IsEnabled");
            }
        }



        // ----------------------------------------------------------------------------------------------------
        // OSD
        // ----------------------------------------------------------------------------------------------------

        // -------------------------
        // OSD
        // -------------------------
        // Item Source
        private List<string> _OSD_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> OSD_Items
        {
            get { return _OSD_Items; }
            set
            {
                _OSD_Items = value;
                OnPropertyChanged("OSD_Items");
            }
        }

        // Selected Item
        private string _OSD_SelectedItem { get; set; }
        public string OSD_SelectedItem
        {
            get { return _OSD_SelectedItem; }
            set
            {
                if (_OSD_SelectedItem == value)
                {
                    return;
                }

                _OSD_SelectedItem = value;
                OnPropertyChanged("OSD_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_IsEnabled = true;
        public bool OSD_IsEnabled
        {
            get { return _OSD_IsEnabled; }
            set
            {
                if (_OSD_IsEnabled == value)
                {
                    return;
                }

                _OSD_IsEnabled = value;
                OnPropertyChanged("OSD_IsEnabled");
            }
        }


        // -------------------------
        // OSD Fractions
        // -------------------------
        // Item Source
        private List<string> _OSD_Fractions_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> OSD_Fractions_Items
        {
            get { return _OSD_Fractions_Items; }
            set
            {
                _OSD_Fractions_Items = value;
                OnPropertyChanged("OSD_Fractions_Items");
            }
        }

        // Selected Item
        private string _OSD_Fractions_SelectedItem { get; set; }
        public string OSD_Fractions_SelectedItem
        {
            get { return _OSD_Fractions_SelectedItem; }
            set
            {
                if (_OSD_Fractions_SelectedItem == value)
                {
                    return;
                }

                _OSD_Fractions_SelectedItem = value;
                OnPropertyChanged("OSD_Fractions_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_Fractions_IsEnabled = true;
        public bool OSD_Fractions_IsEnabled
        {
            get { return _OSD_Fractions_IsEnabled; }
            set
            {
                if (_OSD_Fractions_IsEnabled == value)
                {
                    return;
                }

                _OSD_Fractions_IsEnabled = value;
                OnPropertyChanged("OSD_Fractions_IsEnabled");
            }
        }


        // -------------------------
        // OSD Duration
        // -------------------------
        // Text
        private string _OSD_Duration_Text;
        public string OSD_Duration_Text
        {
            get { return _OSD_Duration_Text; }
            set
            {
                if (_OSD_Duration_Text == value)
                {
                    return;
                }

                _OSD_Duration_Text = value;
                OnPropertyChanged("OSD_Duration_Text");
            }
        }

        // Controls Enable
        private bool _OSD_Duration_IsEnabled = true;
        public bool OSD_Duration_IsEnabled
        {
            get { return _OSD_Duration_IsEnabled; }
            set
            {
                if (_OSD_Duration_IsEnabled == value)
                {
                    return;
                }

                _OSD_Duration_IsEnabled = value;
                OnPropertyChanged("OSD_Duration_IsEnabled");
            }
        }


        // -------------------------
        // OSD Level
        // -------------------------
        // Item Source
        private List<string> _OSD_Level_Items = new List<string>()
        {
            "default",
            "0",
            "1",
            "2",
            "3",
        };
        public List<string> OSD_Level_Items
        {
            get { return _OSD_Level_Items; }
            set
            {
                _OSD_Level_Items = value;
                OnPropertyChanged("OSD_Level_Items");
            }
        }

        // Selected Item
        private string _OSD_Level_SelectedItem { get; set; }
        public string OSD_Level_SelectedItem
        {
            get { return _OSD_Level_SelectedItem; }
            set
            {
                if (_OSD_Level_SelectedItem == value)
                {
                    return;
                }

                _OSD_Level_SelectedItem = value;
                OnPropertyChanged("OSD_Level_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_Level_IsEnabled = true;
        public bool OSD_Level_IsEnabled
        {
            get { return _OSD_Level_IsEnabled; }
            set
            {
                if (_OSD_Level_IsEnabled == value)
                {
                    return;
                }

                _OSD_Level_IsEnabled = value;
                OnPropertyChanged("OSD_Level_IsEnabled");
            }
        }


        // ----------------------------------------------------------------------------------------------------
        // Text
        // ----------------------------------------------------------------------------------------------------

        // -------------------------
        // Font Name
        // -------------------------
        // Item Source
        private List<string> _OSD_Font_Items = new List<string>()
        {
            //
        };
        public List<string> OSD_Font_Items
        {
            get { return _OSD_Font_Items; }
            set
            {
                _OSD_Font_Items = value;
                OnPropertyChanged("OSD_Font_Items");
            }
        }

        // Selected Item
        private string _OSD_Font_SelectedItem { get; set; }
        public string OSD_Font_SelectedItem
        {
            get { return _OSD_Font_SelectedItem; }
            set
            {
                if (_OSD_Font_SelectedItem == value)
                {
                    return;
                }

                _OSD_Font_SelectedItem = value;
                OnPropertyChanged("OSD_Font_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_Font_IsEnabled = true;
        public bool OSD_Font_IsEnabled
        {
            get { return _OSD_Font_IsEnabled; }
            set
            {
                if (_OSD_Font_IsEnabled == value)
                {
                    return;
                }

                _OSD_Font_IsEnabled = value;
                OnPropertyChanged("OSD_Font_IsEnabled");
            }
        }


        // -------------------------
        // Font Size
        // -------------------------
        // Item Source
        private List<string> _OSD_FontSize_Items = new List<string>()
        {
            "default",
            "96",
            "88",
            "80",
            "72",
            "66",
            "60",
            "54",
            "48",
            "44",
            "40",
            "36",
            "32",
            "28",
            "26"
        };
        public List<string> OSD_FontSize_Items
        {
            get { return _OSD_FontSize_Items; }
            set
            {
                _OSD_FontSize_Items = value;
                OnPropertyChanged("OSD_FontSize_Items");
            }
        }

        // Selected Item
        private string _OSD_FontSize_SelectedItem { get; set; }
        public string OSD_FontSize_SelectedItem
        {
            get { return _OSD_FontSize_SelectedItem; }
            set
            {
                if (_OSD_FontSize_SelectedItem == value)
                {
                    return;
                }

                _OSD_FontSize_SelectedItem = value;
                OnPropertyChanged("OSD_FontSize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_FontSize_IsEnabled = true;
        public bool OSD_FontSize_IsEnabled
        {
            get { return _OSD_FontSize_IsEnabled; }
            set
            {
                if (_OSD_FontSize_IsEnabled == value)
                {
                    return;
                }

                _OSD_FontSize_IsEnabled = value;
                OnPropertyChanged("OSD_FontSize_IsEnabled");
            }
        }


        // -------------------------
        // Font Color
        // -------------------------
        // Text
        private string _OSD_FontColor_Text;
        public string OSD_FontColor_Text
        {
            get { return _OSD_FontColor_Text; }
            set
            {
                if (_OSD_FontColor_Text == value)
                {
                    return;
                }

                _OSD_FontColor_Text = value;
                OnPropertyChanged("OSD_FontColor_Text");
            }
        }

        // Controls Enable
        private bool _OSD_FontColor_IsEnabled = true;
        public bool OSD_FontColor_IsEnabled
        {
            get { return _OSD_FontColor_IsEnabled; }
            set
            {
                if (_OSD_FontColor_IsEnabled == value)
                {
                    return;
                }

                _OSD_FontColor_IsEnabled = value;
                OnPropertyChanged("OSD_FontColor_IsEnabled");
            }
        }


        // -------------------------
        // Font Border Size
        // -------------------------
        // Item Source
        private List<string> _OSD_FontBorderSize_Items = new List<string>()
        {
            "default",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
        };
        public List<string> OSD_FontBorderSize_Items
        {
            get { return _OSD_FontBorderSize_Items; }
            set
            {
                _OSD_FontBorderSize_Items = value;
                OnPropertyChanged("OSD_FontBorderSize_Items");
            }
        }

        // Selected Item
        private string _OSD_FontBorderSize_SelectedItem { get; set; }
        public string OSD_FontBorderSize_SelectedItem
        {
            get { return _OSD_FontBorderSize_SelectedItem; }
            set
            {
                if (_OSD_FontBorderSize_SelectedItem == value)
                {
                    return;
                }

                _OSD_FontBorderSize_SelectedItem = value;
                OnPropertyChanged("OSD_FontBorderSize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OSD_FontBorderSize_IsEnabled = true;
        public bool OSD_FontBorderSize_IsEnabled
        {
            get { return _OSD_FontBorderSize_IsEnabled; }
            set
            {
                if (_OSD_FontBorderSize_IsEnabled == value)
                {
                    return;
                }

                _OSD_FontBorderSize_IsEnabled = value;
                OnPropertyChanged("OSD_FontBorderSize_IsEnabled");
            }
        }


        // -------------------------
        // Font Border Color
        // -------------------------
        // Text
        private string _OSD_BorderColor_Text;
        public string OSD_BorderColor_Text
        {
            get { return _OSD_BorderColor_Text; }
            set
            {
                if (_OSD_BorderColor_Text == value)
                {
                    return;
                }

                _OSD_BorderColor_Text = value;
                OnPropertyChanged("OSD_BorderColor_Text");
            }
        }

        // Controls Enable
        private bool _OSD_BorderColor_IsEnabled = true;
        public bool OSD_BorderColor_IsEnabled
        {
            get { return _OSD_BorderColor_IsEnabled; }
            set
            {
                if (_OSD_BorderColor_IsEnabled == value)
                {
                    return;
                }

                _OSD_BorderColor_IsEnabled = value;
                OnPropertyChanged("OSD_BorderColor_IsEnabled");
            }
        }


        // -------------------------
        // Font Shadow Color
        // -------------------------
        // Text
        private string _OSD_ShadowColor_Text;
        public string OSD_ShadowColor_Text
        {
            get { return _OSD_ShadowColor_Text; }
            set
            {
                if (_OSD_ShadowColor_Text == value)
                {
                    return;
                }

                _OSD_ShadowColor_Text = value;
                OnPropertyChanged("OSD_ShadowColor_Text");
            }
        }

        // Controls Enable
        private bool _OSD_ShadowColor_IsEnabled = true;
        public bool OSD_ShadowColor_IsEnabled
        {
            get { return _OSD_ShadowColor_IsEnabled; }
            set
            {
                if (_OSD_ShadowColor_IsEnabled == value)
                {
                    return;
                }

                _OSD_ShadowColor_IsEnabled = value;
                OnPropertyChanged("OSD_ShadowColor_IsEnabled");
            }
        }


        // -------------------------
        // Font Shadow Offset
        // -------------------------
        // Value
        private double _OSD_ShadowOffset_Value;
        public double OSD_ShadowOffset_Value
        {
            get { return _OSD_ShadowOffset_Value; }
            set
            {
                if (_OSD_ShadowOffset_Value == value)
                {
                    return;
                }

                _OSD_ShadowOffset_Value = value;
                OnPropertyChanged("OSD_ShadowOffset_Value");
            }
        }

        // Text
        private string _OSD_ShadowOffset_Text;
        public string OSD_ShadowOffset_Text
        {
            get { return _OSD_ShadowOffset_Text; }
            set
            {
                if (_OSD_ShadowOffset_Text == value)
                {
                    return;
                }

                _OSD_ShadowOffset_Text = value;
                OnPropertyChanged("OSD_ShadowOffset_Text");
            }
        }

        // Controls Enable
        private bool _OSD_ShadowOffset_IsEnabled = true;
        public bool OSD_ShadowOffset_IsEnabled
        {
            get { return _OSD_ShadowOffset_IsEnabled; }
            set
            {
                if (_OSD_ShadowOffset_IsEnabled == value)
                {
                    return;
                }

                _OSD_ShadowOffset_IsEnabled = value;
                OnPropertyChanged("OSD_ShadowOffset_IsEnabled");
            }
        }

    }
}
