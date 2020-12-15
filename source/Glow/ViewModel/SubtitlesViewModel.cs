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
    public class Subtitles : INotifyPropertyChanged
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
        public Subtitles()
        {
            // -------------------------
            // Defaults
            // -------------------------
            Subtitles_SelectedItem = "default";
            LoadFiles_SelectedItem = "default";
            Position_Value = 0;
            FixTiming_SelectedItem = "default";
            Margins_SelectedItem = "default";
            Blend_SelectedItem = "default";

            ASS_SelectedItem = "default";
            ASSOverride_SelectedItem = "default";
            ASSForceMargins_SelectedItem = "default";
            ASSHinting_SelectedItem = "default";
            ASSKerning_SelectedItem = "default";

            EmbeddedFonts_SelectedItem = "default";
            Font_SelectedItem = "default";
            FontSize_SelectedItem = "default";
            FontColor_Text = string.Empty;
            BorderSize_SelectedItem = "default";
            BorderColor_Text = string.Empty;
            ShadowOffset_Value = 0;
            ShadowColor_Text = string.Empty;
        }


        // ----------------------------------------------------------------------------------------------------
        // Subtitle
        // ----------------------------------------------------------------------------------------------------
        // -------------------------
        // Subtitles
        // -------------------------
        // Item Source
        private List<string> _Subtitles_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Subtitles_Items
        {
            get { return _Subtitles_Items; }
            set
            {
                _Subtitles_Items = value;
                OnPropertyChanged("Subtitles_Items");
            }
        }

        // Selected Item
        private string _Subtitles_SelectedItem { get; set; }
        public string Subtitles_SelectedItem
        {
            get { return _Subtitles_SelectedItem; }
            set
            {
                if (_Subtitles_SelectedItem == value)
                {
                    return;
                }

                _Subtitles_SelectedItem = value;
                OnPropertyChanged("Subtitles_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Subtitles_IsEnabled = true;
        public bool Subtitles_IsEnabled
        {
            get { return _Subtitles_IsEnabled; }
            set
            {
                if (_Subtitles_IsEnabled == value)
                {
                    return;
                }

                _Subtitles_IsEnabled = value;
                OnPropertyChanged("Subtitles_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Load Files
        // -------------------------
        // Item Source
        private List<string> _LoadFiles_Items = new List<string>()
        {
            "default",
            "no",
            "exact",
            "fuzzy",
            "all",
        };
        public List<string> LoadFiles_Items
        {
            get { return _LoadFiles_Items; }
            set
            {
                _LoadFiles_Items = value;
                OnPropertyChanged("LoadFiles_Items");
            }
        }

        // Selected Item
        private string _LoadFiles_SelectedItem { get; set; }
        public string LoadFiles_SelectedItem
        {
            get { return _LoadFiles_SelectedItem; }
            set
            {
                if (_LoadFiles_SelectedItem == value)
                {
                    return;
                }

                _LoadFiles_SelectedItem = value;
                OnPropertyChanged("LoadFiles_SelectedItem");
            }
        }

        // Controls Enable
        private bool _LoadFiles_IsEnabled = true;
        public bool LoadFiles_IsEnabled
        {
            get { return _LoadFiles_IsEnabled; }
            set
            {
                if (_LoadFiles_IsEnabled == value)
                {
                    return;
                }

                _LoadFiles_IsEnabled = value;
                OnPropertyChanged("LoadFiles_IsEnabled");
            }
        }


        // -------------------------
        // Subtitle Position
        // -------------------------
        // Value
        private double _Position_Value = 0;
        public double Position_Value
        {
            get { return _Position_Value; }
            set
            {
                if (_Position_Value == value)
                {
                    return;
                }

                _Position_Value = value;
                OnPropertyChanged("Position_Value");
            }
        }

        // Text
        private string _Position_Text;
        public string Position_Text
        {
            get { return _Position_Text; }
            set
            {
                if (_Position_Text == value)
                {
                    return;
                }

                _Position_Text = value;
                OnPropertyChanged("Position_Text");
            }
        }

        // Controls Enable
        private bool _Position_IsEnabled = true;
        public bool Position_IsEnabled
        {
            get { return _Position_IsEnabled; }
            set
            {
                if (_Position_IsEnabled == value)
                {
                    return;
                }

                _Position_IsEnabled = value;
                OnPropertyChanged("Position_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Fix Timing
        // -------------------------
        // Item Source
        private List<string> _FixTiming_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> FixTiming_Items
        {
            get { return _FixTiming_Items; }
            set
            {
                _FixTiming_Items = value;
                OnPropertyChanged("FixTiming_Items");
            }
        }

        // Selected Item
        private string _FixTiming_SelectedItem { get; set; }
        public string FixTiming_SelectedItem
        {
            get { return _FixTiming_SelectedItem; }
            set
            {
                if (_FixTiming_SelectedItem == value)
                {
                    return;
                }

                _FixTiming_SelectedItem = value;
                OnPropertyChanged("FixTiming_SelectedItem");
            }
        }

        // Controls Enable
        private bool _FixTiming_IsEnabled = true;
        public bool FixTiming_IsEnabled
        {
            get { return _FixTiming_IsEnabled; }
            set
            {
                if (_FixTiming_IsEnabled == value)
                {
                    return;
                }

                _FixTiming_IsEnabled = value;
                OnPropertyChanged("FixTiming_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Margins
        // -------------------------
        // Item Source
        private List<string> _Margins_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> Margins_Items
        {
            get { return _Margins_Items; }
            set
            {
                _Margins_Items = value;
                OnPropertyChanged("Margins_Items");
            }
        }

        // Selected Item
        private string _Margins_SelectedItem { get; set; }
        public string Margins_SelectedItem
        {
            get { return _Margins_SelectedItem; }
            set
            {
                if (_Margins_SelectedItem == value)
                {
                    return;
                }

                _Margins_SelectedItem = value;
                OnPropertyChanged("Margins_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Margins_IsEnabled = true;
        public bool Margins_IsEnabled
        {
            get { return _Margins_IsEnabled; }
            set
            {
                if (_Margins_IsEnabled == value)
                {
                    return;
                }

                _Margins_IsEnabled = value;
                OnPropertyChanged("Margins_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Blend
        // -------------------------
        // Item Source
        private List<string> _Blend_Items = new List<string>()
        {
            "default",
            "yes",
            "video",
            "no",
        };
        public List<string> Blend_Items
        {
            get { return _Blend_Items; }
            set
            {
                _Blend_Items = value;
                OnPropertyChanged("Blend_Items");
            }
        }

        // Selected Item
        private string _Blend_SelectedItem { get; set; }
        public string Blend_SelectedItem
        {
            get { return _Blend_SelectedItem; }
            set
            {
                if (_Blend_SelectedItem == value)
                {
                    return;
                }

                _Blend_SelectedItem = value;
                OnPropertyChanged("Blend_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Blend_IsEnabled = true;
        public bool Blend_IsEnabled
        {
            get { return _Blend_IsEnabled; }
            set
            {
                if (_Blend_IsEnabled == value)
                {
                    return;
                }

                _Blend_IsEnabled = value;
                OnPropertyChanged("Blend_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles ASS
        // -------------------------
        // Item Source
        private List<string> _ASS_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> ASS_Items
        {
            get { return _ASS_Items; }
            set
            {
                _ASS_Items = value;
                OnPropertyChanged("ASS_Items");
            }
        }

        // Selected Item
        private string _ASS_SelectedItem { get; set; }
        public string ASS_SelectedItem
        {
            get { return _ASS_SelectedItem; }
            set
            {
                if (_ASS_SelectedItem == value)
                {
                    return;
                }

                _ASS_SelectedItem = value;
                OnPropertyChanged("ASS_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ASS_IsEnabled = true;
        public bool ASS_IsEnabled
        {
            get { return _ASS_IsEnabled; }
            set
            {
                if (_ASS_IsEnabled == value)
                {
                    return;
                }

                _ASS_IsEnabled = value;
                OnPropertyChanged("ASS_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles ASS Override
        // -------------------------
        // Item Source
        private List<string> _ASSOverride_Items = new List<string>()
        {
            "default",
            "no",
            "yes",
            "force",
            "scale",
            "strip",
        };
        public List<string> ASSOverride_Items
        {
            get { return _ASSOverride_Items; }
            set
            {
                _ASSOverride_Items = value;
                OnPropertyChanged("ASSOverride_Items");
            }
        }

        // Selected Item
        private string _ASSOverride_SelectedItem { get; set; }
        public string ASSOverride_SelectedItem
        {
            get { return _ASSOverride_SelectedItem; }
            set
            {
                if (_ASSOverride_SelectedItem == value)
                {
                    return;
                }

                _ASSOverride_SelectedItem = value;
                OnPropertyChanged("ASSOverride_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ASSOverride_IsEnabled = true;
        public bool ASSOverride_IsEnabled
        {
            get { return _ASSOverride_IsEnabled; }
            set
            {
                if (_ASSOverride_IsEnabled == value)
                {
                    return;
                }

                _ASSOverride_IsEnabled = value;
                OnPropertyChanged("ASSOverride_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles ASS Force Margins
        // -------------------------
        // Item Source
        private List<string> _ASSForceMargins_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> ASSForceMargins_Items
        {
            get { return _ASSForceMargins_Items; }
            set
            {
                _ASSForceMargins_Items = value;
                OnPropertyChanged("ASSForceMargins_Items");
            }
        }

        // Selected Item
        private string _ASSForceMargins_SelectedItem { get; set; }
        public string ASSForceMargins_SelectedItem
        {
            get { return _ASSForceMargins_SelectedItem; }
            set
            {
                if (_ASSForceMargins_SelectedItem == value)
                {
                    return;
                }

                _ASSForceMargins_SelectedItem = value;
                OnPropertyChanged("ASSForceMargins_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ASSForceMargins_IsEnabled = true;
        public bool ASSForceMargins_IsEnabled
        {
            get { return _ASSForceMargins_IsEnabled; }
            set
            {
                if (_ASSForceMargins_IsEnabled == value)
                {
                    return;
                }

                _ASSForceMargins_IsEnabled = value;
                OnPropertyChanged("ASSForceMargins_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles ASS Hinting
        // -------------------------
        // Item Source
        private List<string> _ASSHinting_Items = new List<string>()
        {
            "default",
            "none",
            "light",
            "normal",
            "native",
        };
        public List<string> ASSHinting_Items
        {
            get { return _ASSHinting_Items; }
            set
            {
                _ASSHinting_Items = value;
                OnPropertyChanged("ASSHinting_Items");
            }
        }

        // Selected Item
        private string _ASSHinting_SelectedItem { get; set; }
        public string ASSHinting_SelectedItem
        {
            get { return _ASSHinting_SelectedItem; }
            set
            {
                if (_ASSHinting_SelectedItem == value)
                {
                    return;
                }

                _ASSHinting_SelectedItem = value;
                OnPropertyChanged("ASSHinting_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ASSHinting_IsEnabled = true;
        public bool ASSHinting_IsEnabled
        {
            get { return _ASSHinting_IsEnabled; }
            set
            {
                if (_ASSHinting_IsEnabled == value)
                {
                    return;
                }

                _ASSHinting_IsEnabled = value;
                OnPropertyChanged("ASSHinting_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles ASS Kerning
        // -------------------------
        // Item Source
        private List<string> _ASSKerning_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> ASSKerning_Items
        {
            get { return _ASSKerning_Items; }
            set
            {
                _ASSKerning_Items = value;
                OnPropertyChanged("ASSKerning_Items");
            }
        }

        // Selected Item
        private string _ASSKerning_SelectedItem { get; set; }
        public string ASSKerning_SelectedItem
        {
            get { return _ASSKerning_SelectedItem; }
            set
            {
                if (_ASSKerning_SelectedItem == value)
                {
                    return;
                }

                _ASSKerning_SelectedItem = value;
                OnPropertyChanged("ASSKerning_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ASSKerning_IsEnabled = true;
        public bool ASSKerning_IsEnabled
        {
            get { return _ASSKerning_IsEnabled; }
            set
            {
                if (_ASSKerning_IsEnabled == value)
                {
                    return;
                }

                _ASSKerning_IsEnabled = value;
                OnPropertyChanged("ASSKerning_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Embedded Fonts
        // -------------------------
        // Item Source
        private List<string> _EmbeddedFonts_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> EmbeddedFonts_Items
        {
            get { return _EmbeddedFonts_Items; }
            set
            {
                _EmbeddedFonts_Items = value;
                OnPropertyChanged("EmbeddedFonts_Items");
            }
        }

        // Selected Item
        private string _EmbeddedFonts_SelectedItem { get; set; }
        public string EmbeddedFonts_SelectedItem
        {
            get { return _EmbeddedFonts_SelectedItem; }
            set
            {
                if (_EmbeddedFonts_SelectedItem == value)
                {
                    return;
                }

                _EmbeddedFonts_SelectedItem = value;
                OnPropertyChanged("EmbeddedFonts_SelectedItem");
            }
        }

        // Controls Enable
        private bool _EmbeddedFonts_IsEnabled = true;
        public bool EmbeddedFonts_IsEnabled
        {
            get { return _EmbeddedFonts_IsEnabled; }
            set
            {
                if (_EmbeddedFonts_IsEnabled == value)
                {
                    return;
                }

                _EmbeddedFonts_IsEnabled = value;
                OnPropertyChanged("EmbeddedFonts_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Fonts
        // -------------------------
        // Item Source
        private List<string> _Font_Items = new List<string>()
        {
        };
        public List<string> Font_Items
        {
            get { return _Font_Items; }
            set
            {
                _Font_Items = value;
                OnPropertyChanged("Font_Items");
            }
        }

        // Selected Item
        private string _Font_SelectedItem { get; set; }
        public string Font_SelectedItem
        {
            get { return _Font_SelectedItem; }
            set
            {
                if (_Font_SelectedItem == value)
                {
                    return;
                }

                _Font_SelectedItem = value;
                OnPropertyChanged("Font_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Fonts_IsEnabled = true;
        public bool Fonts_IsEnabled
        {
            get { return _Fonts_IsEnabled; }
            set
            {
                if (_Fonts_IsEnabled == value)
                {
                    return;
                }

                _Fonts_IsEnabled = value;
                OnPropertyChanged("Fonts_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles FontSize
        // -------------------------
        // Item Source
        private List<string> _FontSize_Items = new List<string>()
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
            "26",
            "24",
            "22",
        };
        public List<string> FontSize_Items
        {
            get { return _FontSize_Items; }
            set
            {
                _FontSize_Items = value;
                OnPropertyChanged("FontSize_Items");
            }
        }

        // Selected Item
        private string _FontSize_SelectedItem { get; set; }
        public string FontSize_SelectedItem
        {
            get { return _FontSize_SelectedItem; }
            set
            {
                if (_FontSize_SelectedItem == value)
                {
                    return;
                }

                _FontSize_SelectedItem = value;
                OnPropertyChanged("FontSize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _FontSize_IsEnabled = true;
        public bool FontSize_IsEnabled
        {
            get { return _FontSize_IsEnabled; }
            set
            {
                if (_FontSize_IsEnabled == value)
                {
                    return;
                }

                _FontSize_IsEnabled = value;
                OnPropertyChanged("FontSize_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Font Color
        // -------------------------
        // Text
        private string _FontColor_Text;
        public string FontColor_Text
        {
            get { return _FontColor_Text; }
            set
            {
                if (_FontColor_Text == value)
                {
                    return;
                }

                _FontColor_Text = value;
                OnPropertyChanged("FontColor_Text");
            }
        }

        // Controls Enable
        private bool _FontColor_IsEnabled = true;
        public bool FontColor_IsEnabled
        {
            get { return _FontColor_IsEnabled; }
            set
            {
                if (_FontColor_IsEnabled == value)
                {
                    return;
                }

                _FontColor_IsEnabled = value;
                OnPropertyChanged("FontColor_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Border Size
        // -------------------------
        // Item Source
        private List<string> _BorderSize_Items = new List<string>()
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
        public List<string> BorderSize_Items
        {
            get { return _BorderSize_Items; }
            set
            {
                _BorderSize_Items = value;
                OnPropertyChanged("BorderSize_Items");
            }
        }

        // Selected Item
        private string _BorderSize_SelectedItem { get; set; }
        public string BorderSize_SelectedItem
        {
            get { return _BorderSize_SelectedItem; }
            set
            {
                if (_BorderSize_SelectedItem == value)
                {
                    return;
                }

                _BorderSize_SelectedItem = value;
                OnPropertyChanged("BorderSize_SelectedItem");
            }
        }

        // Controls Enable
        private bool _BorderSize_IsEnabled = true;
        public bool BorderSize_IsEnabled
        {
            get { return _BorderSize_IsEnabled; }
            set
            {
                if (_BorderSize_IsEnabled == value)
                {
                    return;
                }

                _BorderSize_IsEnabled = value;
                OnPropertyChanged("BorderSize_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Border Color
        // -------------------------
        // Text
        private string _BorderColor_Text;
        public string BorderColor_Text
        {
            get { return _BorderColor_Text; }
            set
            {
                if (_BorderColor_Text == value)
                {
                    return;
                }

                _BorderColor_Text = value;
                OnPropertyChanged("BorderColor_Text");
            }
        }

        // Controls Enable
        private bool _BorderColor_IsEnabled = true;
        public bool BorderColor_IsEnabled
        {
            get { return _BorderColor_IsEnabled; }
            set
            {
                if (_BorderColor_IsEnabled == value)
                {
                    return;
                }

                _BorderColor_IsEnabled = value;
                OnPropertyChanged("BorderColor_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Shadow Offset
        // -------------------------
        // Value
        private double? _ShadowOffset_Value;
        public double? ShadowOffset_Value
        {
            get { return _ShadowOffset_Value; }
            set
            {
                if (_ShadowOffset_Value == value)
                {
                    return;
                }

                _ShadowOffset_Value = value;
                OnPropertyChanged("ShadowOffset_Value");
            }
        }
        // Text
        private string _ShadowOffset_Text;
        public string ShadowOffset_Text
        {
            get { return _ShadowOffset_Text; }
            set
            {
                if (_ShadowOffset_Text == value)
                {
                    return;
                }

                _ShadowOffset_Text = value;
                OnPropertyChanged("ShadowOffset_Text");
            }
        }
        // Enabled
        private bool _ShadowOffset_IsEnabled = true;
        public bool ShadowOffset_IsEnabled
        {
            get { return _ShadowOffset_IsEnabled; }
            set
            {
                if (_ShadowOffset_IsEnabled == value)
                {
                    return;
                }

                _ShadowOffset_IsEnabled = value;
                OnPropertyChanged("ShadowOffset_IsEnabled");
            }
        }


        // -------------------------
        // Subtitles Shadow Color
        // -------------------------
        // Text
        private string _ShadowColor_Text;
        public string ShadowColor_Text
        {
            get { return _ShadowColor_Text; }
            set
            {
                if (_ShadowColor_Text == value)
                {
                    return;
                }

                _ShadowColor_Text = value;
                OnPropertyChanged("ShadowColor_Text");
            }
        }

        // Controls Enable
        private bool _ShadowColor_IsEnabled = true;
        public bool ShadowColor_IsEnabled
        {
            get { return _ShadowColor_IsEnabled; }
            set
            {
                if (_ShadowColor_IsEnabled == value)
                {
                    return;
                }

                _ShadowColor_IsEnabled = value;
                OnPropertyChanged("ShadowColor_IsEnabled");
            }
        }



        // ----------------------------------------------------------------------------------------------------
        // Settings Window
        // ----------------------------------------------------------------------------------------------------

        // -------------------------
        // mpv Path - TextBox
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


        // --------------------------------------------------
        // mpv Config Path - TextBox
        // --------------------------------------------------
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


        // --------------------------------------------------
        // Presets Path - TextBox
        // --------------------------------------------------
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
        // Subtitle Language
        // -------------------------
        //public static List<string> listSubtitlesLang = ViewModel.Main.listLanguages;

        //public static ObservableCollection<string> _subsLangItems = new ObservableCollection<string>(listSubtitlesLang);
        //public static ObservableCollection<string> LanguageItems
        //{
        //    get { return _subsLangItems; }
        //    set { _subsLangItems = value; }
        //}

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
