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
    public class General : INotifyPropertyChanged
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
        public General()
        {
            // -------------------------
            // Defaults
            // -------------------------
            Priority_SelectedItem = "default";
            SavePositionQuit_SelectedItem = "default";
            KeepOpen_SelectedItem = "default";
            OnTop_SelectedItem = "default";
            WindowBorder_SelectedItem = "default";
            GeometryX_Value = 0;
            GeometryY_Value = 0;
            AutofitWidth_Value = 0;
            AutofitHeight_Value = 0;
            Screensaver_SelectedItem = "default";
            WindowTitle_SelectedItem = "default";
            LogPath_Text = string.Empty;

            ScreenshotPath_Text = string.Empty;
            ScreenshotTemplate_SelectedItem = "default";
            ScreenshotTagColorspace_SelectedItem = "default";
            ScreenshotFormat_SelectedItem = "default";
            ScreenshotQuality_Content = "Quality";
            ScreenshotQuality_Value = 0;

            ExtMKV_SelectedItem = "default";
            ExtMP4_SelectedItem = "default";
            ExtWebM_SelectedItem = "default";
            ExtGIF_SelectedItem = "default";
            ExtJPG_SelectedItem = "default";
            ExtPNG_SelectedItem = "default";
        }

        // ----------------------------------------------------------------------------------------------------
        // General
        // ----------------------------------------------------------------------------------------------------
        // -------------------------
        // Priority
        // -------------------------
        // Item Source
        private List<string> _Priority_Items = new List<string>()
        {
            "default",
            "high",
            "abovenormal",
            "normal",
            "belowormal",
            "idle",
        };
        public List<string> Priority_Items
        {
            get { return _Priority_Items; }
            set
            {
                _Priority_Items = value;
                OnPropertyChanged("Priority_Items");
            }
        }

        // Selected Item
        private string _Priority_SelectedItem { get; set; }
        public string Priority_SelectedItem
        {
            get { return _Priority_SelectedItem; }
            set
            {
                if (_Priority_SelectedItem == value)
                {
                    return;
                }

                _Priority_SelectedItem = value;
                OnPropertyChanged("Priority_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Priority_IsEnabled = true;
        public bool Priority_IsEnabled
        {
            get { return _Priority_IsEnabled; }
            set
            {
                if (_Priority_IsEnabled == value)
                {
                    return;
                }

                _Priority_IsEnabled = value;
                OnPropertyChanged("Priority_IsEnabled");
            }
        }


        // -------------------------
        // Save Position Quit
        // -------------------------
        // Item Source
        private List<string> _SavePositionQuit_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> SavePositionQuit_Items
        {
            get { return _SavePositionQuit_Items; }
            set
            {
                _SavePositionQuit_Items = value;
                OnPropertyChanged("SavePositionQuit_Items");
            }
        }

        // Selected Item
        private string _SavePositionQuit_SelectedItem { get; set; }
        public string SavePositionQuit_SelectedItem
        {
            get { return _SavePositionQuit_SelectedItem; }
            set
            {
                if (_SavePositionQuit_SelectedItem == value)
                {
                    return;
                }

                _SavePositionQuit_SelectedItem = value;
                OnPropertyChanged("SavePositionQuit_SelectedItem");
            }
        }

        // Controls Enable
        private bool _SavePositionQuit_IsEnabled = true;
        public bool SavePositionQuit_IsEnabled
        {
            get { return _SavePositionQuit_IsEnabled; }
            set
            {
                if (_SavePositionQuit_IsEnabled == value)
                {
                    return;
                }

                _SavePositionQuit_IsEnabled = value;
                OnPropertyChanged("SavePositionQuit_IsEnabled");
            }
        }


        // -------------------------
        // Keep Open
        // -------------------------
        // Item Source
        private List<string> _KeepOpen_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> KeepOpen_Items
        {
            get { return _KeepOpen_Items; }
            set
            {
                _KeepOpen_Items = value;
                OnPropertyChanged("KeepOpen_Items");
            }
        }

        // Selected Item
        private string _KeepOpen_SelectedItem { get; set; }
        public string KeepOpen_SelectedItem
        {
            get { return _KeepOpen_SelectedItem; }
            set
            {
                if (_KeepOpen_SelectedItem == value)
                {
                    return;
                }

                _KeepOpen_SelectedItem = value;
                OnPropertyChanged("KeepOpen_SelectedItem");
            }
        }

        // Controls Enable
        private bool _KeepOpen_IsEnabled = true;
        public bool KeepOpen_IsEnabled
        {
            get { return _KeepOpen_IsEnabled; }
            set
            {
                if (_KeepOpen_IsEnabled == value)
                {
                    return;
                }

                _KeepOpen_IsEnabled = value;
                OnPropertyChanged("KeepOpen_IsEnabled");
            }
        }


        // -------------------------
        // OnTop
        // -------------------------
        // Item Source
        private List<string> _OnTop_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> OnTop_Items
        {
            get { return _OnTop_Items; }
            set
            {
                _OnTop_Items = value;
                OnPropertyChanged("OnTop_Items");
            }
        }

        // Selected Item
        private string _OnTop_SelectedItem { get; set; }
        public string OnTop_SelectedItem
        {
            get { return _OnTop_SelectedItem; }
            set
            {
                if (_OnTop_SelectedItem == value)
                {
                    return;
                }

                _OnTop_SelectedItem = value;
                OnPropertyChanged("OnTop_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OnTop_IsEnabled = true;
        public bool OnTop_IsEnabled
        {
            get { return _OnTop_IsEnabled; }
            set
            {
                if (_OnTop_IsEnabled == value)
                {
                    return;
                }

                _OnTop_IsEnabled = value;
                OnPropertyChanged("OnTop_IsEnabled");
            }
        }


        // -------------------------
        // WindowBorder
        // -------------------------
        // Item Source
        private List<string> _WindowBorder_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> WindowBorder_Items
        {
            get { return _WindowBorder_Items; }
            set
            {
                _WindowBorder_Items = value;
                OnPropertyChanged("WindowBorder_Items");
            }
        }

        // Selected Item
        private string _WindowBorder_SelectedItem { get; set; }
        public string WindowBorder_SelectedItem
        {
            get { return _WindowBorder_SelectedItem; }
            set
            {
                if (_WindowBorder_SelectedItem == value)
                {
                    return;
                }

                _WindowBorder_SelectedItem = value;
                OnPropertyChanged("WindowBorder_SelectedItem");
            }
        }

        // Controls Enable
        private bool _WindowBorder_IsEnabled = true;
        public bool WindowBorder_IsEnabled
        {
            get { return _WindowBorder_IsEnabled; }
            set
            {
                if (_WindowBorder_IsEnabled == value)
                {
                    return;
                }

                _WindowBorder_IsEnabled = value;
                OnPropertyChanged("WindowBorder_IsEnabled");
            }
        }


        // -------------------------
        // Geometry X
        // -------------------------
        // Value
        private double _GeometryX_Value = 0;
        public double GeometryX_Value
        {
            get { return _GeometryX_Value; }
            set
            {
                if (_GeometryX_Value == value)
                {
                    return;
                }

                _GeometryX_Value = value;
                OnPropertyChanged("GeometryX_Value");
            }
        }

        // Text
        private string _GeometryX_Text;
        public string GeometryX_Text
        {
            get { return _GeometryX_Text; }
            set
            {
                if (_GeometryX_Text == value)
                {
                    return;
                }

                _GeometryX_Text = value;
                OnPropertyChanged("GeometryX_Text");
            }
        }

        // Controls Enable
        private bool _GeometryX_IsEnabled = true;
        public bool GeometryX_IsEnabled
        {
            get { return _GeometryX_IsEnabled; }
            set
            {
                if (_GeometryX_IsEnabled == value)
                {
                    return;
                }

                _GeometryX_IsEnabled = value;
                OnPropertyChanged("GeometryX_IsEnabled");
            }
        }


        // -------------------------
        // Geometry Y
        // -------------------------
        // Value
        private double _GeometryY_Value = 0;
        public double GeometryY_Value
        {
            get { return _GeometryY_Value; }
            set
            {
                if (_GeometryY_Value == value)
                {
                    return;
                }

                _GeometryY_Value = value;
                OnPropertyChanged("GeometryY_Value");
            }
        }

        // Text
        private string _GeometryY_Text;
        public string GeometryY_Text
        {
            get { return _GeometryY_Text; }
            set
            {
                if (_GeometryY_Text == value)
                {
                    return;
                }

                _GeometryY_Text = value;
                OnPropertyChanged("GeometryY_Text");
            }
        }

        // Controls Enable
        private bool _GeometryY_IsEnabled = true;
        public bool GeometryY_IsEnabled
        {
            get { return _GeometryY_IsEnabled; }
            set
            {
                if (_GeometryY_IsEnabled == value)
                {
                    return;
                }

                _GeometryY_IsEnabled = value;
                OnPropertyChanged("GeometryY_IsEnabled");
            }
        }


        // -------------------------
        // Autofit Width
        // -------------------------
        // Value
        private double _AutofitWidth_Value = 0;
        public double AutofitWidth_Value
        {
            get { return _AutofitWidth_Value; }
            set
            {
                if (_AutofitWidth_Value == value)
                {
                    return;
                }

                _AutofitWidth_Value = value;
                OnPropertyChanged("AutofitWidth_Value");
            }
        }

        // Text
        private string _AutofitWidth_Text;
        public string AutofitWidth_Text
        {
            get { return _AutofitWidth_Text; }
            set
            {
                if (_AutofitWidth_Text == value)
                {
                    return;
                }

                _AutofitWidth_Text = value;
                OnPropertyChanged("AutofitWidth_Text");
            }
        }

        // Controls Enable
        private bool _AutofitWidth_IsEnabled = true;
        public bool AutofitWidth_IsEnabled
        {
            get { return _AutofitWidth_IsEnabled; }
            set
            {
                if (_AutofitWidth_IsEnabled == value)
                {
                    return;
                }

                _AutofitWidth_IsEnabled = value;
                OnPropertyChanged("AutofitWidth_IsEnabled");
            }
        }


        // -------------------------
        // Autofit Height
        // -------------------------
        // Value
        private double _AutofitHeight_Value = 0;
        public double AutofitHeight_Value
        {
            get { return _AutofitHeight_Value; }
            set
            {
                if (_AutofitHeight_Value == value)
                {
                    return;
                }

                _AutofitHeight_Value = value;
                OnPropertyChanged("AutofitHeight_Value");
            }
        }

        // Text
        private string _AutofitHeight_Text;
        public string AutofitHeight_Text
        {
            get { return _AutofitHeight_Text; }
            set
            {
                if (_AutofitHeight_Text == value)
                {
                    return;
                }

                _AutofitHeight_Text = value;
                OnPropertyChanged("AutofitHeight_Text");
            }
        }

        // Controls Enable
        private bool _AutofitHeight_IsEnabled = true;
        public bool AutofitHeight_IsEnabled
        {
            get { return _AutofitHeight_IsEnabled; }
            set
            {
                if (_AutofitHeight_IsEnabled == value)
                {
                    return;
                }

                _AutofitHeight_IsEnabled = value;
                OnPropertyChanged("AutofitHeight_IsEnabled");
            }
        }


        // -------------------------
        // Screensaver
        // -------------------------
        // Item Source
        private List<string> _Screensaver_Items = new List<string>()
        {
            "default",
            "on",
            "off",
        };
        public List<string> Screensaver_Items
        {
            get { return _Screensaver_Items; }
            set
            {
                _Screensaver_Items = value;
                OnPropertyChanged("Screensaver_Items");
            }
        }

        // Selected Item
        private string _Screensaver_SelectedItem { get; set; }
        public string Screensaver_SelectedItem
        {
            get { return _Screensaver_SelectedItem; }
            set
            {
                if (_Screensaver_SelectedItem == value)
                {
                    return;
                }

                _Screensaver_SelectedItem = value;
                OnPropertyChanged("Screensaver_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Screensaver_IsEnabled = true;
        public bool Screensaver_IsEnabled
        {
            get { return _Screensaver_IsEnabled; }
            set
            {
                if (_Screensaver_IsEnabled == value)
                {
                    return;
                }

                _Screensaver_IsEnabled = value;
                OnPropertyChanged("Screensaver_IsEnabled");
            }
        }


        // -------------------------
        // Window Title
        // -------------------------
        // Item Source
        private List<string> _WindowTitle_Items = new List<string>()
        {
            "default",
            "Filename",
            "Media Title",
        };
        public List<string> WindowTitle_Items
        {
            get { return _WindowTitle_Items; }
            set
            {
                _WindowTitle_Items = value;
                OnPropertyChanged("WindowTitle_Items");
            }
        }

        // Selected Item
        private string _WindowTitle_SelectedItem { get; set; }
        public string WindowTitle_SelectedItem
        {
            get { return _WindowTitle_SelectedItem; }
            set
            {
                if (_WindowTitle_SelectedItem == value)
                {
                    return;
                }

                _WindowTitle_SelectedItem = value;
                OnPropertyChanged("WindowTitle_SelectedItem");
            }
        }

        // Controls Enable
        private bool _WindowTitle_IsEnabled = true;
        public bool WindowTitle_IsEnabled
        {
            get { return _WindowTitle_IsEnabled; }
            set
            {
                if (_WindowTitle_IsEnabled == value)
                {
                    return;
                }

                _WindowTitle_IsEnabled = value;
                OnPropertyChanged("WindowTitle_IsEnabled");
            }
        }


        // -------------------------
        // Log Path
        // -------------------------
        // Text
        private string _LogPath_Text;
        public string LogPath_Text
        {
            get { return _LogPath_Text; }
            set
            {
                if (_LogPath_Text == value)
                {
                    return;
                }

                _LogPath_Text = value;
                OnPropertyChanged("LogPath_Text");
            }
        }

        // Controls Enable
        private bool _LogPath_IsEnabled = true;
        public bool LogPath_IsEnabled
        {
            get { return _LogPath_IsEnabled; }
            set
            {
                if (_LogPath_IsEnabled == value)
                {
                    return;
                }

                _LogPath_IsEnabled = value;
                OnPropertyChanged("LogPath_IsEnabled");
            }
        }


        // -------------------------
        // Screenshot Path
        // -------------------------
        // Text
        private string _ScreenshotPath_Text;
        public string ScreenshotPath_Text
        {
            get { return _ScreenshotPath_Text; }
            set
            {
                if (_ScreenshotPath_Text == value)
                {
                    return;
                }

                _ScreenshotPath_Text = value;
                OnPropertyChanged("ScreenshotPath_Text");
            }
        }

        // Controls Enable
        private bool _ScreenshotPath_IsEnabled = true;
        public bool ScreenshotPath_IsEnabled
        {
            get { return _ScreenshotPath_IsEnabled; }
            set
            {
                if (_ScreenshotPath_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotPath_IsEnabled = value;
                OnPropertyChanged("ScreenshotPath_IsEnabled");
            }
        }


        // -------------------------
        // Screenshot Template
        // -------------------------
        // Item Source
        private List<string> _ScreenshotTemplate_Items = new List<string>()
        {
            "default",
            "Playback Time",
            "Date Time",
            "Numbered",
        };
        public List<string> ScreenshotTemplate_Items
        {
            get { return _ScreenshotTemplate_Items; }
            set
            {
                _ScreenshotTemplate_Items = value;
                OnPropertyChanged("ScreenshotTemplate_Items");
            }
        }

        // Selected Item
        private string _ScreenshotTemplate_SelectedItem { get; set; }
        public string ScreenshotTemplate_SelectedItem
        {
            get { return _ScreenshotTemplate_SelectedItem; }
            set
            {
                if (_ScreenshotTemplate_SelectedItem == value)
                {
                    return;
                }

                _ScreenshotTemplate_SelectedItem = value;
                OnPropertyChanged("ScreenshotTemplate_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ScreenshotTemplate_IsEnabled = true;
        public bool ScreenshotTemplate_IsEnabled
        {
            get { return _ScreenshotTemplate_IsEnabled; }
            set
            {
                if (_ScreenshotTemplate_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotTemplate_IsEnabled = value;
                OnPropertyChanged("ScreenshotTemplate_IsEnabled");
            }
        }


        // -------------------------
        // Screenshot Template
        // -------------------------
        // Item Source
        private List<string> _ScreenshotTagColorspace_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> ScreenshotTagColorspace_Items
        {
            get { return _ScreenshotTagColorspace_Items; }
            set
            {
                _ScreenshotTagColorspace_Items = value;
                OnPropertyChanged("ScreenshotTagColorspace_Items");
            }
        }

        // Selected Item
        private string _ScreenshotTagColorspace_SelectedItem { get; set; }
        public string ScreenshotTagColorspace_SelectedItem
        {
            get { return _ScreenshotTagColorspace_SelectedItem; }
            set
            {
                if (_ScreenshotTagColorspace_SelectedItem == value)
                {
                    return;
                }

                _ScreenshotTagColorspace_SelectedItem = value;
                OnPropertyChanged("ScreenshotTagColorspace_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ScreenshotTagColorspace_IsEnabled = true;
        public bool ScreenshotTagColorspace_IsEnabled
        {
            get { return _ScreenshotTagColorspace_IsEnabled; }
            set
            {
                if (_ScreenshotTagColorspace_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotTagColorspace_IsEnabled = value;
                OnPropertyChanged("ScreenshotTagColorspace_IsEnabled");
            }
        }


        // -------------------------
        // Screenshot Format
        // -------------------------
        // Item Source
        private List<string> _ScreenshotFormat_Items = new List<string>()
        {
            "default",
            "png",
            "jpg",
            "jpeg",
        };
        public List<string> ScreenshotFormat_Items
        {
            get { return _ScreenshotFormat_Items; }
            set
            {
                _ScreenshotFormat_Items = value;
                OnPropertyChanged("ScreenshotFormat_Items");
            }
        }

        // Selected Item
        private string _ScreenshotFormat_SelectedItem { get; set; }
        public string ScreenshotFormat_SelectedItem
        {
            get { return _ScreenshotFormat_SelectedItem; }
            set
            {
                if (_ScreenshotFormat_SelectedItem == value)
                {
                    return;
                }

                _ScreenshotFormat_SelectedItem = value;
                OnPropertyChanged("ScreenshotFormat_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ScreenshotFormat_IsEnabled = true;
        public bool ScreenshotFormat_IsEnabled
        {
            get { return _ScreenshotFormat_IsEnabled; }
            set
            {
                if (_ScreenshotFormat_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotFormat_IsEnabled = value;
                OnPropertyChanged("ScreenshotFormat_IsEnabled");
            }
        }


        // -------------------------
        // Screenshot Quality
        // -------------------------
        // Value
        private double _ScreenshotQuality_Value = 0;
        public double ScreenshotQuality_Value
        {
            get { return _ScreenshotQuality_Value; }
            set
            {
                if (_ScreenshotQuality_Value == value)
                {
                    return;
                }

                _ScreenshotQuality_Value = value;
                OnPropertyChanged("ScreenshotQuality_Value");
            }
        }

        // Maximum
        private double _ScreenshotQuality_Maximum = 0;
        public double ScreenshotQuality_Maximum
        {
            get { return _ScreenshotQuality_Maximum; }
            set
            {
                if (_ScreenshotQuality_Maximum == value)
                {
                    return;
                }

                _ScreenshotQuality_Maximum = value;
                OnPropertyChanged("ScreenshotQuality_Maximum");
            }
        }

        // Text
        private string _ScreenshotQuality_Text;
        public string ScreenshotQuality_Text
        {
            get { return _ScreenshotQuality_Text; }
            set
            {
                if (_ScreenshotQuality_Text == value)
                {
                    return;
                }

                _ScreenshotQuality_Text = value;
                OnPropertyChanged("ScreenshotQuality_Text");
            }
        }

        // Content
        private string _ScreenshotQuality_Content;
        public string ScreenshotQuality_Content
        {
            get { return _ScreenshotQuality_Content; }
            set
            {
                if (_ScreenshotQuality_Content == value)
                {
                    return;
                }

                _ScreenshotQuality_Content = value;
                OnPropertyChanged("ScreenshotQuality_Content");
            }
        }

        // Controls Enable
        private bool _ScreenshotQuality_Content_IsEnabled = true;
        public bool ScreenshotQuality_Content_IsEnabled
        {
            get { return _ScreenshotQuality_Content_IsEnabled; }
            set
            {
                if (_ScreenshotQuality_Content_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotQuality_Content_IsEnabled = value;
                OnPropertyChanged("ScreenshotQuality_Content_IsEnabled");
            }
        }

        // Controls Enable
        private bool _ScreenshotQuality_IsEnabled = true;
        public bool ScreenshotQuality_IsEnabled
        {
            get { return _ScreenshotQuality_IsEnabled; }
            set
            {
                if (_ScreenshotQuality_IsEnabled == value)
                {
                    return;
                }

                _ScreenshotQuality_IsEnabled = value;
                OnPropertyChanged("ScreenshotQuality_IsEnabled");
            }
        }


        // ----------------------------------------------------------------------------------------------------
        // Extensions
        // ----------------------------------------------------------------------------------------------------
        // -------------------------
        // Ext MKV
        // -------------------------
        // Item Source
        private List<string> _ExtMKV_Items = new List<string>()
        {
            "default",
            "loop",
        };
        public List<string> ExtMKV_Items
        {
            get { return _ExtMKV_Items; }
            set
            {
                _ExtMKV_Items = value;
                OnPropertyChanged("ExtMKV_Items");
            }
        }

        // Selected Item
        private string _ExtMKV_SelectedItem { get; set; }
        public string ExtMKV_SelectedItem
        {
            get { return _ExtMKV_SelectedItem; }
            set
            {
                if (_ExtMKV_SelectedItem == value)
                {
                    return;
                }

                _ExtMKV_SelectedItem = value;
                OnPropertyChanged("ExtMKV_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtMKV_IsEnabled = true;
        public bool ExtMKV_IsEnabled
        {
            get { return _ExtMKV_IsEnabled; }
            set
            {
                if (_ExtMKV_IsEnabled == value)
                {
                    return;
                }

                _ExtMKV_IsEnabled = value;
                OnPropertyChanged("ExtMKV_IsEnabled");
            }
        }


        // -------------------------
        // Ext MP4
        // -------------------------
        // Item Source
        private List<string> _ExtMP4_Items = new List<string>()
        {
            "default",
            "loop",
        };
        public List<string> ExtMP4_Items
        {
            get { return _ExtMP4_Items; }
            set
            {
                _ExtMP4_Items = value;
                OnPropertyChanged("ExtMP4_Items");
            }
        }

        // Selected Item
        private string _ExtMP4_SelectedItem { get; set; }
        public string ExtMP4_SelectedItem
        {
            get { return _ExtMP4_SelectedItem; }
            set
            {
                if (_ExtMP4_SelectedItem == value)
                {
                    return;
                }

                _ExtMP4_SelectedItem = value;
                OnPropertyChanged("ExtMP4_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtMP4_IsEnabled = true;
        public bool ExtMP4_IsEnabled
        {
            get { return _ExtMP4_IsEnabled; }
            set
            {
                if (_ExtMP4_IsEnabled == value)
                {
                    return;
                }

                _ExtMP4_IsEnabled = value;
                OnPropertyChanged("ExtMP4_IsEnabled");
            }
        }


        // -------------------------
        // Ext WebM
        // -------------------------
        // Item Source
        private List<string> _ExtWebM_Items = new List<string>()
        {
            "default",
            "loop",
        };
        public List<string> ExtWebM_Items
        {
            get { return _ExtWebM_Items; }
            set
            {
                _ExtWebM_Items = value;
                OnPropertyChanged("ExtWebM_Items");
            }
        }

        // Selected Item
        private string _ExtWebM_SelectedItem { get; set; }
        public string ExtWebM_SelectedItem
        {
            get { return _ExtWebM_SelectedItem; }
            set
            {
                if (_ExtWebM_SelectedItem == value)
                {
                    return;
                }

                _ExtWebM_SelectedItem = value;
                OnPropertyChanged("ExtWebM_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtWebM_IsEnabled = true;
        public bool ExtWebM_IsEnabled
        {
            get { return _ExtWebM_IsEnabled; }
            set
            {
                if (_ExtWebM_IsEnabled == value)
                {
                    return;
                }

                _ExtWebM_IsEnabled = value;
                OnPropertyChanged("ExtWebM_IsEnabled");
            }
        }


        // -------------------------
        // Ext GIF
        // -------------------------
        // Item Source
        private List<string> _ExtGIF_Items = new List<string>()
        {
            "default",
            "loop",
        };
        public List<string> ExtGIF_Items
        {
            get { return _ExtGIF_Items; }
            set
            {
                _ExtGIF_Items = value;
                OnPropertyChanged("ExtGIF_Items");
            }
        }

        // Selected Item
        private string _ExtGIF_SelectedItem { get; set; }
        public string ExtGIF_SelectedItem
        {
            get { return _ExtGIF_SelectedItem; }
            set
            {
                if (_ExtGIF_SelectedItem == value)
                {
                    return;
                }

                _ExtGIF_SelectedItem = value;
                OnPropertyChanged("ExtGIF_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtGIF_IsEnabled = true;
        public bool ExtGIF_IsEnabled
        {
            get { return _ExtGIF_IsEnabled; }
            set
            {
                if (_ExtGIF_IsEnabled == value)
                {
                    return;
                }

                _ExtGIF_IsEnabled = value;
                OnPropertyChanged("ExtGIF_IsEnabled");
            }
        }


        // -------------------------
        // Ext JPG
        // -------------------------
        // Item Source
        private List<string> _ExtJPG_Items = new List<string>()
        {
            "default",
            "pause",
        };
        public List<string> ExtJPG_Items
        {
            get { return _ExtJPG_Items; }
            set
            {
                _ExtJPG_Items = value;
                OnPropertyChanged("ExtJPG_Items");
            }
        }

        // Selected Item
        private string _ExtJPG_SelectedItem { get; set; }
        public string ExtJPG_SelectedItem
        {
            get { return _ExtJPG_SelectedItem; }
            set
            {
                if (_ExtJPG_SelectedItem == value)
                {
                    return;
                }

                _ExtJPG_SelectedItem = value;
                OnPropertyChanged("ExtJPG_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtJPG_IsEnabled = true;
        public bool ExtJPG_IsEnabled
        {
            get { return _ExtJPG_IsEnabled; }
            set
            {
                if (_ExtJPG_IsEnabled == value)
                {
                    return;
                }

                _ExtJPG_IsEnabled = value;
                OnPropertyChanged("ExtJPG_IsEnabled");
            }
        }


        // -------------------------
        // Ext PNG
        // -------------------------
        // Item Source
        private List<string> _ExtPNG_Items = new List<string>()
        {
            "default",
            "pause",
        };
        public List<string> ExtPNG_Items
        {
            get { return _ExtPNG_Items; }
            set
            {
                _ExtPNG_Items = value;
                OnPropertyChanged("ExtPNG_Items");
            }
        }

        // Selected Item
        private string _ExtPNG_SelectedItem { get; set; }
        public string ExtPNG_SelectedItem
        {
            get { return _ExtPNG_SelectedItem; }
            set
            {
                if (_ExtPNG_SelectedItem == value)
                {
                    return;
                }

                _ExtPNG_SelectedItem = value;
                OnPropertyChanged("ExtPNG_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ExtPNG_IsEnabled = true;
        public bool ExtPNG_IsEnabled
        {
            get { return _ExtPNG_IsEnabled; }
            set
            {
                if (_ExtPNG_IsEnabled == value)
                {
                    return;
                }

                _ExtPNG_IsEnabled = value;
                OnPropertyChanged("ExtPNG_IsEnabled");
            }
        }




    }
}
