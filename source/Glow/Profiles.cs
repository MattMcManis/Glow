/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017 Matt McManis
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Glow
{
    public partial class Profiles
    {
        public static List<string> listCustomProfilesPaths = new List<string>();
        //public static List<string> listCustomProfilesNames = new List<string>();

        /// <summary>
        ///    Scan PC Custom Profiles
        /// </summary>
        public static void GetCustomProfiles()
        {
            // Presets
            List<string> _presetsItems = new List<string>()
            {
                "Default",
                "Ultra",
                "High",
                "Medium",
                "Low",
                "Debug",
            };

            // User Custom Profiles Full Path
            if (Directory.Exists(MainWindow.profilesDir))
            {
                listCustomProfilesPaths = Directory.GetFiles(MainWindow.profilesDir, "*.ini")
                    .Select(Path.GetFullPath)
                    .ToList();
            }

            // Get Names from Full Paths
            List<string> listCustomProfilesNames = new List<string>();
            foreach (string path in listCustomProfilesPaths)
            {
                // Get Name from Path
                string profileName = Path.GetFileNameWithoutExtension(path);

                // Add Name to List
                // Prevent adding duplicate
                // Ignore Desktop.ini
                if (!listCustomProfilesNames.Contains(profileName) 
                    && !string.Equals(profileName, "desktop", StringComparison.CurrentCultureIgnoreCase))
                {
                    listCustomProfilesNames.Add(profileName);
                }

            }

            // Join Presets and Profiles Lists
            //_presetsItems.AddRange(_customProfilesItems);
            _presetsItems.AddRange(listCustomProfilesNames);
            // Populate ComboBox
            ViewModel._profilesItems = _presetsItems.ToList();

            // Clear Temp Lists
            //listCustomProfilesPaths.Clear();
            //listCustomProfilesPaths.TrimExcess();
            //listCustomProfilesNames.Clear();
            //listCustomProfilesNames.TrimExcess();
        }


        /// <summary>
        ///     Profile
        /// </summary>
        public static void Profile(MainWindow mainwindow)
        {
            // -------------------------
            // Default
            // -------------------------
            if ((string)mainwindow.cboProfile.SelectedItem == "Default")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "normal";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "off";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "yes";
                mainwindow.cboScale.SelectedItem = "bicubic";
                mainwindow.slScaleAntiring.Value = 0;
                mainwindow.cboChromaScale.SelectedItem = "bicubic";
                mainwindow.slChromaAntiring.Value = 0;
                mainwindow.cboDownscale.SelectedItem = "bicubic";
                mainwindow.slDownscaleAntiring.Value = 0;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                //mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                //mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "no";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "5.0";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "yes";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                //mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                //mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                //mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // Ultra
            // -------------------------
            else if ((string)mainwindow.cboProfile.SelectedItem == "Ultra")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "high";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "yes";
                mainwindow.cboScale.SelectedItem = "spline36";
                mainwindow.slScaleAntiring.Value = 1;
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.slChromaAntiring.Value = 1;
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.slDownscaleAntiring.Value = 1;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "no";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "5.0";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "yes";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // High
            // -------------------------
            else if ((string)mainwindow.cboProfile.SelectedItem == "High")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "high";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "yes";
                mainwindow.cboScale.SelectedItem = "ewa_lanczossharp";
                mainwindow.slScaleAntiring.Value = 0.5;
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.slChromaAntiring.Value = 0.5;
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.slDownscaleAntiring.Value = 0;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "no";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "5.0";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "yes";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // Medium
            // -------------------------
            else if ((string)mainwindow.cboProfile.SelectedItem == "Medium")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "abovenormal";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "auto";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "yes";
                mainwindow.cboScale.SelectedItem = "lanczos";
                mainwindow.slScaleAntiring.Value = 0;
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.slChromaAntiring.Value = 0;
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.slDownscaleAntiring.Value = 0;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "no";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "5.0";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "yes";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // Low
            // -------------------------
            else if ((string)mainwindow.cboProfile.SelectedItem == "Low")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "normal";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "no";
                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "no";
                mainwindow.cboScale.SelectedItem = "bilinear";
                mainwindow.slScaleAntiring.Value = 0;
                mainwindow.cboChromaScale.SelectedItem = "bilinear";
                mainwindow.slChromaAntiring.Value = 0;
                mainwindow.cboDownscale.SelectedItem = "bilinear";
                mainwindow.slDownscaleAntiring.Value = 0;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                // deselect all languages
                mainwindow.listViewAudioLanguages.SelectedIndex = -1;

                // -------------------------
                // Subtitles
                // -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "no";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                //mainwindow.cboSubtitlesShadowColor.SelectedIndex = 0; //none
                mainwindow.tbxSubtitlesShadowColor.Text = ""; //none
                mainwindow.slSubtitlesShadowOffset.Value = 0;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                // deselect all languages
                mainwindow.listViewSubtitlesLanguages.SelectedIndex = -1;

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "no";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "no";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // Debug
            // -------------------------
            else if ((string)mainwindow.cboProfile.SelectedItem == "Debug")
            {
                // -------------------------
                // General
                // -------------------------
                mainwindow.cboPriority.SelectedItem = "high";
                mainwindow.cboSavePositionQuit.SelectedItem = "no";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.slGeometryX.Value = 50;
                mainwindow.slGeometryY.Value = 50;
                mainwindow.slAutofitWidth.Value = 100;
                mainwindow.slAutofitHeight.Value = 95;
                mainwindow.cboScreensaver.SelectedItem = "off";
                // Screenshot
                mainwindow.cboScreenshotTemplate.SelectedItem = "Playback Time";
                mainwindow.cboScreenshotTagColorspace.SelectedItem = "no";
                mainwindow.cboScreenshotFormat.SelectedItem = "png";
                mainwindow.slScreenshotQuality.Value = 7; //png compression

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "no";
                mainwindow.cboOpenGLPBOFormat.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.slBrightness.Value = 0;
                mainwindow.slContrast.Value = 0;
                mainwindow.slHue.Value = 0;
                mainwindow.slSaturation.Value = 0;
                mainwindow.slGamma.Value = 0;
                mainwindow.cboGammaAuto.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "yes";
                mainwindow.cboScale.SelectedItem = "spline36";
                mainwindow.slScaleAntiring.Value = 1;
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.slChromaAntiring.Value = 1;
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.slDownscaleAntiring.Value = 1;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                // -------------------------
                // Audio
                // -------------------------
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.slVolume.Value = 100;
                mainwindow.slVolumeMax.Value = 150;
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.slSoftVolumeMax.Value = 150;
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";
                //Language
                mainwindow.listViewAudioLanguages.SelectedItems.Add("English");
                mainwindow.listViewAudioLanguages.SelectedItems.Add("Japanese");


                // -------------------------
                // Subtitles
                //// -------------------------
                mainwindow.cboSubtitles.SelectedItem = "yes";
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = "no";
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesFixTiming.SelectedItem = "yes";
                mainwindow.cboSubtitlesMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFont.SelectedItem = "Noto Sans";
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.tbxSubtitlesFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.tbxSubtitlesBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxSubtitlesShadowColor.Text = "262626"; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;

                // ASS
                mainwindow.cboSubtitlesASS.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSOverride.SelectedItem = "force";
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = "yes";
                mainwindow.cboSubtitlesASSHinting.SelectedItem = "none";
                mainwindow.cboSubtitlesASSKerning.SelectedItem = "yes";

                //Language
                mainwindow.listViewSubtitlesLanguages.SelectedItems.Add("English");

                // -------------------------
                // Stream
                // -------------------------
                // Demuxer
                mainwindow.cboDemuxerThread.SelectedItem = "yes";
                mainwindow.tbxDemuxerBuffersize.Text = "32768";
                mainwindow.tbxDemuxerReadahead.Text = "5.0";
                mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = "yes";
                // Cache
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // -------------------------
                // OSC
                // -------------------------
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboOSCLayout.SelectedItem = "bottombar";
                mainwindow.cboOSCSeekbar.SelectedItem = "bar";

                // -------------------------
                // OSD
                // -------------------------
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.cboOSDFractions.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.slOSDScale.Value = 0.5;
                // Bar
                mainwindow.slOSDBarWidth.Value = 95;
                mainwindow.slOSDBarHeight.Value = 2;
                // Font
                mainwindow.cboOSDFont.SelectedItem = "Noto Sans";
                mainwindow.cboOSDFontSize.SelectedItem = "60";
                mainwindow.tbxOSDFontColor.Text = "FFFFFF"; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.tbxOSDBorderColor.Text = "262626"; //dark gray
                // Shadow
                mainwindow.tbxOSDShadowColor.Text = "262626"; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // User Custom Profile
            // -------------------------
            else
            {
                // Get Profile INI Path
                string input = string.Empty;
                foreach (string path in listCustomProfilesPaths)
                {
                    string filename = Path.GetFileNameWithoutExtension(path);

                    if ((string)mainwindow.cboProfile.SelectedItem == filename)
                    {
                        input = path;
                        break;
                    }
                }

                // Import ini file
                ImportProfile(mainwindow, input);
            }

        }



        /// <summary>
        ///    Export Profile
        /// </summary>
        public static void ExportProfile(MainWindow mainwindow, string input)
        {
            // Selected Item
            ComboBoxItem selectedItem = null;
            string selected = string.Empty;

            // Export's ini file path
            // Get from Save Dialog Path
            //string input = input;

            // Start INI File Write
            INIFile inif = new INIFile(input);

            // --------------------------------------------------
            // General
            // --------------------------------------------------
            inif.Write("General", "priority", (mainwindow.cboPriority.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "savePositiOnQuit", (mainwindow.cboSavePositionQuit.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "keepOpen", (mainwindow.cboKeepOpen.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "onTop", (mainwindow.cboOnTop.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "geometryX", mainwindow.tbxGeometryX.Text.ToString());
            inif.Write("General", "geometryY", mainwindow.tbxGeometryY.Text.ToString());
            inif.Write("General", "autofitWidth", mainwindow.tbxAutofitWidth.Text.ToString());
            inif.Write("General", "autofitHeight", mainwindow.tbxAutofitHeight.Text.ToString());
            inif.Write("General", "screensaver", (mainwindow.cboScreensaver.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "screenshotPath", mainwindow.tbxScreenshotPath.Text.ToString());
            inif.Write("General", "screenshotTemplate", (mainwindow.cboScreenshotTemplate.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "screenshotTagColorspace", (mainwindow.cboScreenshotTagColorspace.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "screenshotFormat", (mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty).ToString());
            inif.Write("General", "screenshotQuality", mainwindow.tbxScreenshotQuality.Text.ToString());

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            // Hardware
            inif.Write("Video", "videoDriver", (mainwindow.cboVideoDriver.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "openglPBO", (mainwindow.cboOpenGLPBO.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "openglPBOFormat", (mainwindow.cboOpenGLPBOFormat.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "hwdec", (mainwindow.cboHWDecoder.SelectedItem ?? string.Empty).ToString());
            // Display
            inif.Write("Video", "displayPrimaries", (mainwindow.cboDisplayPrimaries.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "colorSpace", (mainwindow.cboColorSpace.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "colorRange", (mainwindow.cboColorRange.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "deinterlace", (mainwindow.cboDeinterlace.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "videoSync", (mainwindow.cboVideoSync.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "frameDrop", (mainwindow.cboFramedrop.SelectedItem ?? string.Empty).ToString());
            // Image
            inif.Write("Video", "brightness", mainwindow.tbxBrightness.Text.ToString());
            inif.Write("Video", "contrast", mainwindow.tbxContrast.Text.ToString());
            inif.Write("Video", "hue", mainwindow.tbxHue.Text.ToString());
            inif.Write("Video", "saturation", mainwindow.tbxSaturation.Text.ToString());
            inif.Write("Video", "gamma", mainwindow.tbxGamma.Text.ToString());
            inif.Write("Video", "gammaAuto", (mainwindow.cboGammaAuto.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "deband", (mainwindow.cboDeband.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "debandGrain", mainwindow.tbxDebandGrain.Text.ToString());
            inif.Write("Video", "dither", (mainwindow.cboDither.SelectedItem ?? string.Empty).ToString());
            // Scaling
            inif.Write("Video", "sigmoidUpscaling", (mainwindow.cboSigmoid.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "scale", (mainwindow.cboScale.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "scaleAntiring", mainwindow.tbxScaleAntiring.Text.ToString());
            inif.Write("Video", "chromaScale", (mainwindow.cboChromaScale.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "chromaScaleAntiring", mainwindow.tbxChromaAntiring.Text.ToString());
            inif.Write("Video", "downscale", (mainwindow.cboDownscale.SelectedItem ?? string.Empty).ToString());
            inif.Write("Video", "downscaleAntiring", mainwindow.tbxDownscaleAntiring.Text.ToString());
            inif.Write("Video", "softwareScaler", (mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty).ToString());

            // --------------------------------------------------
            // Audio
            // --------------------------------------------------
            inif.Write("Audio", "driver", (mainwindow.cboAudioDriver.SelectedItem ?? string.Empty).ToString());

            // -------------------------
            // Languages
            // -------------------------
            // ------------
            // Order
            // ------------
            List<string> listAudioLangOrder = new List<string>(ViewModel.AudioLanguageItems);
            string audioLanguagesOrder = string.Join(",", listAudioLangOrder.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Audio", "languagesOrder", audioLanguagesOrder);

            // ------------
            // Selected
            // ------------
            List<string> listAudioLangSelected = new List<string>();
            foreach (string item in mainwindow.listViewAudioLanguages.SelectedItems)
            {
                // add checked item name to list
                listAudioLangSelected.Add(item);
            }
            string audioLanguagesSelected = string.Join(",", listAudioLangSelected.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Audio", "languagesSelected", audioLanguagesSelected);

            inif.Write("Audio", "channels", (mainwindow.cboChannels.SelectedItem ?? string.Empty).ToString());
            inif.Write("Audio", "volume", mainwindow.tbxVolume.Text.ToString());
            inif.Write("Audio", "volumeMax", mainwindow.tbxVolumeMax.Text.ToString());
            inif.Write("Audio", "softVolume", (mainwindow.cboSoftVolume.SelectedItem ?? string.Empty).ToString());
            inif.Write("Audio", "softVolumeMax", mainwindow.tbxSoftVolumeMax.Text.ToString());
            inif.Write("Audio", "normalize", (mainwindow.cboNormalize.SelectedItem ?? string.Empty).ToString());
            inif.Write("Audio", "scaleTempo", (mainwindow.cboScaleTempo.SelectedItem ?? string.Empty).ToString());
            inif.Write("Audio", "loadFiles", (mainwindow.cboAudioLoadFiles.SelectedItem ?? string.Empty).ToString());

            // --------------------------------------------------
            // Subtitle
            // --------------------------------------------------
            inif.Write("Subtitles", "subtitles", (mainwindow.cboSubtitles.SelectedItem ?? string.Empty).ToString());

            // -------------------------
            // Languages
            // -------------------------
            // ------------
            // Order
            // ------------
            List<string> listSubtitlesLangOrder = new List<string>(ViewModel.SubtitlesLanguageItems);
            string subtitlesLanguagesOrder = string.Join(",", listSubtitlesLangOrder.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Subtitles", "languagesOrder", subtitlesLanguagesOrder);

            // ------------
            // Selected
            // ------------
            List<string> listSubtitlesLang = new List<string>();
            foreach (string item in mainwindow.listViewSubtitlesLanguages.SelectedItems)
            {
                listSubtitlesLang.Add(item);
            }
            string subtitlesLanguages = string.Join(",", listSubtitlesLang.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Subtitles", "languagesSelected", subtitlesLanguages);

            inif.Write("Subtitles", "loadFiles", (mainwindow.cboSubtitlesLoadFiles.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "embeddedFonts", (mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "position", mainwindow.tbxSubtitlePosition.Text.ToString());
            inif.Write("Subtitles", "fixTiming", (mainwindow.cboSubtitlesFixTiming.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "useMargins", (mainwindow.cboSubtitlesMargins.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "font", (mainwindow.cboSubtitlesFont.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "fontSize", (mainwindow.cboSubtitlesFontSize.SelectedItem ?? string.Empty).ToString());

            // Font Color
            inif.Write("Subtitles", "fontColor", mainwindow.tbxSubtitlesFontColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.tbxSubtitlesFontColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("Subtitles", "fontColor", selected);

            // Border Size
            inif.Write("Subtitles", "borderSize", (mainwindow.cboSubtitlesBorderSize.SelectedItem ?? string.Empty).ToString());

            // Border Color
            inif.Write("Subtitles", "borderColor", mainwindow.tbxSubtitlesBorderColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesBorderColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("Subtitles", "borderColor", selected);

            // Shadow Color
            inif.Write("Subtitles", "shadowColor", mainwindow.tbxSubtitlesShadowColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesShadowColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("Subtitles", "shadowColor", selected);

            // Shadow Offset
            inif.Write("Subtitles", "shadowOffset", mainwindow.tbxSubtitlesShadowOffset.Text.ToString());
            inif.Write("Subtitles", "blend", (mainwindow.cboSubtitlesBlend.SelectedItem ?? string.Empty).ToString());

            // ASS
            inif.Write("Subtitles", "ass", (mainwindow.cboSubtitlesASS.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "assOverride", (mainwindow.cboSubtitlesASSOverride.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "assForceMargins", (mainwindow.cboSubtitlesASSForceMargins.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "assHinting", (mainwindow.cboSubtitlesASSHinting.SelectedItem ?? string.Empty).ToString());
            inif.Write("Subtitles", "assKerning", (mainwindow.cboSubtitlesASSKerning.SelectedItem ?? string.Empty).ToString());

            // --------------------------------------------------
            // Stream
            // --------------------------------------------------
            inif.Write("Stream", "demuxThread", (mainwindow.cboDemuxerThread.SelectedItem ?? string.Empty).ToString());
            inif.Write("Stream", "demuxerBufferSize", mainwindow.tbxDemuxerBuffersize.Text.ToString());
            inif.Write("Stream", "demuxerReadAhead", mainwindow.tbxDemuxerReadahead.Text.ToString());
            inif.Write("Stream", "demuxerMKVSubtitlePreroll", (mainwindow.cboDemuxerMKVSubPreroll.SelectedItem ?? string.Empty).ToString());
            inif.Write("Stream", "cache", (mainwindow.cboCache.SelectedItem ?? string.Empty).ToString());
            inif.Write("Stream", "cacheDefault", mainwindow.tbxCacheDefault.Text.ToString());
            inif.Write("Stream", "initial", mainwindow.tbxCacheInitial.Text.ToString());
            inif.Write("Stream", "seekMin", mainwindow.tbxCacheSeekMin.Text.ToString());
            inif.Write("Stream", "backBuffer", mainwindow.tbxCacheBackbuffer.Text.ToString());
            inif.Write("Stream", "seconds", mainwindow.tbxCacheSeconds.Text.ToString());
            inif.Write("Stream", "file", (mainwindow.cboCacheFile.SelectedItem ?? string.Empty).ToString());
            inif.Write("Stream", "fileSize", mainwindow.tbxCacheFileSize.Text.ToString());

            // --------------------------------------------------
            // OSC
            // --------------------------------------------------
            inif.Write("OSC", "osc", (mainwindow.cboOSC.SelectedItem ?? string.Empty).ToString());
            inif.Write("OSC", "oscLayout", (mainwindow.cboOSCLayout.SelectedItem ?? string.Empty).ToString());
            inif.Write("OSC", "oscSeekbar", (mainwindow.cboOSCSeekbar.SelectedItem ?? string.Empty).ToString());

            // --------------------------------------------------
            // OSD
            // --------------------------------------------------
            inif.Write("OSD", "videoOSD", (mainwindow.cboOSD.SelectedItem ?? string.Empty).ToString());
            inif.Write("OSD", "fractions", mainwindow.tbxCacheFileSize.Text.ToString());
            inif.Write("OSD", "duration", mainwindow.tbxOSDDuration.Text.ToString());
            inif.Write("OSD", "level", (mainwindow.cboOSDLevel.SelectedItem ?? string.Empty).ToString());
            inif.Write("OSD", "scale", mainwindow.tbxOSDScale.Text.ToString());
            inif.Write("OSD", "barWidth", mainwindow.tbxOSDBarWidth.Text.ToString());
            inif.Write("OSD", "barHeight", mainwindow.tbxOSDBarHeight.Text.ToString());
            inif.Write("OSD", "font", (mainwindow.cboOSDFont.SelectedItem ?? string.Empty).ToString());
            inif.Write("OSD", "fontSize", (mainwindow.cboOSDFontSize.SelectedItem ?? string.Empty).ToString());

            inif.Write("OSD", "fontColor", mainwindow.tbxOSDFontColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("OSD", "fontColor", selected);

            inif.Write("OSD", "borderSize", (mainwindow.cboOSDFontBorderSize.SelectedItem ?? string.Empty).ToString());

            inif.Write("OSD", "borderColor", mainwindow.tbxOSDBorderColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDBorderColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("OSD", "borderColor", selected);

            inif.Write("OSD", "shadowColor", mainwindow.tbxOSDShadowColor.Text.ToString());
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDShadowColor.SelectedValue);
            //selected = (string)(selectedItem.Content);
            //inif.Write("OSD", "shadowColor", selected);

            inif.Write("OSD", "shadowOffset", mainwindow.tbxOSDShadowOffset.Text.ToString());
        }


        /// <summary>
        ///    Import Profile
        /// </summary>
        public static void ImportProfile(MainWindow mainwindow, string input)
        {
            // Import's ini file path
            // Get from Select File Dialog Path
            // string input = inputDir + inputFileName + inputExt;

            // If control failed to imported, add to list
            List<string> listFailedImports = new List<string>();

            INIFile inif = new INIFile(input);

            // --------------------------------------------------
            // General
            // --------------------------------------------------
            // Priority
            string priority = inif.Read("General", "priority");
            if (mainwindow.cboPriority.Items.Contains(priority))
                mainwindow.cboPriority.SelectedItem = priority;
            else
                listFailedImports.Add("General: Priority");

            // Save Position
            string savePositiOnQuit = inif.Read("General", "savePositiOnQuit");
            if (mainwindow.cboSavePositionQuit.Items.Contains(savePositiOnQuit))
                mainwindow.cboSavePositionQuit.SelectedItem = savePositiOnQuit;
            else
                listFailedImports.Add("General: Save Position");

            // Keep Open
            string keepOpen = inif.Read("General", "keepOpen");
            if (mainwindow.cboKeepOpen.Items.Contains(keepOpen))
                mainwindow.cboKeepOpen.SelectedItem = keepOpen;
            else
                listFailedImports.Add("General: Keep Open");

            // On Top
            string onTop = inif.Read("General", "onTop");
            if (mainwindow.cboOnTop.Items.Contains(onTop))
                mainwindow.cboOnTop.SelectedItem = onTop;
            else
                listFailedImports.Add("General: On Top");

            // Geometry X
            mainwindow.tbxGeometryX.Text = inif.Read("General", "geometryX");

            // Geometry Y
            mainwindow.tbxGeometryX.Text = inif.Read("General", "geometryX");

            // Autofit Width
            mainwindow.tbxGeometryX.Text = inif.Read("General", "autofitWidth");

            // Autofit Height
            mainwindow.tbxGeometryX.Text = inif.Read("General", "autofitHeight");

            // Screensaver
            string screensaver = inif.Read("General", "screensaver");
            if (mainwindow.cboScreensaver.Items.Contains(screensaver))
                mainwindow.cboScreensaver.SelectedItem = screensaver;
            else
                listFailedImports.Add("General: Screensaver");

            // Screenshot Path
            mainwindow.tbxScreenshotPath.Text = inif.Read("General", "screenshotPath");

            // Screenshot Template
            string screenshotTemplate = inif.Read("General", "screenshotTemplate");
            if (mainwindow.cboScreenshotTemplate.Items.Contains(screenshotTemplate))
                mainwindow.cboScreenshotTemplate.SelectedItem = screenshotTemplate;
            else
                listFailedImports.Add("General: Screenshot Template");

            // Screenshot Tag Colorspace
            string screenshotTagColorspace = inif.Read("General", "screenshotTagColorspace");
            if (mainwindow.cboScreenshotTagColorspace.Items.Contains(screenshotTagColorspace))
                mainwindow.cboScreenshotTagColorspace.SelectedItem = screenshotTagColorspace;
            else
                listFailedImports.Add("General: Screenshot Tag Colorspace");

            // Screenshot Format
            string screenshotFormat = inif.Read("General", "screenshotFormat");
            if (mainwindow.cboScreenshotFormat.Items.Contains(screenshotFormat))
                mainwindow.cboScreenshotFormat.SelectedItem = screenshotFormat;
            else
                listFailedImports.Add("General: Screenshot Format");

            // Screenshot Quality
            mainwindow.tbxScreenshotQuality.Text = inif.Read("General", "screenshotQuality");

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            // -------------------------
            // Hardware
            // -------------------------
            // Video Driver
            string videoDriver = inif.Read("Video", "videoDriver");
            if (mainwindow.cboVideoDriver.Items.Contains(videoDriver))
                mainwindow.cboVideoDriver.SelectedItem = videoDriver;
            else
                listFailedImports.Add("Video: Video Driver");

            // OpenGL PBO
            string openglPBO = inif.Read("Video", "openglPBO");
            if (mainwindow.cboOpenGLPBO.Items.Contains(openglPBO))
                mainwindow.cboOpenGLPBO.SelectedItem = openglPBO;
            else
                listFailedImports.Add("Video: OpenGL PBO");

            // OpenGL PBO Format
            string openglPBOFormat = inif.Read("Video", "openglPBOFormat");
            if (mainwindow.cboOpenGLPBOFormat.Items.Contains(openglPBOFormat))
                mainwindow.cboOpenGLPBOFormat.SelectedItem = openglPBOFormat;
            else
                listFailedImports.Add("Video: OpenGL PBO Format");

            // HW Decoder
            string hwdec = inif.Read("Video", "hwdec");
            if (mainwindow.cboHWDecoder.Items.Contains(hwdec))
                mainwindow.cboHWDecoder.SelectedItem = hwdec;
            else
                listFailedImports.Add("Video: HW Decoder");

            // -------------------------
            // Display
            // -------------------------
            // Display Primaries
            string displayPrimaries = inif.Read("Video", "displayPrimaries");
            if (mainwindow.cboDisplayPrimaries.Items.Contains(displayPrimaries))
                mainwindow.cboDisplayPrimaries.SelectedItem = displayPrimaries;
            else
                listFailedImports.Add("Video: Display Primaries");

            // Color Space
            string colorSpace = inif.Read("Video", "colorSpace");
            if (mainwindow.cboColorSpace.Items.Contains(colorSpace))
                mainwindow.cboColorSpace.SelectedItem = colorSpace;
            else
                listFailedImports.Add("Video: Color Space");

            // Color Range
            string colorRange = inif.Read("Video", "colorRange");
            if (mainwindow.cboColorRange.Items.Contains(colorRange))
                mainwindow.cboColorRange.SelectedItem = colorRange;
            else
                listFailedImports.Add("Video: Color Range");

            // Deinterlace
            string deinterlace = inif.Read("Video", "deinterlace");
            if (mainwindow.cboDeinterlace.Items.Contains(deinterlace))
                mainwindow.cboDeinterlace.SelectedItem = deinterlace;
            else
                listFailedImports.Add("Video: Deinterlace");

            // Video Sync
            string videoSync = inif.Read("Video", "videoSync");
            if (mainwindow.cboVideoSync.Items.Contains(videoSync))
                mainwindow.cboVideoSync.SelectedItem = videoSync;
            else
                listFailedImports.Add("Video: Video Sync");

            // Frame Drop
            string frameDrop = inif.Read("Video", "frameDrop");
            if (mainwindow.cboFramedrop.Items.Contains(frameDrop))
                mainwindow.cboFramedrop.SelectedItem = frameDrop;
            else
                listFailedImports.Add("Video: Frame Drop");

            // -------------------------
            // Image
            // -------------------------
            mainwindow.tbxBrightness.Text = inif.Read("Video", "brightness");
            mainwindow.tbxContrast.Text = inif.Read("Video", "contrast");
            mainwindow.tbxHue.Text = inif.Read("Video", "hue");
            mainwindow.tbxSaturation.Text = inif.Read("Video", "saturation");
            mainwindow.tbxGamma.Text = inif.Read("Video", "gamma");

            // Gamma Auto
            string gammaAuto = inif.Read("Video", "gammaAuto");
            if (mainwindow.cboGammaAuto.Items.Contains(gammaAuto))
                mainwindow.cboGammaAuto.SelectedItem = gammaAuto;
            else
                listFailedImports.Add("Video: Gamma Auto");

            // Deband
            string deband = inif.Read("Video", "deband");
            if (mainwindow.cboDeband.Items.Contains(deband))
                mainwindow.cboDeband.SelectedItem = deband;
            else
                listFailedImports.Add("Video: Deband");

            // Deband Grain
            mainwindow.tbxDebandGrain.Text = inif.Read("Video", "debandGrain");

            // Dither
            string dither = inif.Read("Video", "dither");
            if (mainwindow.cboDither.Items.Contains(dither))
                mainwindow.cboDither.SelectedItem = dither;
            else
                listFailedImports.Add("Video: Dither");

            // -------------------------
            // Scaling
            // -------------------------
            // Sigmoid Upscaling
            string sigmoidUpscaling = inif.Read("Video", "sigmoidUpscaling");
            if (mainwindow.cboSigmoid.Items.Contains(sigmoidUpscaling))
                mainwindow.cboSigmoid.SelectedItem = sigmoidUpscaling;
            else
                listFailedImports.Add("Video: Sigmoid");

            // Scale
            string scale = inif.Read("Video", "scale");
            if (mainwindow.cboScale.Items.Contains(scale))
                mainwindow.cboScale.SelectedItem = scale;
            else
                listFailedImports.Add("Video: Scale");

            // Scale Antiring
            mainwindow.tbxScaleAntiring.Text = inif.Read("Video", "scaleAntiring");

            // Chroma Scale
            string chromaScale = inif.Read("Video", "chromaScale");
            if (mainwindow.cboChromaScale.Items.Contains(chromaScale))
                mainwindow.cboChromaScale.SelectedItem = chromaScale;
            else
                listFailedImports.Add("Video: Chroma Scale");

            // Chroma Antiring
            mainwindow.tbxChromaAntiring.Text = inif.Read("Video", "chromaScaleAntiring");

            // Downscale
            string downscale = inif.Read("Video", "downscale");
            if (mainwindow.cboDownscale.Items.Contains(downscale))
                mainwindow.cboDownscale.SelectedItem = downscale;
            else
                listFailedImports.Add("Video: Downscale");

            // Downscale Antiring
            mainwindow.tbxDownscaleAntiring.Text = inif.Read("Video", "downscaleAntiring");

            // Software Scaler
            string softwareScaler = inif.Read("Video", "softwareScaler");
            if (mainwindow.cboSoftwareScaler.Items.Contains(softwareScaler))
                mainwindow.cboSoftwareScaler.SelectedItem = softwareScaler;
            else
                listFailedImports.Add("Video: Software Scaler");

            // --------------------------------------------------
            // Audio
            // --------------------------------------------------
            // Audio Driver
            string audioDriver = inif.Read("Audio", "driver");
            if (mainwindow.cboAudioDriver.Items.Contains(audioDriver))
                mainwindow.cboAudioDriver.SelectedItem = audioDriver;
            else
                listFailedImports.Add("Audio: Audio Driver");

            // Channels
            string channels = inif.Read("Audio", "channels");
            if (mainwindow.cboChannels.Items.Contains(channels))
                mainwindow.cboChannels.SelectedItem = channels;
            else
                listFailedImports.Add("Audio: Channels");

            // Volume
            mainwindow.tbxVolume.Text = inif.Read("Audio", "volume");
            mainwindow.tbxVolumeMax.Text = inif.Read("Audio", "volumeMax");

            // Soft Volume
            string softVolume = inif.Read("Audio", "softVolume");
            if (mainwindow.cboSoftVolume.Items.Contains(softVolume))
                mainwindow.cboSoftVolume.SelectedItem = softVolume;
            else
                listFailedImports.Add("Audio: Soft Volume");

            // Soft Volume Max
            mainwindow.tbxSoftVolumeMax.Text = inif.Read("Audio", "softVolumeMax");

            // Normalize
            string normalize = inif.Read("Audio", "normalize");
            if (mainwindow.cboNormalize.Items.Contains(normalize))
                mainwindow.cboNormalize.SelectedItem = normalize;
            else
                listFailedImports.Add("Audio: Normalize");

            // Load Files
            string AudioLoadFiles = inif.Read("Audio", "loadFiles");
            if (mainwindow.cboAudioLoadFiles.Items.Contains(AudioLoadFiles))
                mainwindow.cboAudioLoadFiles.SelectedItem = AudioLoadFiles;
            else
                listFailedImports.Add("Audio: Load Files");

            // -------------------------
            // languages
            // -------------------------
            // ------------
            // Order
            // ------------
            // import full list new order
            string audioLangOrder = inif.Read("Audio", "languagesOrder");
            string[] arrAudioLangOrder = audioLangOrder.Split(',');
            // recreate the list
            ViewModel.listAudioLang = new List<string>(arrAudioLangOrder);
            // recreate item sources
            ViewModel._audioLangItems = new ObservableCollection<string>(ViewModel.listAudioLang);
            mainwindow.listViewAudioLanguages.ItemsSource = ViewModel._audioLangItems;

            // ------------
            // Selected
            // ------------
            string audioLanguagesSelected = inif.Read("Audio", "languagesSelected");
            // Empty List Check
            if (!string.IsNullOrEmpty(audioLanguagesSelected))
            {
                string[] arrAudioLang = audioLanguagesSelected.Split(',');
                foreach (string item in arrAudioLang)
                {
                    if (mainwindow.listViewAudioLanguages.Items.Contains(item))
                    {
                        mainwindow.listViewAudioLanguages.SelectedItems.Add(item);
                    }
                    else
                    {
                        listFailedImports.Add("Audio Languages: " + item);
                    }
                }
            }

            // --------------------------------------------------
            // Subtitles
            // --------------------------------------------------
            // Subtitles
            string subtitles = inif.Read("Subtitles", "subtitles");
            if (mainwindow.cboSubtitles.Items.Contains(subtitles))
                mainwindow.cboSubtitles.SelectedItem = subtitles;
            else
                listFailedImports.Add("Subtitles: Subtitles");

            // Subtitles Load Files
            string subtitlesLoadFiles = inif.Read("Subtitles", "loadFiles");
            if (mainwindow.cboSubtitlesLoadFiles.Items.Contains(subtitlesLoadFiles))
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = subtitlesLoadFiles;
            else
                listFailedImports.Add("Subtitles: Load Files");

            // Subtitles Embedded Fonts
            string subtitlesEmbeddedFonts = inif.Read("Subtitles", "embeddedFonts");
            if (mainwindow.cboSubtitlesEmbeddedFonts.Items.Contains(subtitlesEmbeddedFonts))
                mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem = subtitlesEmbeddedFonts;
            else
                listFailedImports.Add("Subtitles: Embedded Fonts");

            // Subtitles Position
            mainwindow.tbxSubtitlePosition.Text = inif.Read("Subtitles", "position");

            // Fix Timing
            string fixTiming = inif.Read("Subtitles", "fixTiming");
            if (mainwindow.cboSubtitlesFixTiming.Items.Contains(fixTiming))
                mainwindow.cboSubtitlesFixTiming.SelectedItem = fixTiming;
            else
                listFailedImports.Add("Subtitles: Fix Timing");

            // Margins
            string useMargins = inif.Read("Subtitles", "useMargins");
            if (mainwindow.cboSubtitlesMargins.Items.Contains(useMargins))
                mainwindow.cboSubtitlesMargins.SelectedItem = useMargins;
            else
                listFailedImports.Add("Subtitles: Margins");

            // Blend
            string blend = inif.Read("Subtitles", "blend");
            if (mainwindow.cboSubtitlesBlend.Items.Contains(blend))
                mainwindow.cboSubtitlesBlend.SelectedItem = blend;
            else
                listFailedImports.Add("Subtitles: Blend");

            // Subtitles Font
            string subtitlesfont = inif.Read("Subtitles", "font");
            if (mainwindow.cboSubtitlesFont.Items.Contains(subtitlesfont))
                mainwindow.cboSubtitlesFont.SelectedItem = subtitlesfont;
            else
                listFailedImports.Add("Subtitles: Font");

            // Font Size
            string fontSize = inif.Read("Subtitles", "fontSize");
            if (mainwindow.cboSubtitlesFontSize.Items.Contains(fontSize))
                mainwindow.cboSubtitlesFontSize.SelectedItem = fontSize;
            else
                listFailedImports.Add("Subtitles: Font Size");

            // Font Color
            mainwindow.tbxSubtitlesFontColor.Text = inif.Read("Subtitles", "fontColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listSubtitlesFontColor = new List<string>();
            //foreach (var item in mainwindow.tbxSubtitlesFontColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listSubtitlesFontColor.Add(current);
            //}
            //// read ini color
            //string subtitlesFontColor = inif.Read("Subtitles", "fontColor");
            //// if temp list contains color
            //if (listSubtitlesFontColor.Contains(subtitlesFontColor))
            //    mainwindow.tbxSubtitlesFontColor.SelectedItem = mainwindow.tbxSubtitlesFontColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == subtitlesFontColor);
            //else
            //    listFailedImports.Add("Subtitles: Font Color");


            // Border Color
            mainwindow.tbxSubtitlesBorderColor.Text = inif.Read("Subtitles", "borderColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listSubtitlesBorderColor = new List<string>();
            //foreach (var item in mainwindow.cboSubtitlesBorderColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listSubtitlesBorderColor.Add(current);
            //}
            //// read ini color
            //string subtitlesBorderColor = inif.Read("Subtitles", "borderColor");
            //// if temp list contains color
            //if (listSubtitlesBorderColor.Contains(subtitlesBorderColor))
            //    mainwindow.cboSubtitlesBorderColor.SelectedItem = mainwindow.cboSubtitlesBorderColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == subtitlesBorderColor);
            //else
            //    listFailedImports.Add("Subtitles: Border Color");


            // Border Size
            string subtitlesBorderSize = inif.Read("Subtitles", "borderSize");
            if (mainwindow.cboSubtitlesBorderSize.Items.Contains(subtitlesBorderSize))
                mainwindow.cboSubtitlesBorderSize.SelectedItem = subtitlesBorderSize;
            else
                listFailedImports.Add("Subtitles: Border Size");


            // Shadow Color
            mainwindow.tbxSubtitlesShadowColor.Text = inif.Read("Subtitles", "shadowColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listSubtitlesShadowColor = new List<string>();
            //foreach (var item in mainwindow.cboSubtitlesShadowColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listSubtitlesShadowColor.Add(current);
            //}
            //// read ini color
            //string subtitlesShadowColor = inif.Read("Subtitles", "shadowColor");
            //// if temp list contains color
            //if (listSubtitlesShadowColor.Contains(subtitlesShadowColor))
            //    mainwindow.cboSubtitlesShadowColor.SelectedItem = mainwindow.cboSubtitlesShadowColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == subtitlesShadowColor);
            //else
            //    listFailedImports.Add("Subtitles: Shadow Color");

            // Shadow Offset
            mainwindow.tbxSubtitlesShadowOffset.Text = inif.Read("Subtitles", "shadowOffset");

            // ASS
            string subtitlesASS = inif.Read("Subtitles", "ass");
            if (mainwindow.cboSubtitlesASS.Items.Contains(subtitlesASS))
                mainwindow.cboSubtitlesASS.SelectedItem = subtitlesASS;
            else
                listFailedImports.Add("Subtitles: ASS");

            // ASS Override
            string subtitlesASSOverride = inif.Read("Subtitles", "assOverride");
            if (mainwindow.cboSubtitlesASSOverride.Items.Contains(subtitlesASSOverride))
                mainwindow.cboSubtitlesASSOverride.SelectedItem = subtitlesASSOverride;
            else
                listFailedImports.Add("Subtitles: ASS Override");

            // ASS ForceMargins
            string subtitlesASSForceMargins = inif.Read("Subtitles", "assForceMargins");
            if (mainwindow.cboSubtitlesASSForceMargins.Items.Contains(subtitlesASSForceMargins))
                mainwindow.cboSubtitlesASSForceMargins.SelectedItem = subtitlesASSForceMargins;
            else
                listFailedImports.Add("Subtitles: ASS ForceMargins");

            // ASS Hinting
            string subtitlesASSHinting = inif.Read("Subtitles", "assHinting");
            if (mainwindow.cboSubtitlesASSHinting.Items.Contains(subtitlesASSHinting))
                mainwindow.cboSubtitlesASSHinting.SelectedItem = subtitlesASSHinting;
            else
                listFailedImports.Add("Subtitles: ASS Hinting");

            // ASS Kerning
            string subtitlesASSKerning = inif.Read("Subtitles", "assKerning");
            if (mainwindow.cboSubtitlesASSKerning.Items.Contains(subtitlesASSKerning))
                mainwindow.cboSubtitlesASSHinting.SelectedItem = subtitlesASSKerning;
            else
                listFailedImports.Add("Subtitles: ASS Kerning");

            // -------------------------
            // languages
            // -------------------------
            // ------------
            // Order
            // ------------
            // import full list new order
            string subtitlesLangOrder = inif.Read("Subtitles", "languagesOrder");
            string[] arrSubtitlesLangOrder = subtitlesLangOrder.Split(',');
            // recreate the list
            ViewModel.listSubtitlesLang = new List<string>(arrSubtitlesLangOrder);
            // recreate item sources
            ViewModel._subsLangItems = new ObservableCollection<string>(ViewModel.listSubtitlesLang);
            mainwindow.listViewSubtitlesLanguages.ItemsSource = ViewModel._subsLangItems;

            // ------------
            // Selected
            // ------------
            string subtitlesLanguagesSelected = inif.Read("Subtitles", "languagesSelected");
            // Empty List Check
            if (!string.IsNullOrEmpty(subtitlesLanguagesSelected))
            {
                string[] arrSubtitlesLang = subtitlesLanguagesSelected.Split(',');
                foreach (string item in arrSubtitlesLang)
                {
                    if (mainwindow.listViewSubtitlesLanguages.Items.Contains(item))
                    {
                        mainwindow.listViewSubtitlesLanguages.SelectedItems.Add(item);
                    }
                    else
                    {
                        listFailedImports.Add("Subtitles Languages: " + item);
                    }
                }
            }

            // --------------------------------------------------
            // Stream
            // --------------------------------------------------
            // Demux Thread
            string demuxThread = inif.Read("Stream", "demuxThread");
            if (mainwindow.cboDemuxerThread.Items.Contains(demuxThread))
                mainwindow.cboDemuxerThread.SelectedItem = demuxThread;
            else
                listFailedImports.Add("Stream: Demux Thread");

            // Demuxer Buffer Size
            mainwindow.tbxDemuxerBuffersize.Text = inif.Read("Stream", "demuxerBufferSize");

            // Demuxer Read Ahead
            mainwindow.tbxDemuxerReadahead.Text = inif.Read("Stream", "demuxerReadAhead");

            // Demuxer MKV Subtitle Preroll
            mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = inif.Read("Stream", "demuxerMKVSubtitlePreroll");

            // Cache
            string cache = inif.Read("Stream", "cache");
            if (mainwindow.cboCache.Items.Contains(cache))
                mainwindow.cboCache.SelectedItem = cache;
            else
                listFailedImports.Add("Stream: Cache");

            // Cache
            mainwindow.tbxCacheDefault.Text = inif.Read("Stream", "cacheDefault");
            mainwindow.tbxCacheInitial.Text = inif.Read("Stream", "initial");
            mainwindow.tbxCacheSeekMin.Text = inif.Read("Stream", "seekMin");
            mainwindow.tbxCacheBackbuffer.Text = inif.Read("Stream", "backBuffer");
            mainwindow.tbxCacheSeconds.Text = inif.Read("Stream", "seconds");

            // Cache File
            string cachefile = inif.Read("Stream", "file");
            if (mainwindow.cboCacheFile.Items.Contains(cachefile))
                mainwindow.cboCacheFile.SelectedItem = cachefile;
            else
                listFailedImports.Add("Stream: Cache File");

            // Cache File Size
            mainwindow.tbxCacheFileSize.Text = inif.Read("Stream", "fileSize");

            // --------------------------------------------------
            // OSC
            // --------------------------------------------------
            // OSC
            string osc = inif.Read("OSC", "osc");
            if (mainwindow.cboOSC.Items.Contains(osc))
                mainwindow.cboOSC.SelectedItem = osc;
            else
                listFailedImports.Add("OSC: OSC");

            // OSC Layout
            string oscLayout = inif.Read("OSC", "oscLayout");
            if (mainwindow.cboOSCLayout.Items.Contains(oscLayout))
                mainwindow.cboOSCLayout.SelectedItem = oscLayout;
            else
                listFailedImports.Add("OSC: OSC Layout");

            // OSC Seekbar
            string oscSeekbar = inif.Read("OSC", "oscSeekbar");
            if (mainwindow.cboOSCSeekbar.Items.Contains(oscSeekbar))
                mainwindow.cboOSCSeekbar.SelectedItem = oscSeekbar;
            else
                listFailedImports.Add("OSC: OSC Seekbar");

            // --------------------------------------------------
            // OSD
            // --------------------------------------------------
            // OSD
            string videoOSD = inif.Read("OSD", "videoOSD");
            if (mainwindow.cboOSD.Items.Contains(videoOSD))
                mainwindow.cboOSD.SelectedItem = videoOSD;
            else
                listFailedImports.Add("OSD: OSD");

            // Fractions
            mainwindow.tbxCacheFileSize.Text = inif.Read("OSD", "fractions");

            // Duration
            mainwindow.tbxOSDDuration.Text = inif.Read("OSD", "duration");

            // Level
            string osdLevel = inif.Read("OSD", "level");
            if (mainwindow.cboOSDLevel.Items.Contains(osdLevel))
                mainwindow.cboOSDLevel.SelectedItem = osdLevel;
            else
                listFailedImports.Add("OSD: Level");

            // -------------------------
            // Controls
            // -------------------------
            mainwindow.tbxOSDScale.Text = inif.Read("OSD", "scale");
            mainwindow.tbxOSDBarWidth.Text = inif.Read("OSD", "barWidth");
            mainwindow.tbxOSDBarHeight.Text = inif.Read("OSD", "barHeight");

            // -------------------------
            // Text
            // -------------------------
            // Font
            string osdFont = inif.Read("OSD", "font");
            if (mainwindow.cboOSDFont.Items.Contains(osdFont))
                mainwindow.cboOSDFont.SelectedItem = osdFont;
            else
                listFailedImports.Add("OSD: Font");

            // Font Size
            string osdFontSize = inif.Read("OSD", "fontSize");
            if (mainwindow.cboOSDFontSize.Items.Contains(osdFontSize))
                mainwindow.cboOSDFontSize.SelectedItem = osdFontSize;
            else
                listFailedImports.Add("OSD: Font Size");


            // Font Color
            mainwindow.tbxOSDFontColor.Text = inif.Read("OSD", "fontColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listOSDFontColor = new List<string>();
            //foreach (var item in mainwindow.cboOSDFontColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listOSDFontColor.Add(current);
            //}
            //// read ini color
            //string osdFontColor = inif.Read("OSD", "fontColor");
            //// if temp list contains color
            //if (listOSDFontColor.Contains(osdFontColor))
            //    mainwindow.cboOSDFontColor.SelectedItem = mainwindow.cboOSDFontColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == osdFontColor);
            //else
            //    listFailedImports.Add("OSD: Font Color");


            // Border Size
            string osdFontBorderSize = inif.Read("OSD", "borderSize");
            if (mainwindow.cboOSDFontBorderSize.Items.Contains(osdFontBorderSize))
                mainwindow.cboOSDFontBorderSize.SelectedItem = osdFontBorderSize;
            else
                listFailedImports.Add("OSD: Border Size");


            // Border Color
            mainwindow.tbxOSDBorderColor.Text = inif.Read("OSD", "borderColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listOSDBorderColor = new List<string>();
            //foreach (var item in mainwindow.cboOSDBorderColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listOSDBorderColor.Add(current);
            //}
            //// read ini color
            //string osdBorderColor = inif.Read("OSD", "borderColor");
            //// if temp list contains color
            //if (listOSDBorderColor.Contains(osdBorderColor))
            //    mainwindow.cboOSDBorderColor.SelectedItem = mainwindow.cboOSDBorderColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == osdBorderColor);
            //else
            //    listFailedImports.Add("OSD: Border Color");


            // Shadow Color
            mainwindow.tbxOSDShadowColor.Text = inif.Read("OSD", "shadowColor");
            // add combobox items to temp list
            // convert items to string
            //List<string> listOSDShadowColor = new List<string>();
            //// read ini color
            //foreach (var item in mainwindow.cboOSDShadowColor.Items)
            //{
            //    ComboBoxItem currentItem = (ComboBoxItem)(item);
            //    string current = (string)(currentItem.Content);
            //    listOSDShadowColor.Add(current);
            //}
            //// if temp list contains color
            //string osdShadowColor = inif.Read("OSD", "shadowColor");
            //if (listOSDShadowColor.Contains(osdShadowColor))
            //    mainwindow.cboOSDShadowColor.SelectedItem = mainwindow.cboOSDShadowColor.Items
            //        .OfType<ComboBoxItem>()
            //        .FirstOrDefault(x => x.Content.ToString() == osdShadowColor);
            //else
            //    listFailedImports.Add("OSD: Shadow Color");


            // Shadow Offset
            mainwindow.tbxOSDShadowOffset.Text = inif.Read("OSD", "shadowOffset");


            // --------------------------------------------------
            // Failed Imports
            // --------------------------------------------------
            if (listFailedImports.Count() > 0 && listFailedImports != null)
            {
                var message = string.Join(Environment.NewLine, listFailedImports);
                MessageBox.Show("Please set the following and re-save your profile.\n\n" 
                    + message, 
                    "Failed To Import", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        /// <summary>
        ///    INI Reader
        /// </summary>
        /*
        * Source: GitHub Sn0wCrack
        * https://gist.github.com/Sn0wCrack/5891612
        */
        public partial class INIFile
        {
            public string path { get; private set; }

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIFile(string INIPath)
            {
                path = INIPath;
            }
            public void Write(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

            public string Read(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
                return temp.ToString();
            }
        }


    }
}
