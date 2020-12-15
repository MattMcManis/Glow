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
using Glow.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using ViewModel;

namespace Glow
{
    public partial class Presets
    {
        public static List<string> listCustomPresetsPaths = new List<string>();

        /// <summary>
        /// Presets Reset
        /// </summary>
        public static void PresetsReset()
        {
            listCustomPresetsPaths.Clear();
            listCustomPresetsPaths.TrimExcess();
            VM.MainView.Presets_Items.Clear();

            // Set Default Presets (Ultra, High, Medium, Low)
            VM.MainView.Presets_Items = new ObservableCollection<string>(Main.presets_Default_Items);
        }


        /// <summary>
        ///    Scan PC Custom Presets
        /// </summary>
        public static void LoadCustomPresets()
        {
            //listCustomPresetsPaths.Clear();
            //listCustomPresetsPaths.TrimExcess();
            //VM.MainView.Presets_Items.Clear();

            //// Set Default Presets (Ultra, High, Medium, Low)
            //VM.MainView.Presets_Items = new ObservableCollection<string>(Main.presets_Default_Items);

            // Check if Custom Presets Path is valid
            if (MainWindow.IsValidPath(VM.ConfigureView.PresetsPath_Text) == false)
            {
                return;
            }

            // User Custom Presets Full Path
            if (Directory.Exists(VM.ConfigureView.PresetsPath_Text))
            {
                listCustomPresetsPaths = Directory.GetFiles(VM.ConfigureView.PresetsPath_Text, "*.ini")
                                                  .Select(Path.GetFullPath)
                                                  .OrderByDescending(x => x)
                                                  .ToList();

                //MessageBox.Show(VM.ConfigureView.PresetsPath_Text); //debug
                //MessageBox.Show(string.Join("\n", listCustomPresetsPaths)); //debug
            }

            // Presets path does not exist
            else
            {
                // Load Default
                VM.ConfigureView.PresetsPath_Text = MainWindow.presetsDir;

                //MessageBox.Show(VM.ConfigureView.PresetsPath_Text); //debug
            }

            // Get Names from Full Paths
            List<string> listCustomPresetsNames = new List<string>();

            try
            {
                foreach (string path in listCustomPresetsPaths)
                {
                    // Get Name from Path
                    string presetName = Path.GetFileNameWithoutExtension(path);

                    // Add Name to List
                    // Prevent adding duplicate
                    // Ignore Desktop.ini
                    if (!listCustomPresetsNames.Contains(presetName) &&
                        !string.Equals(presetName, "desktop", StringComparison.CurrentCultureIgnoreCase) &&
                        !string.Equals(presetName, "ntuser", StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        //listCustomPresetsNames.Add(presetName);
                        VM.MainView.Presets_Items.Add(presetName);
                    }
                }
            }
            catch
            {

            }

            // Join Presets and Presets Lists
            //ViewModel._PresetsItems.AddRange(listCustomPresetsNames);
            //VM.MainView.Presets_Items.AddRange(listCustomPresetsNames);
            // Populate ComboBox
            //ViewModel._PresetsItems = ViewModel._PresetsItems.Distinct().ToList();
            //VM.MainView.Presets_Items = VM.MainView.Presets_Items.Distinct().ToList();

            // Clear Temp Lists
            //listCustomPresetsPaths.Clear();
            //listCustomPresetsPaths.TrimExcess();
            //listCustomPresetsNames.Clear();
            //listCustomPresetsNames.TrimExcess();
        }


        /// <summary>
        ///     Preset
        /// </summary>
        public static void Preset(MainWindow mainwindow)
        {
            // -------------------------
            // Default
            // -------------------------
            if (VM.MainView.Presets_SelectedItem == "Default")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "default";
                VM.GeneralView.SavePositionQuit_SelectedItem = "default";
                VM.GeneralView.KeepOpen_SelectedItem = "default";
                VM.GeneralView.OnTop_SelectedItem = "default";
                VM.GeneralView.WindowBorder_SelectedItem = "default";
                VM.GeneralView.GeometryX_Value = 0;
                VM.GeneralView.GeometryY_Value = 0;
                VM.GeneralView.AutofitWidth_Value = 0;
                VM.GeneralView.AutofitHeight_Value = 0;
                VM.GeneralView.Screensaver_SelectedItem = "default";
                VM.GeneralView.WindowTitle_SelectedItem = "default";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "default";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "default";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "default";
                VM.GeneralView.ScreenshotQuality_Value = 0;

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "default";
                //VM.VideoView.VideoDriver_SelectedItem = "default";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "default";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "default";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "default";
                VM.VideoView.TransferCharacteristics_SelectedItem = "default";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "default";
                VM.VideoView.VideoSync_SelectedItem = "default";
                VM.VideoView.Framedrop_SelectedItem = "default";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                VM.VideoView.Dither_SelectedItem = "default";
                VM.VideoView.Deband_SelectedItem = "default";
                VM.VideoView.DebandGrain_Text = "";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "default";
                VM.VideoView.Scale_SelectedItem = "default";
                VM.VideoView.ScaleAntiring_Value = 0;
                VM.VideoView.ChromaScale_SelectedItem = "default";
                VM.VideoView.ChromaAntiring_Value = 0;
                VM.VideoView.Downscale_SelectedItem = "default";
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.InterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_Value = 0;
                VM.VideoView.SoftwareScaler_SelectedItem = "default";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "default";
                VM.AudioView.Channels_SelectedItem = "default";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 100;
                VM.AudioView.Normalize_SelectedItem = "default";
                VM.AudioView.ScaleTempo_SelectedItem = "default";
                VM.AudioView.AudioLoadFiles_SelectedItem = "default";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "default";
                VM.SubtitlesView.LoadFiles_SelectedItem = "default";
                VM.SubtitlesView.EmbeddedFonts_SelectedItem = "default";
                VM.SubtitlesView.Position_Value = 0;
                VM.SubtitlesView.FixTiming_SelectedItem = "default";
                VM.SubtitlesView.Margins_SelectedItem = "default";
                VM.SubtitlesView.Blend_SelectedItem = "default";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "default";
                VM.SubtitlesView.FontSize_SelectedItem = "default";
                VM.SubtitlesView.FontColor_Text = ""; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "default";
                //VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                VM.SubtitlesView.BorderColor_Text = ""; //dark gray
                // Shadow
                //VM.SubtitlesView.ShadowColor_Text = "262626"; //dark gray
                VM.SubtitlesView.ShadowColor_Text = ""; //dark gray
                VM.SubtitlesView.ShadowOffset_Value = 0;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "default";
                VM.SubtitlesView.ASSOverride_SelectedItem = "default";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "default";
                VM.SubtitlesView.ASSHinting_SelectedItem = "default";
                VM.SubtitlesView.ASSKerning_SelectedItem = "default";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "default";
                VM.StreamView.DemuxerBuffersize_Text = "";
                VM.StreamView.DemuxerReadahead_Text = "";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "default";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "default";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "default";
                // Cache
                VM.StreamView.Cache_SelectedItem = "default";
                VM.StreamView.CacheDefault_Text = "";
                VM.StreamView.CacheInitial_Text = "";
                VM.StreamView.CacheSeekMin_Text = "";
                VM.StreamView.CacheBackbuffer_Text = "";
                VM.StreamView.CacheSeconds_Text = "";
                VM.StreamView.CacheFile_SelectedItem = "default";
                VM.StreamView.CacheFileSize_Text = "";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "default";
                VM.DisplayView.OSC_Layout_SelectedItem = "default";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "default";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "default";
                VM.DisplayView.OSD_Fractions_SelectedItem = "default";
                VM.DisplayView.OSD_Duration_Text = "";
                VM.DisplayView.OSD_Level_SelectedItem = "default";
                VM.DisplayView.OSC_Scale_Value = 0;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 0;
                VM.DisplayView.OSC_BarHeight_Value = 0;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "default";
                VM.DisplayView.OSD_FontSize_SelectedItem = "default";
                //VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                VM.DisplayView.OSD_FontColor_Text = ""; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "default";
                //VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_BorderColor_Text = ""; //dark gray
                // Shadow
                //VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowColor_Text = ""; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 0;
                //VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "default";
                VM.GeneralView.ExtGIF_SelectedItem = "default";
                VM.GeneralView.ExtJPG_SelectedItem = "default";
                VM.GeneralView.ExtPNG_SelectedItem = "default";
            }

            // -------------------------
            // Ultra
            // -------------------------
            else if (VM.MainView.Presets_SelectedItem == "Ultra")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "high";
                VM.GeneralView.SavePositionQuit_SelectedItem = "no";
                VM.GeneralView.KeepOpen_SelectedItem = "yes";
                VM.GeneralView.OnTop_SelectedItem = "no";
                VM.GeneralView.GeometryX_Value = 50;
                VM.GeneralView.GeometryY_Value = 50;
                VM.GeneralView.AutofitWidth_Value = 100;
                VM.GeneralView.AutofitHeight_Value = 95;
                VM.GeneralView.Screensaver_SelectedItem = "off";
                VM.GeneralView.WindowTitle_SelectedItem = "Media Title";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "Playback Time";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "no";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "png";
                VM.GeneralView.ScreenshotQuality_Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "gpu-hq";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "default";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                //VM.VideoView.VideoDriver_SelectedItem = "opengl-hq";
                //VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                //VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "auto";
                VM.VideoView.TransferCharacteristics_SelectedItem = "auto";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "yes";
                VM.VideoView.VideoSync_SelectedItem = "display-resample";
                VM.VideoView.Framedrop_SelectedItem = "vo";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                //vm.GammaAuto_SelectedItem = "yes";
                VM.VideoView.Dither_SelectedItem = "8";
                VM.VideoView.Deband_SelectedItem = "yes";
                VM.VideoView.DebandGrain_Text = "80";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "yes";
                VM.VideoView.Scale_SelectedItem = "spline36";
                VM.VideoView.ScaleAntiring_Value = 1;
                VM.VideoView.ChromaScale_SelectedItem = "ewa_lanczossoft";
                VM.VideoView.ChromaAntiring_Value = 1;
                VM.VideoView.Downscale_SelectedItem = "mitchell";
                VM.VideoView.DownscaleAntiring_Value = 1;
                VM.VideoView.InterpolationScale_SelectedItem = "mitchell";
                VM.VideoView.InterpolationScaleAntiring_Value = 1;
                VM.VideoView.SoftwareScaler_SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "wasapi";
                VM.AudioView.Channels_SelectedItem = "auto";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 150;
                VM.AudioView.Normalize_SelectedItem = "yes";
                VM.AudioView.ScaleTempo_SelectedItem = "yes";
                VM.AudioView.AudioLoadFiles_SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "yes";
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
                VM.SubtitlesView.Position_Value = 95;
                VM.SubtitlesView.FixTiming_SelectedItem = "yes";
                VM.SubtitlesView.Margins_SelectedItem = "yes";
                VM.SubtitlesView.Blend_SelectedItem = "yes";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "Segoe UI";
                VM.SubtitlesView.FontSize_SelectedItem = "48";
                VM.SubtitlesView.FontColor_Text = "FFFFFF"; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "2";
                VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.SubtitlesView.ShadowColor_Text = "262626"; //dark gray
                VM.SubtitlesView.ShadowOffset_Value = 1.25;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "yes";
                VM.SubtitlesView.ASSOverride_SelectedItem = "force";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "yes";
                VM.SubtitlesView.ASSHinting_SelectedItem = "none";
                VM.SubtitlesView.ASSKerning_SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "no";
                VM.StreamView.DemuxerBuffersize_Text = "32768";
                VM.StreamView.DemuxerReadahead_Text = "5.0";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "yes";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "yes";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "best";
                // Cache
                VM.StreamView.Cache_SelectedItem = "auto";
                VM.StreamView.CacheDefault_Text = "100000";
                VM.StreamView.CacheInitial_Text = "1024";
                VM.StreamView.CacheSeekMin_Text = "1024";
                VM.StreamView.CacheBackbuffer_Text = "25000";
                VM.StreamView.CacheSeconds_Text = "30";
                VM.StreamView.CacheFile_SelectedItem = "TMP";
                VM.StreamView.CacheFileSize_Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "yes";
                VM.DisplayView.OSC_Layout_SelectedItem = "bottombar";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "yes";
                VM.DisplayView.OSD_Fractions_SelectedItem = "yes";
                VM.DisplayView.OSD_Duration_Text = "1500";
                VM.DisplayView.OSD_Level_SelectedItem = "1";
                VM.DisplayView.OSC_Scale_Value = 0.5;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 95;
                VM.DisplayView.OSC_BarHeight_Value = 2;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "Segoe UI";
                VM.DisplayView.OSD_FontSize_SelectedItem = "60";
                VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "1";
                VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "loop";
                VM.GeneralView.ExtGIF_SelectedItem = "loop";
                VM.GeneralView.ExtJPG_SelectedItem = "pause";
                VM.GeneralView.ExtPNG_SelectedItem = "pause";
            }

