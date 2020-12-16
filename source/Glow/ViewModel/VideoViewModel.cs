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
    public class Video : INotifyPropertyChanged
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
        public Video()
        {
            // -------------------------
            // Defaults
            // -------------------------
            VideoDriver_SelectedItem = "default";
            VideoDriverAPI_SelectedItem = "default";
            OpenGLPBO_SelectedItem = "default";
            OpenGLPBOFormat_SelectedItem = "default";
            HWDecoder_SelectedItem = "default";
            ICCProfile_SelectedItem = "default";
            DisplayPrimaries_SelectedItem = "default";
            TransferCharacteristics_SelectedItem = "default";
            ColorSpace_SelectedItem = "default";
            ColorRange_SelectedItem = "default";
            Deinterlace_SelectedItem = "default";
            Interpolation_SelectedItem = "default";
            VideoSync_SelectedItem = "default";
            Framedrop_SelectedItem = "default";

            Brightness_Value = 0;
            Contrast_Value = 0;
            Hue_Value = 0;
            Saturation_Value = 0;
            Gamma_Value = 0;

            Deband_SelectedItem = "default";
            DebandGrain_Text = "";
            Dither_SelectedItem = "default";

            Sigmoid_SelectedItem = "default";
            Scale_SelectedItem = "default";

            ScaleAntiring_Value = 0;
            ChromaScale_SelectedItem = "default";
            ChromaAntiring_Value = 0;
            Downscale_SelectedItem = "default";
            DownscaleAntiring_Value = 0;
            InterpolationScale_SelectedItem = "default";
            InterpolationScaleAntiring_Value = 0;
            SoftwareScaler_SelectedItem = "default";
        }


        // ----------------------------------------------------------------------------------------------------
        // Video
        // ----------------------------------------------------------------------------------------------------
        // -------------------------
        // Video Driver
        // -------------------------
        // Item Source
        private List<string> _VideoDriver_Items = new List<string>()
        {
            "default",
            "gpu",
            "gpu-hq",
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
            "auto",
            "auto-copy",
            "auto-safe",
            "crystalhd",
            "cuda",
            "cuda-copy",
            "d3d11va",
            "d3d11va-copy",
            "dxva2",
            "dxva2-copy",
            "nvdec",
            "nvdec-copy"
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

        // Controls IsEditable
        private bool _ICCProfile_IsEditable = false;
        public bool ICCProfile_IsEditable
        {
            get { return _ICCProfile_IsEditable; }
            set
            {
                if (_ICCProfile_IsEditable == value)
                {
                    return;
                }

                _ICCProfile_IsEditable = value;
                OnPropertyChanged("ICCProfile_IsEditable");
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


        // -------------------------
        // Display Primaries
        // -------------------------
        // Item Source
        private List<string> _DisplayPrimaries_Items = new List<string>()
        {
            "default",
            "auto",
            "bt.470m",
            "bt.601-525",
            "bt.601-625",
            "bt.709",
            "bt.2020",
            "apple",
            "adobe",
            "prophoto",
            "cie1931",
            "dci-p3",
            "v-gamut",
            "s-gamut"
        };
        public List<string> DisplayPrimaries_Items
        {
            get { return _DisplayPrimaries_Items; }
            set
            {
                _DisplayPrimaries_Items = value;
                OnPropertyChanged("DisplayPrimaries_Items");
            }
        }

        // Selected Item
        private string _DisplayPrimaries_SelectedItem { get; set; }
        public string DisplayPrimaries_SelectedItem
        {
            get { return _DisplayPrimaries_SelectedItem; }
            set
            {
                if (_DisplayPrimaries_SelectedItem == value)
                {
                    return;
                }

                _DisplayPrimaries_SelectedItem = value;
                OnPropertyChanged("DisplayPrimaries_SelectedItem");
            }
        }

        // Controls Enable
        private bool _DisplayPrimaries_IsEnabled = true;
        public bool DisplayPrimaries_IsEnabled
        {
            get { return _DisplayPrimaries_IsEnabled; }
            set
            {
                if (_DisplayPrimaries_IsEnabled == value)
                {
                    return;
                }

                _DisplayPrimaries_IsEnabled = value;
                OnPropertyChanged("DisplayPrimaries_IsEnabled");
            }
        }


        // -------------------------
        // Transfer Characteristics
        // -------------------------
        // Item Source
        private List<string> _TransferCharacteristics_Items = new List<string>()
        {
            "default",
            "auto",
            "bt.1886",
            "srgb",
            "linear",
            "gamma1.8",
            "gamma2.2",
            "gamma2.8",
            "prophoto",
            "pq",
            "hlg",
            "v-log",
            "s-log1",
            "s-log2"
        };
        public List<string> TransferCharacteristics_Items
        {
            get { return _TransferCharacteristics_Items; }
            set
            {
                _TransferCharacteristics_Items = value;
                OnPropertyChanged("TransferCharacteristics_Items");
            }
        }

        // Selected Item
        private string _TransferCharacteristics_SelectedItem { get; set; }
        public string TransferCharacteristics_SelectedItem
        {
            get { return _TransferCharacteristics_SelectedItem; }
            set
            {
                if (_TransferCharacteristics_SelectedItem == value)
                {
                    return;
                }

                _TransferCharacteristics_SelectedItem = value;
                OnPropertyChanged("TransferCharacteristics_SelectedItem");
            }
        }

        // Controls Enable
        private bool _TransferCharacteristics_IsEnabled = true;
        public bool TransferCharacteristics_IsEnabled
        {
            get { return _TransferCharacteristics_IsEnabled; }
            set
            {
                if (_TransferCharacteristics_IsEnabled == value)
                {
                    return;
                }

                _TransferCharacteristics_IsEnabled = value;
                OnPropertyChanged("TransferCharacteristics_IsEnabled");
            }
        }


        // -------------------------
        // ColorSpace
        // -------------------------
        // Item Source
        private List<string> _ColorSpace_Items = new List<string>()
        {
            "default",
            "bt.601",
            "bt.709",
            "bt.2020-ncl",
            "bt.2020-cl",
            "mpte-240m"
        };
        public List<string> ColorSpace_Items
        {
            get { return _ColorSpace_Items; }
            set
            {
                _ColorSpace_Items = value;
                OnPropertyChanged("ColorSpace_Items");
            }
        }

        // Selected Item
        private string _ColorSpace_SelectedItem { get; set; }
        public string ColorSpace_SelectedItem
        {
            get { return _ColorSpace_SelectedItem; }
            set
            {
                if (_ColorSpace_SelectedItem == value)
                {
                    return;
                }

                _ColorSpace_SelectedItem = value;
                OnPropertyChanged("ColorSpace_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ColorSpace_IsEnabled = true;
        public bool ColorSpace_IsEnabled
        {
            get { return _ColorSpace_IsEnabled; }
            set
            {
                if (_ColorSpace_IsEnabled == value)
                {
                    return;
                }

                _ColorSpace_IsEnabled = value;
                OnPropertyChanged("ColorSpace_IsEnabled");
            }
        }


        // -------------------------
        // Color Range
        // -------------------------
        // Item Source
        private List<string> _ColorRange_Items = new List<string>()
        {
            "default",
            "limited",
            "full"
        };
        public List<string> ColorRange_Items
        {
            get { return _ColorRange_Items; }
            set
            {
                _ColorRange_Items = value;
                OnPropertyChanged("ColorRange_Items");
            }
        }

        // Selected Item
        private string _ColorRange_SelectedItem { get; set; }
        public string ColorRange_SelectedItem
        {
            get { return _ColorRange_SelectedItem; }
            set
            {
                if (_ColorRange_SelectedItem == value)
                {
                    return;
                }

                _ColorRange_SelectedItem = value;
                OnPropertyChanged("ColorRange_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ColorRange_IsEnabled = true;
        public bool ColorRange_IsEnabled
        {
            get { return _ColorRange_IsEnabled; }
            set
            {
                if (_ColorRange_IsEnabled == value)
                {
                    return;
                }

                _ColorRange_IsEnabled = value;
                OnPropertyChanged("ColorRange_IsEnabled");
            }
        }


        // -------------------------
        // Deinterlace
        // -------------------------
        // Item Source
        private List<string> _Deinterlace_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Deinterlace_Items
        {
            get { return _Deinterlace_Items; }
            set
            {
                _Deinterlace_Items = value;
                OnPropertyChanged("Deinterlace_Items");
            }
        }

        // Selected Item
        private string _Deinterlace_SelectedItem { get; set; }
        public string Deinterlace_SelectedItem
        {
            get { return _Deinterlace_SelectedItem; }
            set
            {
                if (_Deinterlace_SelectedItem == value)
                {
                    return;
                }

                _Deinterlace_SelectedItem = value;
                OnPropertyChanged("Deinterlace_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Deinterlace_IsEnabled = true;
        public bool Deinterlace_IsEnabled
        {
            get { return _Deinterlace_IsEnabled; }
            set
            {
                if (_Deinterlace_IsEnabled == value)
                {
                    return;
                }

                _Deinterlace_IsEnabled = value;
                OnPropertyChanged("Deinterlace_IsEnabled");
            }
        }


        // -------------------------
        // Interpolation
        // -------------------------
        // Item Source
        private List<string> _Interpolation_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Interpolation_Items
        {
            get { return _Interpolation_Items; }
            set
            {
                _Interpolation_Items = value;
                OnPropertyChanged("Interpolation_Items");
            }
        }

        // Selected Item
        private string _Interpolation_SelectedItem { get; set; }
        public string Interpolation_SelectedItem
        {
            get { return _Interpolation_SelectedItem; }
            set
            {
                if (_Interpolation_SelectedItem == value)
                {
                    return;
                }

                _Interpolation_SelectedItem = value;
                OnPropertyChanged("Interpolation_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Interpolation_IsEnabled = true;
        public bool Interpolation_IsEnabled
        {
            get { return _Interpolation_IsEnabled; }
            set
            {
                if (_Interpolation_IsEnabled == value)
                {
                    return;
                }

                _Interpolation_IsEnabled = value;
                OnPropertyChanged("Interpolation_IsEnabled");
            }
        }


        // -------------------------
        // VideoSync
        // -------------------------
        // Item Source
        private List<string> _VideoSync_Items = new List<string>()
        {
            "default",
            "off",
            "display-resample",
            "display-resample-vdrop",
            "display-resample-desync",
            "display-vdrop",
            "display-adrop",
            "display-desync",
            "desync",
            "audio",
        };
        public List<string> VideoSync_Items
        {
            get { return _VideoSync_Items; }
            set
            {
                _VideoSync_Items = value;
                OnPropertyChanged("VideoSync_Items");
            }
        }

        // Selected Item
        private string _VideoSync_SelectedItem { get; set; }
        public string VideoSync_SelectedItem
        {
            get { return _VideoSync_SelectedItem; }
            set
            {
                if (_VideoSync_SelectedItem == value)
                {
                    return;
                }

                _VideoSync_SelectedItem = value;
                OnPropertyChanged("VideoSync_SelectedItem");
            }
        }

        // Controls Enable
        private bool _VideoSync_IsEnabled = true;
        public bool VideoSync_IsEnabled
        {
            get { return _VideoSync_IsEnabled; }
            set
            {
                if (_VideoSync_IsEnabled == value)
                {
                    return;
                }

                _VideoSync_IsEnabled = value;
                OnPropertyChanged("VideoSync_IsEnabled");
            }
        }


        // -------------------------
        // Framedrop
        // -------------------------
        // Item Source
        private List<string> _Framedrop_Items = new List<string>()
        {
            "default",
            "no",
            "vo",
            "decoder",
            "decoder+vo",
        };
        public List<string> Framedrop_Items
        {
            get { return _Framedrop_Items; }
            set
            {
                _Framedrop_Items = value;
                OnPropertyChanged("Framedrop_Items");
            }
        }

        // Selected Item
        private string _Framedrop_SelectedItem { get; set; }
        public string Framedrop_SelectedItem
        {
            get { return _Framedrop_SelectedItem; }
            set
            {
                if (_Framedrop_SelectedItem == value)
                {
                    return;
                }

                _Framedrop_SelectedItem = value;
                OnPropertyChanged("Framedrop_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Framedrop_IsEnabled = true;
        public bool Framedrop_IsEnabled
        {
            get { return _Framedrop_IsEnabled; }
            set
            {
                if (_Framedrop_IsEnabled == value)
                {
                    return;
                }

                _Framedrop_IsEnabled = value;
                OnPropertyChanged("Framedrop_IsEnabled");
            }
        }


        // -------------------------
        // Brightness
        // -------------------------
        // Value
        private double _Brightness_Value;
        public double Brightness_Value
        {
            get { return _Brightness_Value; }
            set
            {
                if (_Brightness_Value == value)
                {
                    return;
                }

                _Brightness_Value = value;
                OnPropertyChanged("Brightness_Value");
            }
        }

        // Text
        private string _Brightness_Text;
        public string Brightness_Text
        {
            get { return _Brightness_Text; }
            set
            {
                if (_Brightness_Text == value)
                {
                    return;
                }

                _Brightness_Text = value;
                OnPropertyChanged("Brightness_Text");
            }
        }

        // Controls Enable
        private bool _Brightness_IsEnabled = true;
        public bool Brightness_IsEnabled
        {
            get { return _Brightness_IsEnabled; }
            set
            {
                if (_Brightness_IsEnabled == value)
                {
                    return;
                }

                _Brightness_IsEnabled = value;
                OnPropertyChanged("Brightness_IsEnabled");
            }
        }


        // -------------------------
        // Contrast
        // -------------------------
        // Value
        private double _Contrast_Value;
        public double Contrast_Value
        {
            get { return _Contrast_Value; }
            set
            {
                if (_Contrast_Value == value)
                {
                    return;
                }

                _Contrast_Value = value;
                OnPropertyChanged("Contrast_Value");
            }
        }

        // Text
        private string _Contrast_Text;
        public string Contrast_Text
        {
            get { return _Contrast_Text; }
            set
            {
                if (_Contrast_Text == value)
                {
                    return;
                }

                _Contrast_Text = value;
                OnPropertyChanged("Contrast_Text");
            }
        }

        // Controls Enable
        private bool _Contrast_IsEnabled = true;
        public bool Contrast_IsEnabled
        {
            get { return _Contrast_IsEnabled; }
            set
            {
                if (_Contrast_IsEnabled == value)
                {
                    return;
                }

                _Contrast_IsEnabled = value;
                OnPropertyChanged("Contrast_IsEnabled");
            }
        }


        // -------------------------
        // Hue
        // -------------------------
        // Value
        private double _Hue_Value;
        public double Hue_Value
        {
            get { return _Hue_Value; }
            set
            {
                if (_Hue_Value == value)
                {
                    return;
                }

                _Hue_Value = value;
                OnPropertyChanged("Hue_Value");
            }
        }

        // Text
        private string _Hue_Text;
        public string Hue_Text
        {
            get { return _Hue_Text; }
            set
            {
                if (_Hue_Text == value)
                {
                    return;
                }

                _Hue_Text = value;
                OnPropertyChanged("Hue_Text");
            }
        }

        // Controls Enable
        private bool _Hue_IsEnabled = true;
        public bool Hue_IsEnabled
        {
            get { return _Hue_IsEnabled; }
            set
            {
                if (_Hue_IsEnabled == value)
                {
                    return;
                }

                _Hue_IsEnabled = value;
                OnPropertyChanged("Hue_IsEnabled");
            }
        }


        // -------------------------
        // Saturation TextBox
        // -------------------------
        // Value
        private double _Saturation_Value;
        public double Saturation_Value
        {
            get { return _Saturation_Value; }
            set
            {
                if (_Saturation_Value == value)
                {
                    return;
                }

                _Saturation_Value = value;
                OnPropertyChanged("Saturation_Value");
            }
        }

        // Text
        private string _Saturation_Text;
        public string Saturation_Text
        {
            get { return _Saturation_Text; }
            set
            {
                if (_Saturation_Text == value)
                {
                    return;
                }

                _Saturation_Text = value;
                OnPropertyChanged("Saturation_Text");
            }
        }

        // Controls Enable
        private bool _Saturation_IsEnabled = true;
        public bool Saturation_IsEnabled
        {
            get { return _Saturation_IsEnabled; }
            set
            {
                if (_Saturation_IsEnabled == value)
                {
                    return;
                }

                _Saturation_IsEnabled = value;
                OnPropertyChanged("Saturation_IsEnabled");
            }
        }


        // -------------------------
        // Gamma TextBox
        // -------------------------
        // Value
        private double _Gamma_Value;
        public double Gamma_Value
        {
            get { return _Gamma_Value; }
            set
            {
                if (_Gamma_Value == value)
                {
                    return;
                }

                _Gamma_Value = value;
                OnPropertyChanged("Gamma_Value");
            }
        }

        // Text
        private string _Gamma_Text;
        public string Gamma_Text
        {
            get { return _Gamma_Text; }
            set
            {
                if (_Gamma_Text == value)
                {
                    return;
                }

                _Gamma_Text = value;
                OnPropertyChanged("Gamma_Text");
            }
        }

        // Controls Enable
        private bool _Gamma_IsEnabled = true;
        public bool Gamma_IsEnabled
        {
            get { return _Gamma_IsEnabled; }
            set
            {
                if (_Gamma_IsEnabled == value)
                {
                    return;
                }

                _Gamma_IsEnabled = value;
                OnPropertyChanged("Gamma_IsEnabled");
            }
        }


        // -------------------------
        // Deband
        // -------------------------
        // Item Source
        private List<string> _Deband_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Deband_Items
        {
            get { return _Deband_Items; }
            set
            {
                _Deband_Items = value;
                OnPropertyChanged("Deband_Items");
            }
        }

        // Selected Item
        private string _Deband_SelectedItem { get; set; }
        public string Deband_SelectedItem
        {
            get { return _Deband_SelectedItem; }
            set
            {
                if (_Deband_SelectedItem == value)
                {
                    return;
                }

                _Deband_SelectedItem = value;
                OnPropertyChanged("Deband_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Deband_IsEnabled = true;
        public bool Deband_IsEnabled
        {
            get { return _Deband_IsEnabled; }
            set
            {
                if (_Deband_IsEnabled == value)
                {
                    return;
                }

                _Deband_IsEnabled = value;
                OnPropertyChanged("Deband_IsEnabled");
            }
        }


        // -------------------------
        // Deband Grain TextBox
        // -------------------------
        // Text
        private string _DebandGrain_Text;
        public string DebandGrain_Text
        {
            get { return _DebandGrain_Text; }
            set
            {
                if (_DebandGrain_Text == value)
                {
                    return;
                }

                _DebandGrain_Text = value;
                OnPropertyChanged("DebandGrain_Text");
            }
        }

        // Controls Enable
        private bool _DebandGrain_IsEnabled = true;
        public bool DebandGrain_IsEnabled
        {
            get { return _DebandGrain_IsEnabled; }
            set
            {
                if (_DebandGrain_IsEnabled == value)
                {
                    return;
                }

                _DebandGrain_IsEnabled = value;
                OnPropertyChanged("DebandGrain_IsEnabled");
            }
        }


        // -------------------------
        // Dither
        // -------------------------
        // Item Source
        private List<string> _Dither_Items = new List<string>()
        {
            "default",
            "no",
            "auto",
            "8",
        };
        public List<string> Dither_Items
        {
            get { return _Dither_Items; }
            set
            {
                _Dither_Items = value;
                OnPropertyChanged("Dither_Items");
            }
        }

        // Selected Item
        private string _Dither_SelectedItem { get; set; }
        public string Dither_SelectedItem
        {
            get { return _Dither_SelectedItem; }
            set
            {
                if (_Dither_SelectedItem == value)
                {
                    return;
                }

                _Dither_SelectedItem = value;
                OnPropertyChanged("Dither_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Dither_IsEnabled = true;
        public bool Dither_IsEnabled
        {
            get { return _Dither_IsEnabled; }
            set
            {
                if (_Dither_IsEnabled == value)
                {
                    return;
                }

                _Dither_IsEnabled = value;
                OnPropertyChanged("Dither_IsEnabled");
            }
        }


        // -------------------------
        // Sigmoid
        // -------------------------
        // Item Source
        private List<string> _Sigmoid_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> Sigmoid_Items
        {
            get { return _Sigmoid_Items; }
            set
            {
                _Sigmoid_Items = value;
                OnPropertyChanged("Sigmoid_Items");
            }
        }

        // Selected Item
        private string _Sigmoid_SelectedItem { get; set; }
        public string Sigmoid_SelectedItem
        {
            get { return _Sigmoid_SelectedItem; }
            set
            {
                if (_Sigmoid_SelectedItem == value)
                {
                    return;
                }

                _Sigmoid_SelectedItem = value;
                OnPropertyChanged("Sigmoid_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Sigmoid_IsEnabled = true;
        public bool Sigmoid_IsEnabled
        {
            get { return _Sigmoid_IsEnabled; }
            set
            {
                if (_Sigmoid_IsEnabled == value)
                {
                    return;
                }

                _Sigmoid_IsEnabled = value;
                OnPropertyChanged("Sigmoid_IsEnabled");
            }
        }


        // -------------------------
        // Scale
        // -------------------------
        // Item Source
        private List<string> _Scale_Items = new List<string>()
        {
            "default",
            "off",
            "nearest",
            "linear",
            "bilinear",
            "bicubic",
            "gaussian",
            "lanczos",
            "ewa_lanczos",
            "ewa_lanczossharp",
            "ewa_lanczossoft",
            "robidoux",
            "robidouxsharp",
            "ewa_ginseng",
            "ewa_hanning",
            "mitchell",
            "catmull_rom",
            "spline16",
            "spline36",
            "spline64",
            "sinc",
            "jinc",
            "oversample",
        };
        public List<string> Scale_Items
        {
            get { return _Scale_Items; }
            set
            {
                _Scale_Items = value;
                OnPropertyChanged("Scale_Items");
            }
        }

        // Selected Item
        private string _Scale_SelectedItem { get; set; }
        public string Scale_SelectedItem
        {
            get { return _Scale_SelectedItem; }
            set
            {
                if (_Scale_SelectedItem == value)
                {
                    return;
                }

                _Scale_SelectedItem = value;
                OnPropertyChanged("Scale_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Scale_IsEnabled = true;
        public bool Scale_IsEnabled
        {
            get { return _Scale_IsEnabled; }
            set
            {
                if (_Scale_IsEnabled == value)
                {
                    return;
                }

                _Scale_IsEnabled = value;
                OnPropertyChanged("Scale_IsEnabled");
            }
        }


        // -------------------------
        // Scale Antiring
        // -------------------------
        // Value
        private double _ScaleAntiring_Value;
        public double ScaleAntiring_Value
        {
            get { return _ScaleAntiring_Value; }
            set
            {
                if (_ScaleAntiring_Value == value)
                {
                    return;
                }

                _ScaleAntiring_Value = value;
                OnPropertyChanged("ScaleAntiring_Value");
            }
        }

        // Text
        private string _ScaleAntiring_Text;
        public string ScaleAntiring_Text
        {
            get { return _ScaleAntiring_Text; }
            set
            {
                if (_ScaleAntiring_Text == value)
                {
                    return;
                }

                _ScaleAntiring_Text = value;
                OnPropertyChanged("ScaleAntiring_Text");
            }
        }

        // Controls Enable
        private bool _ScaleAntiring_IsEnabled = true;
        public bool ScaleAntiring_IsEnabled
        {
            get { return _ScaleAntiring_IsEnabled; }
            set
            {
                if (_ScaleAntiring_IsEnabled == value)
                {
                    return;
                }

                _ScaleAntiring_IsEnabled = value;
                OnPropertyChanged("ScaleAntiring_IsEnabled");
            }
        }


        // -------------------------
        // Chroma Scale
        // -------------------------
        // Item Source
        private List<string> _ChromaScale_Items = new List<string>()
        {
            "default",
            "off",
            "nearest",
            "linear",
            "bilinear",
            "bicubic",
            "gaussian",
            "lanczos",
            "ewa_lanczos",
            "ewa_lanczossharp",
            "ewa_lanczossoft",
            "robidoux",
            "robidouxsharp",
            "ewa_ginseng",
            "ewa_hanning",
            "mitchell",
            "catmull_rom",
            "spline16",
            "spline36",
            "spline64",
            "sinc",
            "jinc",
            "oversample",
        };
        public List<string> ChromaScale_Items
        {
            get { return _ChromaScale_Items; }
            set
            {
                _ChromaScale_Items = value;
                OnPropertyChanged("ChromaScale_Items");
            }
        }

        // Selected Item
        private string _ChromaScale_SelectedItem { get; set; }
        public string ChromaScale_SelectedItem
        {
            get { return _ChromaScale_SelectedItem; }
            set
            {
                if (_ChromaScale_SelectedItem == value)
                {
                    return;
                }

                _ChromaScale_SelectedItem = value;
                OnPropertyChanged("ChromaScale_SelectedItem");
            }
        }

        // Controls Enable
        private bool _ChromaScale_IsEnabled = true;
        public bool ChromaScale_IsEnabled
        {
            get { return _ChromaScale_IsEnabled; }
            set
            {
                if (_ChromaScale_IsEnabled == value)
                {
                    return;
                }

                _ChromaScale_IsEnabled = value;
                OnPropertyChanged("ChromaScale_IsEnabled");
            }
        }


        // -------------------------
        // Chroma Antiring
        // -------------------------
        // Value
        private double _ChromaAntiring_Value;
        public double ChromaAntiring_Value
        {
            get { return _ChromaAntiring_Value; }
            set
            {
                if (_ChromaAntiring_Value == value)
                {
                    return;
                }

                _ChromaAntiring_Value = value;
                OnPropertyChanged("ChromaAntiring_Value");
            }
        }

        // Text
        private string _ChromaAntiring_Text;
        public string ChromaAntiring_Text
        {
            get { return _ChromaAntiring_Text; }
            set
            {
                if (_ChromaAntiring_Text == value)
                {
                    return;
                }

                _ChromaAntiring_Text = value;
                OnPropertyChanged("ChromaAntiring_Text");
            }
        }

        // Controls Enable
        private bool _ChromaAntiring_IsEnabled = true;
        public bool ChromaAntiring_IsEnabled
        {
            get { return _ChromaAntiring_IsEnabled; }
            set
            {
                if (_ChromaAntiring_IsEnabled == value)
                {
                    return;
                }

                _ChromaAntiring_IsEnabled = value;
                OnPropertyChanged("ChromaAntiring_IsEnabled");
            }
        }


        // -------------------------
        // Downscale
        // -------------------------
        // Item Source
        private List<string> _Downscale_Items = new List<string>()
        {
            "default",
            "off",
            "nearest",
            "linear",
            "bilinear",
            "bicubic",
            "gaussian",
            "lanczos",
            "ewa_lanczos",
            "ewa_lanczossharp",
            "ewa_lanczossoft",
            "robidoux",
            "robidouxsharp",
            "ewa_ginseng",
            "ewa_hanning",
            "mitchell",
            "catmull_rom",
            "spline16",
            "spline36",
            "spline64",
            "sinc",
            "jinc",
            "oversample",
        };
        public List<string> Downscale_Items
        {
            get { return _Downscale_Items; }
            set
            {
                _Downscale_Items = value;
                OnPropertyChanged("Downscale_Items");
            }
        }

        // Selected Item
        private string _Downscale_SelectedItem { get; set; }
        public string Downscale_SelectedItem
        {
            get { return _Downscale_SelectedItem; }
            set
            {
                if (_Downscale_SelectedItem == value)
                {
                    return;
                }

                _Downscale_SelectedItem = value;
                OnPropertyChanged("Downscale_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Downscale_IsEnabled = true;
        public bool Downscale_IsEnabled
        {
            get { return _Downscale_IsEnabled; }
            set
            {
                if (_Downscale_IsEnabled == value)
                {
                    return;
                }

                _Downscale_IsEnabled = value;
                OnPropertyChanged("Downscale_IsEnabled");
            }
        }


        // -------------------------
        // Downscale Antiring
        // -------------------------
        // Value
        private double _DownscaleAntiring_Value;
        public double DownscaleAntiring_Value
        {
            get { return _DownscaleAntiring_Value; }
            set
            {
                if (_DownscaleAntiring_Value == value)
                {
                    return;
                }

                _DownscaleAntiring_Value = value;
                OnPropertyChanged("DownscaleAntiring_Value");
            }
        }

        // Text
        private string _DownscaleAntiring_Text;
        public string DownscaleAntiring_Text
        {
            get { return _DownscaleAntiring_Text; }
            set
            {
                if (_DownscaleAntiring_Text == value)
                {
                    return;
                }

                _DownscaleAntiring_Text = value;
                OnPropertyChanged("DownscaleAntiring_Text");
            }
        }

        // Controls Enable
        private bool _DownscaleAntiring_IsEnabled = true;
        public bool DownscaleAntiring_IsEnabled
        {
            get { return _DownscaleAntiring_IsEnabled; }
            set
            {
                if (_DownscaleAntiring_IsEnabled == value)
                {
                    return;
                }

                _DownscaleAntiring_IsEnabled = value;
                OnPropertyChanged("DownscaleAntiring_IsEnabled");
            }
        }


        // -------------------------
        // Interpolation Scale
        // -------------------------
        // Item Source
        private List<string> _InterpolationScale_Items = new List<string>()
        {
            "default",
            "off",
            "nearest",
            "linear",
            "bicubic",
            "box",
            "triangle",
            "gaussian",
            "lanczos",
            "robidoux",
            "robidouxsharp",
            "ginseng",
            "mitchell",
            "catmull_rom",
            "spline16",
            "spline36",
            "spline64",
            "sinc",
            "oversample",
        };
        public List<string> InterpolationScale_Items
        {
            get { return _InterpolationScale_Items; }
            set
            {
                _InterpolationScale_Items = value;
                OnPropertyChanged("InterpolationScale_Items");
            }
        }

        // Selected Item
        private string _InterpolationScale_SelectedItem { get; set; }
        public string InterpolationScale_SelectedItem
        {
            get { return _InterpolationScale_SelectedItem; }
            set
            {
                if (_InterpolationScale_SelectedItem == value)
                {
                    return;
                }

                _InterpolationScale_SelectedItem = value;
                OnPropertyChanged("InterpolationScale_SelectedItem");
            }
        }

        // Controls Enable
        private bool _InterpolationScale_IsEnabled = true;
        public bool InterpolationScale_IsEnabled
        {
            get { return _InterpolationScale_IsEnabled; }
            set
            {
                if (_InterpolationScale_IsEnabled == value)
                {
                    return;
                }

                _InterpolationScale_IsEnabled = value;
                OnPropertyChanged("InterpolationScale_IsEnabled");
            }
        }


        // -------------------------
        // InterpolationScale Antiring
        // -------------------------
        // Value
        private double _InterpolationScaleAntiring_Value;
        public double InterpolationScaleAntiring_Value
        {
            get { return _InterpolationScaleAntiring_Value; }
            set
            {
                if (_InterpolationScaleAntiring_Value == value)
                {
                    return;
                }

                _InterpolationScaleAntiring_Value = value;
                OnPropertyChanged("InterpolationScaleAntiring_Value");
            }
        }

        // Text
        private string _InterpolationScaleAntiring_Text;
        public string InterpolationScaleAntiring_Text
        {
            get { return _InterpolationScaleAntiring_Text; }
            set
            {
                if (_InterpolationScaleAntiring_Text == value)
                {
                    return;
                }

                _InterpolationScaleAntiring_Text = value;
                OnPropertyChanged("InterpolationScaleAntiring_Text");
            }
        }

        // Controls Enable
        private bool _InterpolationScaleAntiring_IsEnabled = true;
        public bool InterpolationScaleAntiring_IsEnabled
        {
            get { return _InterpolationScaleAntiring_IsEnabled; }
            set
            {
                if (_InterpolationScaleAntiring_IsEnabled == value)
                {
                    return;
                }

                _InterpolationScaleAntiring_IsEnabled = value;
                OnPropertyChanged("InterpolationScaleAntiring_IsEnabled");
            }
        }


        // -------------------------
        // Software Scaler
        // -------------------------
        // Item Source
        private List<string> _SoftwareScaler_Items = new List<string>()
        {
            "default",
            "off",
            "bilinear",
            "bicubic",
            "gauss",
            "lanczos",
            "spline",
            "sinc",
        };
        public List<string> SoftwareScaler_Items
        {
            get { return _SoftwareScaler_Items; }
            set
            {
                _SoftwareScaler_Items = value;
                OnPropertyChanged("SoftwareScaler_Items");
            }
        }

        // Selected Item
        private string _SoftwareScaler_SelectedItem { get; set; }
        public string SoftwareScaler_SelectedItem
        {
            get { return _SoftwareScaler_SelectedItem; }
            set
            {
                if (_SoftwareScaler_SelectedItem == value)
                {
                    return;
                }

                _SoftwareScaler_SelectedItem = value;
                OnPropertyChanged("SoftwareScaler_SelectedItem");
            }
        }

        // Controls Enable
        private bool _SoftwareScaler_IsEnabled = true;
        public bool SoftwareScaler_IsEnabled
        {
            get { return _SoftwareScaler_IsEnabled; }
            set
            {
                if (_SoftwareScaler_IsEnabled == value)
                {
                    return;
                }

                _SoftwareScaler_IsEnabled = value;
                OnPropertyChanged("SoftwareScaler_IsEnabled");
            }
        }
        

    }
}
