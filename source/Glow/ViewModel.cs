using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glow
{
    public partial class ViewModel
    {
        // -------------------------
        // Fonts
        // -------------------------
        public static List<string> fonts = new List<string>();
        public static InstalledFontCollection installedFonts = new InstalledFontCollection();
        public static List<string> FontItems
        {
            get { return fonts; }
            set { fonts = value; }
        }

        public static string FontSelectedItem { get; set; }

        // -------------------------
        // Presets
        // -------------------------
        // Presets
        public static List<string> _presetsItems = new List<string>()
        {
            "Default",
            "Ultra",
            "High",
            "Medium",
            "Low",
            //"Debug",
        };

        // -------------------------
        // Custom Profiles
        // -------------------------
        public static List<string> _profilesItems = new List<string>();
        public static List<string> ProfilesItems
        {
            get { return _profilesItems; }
            set { _profilesItems = value; }
        }

        public static string ProfileSelectedItem { get; set; }


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
        public static List<string> _videoDriver_Items = new List<string>()
        {
            "default",
            "opengl",
            "opengl-hq",
            "vulkan",
            "d3d11"
        };
        public static List<string> VideoDriverItems
        {
            get { return _videoDriver_Items; }
            set { _videoDriver_Items = value; }
        }
        public static string VideoDriverSelectedItem { get; set; }

        // -------------------------
        // OpenGL PBO
        // -------------------------
        public static List<string> _openglPBO_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public static List<string> OpenGLPBOItems
        {
            get { return _openglPBO_Items; }
            set { _openglPBO_Items = value; }
        }
        public static string OpenGLPBOSelectedItem { get; set; }

        // -------------------------
        // HW Decoder
        // -------------------------
        public static List<string> _hwDecoder_Items = new List<string>()
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
            "crystalhd",
        };
        public static List<string> HWDecoderItems
        {
            get { return _hwDecoder_Items; }
            set { _hwDecoder_Items = value; }
        }
        public static string HWDecoderSelectedItem { get; set; }
    }
}