            // -------------------------
            // High
            // -------------------------
            else if (VM.MainView.Presets_SelectedItem == "High")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "high";
                VM.GeneralView.SavePositionQuit_SelectedItem = "no";
                VM.GeneralView.KeepOpen_SelectedItem = "yes";
                VM.GeneralView.OnTop_SelectedItem = "no";
                VM.GeneralView.GeometryX_Value = 50;
                VM.GeneralView.GeometryY_Value = 50;
                VM.GeneralView.AutofitWidth_Value = 100;
                VM.GeneralView.AutofitHeight_Value = 95;
                VM.GeneralView.Screensaver_SelectedItem = "off";
                VM.GeneralView.WindowTitle_SelectedItem = "Media Title";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "Playback Time";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "no";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "png";
                VM.GeneralView.ScreenshotQuality_Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "gpu";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "no";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                //VM.VideoView.VideoDriver_SelectedItem = "opengl";
                //VM.VideoView.VideoDriverAPI_SelectedItem = "opengl";
                //VM.VideoView.OpenGLPBO_SelectedItem = "no";
                //VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                //VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "auto";
                VM.VideoView.TransferCharacteristics_SelectedItem = "auto";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "yes";
                VM.VideoView.VideoSync_SelectedItem = "display-resample";
                VM.VideoView.Framedrop_SelectedItem = "vo";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                //vm.GammaAuto_SelectedItem = "yes";
                VM.VideoView.Dither_SelectedItem = "8";
                VM.VideoView.Deband_SelectedItem = "yes";
                VM.VideoView.DebandGrain_Text = "80";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "yes";
                VM.VideoView.Scale_SelectedItem = "ewa_lanczossharp";
                VM.VideoView.ScaleAntiring_Value = 0.5;
                VM.VideoView.ChromaScale_SelectedItem = "ewa_lanczossoft";
                VM.VideoView.ChromaAntiring_Value = 0.5;
                VM.VideoView.Downscale_SelectedItem = "mitchell";
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.InterpolationScale_SelectedItem = "mitchell";
                VM.VideoView.InterpolationScaleAntiring_Value = 0;
                VM.VideoView.SoftwareScaler_SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "wasapi";
                VM.AudioView.Channels_SelectedItem = "auto";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 150;
                VM.AudioView.Normalize_SelectedItem = "yes";
                VM.AudioView.ScaleTempo_SelectedItem = "yes";
                VM.AudioView.AudioLoadFiles_SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "yes";
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
                VM.SubtitlesView.EmbeddedFonts_SelectedItem = "no";
                VM.SubtitlesView.Position_Value = 95;
                VM.SubtitlesView.FixTiming_SelectedItem = "yes";
                VM.SubtitlesView.Margins_SelectedItem = "yes";
                VM.SubtitlesView.Blend_SelectedItem = "yes";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "Segoe UI";
                VM.SubtitlesView.FontSize_SelectedItem = "44";
                VM.SubtitlesView.FontColor_Text = "FFFFFF"; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "2";
                VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.SubtitlesView.ShadowColor_Text = "262626"; //dark gray
                VM.SubtitlesView.ShadowOffset_Value = 1.25;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "yes";
                VM.SubtitlesView.ASSOverride_SelectedItem = "force";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "yes";
                VM.SubtitlesView.ASSHinting_SelectedItem = "none";
                VM.SubtitlesView.ASSKerning_SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "no";
                VM.StreamView.DemuxerBuffersize_Text = "32768";
                VM.StreamView.DemuxerReadahead_Text = "5.0";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "yes";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "yes";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "best";
                // Cache
                VM.StreamView.Cache_SelectedItem = "auto";
                VM.StreamView.CacheDefault_Text = "100000";
                VM.StreamView.CacheInitial_Text = "1024";
                VM.StreamView.CacheSeekMin_Text = "1024";
                VM.StreamView.CacheBackbuffer_Text = "25000";
                VM.StreamView.CacheSeconds_Text = "30";
                VM.StreamView.CacheFile_SelectedItem = "TMP";
                VM.StreamView.CacheFileSize_Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "yes";
                VM.DisplayView.OSC_Layout_SelectedItem = "bottombar";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "yes";
                VM.DisplayView.OSD_Fractions_SelectedItem = "yes";
                VM.DisplayView.OSD_Duration_Text = "1500";
                VM.DisplayView.OSD_Level_SelectedItem = "1";
                VM.DisplayView.OSC_Scale_Value = 0.5;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 95;
                VM.DisplayView.OSC_BarHeight_Value = 2;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "Segoe UI";
                VM.DisplayView.OSD_FontSize_SelectedItem = "60";
                VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "1";
                VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "loop";
                VM.GeneralView.ExtGIF_SelectedItem = "loop";
                VM.GeneralView.ExtJPG_SelectedItem = "pause";
                VM.GeneralView.ExtPNG_SelectedItem = "pause";
            }

