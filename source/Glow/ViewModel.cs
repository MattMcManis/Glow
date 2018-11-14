/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017, 2018 Matt McManis
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

namespace Glow
{
    public class ViewModel : INotifyPropertyChanged
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
        /// View Model Main
        /// </summary>
        public ViewModel()
        {
            // -------------------------
            // Defaults
            // -------------------------
            // Video
            VideoDriver_SelectedItem = "default";
            Profiles_SelectedItem = "Default";
            Fonts_SelectedItem = "default";

            UpdateAutoCheck_IsChecked = true;
        }


        // -------------------------
        // Update Auto Check - Toggle
        // -------------------------
        // Checked
        private bool _UpdateAutoCheck_IsChecked;
        public bool UpdateAutoCheck_IsChecked
        {
            get { return _UpdateAutoCheck_IsChecked; }
            set
            {
                if (_UpdateAutoCheck_IsChecked == value) return;

                _UpdateAutoCheck_IsChecked = value;
            }
        }
        // Enabled
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


        // --------------------------------------------------
        // Update Auto Check - TextBlock
        // --------------------------------------------------
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


        // -------------------------
        // Fonts
        // -------------------------
        private static List<string> _Fonts_Items = new List<string>();
        public static InstalledFontCollection installedFonts = new InstalledFontCollection();
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


        // -------------------------
        // Presets
        // -------------------------
        // Item Source
        public List<string> _Presets_Items = new List<string>()
        {
            "Default",
            "Ultra",
            "High",
            "Medium",
            "Low",
            // Debug
        };

        public List<string> Presets_Items
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
                OnPropertyChanged("Presets_SelectedIndex");
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
        // Custom Profiles
        // -------------------------
        // Item Source
        public static List<string> _Profiles_Items = new List<string>();
        public List<string> Profiles_Items
        {
            get { return _Profiles_Items; }
            set
            {
                _Profiles_Items = value;
                OnPropertyChanged("Profiles_Items");
            }
        }

        // Selected Index
        private int _Profiles_SelectedIndex { get; set; }
        public int Profiles_SelectedIndex
        {
            get { return _Profiles_SelectedIndex; }
            set
            {
                if (_Profiles_SelectedIndex == value)
                {
                    return;
                }

                _Profiles_SelectedIndex = value;
                OnPropertyChanged("Profiles_SelectedIndex");
            }
        }