            // -------------------------
            // Medium
            // -------------------------
            else if (VM.MainView.Presets_SelectedItem == "Medium")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "abovenormal";
                VM.GeneralView.SavePositionQuit_SelectedItem = "no";
                VM.GeneralView.KeepOpen_SelectedItem = "yes";
                VM.GeneralView.OnTop_SelectedItem = "no";
                VM.GeneralView.GeometryX_Value = 50;
                VM.GeneralView.GeometryY_Value = 50;
                VM.GeneralView.AutofitWidth_Value = 100;
                VM.GeneralView.AutofitHeight_Value = 95;
                VM.GeneralView.Screensaver_SelectedItem = "off";
                VM.GeneralView.WindowTitle_SelectedItem = "Media Title";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "Playback Time";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "no";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "png";
                VM.GeneralView.ScreenshotQuality_Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "gpu";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "no";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                //VM.VideoView.VideoDriver_SelectedItem = "opengl";
                //VM.VideoView.VideoDriverAPI_SelectedItem = "opengl";
                //VM.VideoView.OpenGLPBO_SelectedItem = "no";
                //VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                //VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "auto";
                VM.VideoView.TransferCharacteristics_SelectedItem = "auto";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "default";
                VM.VideoView.VideoSync_SelectedItem = "default";
                VM.VideoView.Framedrop_SelectedItem = "vo";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                //vm.GammaAuto_SelectedItem = "yes";
                VM.VideoView.Dither_SelectedItem = "auto";
                VM.VideoView.Deband_SelectedItem = "yes";
                VM.VideoView.DebandGrain_Text = "";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "yes";
                VM.VideoView.Scale_SelectedItem = "lanczos";
                VM.VideoView.ScaleAntiring_Value = 0;
                VM.VideoView.ChromaScale_SelectedItem = "ewa_lanczossoft";
                VM.VideoView.ChromaAntiring_Value = 0;
                VM.VideoView.Downscale_SelectedItem = "mitchell";
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.InterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_Value = 0;
                VM.VideoView.SoftwareScaler_SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "wasapi";
                VM.AudioView.Channels_SelectedItem = "auto";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 150;
                VM.AudioView.Normalize_SelectedItem = "yes";
                VM.AudioView.ScaleTempo_SelectedItem = "yes";
                VM.AudioView.AudioLoadFiles_SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "yes";
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
                VM.SubtitlesView.EmbeddedFonts_SelectedItem = "no";
                VM.SubtitlesView.Position_Value = 95;
                VM.SubtitlesView.FixTiming_SelectedItem = "yes";
                VM.SubtitlesView.Margins_SelectedItem = "yes";
                VM.SubtitlesView.Blend_SelectedItem = "yes";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "Segoe UI";
                VM.SubtitlesView.FontSize_SelectedItem = "44";
                VM.SubtitlesView.FontColor_Text = "FFFFFF"; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "2";
                VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.SubtitlesView.ShadowColor_Text = "262626"; //dark gray
                VM.SubtitlesView.ShadowOffset_Value = 1.25;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "yes";
                VM.SubtitlesView.ASSOverride_SelectedItem = "force";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "yes";
                VM.SubtitlesView.ASSHinting_SelectedItem = "none";
                VM.SubtitlesView.ASSKerning_SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "no";
                VM.StreamView.DemuxerBuffersize_Text = "32768";
                VM.StreamView.DemuxerReadahead_Text = "5.0";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "yes";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "yes";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "good";
                // Cache
                VM.StreamView.Cache_SelectedItem = "auto";
                VM.StreamView.CacheDefault_Text = "100000";
                VM.StreamView.CacheInitial_Text = "1024";
                VM.StreamView.CacheSeekMin_Text = "1024";
                VM.StreamView.CacheBackbuffer_Text = "25000";
                VM.StreamView.CacheSeconds_Text = "30";
                VM.StreamView.CacheFile_SelectedItem = "TMP";
                VM.StreamView.CacheFileSize_Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "yes";
                VM.DisplayView.OSC_Layout_SelectedItem = "bottombar";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "yes";
                VM.DisplayView.OSD_Fractions_SelectedItem = "yes";
                VM.DisplayView.OSD_Duration_Text = "1500";
                VM.DisplayView.OSD_Level_SelectedItem = "1";
                VM.DisplayView.OSC_Scale_Value = 0.5;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 95;
                VM.DisplayView.OSC_BarHeight_Value = 2;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "Segoe UI";
                VM.DisplayView.OSD_FontSize_SelectedItem = "60";
                VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "1";
                VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "loop";
                VM.GeneralView.ExtGIF_SelectedItem = "loop";
                VM.GeneralView.ExtJPG_SelectedItem = "pause";
                VM.GeneralView.ExtPNG_SelectedItem = "pause";
            }

            // -------------------------
            // Low
            // -------------------------
            else if (VM.MainView.Presets_SelectedItem == "Low")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "normal";
                VM.GeneralView.SavePositionQuit_SelectedItem = "no";
                VM.GeneralView.KeepOpen_SelectedItem = "yes";
                VM.GeneralView.OnTop_SelectedItem = "no";
                VM.GeneralView.GeometryX_Value = 50;
                VM.GeneralView.GeometryY_Value = 50;
                VM.GeneralView.AutofitWidth_Value = 100;
                VM.GeneralView.AutofitHeight_Value = 95;
                VM.GeneralView.Screensaver_SelectedItem = "off";
                VM.GeneralView.WindowTitle_SelectedItem = "Media Title";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "Playback Time";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "no";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "png";
                VM.GeneralView.ScreenshotQuality_Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "gpu";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "no";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                //VM.VideoView.VideoDriver_SelectedItem = "opengl";
                //VM.VideoView.VideoDriverAPI_SelectedItem = "opengl";
                //VM.VideoView.OpenGLPBO_SelectedItem = "no";
                //VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                //VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "auto";
                VM.VideoView.TransferCharacteristics_SelectedItem = "auto";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "default";
                VM.VideoView.VideoSync_SelectedItem = "default";
                VM.VideoView.Framedrop_SelectedItem = "vo";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                //vm.GammaAuto_SelectedItem = "no";
                VM.VideoView.Dither_SelectedItem = "no";
                VM.VideoView.Deband_SelectedItem = "no";
                VM.VideoView.DebandGrain_Text = "";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "no";
                VM.VideoView.Scale_SelectedItem = "bilinear";
                VM.VideoView.ScaleAntiring_Value = 0;
                VM.VideoView.ChromaScale_SelectedItem = "bilinear";
                VM.VideoView.ChromaAntiring_Value = 0;
                VM.VideoView.Downscale_SelectedItem = "bilinear";
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.InterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_Value = 0;
                VM.VideoView.SoftwareScaler_SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "wasapi";
                VM.AudioView.Channels_SelectedItem = "auto";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 150;
                VM.AudioView.Normalize_SelectedItem = "yes";
                VM.AudioView.ScaleTempo_SelectedItem = "yes";
                VM.AudioView.AudioLoadFiles_SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "yes";
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
                VM.SubtitlesView.EmbeddedFonts_SelectedItem = "no";
                VM.SubtitlesView.Position_Value = 95;
                VM.SubtitlesView.FixTiming_SelectedItem = "yes";
                VM.SubtitlesView.Margins_SelectedItem = "yes";
                VM.SubtitlesView.Blend_SelectedItem = "no";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "Segoe UI";
                VM.SubtitlesView.FontSize_SelectedItem = "44";
                VM.SubtitlesView.FontColor_Text = "FFFFFF"; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "2";
                VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                // Shadow
                //vm.ShadowColor.SelectedIndex = 0; //none
                VM.SubtitlesView.ShadowColor_Text = ""; //none
                VM.SubtitlesView.ShadowOffset_Value = 0;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "yes";
                VM.SubtitlesView.ASSOverride_SelectedItem = "force";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "yes";
                VM.SubtitlesView.ASSHinting_SelectedItem = "none";
                VM.SubtitlesView.ASSKerning_SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "no";
                VM.StreamView.DemuxerBuffersize_Text = "32768";
                VM.StreamView.DemuxerReadahead_Text = "";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "no";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "yes";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "worst";
                // Cache
                VM.StreamView.Cache_SelectedItem = "auto";
                VM.StreamView.CacheDefault_Text = "100000";
                VM.StreamView.CacheInitial_Text = "1024";
                VM.StreamView.CacheSeekMin_Text = "1024";
                VM.StreamView.CacheBackbuffer_Text = "25000";
                VM.StreamView.CacheSeconds_Text = "30";
                VM.StreamView.CacheFile_SelectedItem = "TMP";
                VM.StreamView.CacheFileSize_Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "yes";
                VM.DisplayView.OSC_Layout_SelectedItem = "bottombar";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "yes";
                VM.DisplayView.OSD_Fractions_SelectedItem = "yes";
                VM.DisplayView.OSD_Duration_Text = "1500";
                VM.DisplayView.OSD_Level_SelectedItem = "1";
                VM.DisplayView.OSC_Scale_Value = 0.5;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 95;
                VM.DisplayView.OSC_BarHeight_Value = 2;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "Segoe UI";
                VM.DisplayView.OSD_FontSize_SelectedItem = "60";
                VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "1";
                VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "loop";
                VM.GeneralView.ExtGIF_SelectedItem = "loop";
                VM.GeneralView.ExtJPG_SelectedItem = "pause";
                VM.GeneralView.ExtPNG_SelectedItem = "pause";
            }

            // -------------------------
            // Debug
            // -------------------------
            else if (VM.MainView.Presets_SelectedItem == "Debug")
            {
                // -------------------------
                // General
                // -------------------------
                VM.GeneralView.Priority_SelectedItem = "high";
                VM.GeneralView.SavePositionQuit_SelectedItem = "no";
                VM.GeneralView.KeepOpen_SelectedItem = "yes";
                VM.GeneralView.OnTop_SelectedItem = "no";
                VM.GeneralView.GeometryX_Value = 50;
                VM.GeneralView.GeometryY_Value = 50;
                VM.GeneralView.AutofitWidth_Value = 100;
                VM.GeneralView.AutofitHeight_Value = 95;
                VM.GeneralView.Screensaver_SelectedItem = "off";
                VM.GeneralView.WindowTitle_SelectedItem = "Media Title";
                VM.GeneralView.LogPath_Text = "";
                // Screenshot
                VM.GeneralView.ScreenshotPath_Text = "";
                VM.GeneralView.ScreenshotTemplate_SelectedItem = "Playback Time";
                VM.GeneralView.ScreenshotTagColorspace_SelectedItem = "no";
                VM.GeneralView.ScreenshotFormat_SelectedItem = "png";
                VM.GeneralView.ScreenshotQuality_Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                VM.VideoView.VideoDriver_SelectedItem = "gpu";
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                VM.VideoView.OpenGLPBO_SelectedItem = "no";
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                //VM.VideoView.VideoDriver_SelectedItem = "opengl";
                //VM.VideoView.VideoDriverAPI_SelectedItem = "opengl";
                //VM.VideoView.OpenGLPBO_SelectedItem = "no";
                //VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                //VM.VideoView.HWDecoder_SelectedItem = "auto-copy";
                // Display
                VM.VideoView.ICCProfile_SelectedItem = "default";
                VM.VideoView.DisplayPrimaries_SelectedItem = "auto";
                VM.VideoView.TransferCharacteristics_SelectedItem = "auto";
                VM.VideoView.ColorSpace_SelectedItem = "default";
                VM.VideoView.ColorRange_SelectedItem = "default";
                VM.VideoView.Interpolation_SelectedItem = "yes";
                VM.VideoView.VideoSync_SelectedItem = "display-resample";
                VM.VideoView.Framedrop_SelectedItem = "vo";
                // Image
                VM.VideoView.Brightness_Value = 0;
                VM.VideoView.Contrast_Value = 0;
                VM.VideoView.Hue_Value = 0;
                VM.VideoView.Saturation_Value = 0;
                VM.VideoView.Gamma_Value = 0;
                //vm.GammaAuto_SelectedItem = "yes";
                VM.VideoView.Dither_SelectedItem = "8";
                VM.VideoView.Deband_SelectedItem = "yes";
                VM.VideoView.DebandGrain_Text = "80";
                VM.VideoView.Deinterlace_SelectedItem = "default";
                // Scaling
                VM.VideoView.Sigmoid_SelectedItem = "yes";
                VM.VideoView.Scale_SelectedItem = "spline36";
                VM.VideoView.ScaleAntiring_Value = 1;
                VM.VideoView.ChromaScale_SelectedItem = "ewa_lanczossoft";
                VM.VideoView.ChromaAntiring_Value = 1;
                VM.VideoView.Downscale_SelectedItem = "mitchell";
                VM.VideoView.DownscaleAntiring_Value = 1;
                VM.VideoView.InterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_Value = 0;
                VM.VideoView.SoftwareScaler_SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                VM.AudioView.AudioDriver_SelectedItem = "wasapi";
                VM.AudioView.Channels_SelectedItem = "auto";
                VM.AudioView.Volume_Value = 100;
                VM.AudioView.VolumeMax_Value = 150;
                //vm.SoftVolumeMax_Value = 150;
                VM.AudioView.Normalize_SelectedItem = "yes";
                VM.AudioView.ScaleTempo_SelectedItem = "yes";
                VM.AudioView.AudioLoadFiles_SelectedItem = "fuzzy";
                //Language
                //mainwindow.listViewAudioLanguages_SelectedItems.Add("English");
                //mainwindow.listViewAudioLanguages_SelectedItems.Add("Japanese");


                // -------------------------
                // Subtitles
                // -------------------------
                VM.SubtitlesView.Subtitles_SelectedItem = "yes";
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
                VM.SubtitlesView.EmbeddedFonts_SelectedItem = "no";
                VM.SubtitlesView.Position_Value = 95;
                VM.SubtitlesView.FixTiming_SelectedItem = "yes";
                VM.SubtitlesView.Margins_SelectedItem = "yes";
                VM.SubtitlesView.Blend_SelectedItem = "yes";
                // Font
                VM.SubtitlesView.Font_SelectedItem = "Noto Sans";
                VM.SubtitlesView.FontSize_SelectedItem = "44";
                VM.SubtitlesView.FontColor_Text = "FFFFFF"; //white
                // Border
                VM.SubtitlesView.BorderSize_SelectedItem = "2";
                VM.SubtitlesView.BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.SubtitlesView.ShadowColor_Text = "262626"; //dark gray
                VM.SubtitlesView.ShadowOffset_Value = 1.25;

                // ASS
                VM.SubtitlesView.ASS_SelectedItem = "yes";
                VM.SubtitlesView.ASSOverride_SelectedItem = "force";
                VM.SubtitlesView.ASSForceMargins_SelectedItem = "yes";
                VM.SubtitlesView.ASSHinting_SelectedItem = "none";
                VM.SubtitlesView.ASSKerning_SelectedItem = "yes";

                //Language
                //mainwindow.listViewSubtitlesLanguages_SelectedItems.Add("English");
                VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Add("English");

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                VM.StreamView.DemuxerThread_SelectedItem = "yes";
                VM.StreamView.DemuxerBuffersize_Text = "32768";
                VM.StreamView.DemuxerReadahead_Text = "5.0";
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = "yes";
                // YouTube
                VM.StreamView.YouTubeDL_SelectedItem = "yes";
                VM.StreamView.YouTubeDLQuality_SelectedItem = "best";
                // Cache
                VM.StreamView.Cache_SelectedItem = "auto";
                VM.StreamView.CacheDefault_Text = "100000";
                VM.StreamView.CacheInitial_Text = "1024";
                VM.StreamView.CacheSeekMin_Text = "1024";
                VM.StreamView.CacheBackbuffer_Text = "25000";
                VM.StreamView.CacheSeconds_Text = "30";
                VM.StreamView.CacheFile_SelectedItem = "TMP";
                VM.StreamView.CacheFileSize_Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                VM.DisplayView.OSC_SelectedItem = "yes";
                VM.DisplayView.OSC_Layout_SelectedItem = "bottombar";
                VM.DisplayView.OSC_Seekbar_SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                VM.DisplayView.OSD_SelectedItem = "yes";
                VM.DisplayView.OSD_Fractions_SelectedItem = "yes";
                VM.DisplayView.OSD_Duration_Text = "1500";
                VM.DisplayView.OSD_Level_SelectedItem = "1";
                VM.DisplayView.OSC_Scale_Value = 0.5;
                // Bar
                VM.DisplayView.OSC_BarWidth_Value = 95;
                VM.DisplayView.OSC_BarHeight_Value = 2;
                // Font
                VM.DisplayView.OSD_Font_SelectedItem = "Noto Sans";
                VM.DisplayView.OSD_FontSize_SelectedItem = "60";
                VM.DisplayView.OSD_FontColor_Text = "FFFFFF"; //white
                // Border
                VM.DisplayView.OSD_FontBorderSize_SelectedItem = "1";
                VM.DisplayView.OSD_BorderColor_Text = "262626"; //dark gray
                // Shadow
                VM.DisplayView.OSD_ShadowColor_Text = "262626"; //dark gray
                VM.DisplayView.OSD_ShadowOffset_Value = 1.25;

                // -------------------------
                // Extensions
                // -------------------------
                VM.GeneralView.ExtMKV_SelectedItem = "default";
                VM.GeneralView.ExtMP4_SelectedItem = "default";
                VM.GeneralView.ExtWebM_SelectedItem = "loop";
                VM.GeneralView.ExtGIF_SelectedItem = "loop";
                VM.GeneralView.ExtJPG_SelectedItem = "pause";
                VM.GeneralView.ExtPNG_SelectedItem = "pause";
            }

            // -------------------------
            // User Custom Preset
            // -------------------------
            else
            {
                // Get Preset INI Path
                string input = string.Empty;
                foreach (string path in listCustomPresetsPaths)
                {
                    string filename = Path.GetFileNameWithoutExtension(path);

                    if (VM.MainView.Presets_SelectedItem == filename)
                    {
                        input = path;
                        break;
                    }
                }

                // Import Custom Preset INI file
                ImportPreset(mainwindow, input);
            }

        }



        /// <summary>
        ///    Export Preset
        /// </summary>
        public static void ExportPreset(MainWindow mainwindow, string preset)
        {
            // Check if Preset Directory exists
            if (Directory.Exists(VM.ConfigureView.PresetsPath_Text))
            {
                // Start INI File Write
                Configure.ConfigFile inif = new Configure.ConfigFile(preset);

                // --------------------------------------------------
                // Settings
                // --------------------------------------------------
                //inif.Write("Settings", "mpvDir", Paths.mpvDir);
                //inif.Write("Settings", "configDir", Paths.mpvConfigDir);
                //inif.Write("Settings", "presetsDir", Paths.presetsDir);
                //inif.Write("Settings", "mpvDir", VM.ConfigureView.mpvPath_Text);
                //inif.Write("Settings", "configDir", VM.ConfigureView.mpvConfigPath_Text);
                //inif.Write("Settings", "presetsDir", VM.ConfigureView.PresetsPath_Text);

                // --------------------------------------------------
                // General
                // --------------------------------------------------
                inif.Write("General", "priority", VM.GeneralView.Priority_SelectedItem);
                inif.Write("General", "savePositiOnQuit", VM.GeneralView.SavePositionQuit_SelectedItem);
                inif.Write("General", "keepOpen", VM.GeneralView.KeepOpen_SelectedItem);
                inif.Write("General", "onTop", VM.GeneralView.OnTop_SelectedItem);
                inif.Write("General", "border", VM.GeneralView.WindowBorder_SelectedItem);
                inif.Write("General", "geometryX", VM.GeneralView.GeometryX_Value.ToString());
                inif.Write("General", "geometryY", VM.GeneralView.GeometryY_Value.ToString());
                inif.Write("General", "autofitWidth", VM.GeneralView.AutofitWidth_Value.ToString());
                inif.Write("General", "autofitHeight", VM.GeneralView.AutofitHeight_Value.ToString());
                inif.Write("General", "screensaver", VM.GeneralView.Screensaver_SelectedItem);
                inif.Write("General", "windowTitle", VM.GeneralView.WindowTitle_SelectedItem);
                inif.Write("General", "logPath", VM.GeneralView.LogPath_Text);
                // Screenshot
                inif.Write("General", "screenshotPath", VM.GeneralView.ScreenshotPath_Text);
                inif.Write("General", "screenshotTemplate", VM.GeneralView.ScreenshotTemplate_SelectedItem);
                inif.Write("General", "screenshotTagColorspace", VM.GeneralView.ScreenshotTagColorspace_SelectedItem);
                inif.Write("General", "screenshotFormat", VM.GeneralView.ScreenshotFormat_SelectedItem);
                inif.Write("General", "screenshotQuality", VM.GeneralView.ScreenshotQuality_Value.ToString());

                // --------------------------------------------------
                // Video
                // --------------------------------------------------
                // Hardware
                inif.Write("Video", "videoDriver", VM.VideoView.VideoDriver_SelectedItem);
                //inif.Write("Video", "videoDriver", (VM.VideoView.VideoDriver_SelectedItem);
                inif.Write("Video", "videoDriverAPI", VM.VideoView.VideoDriverAPI_SelectedItem);
                inif.Write("Video", "openglPBO", VM.VideoView.OpenGLPBO_SelectedItem);
                inif.Write("Video", "openglPBOFormat", VM.VideoView.OpenGLPBOFormat_SelectedItem);
                inif.Write("Video", "hwdec", VM.VideoView.HWDecoder_SelectedItem);
                // Display
                //inif.Write("Video", "ICCProfilePath", vm.ICCProfilePath_Text);
                inif.Write("Video", "ICCProfile", VM.VideoView.ICCProfile_SelectedItem);
                inif.Write("Video", "displayPrimaries", VM.VideoView.DisplayPrimaries_SelectedItem);
                inif.Write("Video", "transferCharacteristics", VM.VideoView.TransferCharacteristics_SelectedItem);
                inif.Write("Video", "colorSpace", VM.VideoView.ColorSpace_SelectedItem);
                inif.Write("Video", "colorRange", VM.VideoView.ColorRange_SelectedItem);
                inif.Write("Video", "deinterlace", VM.VideoView.Deinterlace_SelectedItem);
                inif.Write("Video", "interpolation", VM.VideoView.Interpolation_SelectedItem);
                inif.Write("Video", "videoSync", VM.VideoView.VideoSync_SelectedItem);
                inif.Write("Video", "frameDrop", VM.VideoView.Framedrop_SelectedItem);
                // Image
                inif.Write("Video", "brightness", VM.VideoView.Brightness_Value.ToString());
                inif.Write("Video", "contrast", VM.VideoView.Contrast_Value.ToString());
                inif.Write("Video", "hue", VM.VideoView.Hue_Value.ToString());
                inif.Write("Video", "saturation", VM.VideoView.Saturation_Value.ToString());
                inif.Write("Video", "gamma", VM.VideoView.Gamma_Value.ToString());
                //inif.Write("Video", "gammaAuto", (vm.GammaAuto_SelectedItem);
                inif.Write("Video", "deband", VM.VideoView.Deband_SelectedItem);
                inif.Write("Video", "debandGrain", VM.VideoView.DebandGrain_Text);
                inif.Write("Video", "dither", VM.VideoView.Dither_SelectedItem);
                // Scaling
                inif.Write("Video", "sigmoidUpscaling", VM.VideoView.Sigmoid_SelectedItem);
                inif.Write("Video", "scale", VM.VideoView.Scale_SelectedItem);
                inif.Write("Video", "scaleAntiring", VM.VideoView.ScaleAntiring_Value.ToString());
                inif.Write("Video", "chromaScale", VM.VideoView.ChromaScale_SelectedItem);
                inif.Write("Video", "chromaScaleAntiring", VM.VideoView.ChromaAntiring_Value.ToString());
                inif.Write("Video", "downscale", VM.VideoView.Downscale_SelectedItem);
                inif.Write("Video", "downscaleAntiring", VM.VideoView.DownscaleAntiring_Value.ToString());
                inif.Write("Video", "interpolationScale", VM.VideoView.InterpolationScale_SelectedItem);
                inif.Write("Video", "interpolationAntiring", VM.VideoView.InterpolationScaleAntiring_Value.ToString());
                inif.Write("Video", "softwareScaler", VM.VideoView.SoftwareScaler_SelectedItem);

                // --------------------------------------------------
                // Audio
                // --------------------------------------------------
                inif.Write("Audio", "driver", VM.AudioView.AudioDriver_SelectedItem);

                // -------------------------
                // Languages
                // -------------------------
                // Order
                string audioLanguagePriority_ItemOrder = string.Join(",", VM.AudioView.LanguagePriority_ListView_Items
                                                               .Where(s => !string.IsNullOrWhiteSpace(s)));
                inif.Write("Audio", "languagesOrder", audioLanguagePriority_ItemOrder);

                // Selected
                string audioLanguagePriority_SelectedItems = string.Join(",", VM.AudioView.LanguagePriority_ListView_SelectedItems
                                                                   .Where(s => !string.IsNullOrEmpty(s)));
                inif.Write("Audio", "languagesSelected", audioLanguagePriority_SelectedItems);


                //// ------------
                //// Order
                //// ------------
                //List<string> listAudioLangOrder = new List<string>(VM.AudioView.LanguagePriority_ListView_Items/*ViewModel.AudioLanguageItems*/);
                //string audioLanguagesOrder = string.Join(",", listAudioLangOrder.Where(s => !string.IsNullOrEmpty(s)));
                //inif.Write("Audio", "languagesOrder", audioLanguagesOrder);

                //// ------------
                //// Selected
                //// ------------
                //List<string> listAudioLangSelected = new List<string>();
                //foreach (string item in VM.AudioView.LanguagePriority_ListView_SelectedItems/*mainwindow.listViewAudioLanguages_SelectedItems*/)
                //{
                //    // add checked item name to list
                //    listAudioLangSelected.Add(item);
                //}
                //string audioLanguagesSelected = string.Join(",", listAudioLangSelected.Where(s => !string.IsNullOrEmpty(s)));
                //inif.Write("Audio", "languagesSelected", audioLanguagesSelected);

                inif.Write("Audio", "channels", VM.AudioView.Channels_SelectedItem);
                inif.Write("Audio", "volume", VM.AudioView.Volume_Value.ToString());
                inif.Write("Audio", "volumeMax", VM.AudioView.VolumeMax_Value.ToString());
                //inif.Write("Audio", "softVolumeMax", vm.SoftVolumeMax_Text);
                inif.Write("Audio", "normalize", VM.AudioView.Normalize_SelectedItem);
                inif.Write("Audio", "scaleTempo", VM.AudioView.ScaleTempo_SelectedItem);
                inif.Write("Audio", "loadFiles", VM.AudioView.AudioLoadFiles_SelectedItem);

                // --------------------------------------------------
                // Subtitles
                // --------------------------------------------------
                inif.Write("Subtitles", "subtitles", VM.SubtitlesView.Subtitles_SelectedItem);

                // -------------------------
                // Languages
                // -------------------------
                // Order
                string subtitlesLanguagePriority_ItemOrder = string.Join(",", VM.SubtitlesView.LanguagePriority_ListView_Items
                                                                   .Where(s => !string.IsNullOrWhiteSpace(s)));
                inif.Write("Subtitles", "languagesOrder", subtitlesLanguagePriority_ItemOrder);

                // Selected
                string subtitlesLanguagePriority_SelectedItems = string.Join(",", VM.SubtitlesView.LanguagePriority_ListView_SelectedItems
                                                                       .Where(s => !string.IsNullOrEmpty(s)));
                inif.Write("Subtitles", "languagesSelected", subtitlesLanguagePriority_SelectedItems);

                //// ------------
                //// Order
                //// ------------
                //List<string> listSubtitlesLangOrder = new List<string>(VM.SubtitlesView.LanguagePriority_ListView_Items/*ViewModel.SubtitlesLanguageItems*/);
                //string subtitlesLanguagesOrder = string.Join(",", listSubtitlesLangOrder.Where(s => !string.IsNullOrEmpty(s)));
                //inif.Write("Subtitles", "languagesOrder", subtitlesLanguagesOrder);

                //// ------------
                //// Selected
                //// ------------
                //List<string> listSubtitlesLang = new List<string>();
                //foreach (string item in VM.SubtitlesView.LanguagePriority_ListView_SelectedItems/*mainwindow.listViewSubtitlesLanguages_SelectedItems*/)
                //{
                //    listSubtitlesLang.Add(item);
                //}
                //string subtitlesLanguages = string.Join(",", listSubtitlesLang.Where(s => !string.IsNullOrEmpty(s)));
                //inif.Write("Subtitles", "languagesSelected", subtitlesLanguages);

                inif.Write("Subtitles", "loadFiles", VM.SubtitlesView.LoadFiles_SelectedItem);
                inif.Write("Subtitles", "embeddedFonts", VM.SubtitlesView.EmbeddedFonts_SelectedItem);
                inif.Write("Subtitles", "position", VM.SubtitlesView.Position_Value.ToString());
                inif.Write("Subtitles", "fixTiming", VM.SubtitlesView.FixTiming_SelectedItem);
                inif.Write("Subtitles", "useMargins", VM.SubtitlesView.Margins_SelectedItem);
                inif.Write("Subtitles", "font", VM.SubtitlesView.Font_SelectedItem);
                inif.Write("Subtitles", "fontSize", VM.SubtitlesView.FontSize_SelectedItem);

                // Font Color
                inif.Write("Subtitles", "fontColor", VM.SubtitlesView.FontColor_Text);
                //selectedItem = (ComboBoxItem)(vm.FontColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("Subtitles", "fontColor", selected);

                // Border Size
                inif.Write("Subtitles", "borderSize", VM.SubtitlesView.BorderSize_SelectedItem);

                // Border Color
                inif.Write("Subtitles", "borderColor", VM.SubtitlesView.BorderColor_Text);
                //selectedItem = (ComboBoxItem)(vm.BorderColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("Subtitles", "borderColor", selected);

                // Shadow Color
                inif.Write("Subtitles", "shadowColor", VM.SubtitlesView.ShadowColor_Text);
                //selectedItem = (ComboBoxItem)(vm.ShadowColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("Subtitles", "shadowColor", selected);

                // Shadow Offset
                inif.Write("Subtitles", "shadowOffset", VM.SubtitlesView.ShadowOffset_Value.ToString());
                inif.Write("Subtitles", "blend", VM.SubtitlesView.Blend_SelectedItem);

                // ASS
                inif.Write("Subtitles", "ass", VM.SubtitlesView.ASS_SelectedItem);
                inif.Write("Subtitles", "assOverride", VM.SubtitlesView.ASSOverride_SelectedItem);
                inif.Write("Subtitles", "assForceMargins", VM.SubtitlesView.ASSForceMargins_SelectedItem);
                inif.Write("Subtitles", "assHinting", VM.SubtitlesView.ASSHinting_SelectedItem);
                inif.Write("Subtitles", "assKerning", VM.SubtitlesView.ASSKerning_SelectedItem);

                // --------------------------------------------------
                // Stream
                // --------------------------------------------------
                // Demuxer
                inif.Write("Stream", "demuxThread", VM.StreamView.DemuxerThread_SelectedItem);
                inif.Write("Stream", "demuxerBufferSize", VM.StreamView.DemuxerBuffersize_Text);
                inif.Write("Stream", "demuxerReadAhead", VM.StreamView.DemuxerReadahead_Text);
                inif.Write("Stream", "demuxerMKVSubtitlePreroll", VM.StreamView.DemuxerMKVSubPreroll_SelectedItem);
                // YouTube
                inif.Write("Stream", "youtubedl", VM.StreamView.YouTubeDL_SelectedItem);
                inif.Write("Stream", "youtubedlQuality", VM.StreamView.YouTubeDLQuality_SelectedItem);
                // Cache
                inif.Write("Stream", "cache", VM.StreamView.Cache_SelectedItem);
                inif.Write("Stream", "cacheDefault", VM.StreamView.CacheDefault_Text);
                inif.Write("Stream", "initial", VM.StreamView.CacheInitial_Text);
                inif.Write("Stream", "seekMin", VM.StreamView.CacheSeekMin_Text);
                inif.Write("Stream", "backBuffer", VM.StreamView.CacheBackbuffer_Text);
                inif.Write("Stream", "seconds", VM.StreamView.CacheSeconds_Text);
                inif.Write("Stream", "file", VM.StreamView.CacheFile_SelectedItem);
                inif.Write("Stream", "fileSize", VM.StreamView.CacheFileSize_Text);

                // --------------------------------------------------
                // OSC
                // --------------------------------------------------
                inif.Write("OSC", "osc", VM.DisplayView.OSC_SelectedItem);
                inif.Write("OSC", "oscLayout", VM.DisplayView.OSC_Layout_SelectedItem);
                inif.Write("OSC", "oscSeekbar", VM.DisplayView.OSC_Seekbar_SelectedItem);

                // --------------------------------------------------
                // OSD
                // --------------------------------------------------
                inif.Write("OSD", "videoOSD", VM.DisplayView.OSD_SelectedItem);
                inif.Write("OSD", "fractions", VM.DisplayView.OSD_Fractions_SelectedItem);
                inif.Write("OSD", "duration", VM.DisplayView.OSD_Duration_Text);
                inif.Write("OSD", "level", VM.DisplayView.OSD_Level_SelectedItem);
                inif.Write("OSD", "scale", VM.DisplayView.OSC_Scale_Value.ToString());
                inif.Write("OSD", "barWidth", VM.DisplayView.OSC_BarWidth_Value.ToString());
                inif.Write("OSD", "barHeight", VM.DisplayView.OSC_BarHeight_Value.ToString());
                inif.Write("OSD", "font", VM.DisplayView.OSD_Font_SelectedItem);
                inif.Write("OSD", "fontSize", VM.DisplayView.OSD_FontSize_SelectedItem);

                inif.Write("OSD", "fontColor", VM.DisplayView.OSD_FontColor_Text);
                //selectedItem = (ComboBoxItem)(VM.DisplayView.OSD_FontColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("OSD", "fontColor", selected);

                inif.Write("OSD", "borderSize", VM.DisplayView.OSD_FontBorderSize_SelectedItem);

                inif.Write("OSD", "borderColor", VM.DisplayView.OSD_BorderColor_Text);
                //selectedItem = (ComboBoxItem)(VM.DisplayView.OSDBorderColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("OSD", "borderColor", selected);

                inif.Write("OSD", "shadowColor", VM.DisplayView.OSD_ShadowColor_Text);
                //selectedItem = (ComboBoxItem)(VM.DisplayView.OSDShadowColor.SelectedValue);
                //selected = (string)(selectedItem.Content);
                //inif.Write("OSD", "shadowColor", selected);

                inif.Write("OSD", "shadowOffset", VM.DisplayView.OSD_ShadowOffset_Value.ToString());

                // --------------------------------------------------
                // Extensions
                // --------------------------------------------------
                inif.Write("Extensions", "mkv", VM.GeneralView.ExtMKV_SelectedItem);
                inif.Write("Extensions", "mp4", VM.GeneralView.ExtMP4_SelectedItem);
                inif.Write("Extensions", "webm", VM.GeneralView.ExtWebM_SelectedItem);
                inif.Write("Extensions", "gif", VM.GeneralView.ExtGIF_SelectedItem);
                inif.Write("Extensions", "jpg", VM.GeneralView.ExtJPG_SelectedItem);
                inif.Write("Extensions", "png", VM.GeneralView.ExtPNG_SelectedItem);
            }

            // Create Presets Directory if does not exist
            else
            {
                // Yes/No Dialog Confirmation
                //
                MessageBoxResult resultExport = MessageBox.Show("Presets Folder does not exist. Automatically create it?",
                                                                "Directory Not Found",
                                                                MessageBoxButton.YesNo,
                                                                MessageBoxImage.Information);
                switch (resultExport)
                {
                    // Create
                    case MessageBoxResult.Yes:
                        try
                        {
                            Directory.CreateDirectory(VM.ConfigureView.PresetsPath_Text);
                        }
                        catch
                        {
                            MessageBox.Show("Could not create Presets folder. May require Administrator privileges.",
                                            "Error",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Error);
                        }
                        break;
                    // Use Default
                    case MessageBoxResult.No:
                        break;
                }
            }
        }


        /// <summary>
        ///    Import Preset
        /// </summary>
        public static void ImportPreset(MainWindow mainwindow, string preset)
        {
            // If control failed to imported, add to list
            List<string> listFailedImports = new List<string>();

            // Start INI File Read
            Configure.ConfigFile inif = null;

            // -------------------------
            // Check if Preset ini file exists
            // -------------------------
            if (File.Exists(preset))
            {
                inif = new Configure.ConfigFile(preset);

                // --------------------------------------------------
                // General
                // --------------------------------------------------
                // Priority
                string priority = inif.Read("General", "priority");
                if (VM.GeneralView.Priority_Items.Contains(priority))
                    VM.GeneralView.Priority_SelectedItem = priority;
                else
                    listFailedImports.Add("General: Priority");

                // Save Position
                string savePositiOnQuit = inif.Read("General", "savePositiOnQuit");
                if (VM.GeneralView.SavePositionQuit_Items.Contains(savePositiOnQuit))
                    VM.GeneralView.SavePositionQuit_SelectedItem = savePositiOnQuit;
                else
                    listFailedImports.Add("General: Save Position");

                // Keep Open
                string keepOpen = inif.Read("General", "keepOpen");
                if (VM.GeneralView.KeepOpen_Items.Contains(keepOpen))
                    VM.GeneralView.KeepOpen_SelectedItem = keepOpen;
                else
                    listFailedImports.Add("General: Keep Open");

                // On Top
                string onTop = inif.Read("General", "onTop");
                if (VM.GeneralView.OnTop_Items.Contains(onTop))
                    VM.GeneralView.OnTop_SelectedItem = onTop;
                else
                    listFailedImports.Add("General: On Top");

                // Border
                string border = inif.Read("General", "border");
                if (VM.GeneralView.WindowBorder_Items.Contains(border))
                    VM.GeneralView.WindowBorder_SelectedItem = border;
                else
                    listFailedImports.Add("General: Border");

                // Geometry X
                double geometryX = 0;
                double.TryParse(inif.Read("General", "geometryX"), out geometryX);
                VM.GeneralView.GeometryX_Value = geometryX;

                // Geometry Y
                double geometryY = 0;
                double.TryParse(inif.Read("General", "geometryY"), out geometryY);
                VM.GeneralView.GeometryY_Value = geometryY;

                // Autofit Width
                double autofitWidth = 0;
                double.TryParse(inif.Read("General", "autofitWidth"), out autofitWidth);
                VM.GeneralView.AutofitWidth_Value = autofitWidth;

                // Autofit Height
                double autofitHeight = 0;
                double.TryParse(inif.Read("General", "autofitHeight"), out autofitHeight);
                VM.GeneralView.AutofitHeight_Value = autofitHeight;

                // Screensaver
                string screensaver = inif.Read("General", "screensaver");
                if (VM.GeneralView.Screensaver_Items.Contains(screensaver))
                    VM.GeneralView.Screensaver_SelectedItem = screensaver;
                else
                    listFailedImports.Add("General: Screensaver");

                // Window Title
                string windowTitle = inif.Read("General", "windowTitle");
                if (VM.GeneralView.WindowTitle_Items.Contains(windowTitle))
                    VM.GeneralView.WindowTitle_SelectedItem = windowTitle;
                else
                    listFailedImports.Add("General: Window Title");

                // Log Path
                VM.GeneralView.LogPath_Text = inif.Read("General", "logPath");

                // Screenshot Path
                VM.GeneralView.ScreenshotPath_Text = inif.Read("General", "screenshotPath");

                // Screenshot Template
                string screenshotTemplate = inif.Read("General", "screenshotTemplate");
                if (VM.GeneralView.ScreenshotTemplate_Items.Contains(screenshotTemplate))
                    VM.GeneralView.ScreenshotTemplate_SelectedItem = screenshotTemplate;
                else
                    listFailedImports.Add("General: Screenshot Template");

                // Screenshot Tag Colorspace
                string screenshotTagColorspace = inif.Read("General", "screenshotTagColorspace");
                if (VM.GeneralView.ScreenshotTagColorspace_Items.Contains(screenshotTagColorspace))
                    VM.GeneralView.ScreenshotTagColorspace_SelectedItem = screenshotTagColorspace;
                else
                    listFailedImports.Add("General: Screenshot Tag Colorspace");

                // Screenshot Format
                string screenshotFormat = inif.Read("General", "screenshotFormat");
                if (VM.GeneralView.ScreenshotFormat_Items.Contains(screenshotFormat))
                    VM.GeneralView.ScreenshotFormat_SelectedItem = screenshotFormat;
                else
                    listFailedImports.Add("General: Screenshot Format");

                // Screenshot Quality
                double screenshotQuality = 0;
                double.TryParse(inif.Read("General", "screenshotQuality"), out screenshotQuality);
                VM.GeneralView.ScreenshotQuality_Value = screenshotQuality;

                // --------------------------------------------------
                // Video
                // --------------------------------------------------
                // -------------------------
                // Hardware
                // -------------------------
                // Video Driver
                string videoDriver = inif.Read("Video", "videoDriver");
                if (VM.VideoView.VideoDriver_Items.Contains(videoDriver))
                    VM.VideoView.VideoDriver_SelectedItem = videoDriver;
                else
                    listFailedImports.Add("Video: Video Driver");

                // Video Driver API
                string videoDriverAPI = inif.Read("Video", "videoDriverAPI");
                if (VM.VideoView.VideoDriverAPI_Items.Contains(videoDriverAPI))
                    VM.VideoView.VideoDriverAPI_SelectedItem = videoDriverAPI;
                else
                    listFailedImports.Add("Video: Video Driver API");

                // OpenGL PBO
                string openglPBO = inif.Read("Video", "openglPBO");
                if (VM.VideoView.OpenGLPBO_Items.Contains(openglPBO))
                    VM.VideoView.OpenGLPBO_SelectedItem = openglPBO;
                else
                    listFailedImports.Add("Video: OpenGL PBO");

                // OpenGL PBO Format
                string openglPBOFormat = inif.Read("Video", "openglPBOFormat");
                if (VM.VideoView.OpenGLPBOFormat_Items.Contains(openglPBOFormat))
                    VM.VideoView.OpenGLPBOFormat_SelectedItem = openglPBOFormat;
                else
                    listFailedImports.Add("Video: OpenGL PBO Format");

                // HW Decoder
                string hwdec = inif.Read("Video", "hwdec");
                if (VM.VideoView.HWDecoder_Items.Contains(hwdec))
                    VM.VideoView.HWDecoder_SelectedItem = hwdec;
                else
                    listFailedImports.Add("Video: HW Decoder");

                // -------------------------
                // Display
                // -------------------------

                // ICC Preset
                string ICCProfile = inif.Read("Video", "ICCProfile");
                if (ICCProfile != "default" && ICCProfile != "auto" && ICCProfile != "select")
                {
                    VM.VideoView.ICCProfile_Items.Add(ICCProfile);
                    VM.VideoView.ICCProfile_SelectedItem = ICCProfile;
                    VM.VideoView.ICCProfile_IsEditable = true;
                }

                if (VM.VideoView.ICCProfile_Items.Contains(ICCProfile))
                    VM.VideoView.ICCProfile_SelectedItem = ICCProfile;
                else
                    listFailedImports.Add("Video: Display Primaries");
                //vm.ICCProfilePath_Text = inif.Read("Video", "ICCProfilePath");

                // Display Primaries
                string displayPrimaries = inif.Read("Video", "displayPrimaries");
                if (VM.VideoView.DisplayPrimaries_Items.Contains(displayPrimaries))
                    VM.VideoView.DisplayPrimaries_SelectedItem = displayPrimaries;
                else
                    listFailedImports.Add("Video: Display Primaries");

                // Transfer Characteristics
                string transferCharacteristics = inif.Read("Video", "transferCharacteristics");
                if (VM.VideoView.TransferCharacteristics_Items.Contains(transferCharacteristics))
                    VM.VideoView.TransferCharacteristics_SelectedItem = transferCharacteristics;
                else
                    listFailedImports.Add("Video: Transfer Characteristics");

                // Color Space
                string colorSpace = inif.Read("Video", "colorSpace");
                if (VM.VideoView.ColorSpace_Items.Contains(colorSpace))
                    VM.VideoView.ColorSpace_SelectedItem = colorSpace;
                else
                    listFailedImports.Add("Video: Color Space");

                // Color Range
                string colorRange = inif.Read("Video", "colorRange");
                if (VM.VideoView.ColorRange_Items.Contains(colorRange))
                    VM.VideoView.ColorRange_SelectedItem = colorRange;
                else
                    listFailedImports.Add("Video: Color Range");

                // Deinterlace
                string deinterlace = inif.Read("Video", "deinterlace");
                if (VM.VideoView.Deinterlace_Items.Contains(deinterlace))
                    VM.VideoView.Deinterlace_SelectedItem = deinterlace;
                else
                    listFailedImports.Add("Video: Deinterlace");

                // Interpolation
                string interpolation = inif.Read("Video", "interpolation");
                if (VM.VideoView.Interpolation_Items.Contains(interpolation))
                    VM.VideoView.Interpolation_SelectedItem = interpolation;
                else
                    listFailedImports.Add("Video: Interpolation");

                // Video Sync
                string videoSync = inif.Read("Video", "videoSync");
                if (VM.VideoView.VideoSync_Items.Contains(videoSync))
                    VM.VideoView.VideoSync_SelectedItem = videoSync;
                else
                    listFailedImports.Add("Video: Video Sync");

                // Frame Drop
                string frameDrop = inif.Read("Video", "frameDrop");
                if (VM.VideoView.Framedrop_Items.Contains(frameDrop))
                    VM.VideoView.Framedrop_SelectedItem = frameDrop;
                else
                    listFailedImports.Add("Video: Frame Drop");

                // -------------------------
                // Image
                // -------------------------
                double brightness = 0;
                double.TryParse(inif.Read("Video", "brightness"), out brightness);
                VM.VideoView.Brightness_Value = brightness;

                double contrast = 0;
                double.TryParse(inif.Read("Video", "contrast"), out contrast);
                VM.VideoView.Contrast_Value = contrast;

                double hue = 0;
                double.TryParse(inif.Read("Video", "hue"), out hue);
                VM.VideoView.Hue_Value = hue;

                double saturation = 0;
                double.TryParse(inif.Read("Video", "saturation"), out saturation);
                VM.VideoView.Saturation_Value = saturation;

                double gamma = 0;
                double.TryParse(inif.Read("Video", "gamma"), out gamma);
                VM.VideoView.Gamma_Value = gamma;

                // Gamma Auto
                //string gammaAuto = inif.Read("Video", "gammaAuto");
                //if (vm.GammaAuto_Items.Contains(gammaAuto))
                //    vm.GammaAuto_SelectedItem = gammaAuto;
                //else
                //    listFailedImports.Add("Video: Gamma Auto");

                // Deband
                string deband = inif.Read("Video", "deband");
                if (VM.VideoView.Deband_Items.Contains(deband))
                    VM.VideoView.Deband_SelectedItem = deband;
                else
                    listFailedImports.Add("Video: Deband");

                // Deband Grain
                VM.VideoView.DebandGrain_Text = inif.Read("Video", "debandGrain");

                // Dither
                string dither = inif.Read("Video", "dither");
                if (VM.VideoView.Dither_Items.Contains(dither))
                    VM.VideoView.Dither_SelectedItem = dither;
                else
                    listFailedImports.Add("Video: Dither");

                // -------------------------
                // Scaling
                // -------------------------
                // Sigmoid Upscaling
                string sigmoidUpscaling = inif.Read("Video", "sigmoidUpscaling");
                if (VM.VideoView.Sigmoid_Items.Contains(sigmoidUpscaling))
                    VM.VideoView.Sigmoid_SelectedItem = sigmoidUpscaling;
                else
                    listFailedImports.Add("Video: Sigmoid");

                // Scale
                string scale = inif.Read("Video", "scale");
                if (VM.VideoView.Scale_Items.Contains(scale))
                    VM.VideoView.Scale_SelectedItem = scale;
                else
                    listFailedImports.Add("Video: Scale");

                // Scale Antiring
                double scaleAntiring = 0.0;
                double.TryParse(inif.Read("Video", "scaleAntiring"), out scaleAntiring);
                VM.VideoView.ScaleAntiring_Value = scaleAntiring;

                // Chroma Scale
                string chromaScale = inif.Read("Video", "chromaScale");
                if (VM.VideoView.ChromaScale_Items.Contains(chromaScale))
                    VM.VideoView.ChromaScale_SelectedItem = chromaScale;
                else
                    listFailedImports.Add("Video: Chroma Scale");

                // Chroma Antiring
                double chromaScaleAntiring = 0.0;
                double.TryParse(inif.Read("Video", "chromaScaleAntiring"), out chromaScaleAntiring);
                VM.VideoView.ChromaAntiring_Value = chromaScaleAntiring;

                // Downscale
                string downscale = inif.Read("Video", "downscale");
                if (VM.VideoView.Downscale_Items.Contains(downscale))
                    VM.VideoView.Downscale_SelectedItem = downscale;
                else
                    listFailedImports.Add("Video: Downscale");

                // Downscale Antiring
                double downscaleAntiring = 0.0;
                double.TryParse(inif.Read("General", "downscaleAntiring"), out downscaleAntiring);
                VM.VideoView.DownscaleAntiring_Value = downscaleAntiring;

                // Interpolation Scale
                string tscale = inif.Read("Video", "interpolationScale");
                if (VM.VideoView.InterpolationScale_Items.Contains(tscale))
                    VM.VideoView.InterpolationScale_SelectedItem = tscale;
                else
                    listFailedImports.Add("Video: Interpolation Scale");

                // Interpolation Antiring
                double interpolationAntiring = 0.0;
                double.TryParse(inif.Read("Video", "interpolationAntiring"), out interpolationAntiring);
                VM.VideoView.InterpolationScaleAntiring_Value = interpolationAntiring;

                // Software Scaler
                string softwareScaler = inif.Read("Video", "softwareScaler");
                if (VM.VideoView.SoftwareScaler_Items.Contains(softwareScaler))
                    VM.VideoView.SoftwareScaler_SelectedItem = softwareScaler;
                else
                    listFailedImports.Add("Video: Software Scaler");

                // --------------------------------------------------
                // Audio
                // --------------------------------------------------
                // Audio Driver
                string audioDriver = inif.Read("Audio", "driver");
                if (VM.AudioView.AudioDriver_Items.Contains(audioDriver))
                    VM.AudioView.AudioDriver_SelectedItem = audioDriver;
                else
                    listFailedImports.Add("Audio: Audio Driver");

                // Channels
                string channels = inif.Read("Audio", "channels");
                if (VM.AudioView.Channels_Items.Contains(channels))
                    VM.AudioView.Channels_SelectedItem = channels;
                else
                    listFailedImports.Add("Audio: Channels");

                // Volume
                double volume = 100;
                double.TryParse(inif.Read("Audio", "volume"), out volume);
                VM.AudioView.Volume_Value = volume;

                double volumeMax = 100;
                double.TryParse(inif.Read("Audio", "volumeMax"), out volumeMax);
                VM.AudioView.VolumeMax_Value = volumeMax;

                // Soft Volume Max
                //vm.SoftVolumeMax_Text = inif.Read("Audio", "softVolumeMax");

                // Scale Tempo
                string normalize = inif.Read("Audio", "normalize");
                if (VM.AudioView.Normalize_Items.Contains(normalize))
                    VM.AudioView.Normalize_SelectedItem = normalize;
                else
                    listFailedImports.Add("Audio: Normalize");

                // Scale Tempo
                string scaleTempo = inif.Read("Audio", "scaleTempo");
                if (VM.AudioView.ScaleTempo_Items.Contains(scaleTempo))
                    VM.AudioView.ScaleTempo_SelectedItem = scaleTempo;
                else
                    listFailedImports.Add("Audio: Scale Tempo");

                // Load Files
                string AudioLoadFiles = inif.Read("Audio", "loadFiles");
                if (VM.AudioView.AudioLoadFiles_Items.Contains(AudioLoadFiles))
                    VM.AudioView.AudioLoadFiles_SelectedItem = AudioLoadFiles;
                else
                    listFailedImports.Add("Audio: Load Files");

                // -------------------------
                // languages
                // -------------------------
                // Language Priority
                // import full list new order
                string audioLanguagePriority_ItemOrder = inif.Read("Audio", "languagesOrder");
                // null check
                if (!string.IsNullOrWhiteSpace(audioLanguagePriority_ItemOrder))
                {
                    // Split the list by commas
                    string[] arrLanguagePriority_ItemOrder = audioLanguagePriority_ItemOrder.Split(',');

                    // Create the new list
                    // Remove Duplicates
                    VM.AudioView.LanguagePriority_ListView_Items = new ObservableCollection<string>(arrLanguagePriority_ItemOrder
                                                                                                    .Distinct()
                                                                                                    .ToList()
                                                                                                    .AsEnumerable()
                                                                                                   );
                    //VM.ConfigureView.LanguagePriority_ListView_Items = arrLanguagePriority_ItemOrder.Distinct().ToList();

                    // Check the Master Default List for Missing Items
                    //IEnumerable<string> missingItems = MainWindow.LanguagePriority_Defaults
                    //                                             .Except(VM.AudioView.LanguagePriority_ListView_Items/*arrLanguagePriority_ItemOrder*/)
                    //                                             .ToList()
                    //                                             .AsEnumerable();
                    //List<string> missingItems = MainWindow.LanguagePriority_Defaults.Except(arrLanguagePriority_ItemOrder).ToList();

                    //foreach (string item in missingItems)
                    //{
                    //    VM.AudioView.LanguagePriority_ListView_Items.Add(item/*missingItems[i]*/);
                    //}

                    // Selected Items String (items separated by commas)
                    string LanguagePriority_SelectedItems = inif.Read("Audio", "languagesSelected");
                    // Empty List Check
                    if (!string.IsNullOrEmpty(LanguagePriority_SelectedItems))
                    {
                        // Split
                        string[] arrLanguagePriority_SelectedItems = LanguagePriority_SelectedItems.Split(',');

                        // Remove Duplicates
                        List<string> lstLanguagePriority_SelectedItems = arrLanguagePriority_SelectedItems.Distinct().ToList();

                        // Import Selected Items
                        for (var i = 0; i < lstLanguagePriority_SelectedItems.Count; i++)
                        {
                            // If Items List Contains the Imported Item
                            if (VM.AudioView.LanguagePriority_ListView_Items.Contains(arrLanguagePriority_SelectedItems[i]))
                            {
                                // Added Item to Selected Items List
                                //VM.ConfigureView.LanguagePriority_ListView_SelectedItems.Add(arrLanguagePriority_SelectedItems[i]);

                                // Select the Item
                                try
                                {
                                    mainwindow.listViewAudioLanguages.SelectedItems.Add(arrLanguagePriority_SelectedItems[i]);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }

                //// ------------
                //// Order
                //// ------------
                //// import full list new order
                //string audioLangOrder = inif.Read("Audio", "languagesOrder");
                //string[] arrAudioLangOrder = audioLangOrder.Split(',');
                //// recreate the list
                ////ViewModel.listAudioLang = new List<string>(arrAudioLangOrder);
                //// recreate item sources
                ////ViewModel._audioLangItems = new ObservableCollection<string>(ViewModel.listAudioLang);
                ////mainwindow.listViewAudioLanguages.ItemsSource = ViewModel._audioLangItems;
                //VM.AudioView.LanguagePriority_ListView_Items = new ObservableCollection<string>(arrAudioLangOrder);

                //// ------------
                //// Selected
                //// ------------
                //string audioLanguagesSelected = inif.Read("Audio", "languagesSelected");
                //// Empty List Check
                //if (!string.IsNullOrEmpty(audioLanguagesSelected))
                //{
                //    string[] arrAudioLang = audioLanguagesSelected.Split(',');
                //    foreach (string item in arrAudioLang)
                //    {
                //        if (/*mainwindow.listViewAudioLanguages.Items*/VM.AudioView.LanguagePriority_ListView_Items.Contains(item))
                //        {

                //            VM.AudioView.LanguagePriority_ListView_SelectedItems.Add(item);
                //            mainwindow.listViewAudioLanguages.Add(item);
                //        }
                //        else
                //        {
                //            listFailedImports.Add("Audio Languages: " + item);
                //        }
                //    }
                //}

                // --------------------------------------------------
                // Subtitles
                // --------------------------------------------------
                // Subtitles
                string subtitles = inif.Read("Subtitles", "subtitles");
                if (VM.SubtitlesView.Subtitles_Items.Contains(subtitles))
                    VM.SubtitlesView.Subtitles_SelectedItem = subtitles;
                else
                    listFailedImports.Add("Subtitles: Subtitles");

                // Subtitles Load Files
                string subtitlesLoadFiles = inif.Read("Subtitles", "loadFiles");
                if (VM.SubtitlesView.LoadFiles_Items.Contains(subtitlesLoadFiles))
                    VM.SubtitlesView.LoadFiles_SelectedItem = subtitlesLoadFiles;
                else
                    listFailedImports.Add("Subtitles: Load Files");

                // Subtitles Embedded Fonts
                string subtitlesEmbeddedFonts = inif.Read("Subtitles", "embeddedFonts");
                if (VM.SubtitlesView.EmbeddedFonts_Items.Contains(subtitlesEmbeddedFonts))
                    VM.SubtitlesView.EmbeddedFonts_SelectedItem = subtitlesEmbeddedFonts;
                else
                    listFailedImports.Add("Subtitles: Embedded Fonts");

                // Subtitles Position
                double position = 0.0;
                double.TryParse(inif.Read("Subtitles", "position"), out position);
                VM.SubtitlesView.Position_Value = position;

                // Fix Timing
                string fixTiming = inif.Read("Subtitles", "fixTiming");
                if (VM.SubtitlesView.FixTiming_Items.Contains(fixTiming))
                    VM.SubtitlesView.FixTiming_SelectedItem = fixTiming;
                else
                    listFailedImports.Add("Subtitles: Fix Timing");

                // Margins
                string useMargins = inif.Read("Subtitles", "useMargins");
                if (VM.SubtitlesView.Margins_Items.Contains(useMargins))
                    VM.SubtitlesView.Margins_SelectedItem = useMargins;
                else
                    listFailedImports.Add("Subtitles: Margins");

                // Blend
                string blend = inif.Read("Subtitles", "blend");
                if (VM.SubtitlesView.Blend_Items.Contains(blend))
                    VM.SubtitlesView.Blend_SelectedItem = blend;
                else
                    listFailedImports.Add("Subtitles: Blend");

                // Subtitles Font
                string subtitlesfont = inif.Read("Subtitles", "font");
                if (VM.SubtitlesView.Font_Items.Contains(subtitlesfont))
                    VM.SubtitlesView.Font_SelectedItem = subtitlesfont;
                else
                    listFailedImports.Add("Subtitles: Font");

                // Font Size
                string fontSize = inif.Read("Subtitles", "fontSize");
                if (VM.SubtitlesView.FontSize_Items.Contains(fontSize))
                    VM.SubtitlesView.FontSize_SelectedItem = fontSize;
                else
                    listFailedImports.Add("Subtitles: Font Size");

                // Font Color
                VM.SubtitlesView.FontColor_Text = inif.Read("Subtitles", "fontColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listFontColor = new List<string>();
                //foreach (var item in vm.FontColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listFontColor.Add(current);
                //}
                //// read ini color
                //string subtitlesFontColor = inif.Read("Subtitles", "fontColor");
                //// if temp list contains color
                //if (listFontColor.Contains(subtitlesFontColor))
                //    vm.FontColor_SelectedItem = vm.FontColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == subtitlesFontColor);
                //else
                //    listFailedImports.Add("Subtitles: Font Color");


                // Border Color
                VM.SubtitlesView.BorderColor_Text = inif.Read("Subtitles", "borderColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listBorderColor = new List<string>();
                //foreach (var item in vm.BorderColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listBorderColor.Add(current);
                //}
                //// read ini color
                //string subtitlesBorderColor = inif.Read("Subtitles", "borderColor");
                //// if temp list contains color
                //if (listBorderColor.Contains(subtitlesBorderColor))
                //    vm.BorderColor_SelectedItem = vm.BorderColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == subtitlesBorderColor);
                //else
                //    listFailedImports.Add("Subtitles: Border Color");


                // Border Size
                string subtitlesBorderSize = inif.Read("Subtitles", "borderSize");
                if (VM.SubtitlesView.BorderSize_Items.Contains(subtitlesBorderSize))
                    VM.SubtitlesView.BorderSize_SelectedItem = subtitlesBorderSize;
                else
                    listFailedImports.Add("Subtitles: Border Size");


                // Shadow Color
                VM.SubtitlesView.ShadowColor_Text = inif.Read("Subtitles", "shadowColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listShadowColor = new List<string>();
                //foreach (var item in vm.ShadowColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listShadowColor.Add(current);
                //}
                //// read ini color
                //string subtitlesShadowColor = inif.Read("Subtitles", "shadowColor");
                //// if temp list contains color
                //if (listShadowColor.Contains(subtitlesShadowColor))
                //    vm.ShadowColor_SelectedItem = vm.ShadowColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == subtitlesShadowColor);
                //else
                //    listFailedImports.Add("Subtitles: Shadow Color");

                // Shadow Offset
                double subsShadowOffset = 0.0;
                double.TryParse(inif.Read("Subtitles", "shadowOffset"), out subsShadowOffset);
                VM.SubtitlesView.ShadowOffset_Value = subsShadowOffset;

                // ASS
                string subtitlesASS = inif.Read("Subtitles", "ass");
                if (VM.SubtitlesView.ASS_Items.Contains(subtitlesASS))
                    VM.SubtitlesView.ASS_SelectedItem = subtitlesASS;
                else
                    listFailedImports.Add("Subtitles: ASS");

                // ASS Override
                string subtitlesASSOverride = inif.Read("Subtitles", "assOverride");
                if (VM.SubtitlesView.ASSOverride_Items.Contains(subtitlesASSOverride))
                    VM.SubtitlesView.ASSOverride_SelectedItem = subtitlesASSOverride;
                else
                    listFailedImports.Add("Subtitles: ASS Override");

                // ASS ForceMargins
                string subtitlesASSForceMargins = inif.Read("Subtitles", "assForceMargins");
                if (VM.SubtitlesView.ASSForceMargins_Items.Contains(subtitlesASSForceMargins))
                    VM.SubtitlesView.ASSForceMargins_SelectedItem = subtitlesASSForceMargins;
                else
                    listFailedImports.Add("Subtitles: ASS ForceMargins");

                // ASS Hinting
                string subtitlesASSHinting = inif.Read("Subtitles", "assHinting");
                if (VM.SubtitlesView.ASSHinting_Items.Contains(subtitlesASSHinting))
                    VM.SubtitlesView.ASSHinting_SelectedItem = subtitlesASSHinting;
                else
                    listFailedImports.Add("Subtitles: ASS Hinting");

                // ASS Kerning
                string subtitlesASSKerning = inif.Read("Subtitles", "assKerning");
                if (VM.SubtitlesView.ASSKerning_Items.Contains(subtitlesASSKerning))
                    VM.SubtitlesView.ASSKerning_SelectedItem = subtitlesASSKerning;
                else
                    listFailedImports.Add("Subtitles: ASS Kerning");

                // -------------------------
                // languages
                // -------------------------
                // Language Priority
                // import full list new order
                string subtitlesLanguagePriority_ItemOrder = inif.Read("Subtitles", "languagesOrder");
                // null check
                if (!string.IsNullOrWhiteSpace(subtitlesLanguagePriority_ItemOrder))
                {
                    // Split the list by commas
                    string[] arrLanguagePriority_ItemOrder = subtitlesLanguagePriority_ItemOrder.Split(',');

                    // Create the new list
                    // Remove Duplicates
                    VM.SubtitlesView.LanguagePriority_ListView_Items = new ObservableCollection<string>(arrLanguagePriority_ItemOrder
                                                                                                    .Distinct()
                                                                                                    .ToList()
                                                                                                    .AsEnumerable()
                                                                                                   );
                    //VM.ConfigureView.LanguagePriority_ListView_Items = arrLanguagePriority_ItemOrder.Distinct().ToList();

                    // Check the Master Default List for Missing Items
                    //IEnumerable<string> missingItems = MainWindow.LanguagePriority_Defaults
                    //                                             .Except(VM.SubtitlesView.LanguagePriority_ListView_Items/*arrLanguagePriority_ItemOrder*/)
                    //                                             .ToList()
                    //                                             .AsEnumerable();
                    //List<string> missingItems = MainWindow.LanguagePriority_Defaults.Except(arrLanguagePriority_ItemOrder).ToList();

                    //foreach (string item in missingItems)
                    //{
                    //    VM.SubtitlesView.LanguagePriority_ListView_Items.Add(item/*missingItems[i]*/);
                    //}

                    // Selected Items String (items separated by commas)
                    string LanguagePriority_SelectedItems = inif.Read("Subtitles", "languagesSelected");
                    // Empty List Check
                    if (!string.IsNullOrEmpty(LanguagePriority_SelectedItems))
                    {
                        // Split
                        string[] arrLanguagePriority_SelectedItems = LanguagePriority_SelectedItems.Split(',');

                        // Remove Duplicates
                        List<string> lstLanguagePriority_SelectedItems = arrLanguagePriority_SelectedItems.Distinct().ToList();

                        // Import Selected Items
                        for (var i = 0; i < lstLanguagePriority_SelectedItems.Count; i++)
                        {
                            // If Items List Contains the Imported Item
                            if (VM.SubtitlesView.LanguagePriority_ListView_Items.Contains(arrLanguagePriority_SelectedItems[i]))
                            {
                                // Added Item to Selected Items List
                                //VM.ConfigureView.LanguagePriority_ListView_SelectedItems.Add(arrLanguagePriority_SelectedItems[i]);

                                // Select the Item
                                try
                                {
                                    mainwindow.listViewSubtitlesLanguages.SelectedItems.Add(arrLanguagePriority_SelectedItems[i]);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }

                //// ------------
                //// Order
                //// ------------
                //// import full list new order
                //string subtitlesLangOrder = inif.Read("Subtitles", "languagesOrder");
                //string[] arrSubtitlesLangOrder = subtitlesLangOrder.Split(',');
                //// recreate the list
                ////ViewModel.listSubtitlesLang = new List<string>(arrSubtitlesLangOrder);
                //// recreate item sources
                ////ViewModel._subsLangItems = new ObservableCollection<string>(ViewModel.listSubtitlesLang);
                ////mainwindow.listViewSubtitlesLanguages_ItemsSource = ViewModel._subsLangItems;
                //VM.SubtitlesView.LanguagePriority_ListView_Items = new ObservableCollection<string>(arrSubtitlesLangOrder);

                //// ------------
                //// Selected
                //// ------------
                //string subtitlesLanguagesSelected = inif.Read("Subtitles", "languagesSelected");
                //// Empty List Check
                //if (!string.IsNullOrEmpty(subtitlesLanguagesSelected))
                //{
                //    string[] arrSubtitlesLang = subtitlesLanguagesSelected.Split(',');
                //    foreach (string item in arrSubtitlesLang)
                //    {
                //        if (/*mainwindow.listViewSubtitlesLanguages_Items*/VM.SubtitlesView.LanguagePriority_ListView_Items.Contains(item))
                //        {
                //            //mainwindow.listViewSubtitlesLanguages_SelectedItems.Add(item);
                //            VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Add(item);
                //        }
                //        else
                //        {
                //            listFailedImports.Add("Subtitles Languages: " + item);
                //        }
                //    }
                //}

                // --------------------------------------------------
                // Stream
                // --------------------------------------------------
                // Demux Thread
                string demuxThread = inif.Read("Stream", "demuxThread");
                if (VM.StreamView.DemuxerThread_Items.Contains(demuxThread))
                    VM.StreamView.DemuxerThread_SelectedItem = demuxThread;
                else
                    listFailedImports.Add("Stream: Demux Thread");

                // Demuxer Buffer Size
                VM.StreamView.DemuxerBuffersize_Text = inif.Read("Stream", "demuxerBufferSize");

                // Demuxer Read Ahead
                VM.StreamView.DemuxerReadahead_Text = inif.Read("Stream", "demuxerReadAhead");

                // Demuxer MKV Subtitle Preroll
                VM.StreamView.DemuxerMKVSubPreroll_SelectedItem = inif.Read("Stream", "demuxerMKVSubtitlePreroll");


                // youtube-dl
                string youtubedl = inif.Read("Stream", "youtubedl");
                if (VM.StreamView.YouTubeDL_Items.Contains(youtubedl))
                    VM.StreamView.YouTubeDL_SelectedItem = youtubedl;
                else
                    listFailedImports.Add("Stream: youtube-dl");

                // YouTube Quality
                string youTubeDLQuality = inif.Read("Stream", "youtubedlQuality");
                if (VM.StreamView.YouTubeDLQuality_Items.Contains(youTubeDLQuality))
                    VM.StreamView.YouTubeDLQuality_SelectedItem = youTubeDLQuality;
                else
                    listFailedImports.Add("Stream: youtubedlQuality");


                // Cache
                string cache = inif.Read("Stream", "cache");
                if (VM.StreamView.Cache_Items.Contains(cache))
                    VM.StreamView.Cache_SelectedItem = cache;
                else
                    listFailedImports.Add("Stream: Cache");

                // Cache
                //VM.StreamView.CacheDefault_Text = inif.Read("Stream", "cacheDefault");
                //VM.StreamView.CacheInitial_Text = inif.Read("Stream", "initial");
                //VM.StreamView.CacheSeekMin_Text = inif.Read("Stream", "seekMin");
                //VM.StreamView.CacheBackbuffer_Text = inif.Read("Stream", "backBuffer");
                //VM.StreamView.CacheSeconds_Text = inif.Read("Stream", "seconds");

                // Cache File
                //string cachefile = inif.Read("Stream", "file");
                //if (VM.StreamView.CacheFile_Items.Contains(cachefile))
                //    VM.StreamView.CacheFile_SelectedItem = cachefile;
                //else
                //    listFailedImports.Add("Stream: Cache File");

                // Cache File Size
                //VM.StreamView.CacheFileSize_Text = inif.Read("Stream", "fileSize");

                // --------------------------------------------------
                // OSC
                // --------------------------------------------------
                // OSC
                string osc = inif.Read("OSC", "osc");
                if (VM.DisplayView.OSC_Items.Contains(osc))
                    VM.DisplayView.OSC_SelectedItem = osc;
                else
                    listFailedImports.Add("OSC: OSC");

                // OSC Layout
                string oscLayout = inif.Read("OSC", "oscLayout");
                if (VM.DisplayView.OSC_Layout_Items.Contains(oscLayout))
                    VM.DisplayView.OSC_Layout_SelectedItem = oscLayout;
                else
                    listFailedImports.Add("OSC: OSC Layout");

                // OSC Seekbar
                string oscSeekbar = inif.Read("OSC", "oscSeekbar");
                if (VM.DisplayView.OSC_Seekbar_Items.Contains(oscSeekbar))
                    VM.DisplayView.OSC_Seekbar_SelectedItem = oscSeekbar;
                else
                    listFailedImports.Add("OSC: OSC Seekbar");

                // --------------------------------------------------
                // OSD
                // --------------------------------------------------
                // OSD
                string videoOSD = inif.Read("OSD", "videoOSD");
                if (VM.DisplayView.OSD_Items.Contains(videoOSD))
                    VM.DisplayView.OSD_SelectedItem = videoOSD;
                else
                    listFailedImports.Add("OSD: OSD");

                // Fractions
                string osdFractions = inif.Read("OSD", "fractions");
                if (VM.DisplayView.OSD_Fractions_Items.Contains(osdFractions))
                    VM.DisplayView.OSD_Fractions_SelectedItem = osdFractions;
                else
                    listFailedImports.Add("OSD: Fractions");

                // Duration
                VM.DisplayView.OSD_Duration_Text = inif.Read("OSD", "duration");

                // Level
                string osdLevel = inif.Read("OSD", "level");
                if (VM.DisplayView.OSD_Level_Items.Contains(osdLevel))
                    VM.DisplayView.OSD_Level_SelectedItem = osdLevel;
                else
                    listFailedImports.Add("OSD: Level");

                // -------------------------
                // Controls
                // -------------------------
                double osdScale = 0.0;
                double.TryParse(inif.Read("OSD", "scale"), out osdScale);
                VM.DisplayView.OSC_Scale_Value = osdScale;

                double barWidth = 0.0;
                double.TryParse(inif.Read("OSD", "barWidth"), out barWidth);
                VM.DisplayView.OSC_BarWidth_Value = barWidth;

                double barHeight = 0.0;
                double.TryParse(inif.Read("OSD", "barHeight"), out barHeight);
                VM.DisplayView.OSC_BarHeight_Value = barHeight;

                // -------------------------
                // Text
                // -------------------------
                // Font
                string osdFont = inif.Read("OSD", "font");
                if (VM.DisplayView.OSD_Font_Items.Contains(osdFont))
                    VM.DisplayView.OSD_Font_SelectedItem = osdFont;
                else
                    listFailedImports.Add("OSD: Font");

                // Font Size
                string osdFontSize = inif.Read("OSD", "fontSize");
                if (VM.DisplayView.OSD_FontSize_Items.Contains(osdFontSize))
                    VM.DisplayView.OSD_FontSize_SelectedItem = osdFontSize;
                else
                    listFailedImports.Add("OSD: Font Size");


                // Font Color
                VM.DisplayView.OSD_FontColor_Text = inif.Read("OSD", "fontColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listOSD_FontColor = new List<string>();
                //foreach (var item in VM.DisplayView.OSD_FontColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listOSD_FontColor.Add(current);
                //}
                //// read ini color
                //string osdFontColor = inif.Read("OSD", "fontColor");
                //// if temp list contains color
                //if (listOSD_FontColor.Contains(osdFontColor))
                //    VM.DisplayView.OSD_FontColor_SelectedItem = VM.DisplayView.OSD_FontColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == osdFontColor);
                //else
                //    listFailedImports.Add("OSD: Font Color");


                // Border Size
                string osdFontBorderSize = inif.Read("OSD", "borderSize");
                if (VM.DisplayView.OSD_FontBorderSize_Items.Contains(osdFontBorderSize))
                    VM.DisplayView.OSD_FontBorderSize_SelectedItem = osdFontBorderSize;
                else
                    listFailedImports.Add("OSD: Border Size");


                // Border Color
                VM.DisplayView.OSD_BorderColor_Text = inif.Read("OSD", "borderColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listOSDBorderColor = new List<string>();
                //foreach (var item in VM.DisplayView.OSDBorderColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listOSDBorderColor.Add(current);
                //}
                //// read ini color
                //string osdBorderColor = inif.Read("OSD", "borderColor");
                //// if temp list contains color
                //if (listOSDBorderColor.Contains(osdBorderColor))
                //    VM.DisplayView.OSDBorderColor_SelectedItem = VM.DisplayView.OSDBorderColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == osdBorderColor);
                //else
                //    listFailedImports.Add("OSD: Border Color");


                // Shadow Color
                VM.DisplayView.OSD_ShadowColor_Text = inif.Read("OSD", "shadowColor");
                // add combobox items to temp list
                // convert items to string
                //List<string> listOSDShadowColor = new List<string>();
                //// read ini color
                //foreach (var item in VM.DisplayView.OSDShadowColor_Items)
                //{
                //    ComboBoxItem currentItem = (ComboBoxItem)(item);
                //    string current = (string)(currentItem.Content);
                //    listOSDShadowColor.Add(current);
                //}
                //// if temp list contains color
                //string osdShadowColor = inif.Read("OSD", "shadowColor");
                //if (listOSDShadowColor.Contains(osdShadowColor))
                //    VM.DisplayView.OSDShadowColor_SelectedItem = VM.DisplayView.OSDShadowColor_Items
                //        .OfType<ComboBoxItem>()
                //        .FirstOrDefault(x => x.Content.ToString() == osdShadowColor);
                //else
                //    listFailedImports.Add("OSD: Shadow Color");


                // Shadow Offset
                double osdShadowOffset = 0.00;
                double.TryParse(inif.Read("OSD", "shadowOffset"), out osdShadowOffset);
                VM.DisplayView.OSD_ShadowOffset_Value = osdShadowOffset;

                // --------------------------------------------------
                // Extensions
                // --------------------------------------------------
                // MKV
                string mkv = inif.Read("Extensions", "mkv");
                if (VM.GeneralView.ExtMKV_Items.Contains(mkv))
                    VM.GeneralView.ExtMKV_SelectedItem = mkv;
                else
                    listFailedImports.Add("Extensions: mkv");

                // MP4
                string mp4 = inif.Read("Extensions", "mp4");
                if (VM.GeneralView.ExtMP4_Items.Contains(mp4))
                    VM.GeneralView.ExtMP4_SelectedItem = mp4;
                else
                    listFailedImports.Add("Extensions: mp4");

                // WebM
                string webm = inif.Read("Extensions", "webm");
                if (VM.GeneralView.ExtWebM_Items.Contains(webm))
                    VM.GeneralView.ExtWebM_SelectedItem = webm;
                else
                    listFailedImports.Add("Extensions: webm");

                // GIF
                string gif = inif.Read("Extensions", "gif");
                if (VM.GeneralView.ExtGIF_Items.Contains(gif))
                    VM.GeneralView.ExtGIF_SelectedItem = gif;
                else
                    listFailedImports.Add("Extensions: gif");

                // JPG
                string jpg = inif.Read("Extensions", "jpg");
                if (VM.GeneralView.ExtJPG_Items.Contains(jpg))
                    VM.GeneralView.ExtJPG_SelectedItem = jpg;
                else
                    listFailedImports.Add("Extensions: jpg");

                // PNG
                string png = inif.Read("Extensions", "png");
                if (VM.GeneralView.ExtPNG_Items.Contains(png))
                    VM.GeneralView.ExtPNG_SelectedItem = png;
                else
                    listFailedImports.Add("Extensions: png");


                // --------------------------------------------------
                // Failed Imports
                // --------------------------------------------------
                if (listFailedImports.Count > 0 && listFailedImports != null)
                {
                    // Open Window
                    FailedWindow(mainwindow, listFailedImports);
                }
            }

            // Preset ini file does not exist
            //else
            //{
            //    MessageBox.Show("Custom Preset does not exist.",
            //                    "Notice",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Warning);

            //    return;
            //}


        }

        /// <summary>
        ///    Failed Window Open
        /// </summary>
        private static Boolean IsFailedImportWindowOpened = false;
        public static void FailedWindow(MainWindow mainwindow, List<string> listFailedImports)
        {
            ConfigureWindow.failedImportMessage = string.Join(Environment.NewLine, listFailedImports);

            // Detect which screen we're on
            var allScreens = System.Windows.Forms.Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => mainwindow.Left >= s.WorkingArea.Left && mainwindow.Left < s.WorkingArea.Right);

            // Start Window
            FailedImportWindow failedimportwindow = new FailedImportWindow();

            // Only allow 1 Window instance
            if (IsFailedImportWindowOpened) return;
            failedimportwindow.ContentRendered += delegate { IsFailedImportWindowOpened = true; };
            failedimportwindow.Closed += delegate { IsFailedImportWindowOpened = false; };

            // Position Relative to MainWindow
            failedimportwindow.Left = Math.Max((mainwindow.Left + (mainwindow.Width - failedimportwindow.Width) / 2), thisScreen.WorkingArea.Left);
            failedimportwindow.Top = Math.Max((mainwindow.Top + (mainwindow.Height - failedimportwindow.Height) / 2), thisScreen.WorkingArea.Top);

            // Open Window
            failedimportwindow.Show();
        }


    }
}