        // Selected Item
        private string _Profiles_SelectedItem { get; set; }
        public string Profiles_SelectedItem
        {
            get { return _Profiles_SelectedItem; }
            set
            {
                if (_Profiles_SelectedItem == value)
                {
                    return;
                }

                _Profiles_SelectedItem = value;
                OnPropertyChanged("Profiles_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Profiles_IsEnabled = true;
        public bool Profiles_IsEnabled
        {
            get { return _Profiles_IsEnabled; }
            set
            {
                if (_Profiles_IsEnabled == value)
                {
                    return;
                }

                _Profiles_IsEnabled = value;
                OnPropertyChanged("Profiles_IsEnabled");
            }
        }


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
        // Audio Language
        // -------------------------
        public static List<string> listAudioLang = listLanguages;
        public static ObservableCollection<string> _audioLangItems = new ObservableCollection<string>(listAudioLang);
        public static ObservableCollection<string> AudioLanguageItems
        {
            get { return _audioLangItems; }
            set { _audioLangItems = value; }
        }


        // -------------------------
        // Subtitle Language
        // -------------------------
        public static List<string> listSubtitlesLang = listLanguages;

        public static ObservableCollection<string> _subsLangItems = new ObservableCollection<string>(listSubtitlesLang);
        public static ObservableCollection<string> SubtitlesLanguageItems
        {
            get { return _subsLangItems; }
            set { _subsLangItems = value; }
        }


        // --------------------------------------------------
        // Video
        // --------------------------------------------------
        // -------------------------
        // Video Driver
        // -------------------------
        // Item Source
        private List<string> _VideoDriver_Items = new List<string>()
        {
            "default",
            "gpu",
            "gpu-hq",
            //"opengl", // old
            //"opengl-hq", // old
            "direct3d",
            "vaapi",
            "caca"
        };
        public List<string> VideoDriver_Items
        {
            get { return _VideoDriver_Items; }
            set
            {
                _VideoDriver_Items = value;
                OnPropertyChanged("VideoDriver_Items");
            }
        }

        // Selected Index
        private int _VideoDriver_SelectedIndex { get; set; }
        public int VideoDriver_SelectedIndex
        {
            get { return _VideoDriver_SelectedIndex; }
            set
            {
                if (_VideoDriver_SelectedIndex == value)
                {
                    return;
                }

                _VideoDriver_SelectedIndex = value;
                OnPropertyChanged("VideoDriver_SelectedIndex");
            }
        }

        // Selected Item
        private string _VideoDriver_SelectedItem { get; set; }
        public string VideoDriver_SelectedItem
        {
            get { return _VideoDriver_SelectedItem; }
            set
            {
                if (_VideoDriver_SelectedItem == value)
                {
                    return;
                }

                _VideoDriver_SelectedItem = value;
                OnPropertyChanged("VideoDriver_SelectedItem");
            }
        }

        // Controls Enable
        private bool _VideoDriver_IsEnabled = true;
        public bool VideoDriver_IsEnabled
        {
            get { return _VideoDriver_IsEnabled; }
            set
            {
                if (_VideoDriver_IsEnabled == value)
                {
                    return;
                }

                _VideoDriver_IsEnabled = value;
                OnPropertyChanged("VideoDriver_IsEnabled");
            }
        }

        // -------------------------
        // Video Driver API
        // -------------------------
        // Item Source
        private List<string> _VideoDriverAPI_Items = new List<string>()
        {
            "default",
            "opengl",
            "vulkan",
            "d3d11"
        };
        public List<string> VideoDriverAPI_Items
        {
            get { return _VideoDriverAPI_Items; }
            set
            {
                _VideoDriverAPI_Items = value;
                OnPropertyChanged("VideoDriverAPI_Items");
            }
        }

        // Selected Index
        private int _VideoDriverAPI_SelectedIndex { get; set; }
        public int VideoDriverAPI_SelectedIndex
        {
            get { return _VideoDriverAPI_SelectedIndex; }
            set
            {
                if (_VideoDriverAPI_SelectedIndex == value)
                {
                    return;
                }

                _VideoDriverAPI_SelectedIndex = value;
                OnPropertyChanged("VideoDriverAPI_SelectedIndex");
            }
        }

        // Selected Item
        private string _VideoDriverAPI_SelectedItem { get; set; }
        public string VideoDriverAPI_SelectedItem
        {
            get { return _VideoDriverAPI_SelectedItem; }
            set
            {
                if (_VideoDriverAPI_SelectedItem == value)
                {
                    return;
                }

                _VideoDriverAPI_SelectedItem = value;
                OnPropertyChanged("VideoDriverAPI_SelectedItem");
            }
        }

        // Controls Enable
        private bool _VideoDriverAPI_IsEnabled = true;
        public bool VideoDriverAPI_IsEnabled
        {
            get { return _VideoDriverAPI_IsEnabled; }
            set
            {
                if (_VideoDriverAPI_IsEnabled == value)
                {
                    return;
                }

                _VideoDriverAPI_IsEnabled = value;
                OnPropertyChanged("VideoDriverAPI_IsEnabled");
            }
        }

        // -------------------------
        // OpenGL PBO
        // -------------------------
        // Item Source
        private List<string> _OpenGLPBO_Items = new List<string>()
        {
            "default",
            "yes",
            "no"
        };
        public List<string> OpenGLPBO_Items
        {
            get { return _OpenGLPBO_Items; }
            set
            {
                _OpenGLPBO_Items = value;
                OnPropertyChanged("OpenGLPBO_Items");
            }
        }

        // Selected Index
        private int _OpenGLPBO_SelectedIndex { get; set; }
        public int OpenGLPBO_SelectedIndex
        {
            get { return _OpenGLPBO_SelectedIndex; }
            set
            {
                if (_OpenGLPBO_SelectedIndex == value)
                {
                    return;
                }

                _OpenGLPBO_SelectedIndex = value;
                OnPropertyChanged("OpenGLPBO_SelectedIndex");
            }
        }

        // Selected Item
        private string _OpenGLPBO_SelectedItem { get; set; }
        public string OpenGLPBO_SelectedItem
        {
            get { return _OpenGLPBO_SelectedItem; }
            set
            {
                if (_OpenGLPBO_SelectedItem == value)
                {
                    return;
                }

                _OpenGLPBO_SelectedItem = value;
                OnPropertyChanged("OpenGLPBO_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OpenGLPBO_IsEnabled = true;
        public bool OpenGLPBO_IsEnabled
        {
            get { return _OpenGLPBO_IsEnabled; }
            set
            {
                if (_OpenGLPBO_IsEnabled == value)
                {
                    return;
                }

                _OpenGLPBO_IsEnabled = value;
                OnPropertyChanged("OpenGLPBO_IsEnabled");
            }
        }


        // -------------------------
        // OpenGL PBO Format
        // -------------------------
        // Item Source
        private List<string> _OpenGLPBOFormat_Items = new List<string>()
        {
            "default",
            "off",
            "rgb8",
            "rgb10",
            "rgb10_a2",
            "rgb16",
            "rgb16f",
            "rgb32f",
            "rgba12",
            "rgba16",
            "rgba16f",
            "rgba32f",
        };
        public List<string> OpenGLPBOFormat_Items
        {
            get { return _OpenGLPBOFormat_Items; }
            set
            {
                _OpenGLPBOFormat_Items = value;
                OnPropertyChanged("OpenGLPBOFormat_Items");
            }
        }

        // Selected Index
        private int _OpenGLPBOFormat_SelectedIndex { get; set; }
        public int OpenGLPBOFormat_SelectedIndex
        {
            get { return _OpenGLPBOFormat_SelectedIndex; }
            set
            {
                if (_OpenGLPBOFormat_SelectedIndex == value)
                {
                    return;
                }

                _OpenGLPBOFormat_SelectedIndex = value;
                OnPropertyChanged("OpenGLPBOFormat_SelectedIndex");
            }
        }

        // Selected Item
        private string _OpenGLPBOFormat_SelectedItem { get; set; }
        public string OpenGLPBOFormat_SelectedItem
        {
            get { return _OpenGLPBOFormat_SelectedItem; }
            set
            {
                if (_OpenGLPBOFormat_SelectedItem == value)
                {
                    return;
                }

                _OpenGLPBOFormat_SelectedItem = value;
                OnPropertyChanged("OpenGLPBOFormat_SelectedItem");
            }
        }

        // Controls Enable
        private bool _OpenGLPBOFormat_IsEnabled = true;
        public bool OpenGLPBOFormat_IsEnabled
        {
            get { return _OpenGLPBOFormat_IsEnabled; }
            set
            {
                if (_OpenGLPBOFormat_IsEnabled == value)
                {
                    return;
                }

                _OpenGLPBOFormat_IsEnabled = value;
                OnPropertyChanged("OpenGLPBOFormat_IsEnabled");
            }
        }

        // -------------------------
        // HW Decoder
        // -------------------------
        // Item Source
        private List<string> _HWDecoder_Items = new List<string>()
        {
            "default",
            "no",
            "yes",
            "auto-copy",
            "dxva2",
            "dxva2-copy",
            "d3d11va",
            "d3d11va-copy",
            "cuda",
            "cuda-copy",
            "crystalhd"
        };
        public List<string> HWDecoder_Items
        {
            get { return _HWDecoder_Items; }
            set
            {
                _HWDecoder_Items = value;
                OnPropertyChanged("HWDecoder_Items");
            }
        }

        // Selected Index
        private int _HWDecoder_SelectedIndex { get; set; }
        public int HWDecoder_SelectedIndex
        {
            get { return _HWDecoder_SelectedIndex; }
            set
            {
                if (_HWDecoder_SelectedIndex == value)
                {
                    return;
                }

                _HWDecoder_SelectedIndex = value;
                OnPropertyChanged("HWDecoder_SelectedIndex");
            }
        }

        // Selected Item
        private string _HWDecoder_SelectedItem { get; set; }
        public string HWDecoder_SelectedItem
        {
            get { return _HWDecoder_SelectedItem; }
            set
            {
                if (_HWDecoder_SelectedItem == value)
                {
                    return;
                }

                _HWDecoder_SelectedItem = value;
                OnPropertyChanged("HWDecoder_SelectedItem");
            }
        }

        // Controls Enable
        private bool _HWDecoder_IsEnabled = true;
        public bool HWDecoder_IsEnabled
        {
            get { return _HWDecoder_IsEnabled; }
            set
            {
                if (_HWDecoder_IsEnabled == value)
                {
                    return;
                }

                _HWDecoder_IsEnabled = value;
                OnPropertyChanged("HWDecoder_IsEnabled");
            }
        }


        // -------------------------
        // ICC Profile
        // -------------------------
        // Item Source
        private List<string> _ICCProfile_Items = new List<string>()
        {
            "default",
            "auto",
            "select",
        };
        public List<string> ICCProfile_Items
        {
            get { return _ICCProfile_Items; }
            set
            {
                _ICCProfile_Items = value;
                OnPropertyChanged("ICCProfile_Items");
            }
        }

        // Selected Index
        private int _ICCProfile_SelectedIndex { get; set; }
        public int ICCProfile_SelectedIndex
        {
            get { return _ICCProfile_SelectedIndex; }
            set
            {
                if (_ICCProfile_SelectedIndex == value)
                {
                    return;
                }

                _ICCProfile_SelectedIndex = value;
                OnPropertyChanged("ICCProfile_SelectedIndex");
            }
        }

        // Selected Item
        private string _ICCProfile_SelectedItem { get; set; }
        public string ICCProfile_SelectedItem
        {
            get { return _ICCProfile_SelectedItem; }
            set
            {
                if (_ICCProfile_SelectedItem == value)
                {
                    return;
                }

                _ICCProfile_SelectedItem = value;
                OnPropertyChanged("ICCProfile_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ICCProfile_IsEnabled = true;
        public bool ICCProfile_IsEnabled
        {
            get { return _ICCProfile_IsEnabled; }
            set
            {
                if (_ICCProfile_IsEnabled == value)
                {
                    return;
                }

                _ICCProfile_IsEnabled = value;
                OnPropertyChanged("ICCProfile_IsEnabled");
            }
        }





        // --------------------------------------------------
        // Settings Window
        // --------------------------------------------------

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
        // Profiles Path - TextBox
        // --------------------------------------------------
        // Text
        private string _ProfilesPath_Text;
        public string ProfilesPath_Text
        {
            get { return _ProfilesPath_Text; }
            set
            {
                if (_ProfilesPath_Text == value)
                {
                    return;
                }

                _ProfilesPath_Text = value;
                OnPropertyChanged("ProfilesPath_Text");
            }
        }

        // Controls Enable
        private bool _ProfilesPath_IsEnabled = true;
        public bool ProfilesPath_IsEnabled
        {
            get { return _ProfilesPath_IsEnabled; }
            set
            {
                if (_ProfilesPath_IsEnabled == value)
                {
                    return;
                }

                _ProfilesPath_IsEnabled = value;
                OnPropertyChanged("ProfilesPath_IsEnabled");
            }
        }


        // --------------------------------------------------
        // Theme
        // --------------------------------------------------
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

        // Selected Index
        private int _Theme_SelectedIndex { get; set; }
        public int Theme_SelectedIndex
        {
            get { return _Theme_SelectedIndex; }
            set
            {
                if (_Theme_SelectedIndex == value)
                {
                    return;
                }

                _Theme_SelectedIndex = value;
                OnPropertyChanged("Theme_SelectedIndex");
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
