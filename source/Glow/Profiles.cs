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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Glow
{
    public partial class Profiles
    {
        /// <summary>
        ///    Choose Preset
        /// </summary>
        public static void Preset(MainWindow mainwindow)
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedIndex = 0;
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "off";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "on";
                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "on";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "on";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "on";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "on";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "on";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl";
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "on";
                mainwindow.cboDither.SelectedItem = "auto";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "on";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl";
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "no";
                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "off";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "no";
                // Font
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 0; //none
                mainwindow.slSubtitlesShadowOffset.Value = 0;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
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
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // -------------------------
                // Video
                // -------------------------
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboOpenGLPBO.SelectedItem = "off";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                // Display
                mainwindow.cboDisplayPrimaries.SelectedItem = "auto";
                mainwindow.cboTransferCharacteristics.SelectedItem = "auto";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";
                // Image
                mainwindow.cboGammaAuto.SelectedItem = "on";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                // Scaling
                mainwindow.cboSigmoid.SelectedItem = "on";
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
                mainwindow.slSubtitlePosition.Value = 95;
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                // Font
                mainwindow.cboSubtitlesFont.SelectedItem = "Noto Sans";
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboSubtitlesShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slSubtitlesShadowOffset.Value = 1.25;
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
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "1";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }
        }



        /// <summary>
        ///    Export Preset
        /// </summary>
        public static void ExportProfile(MainWindow mainwindow, string inputDir, string inputFileName, string inputExt)
        {
            // Selected Item
            ComboBoxItem selectedItem = null;
            string selected = string.Empty;

            // Export's ini file path
            // Get from Save Dialog Path
            string input = inputDir + inputFileName + inputExt;

            // Start INI File Write
            INIFile inif = new INIFile(input);

            // --------------------------------------------------
            // General
            // --------------------------------------------------
            inif.Write("General", "priority", mainwindow.cboPriority.SelectedItem.ToString());
            inif.Write("General", "savePositiOnQuit", mainwindow.cboSavePositionQuit.SelectedItem.ToString());
            inif.Write("General", "keepOpen", mainwindow.cboKeepOpen.SelectedItem.ToString());
            inif.Write("General", "onTop", mainwindow.cboOnTop.SelectedItem.ToString());
            inif.Write("General", "osc", mainwindow.cboOSC.SelectedItem.ToString());
            inif.Write("General", "screenshot", mainwindow.cboScreenshot.SelectedItem.ToString());

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            // Hardware
            inif.Write("Video", "videoDriver", mainwindow.cboVideoDriver.SelectedItem.ToString());
            inif.Write("Video", "openglPBO", mainwindow.cboOpenGLPBO.SelectedItem.ToString());
            inif.Write("Video", "hwdec", mainwindow.cboHWDecoder.SelectedItem.ToString());
            // Display
            inif.Write("Video", "displayPrimaries", mainwindow.cboDisplayPrimaries.SelectedItem.ToString());
            inif.Write("Video", "colorSpace", mainwindow.cboColorSpace.SelectedItem.ToString());
            inif.Write("Video", "colorRange", mainwindow.cboColorRange.SelectedItem.ToString());
            inif.Write("Video", "deinterlace", mainwindow.cboDeinterlace.SelectedItem.ToString());
            inif.Write("Video", "videoSync", mainwindow.cboVideoSync.SelectedItem.ToString());
            inif.Write("Video", "frameDrop", mainwindow.cboFramedrop.SelectedItem.ToString());
            // Image
            inif.Write("Video", "brightness", mainwindow.tbxBrightness.Text.ToString());
            inif.Write("Video", "contrast", mainwindow.tbxContrast.Text.ToString());
            inif.Write("Video", "hue", mainwindow.tbxHue.Text.ToString());
            inif.Write("Video", "saturation", mainwindow.tbxSaturation.Text.ToString());
            inif.Write("Video", "gamma", mainwindow.tbxGamma.Text.ToString());
            inif.Write("Video", "deband", mainwindow.cboDeband.SelectedItem.ToString());
            inif.Write("Video", "debandGrain", mainwindow.tbxDebandGrain.Text.ToString());
            inif.Write("Video", "dither", mainwindow.cboDither.SelectedItem.ToString());
            // Scaling
            inif.Write("Video", "sigmoidUpscaling", mainwindow.cboSigmoid.SelectedItem.ToString());
            inif.Write("Video", "scale", mainwindow.cboScale.SelectedItem.ToString());
            inif.Write("Video", "scaleAntiring", mainwindow.tbxScaleAntiring.Text.ToString());
            inif.Write("Video", "chromaScale", mainwindow.cboChromaScale.SelectedItem.ToString());
            inif.Write("Video", "chromaScaleAntiring", mainwindow.tbxChromaAntiring.Text.ToString());
            inif.Write("Video", "downscale", mainwindow.cboDownscale.SelectedItem.ToString());
            inif.Write("Video", "downscaleAntiring", mainwindow.tbxDownscaleAntiring.Text.ToString());
            inif.Write("Video", "softwareScaler", mainwindow.cboSoftwareScaler.SelectedItem.ToString());

            // --------------------------------------------------
            // Audio
            // --------------------------------------------------
            inif.Write("Audio", "driver", mainwindow.cboAudioDriver.SelectedItem.ToString());

            // -------------------------
            // Languages
            // -------------------------
            // Order
            List<string> listAudioLangOrder = new List<string>(MainWindow.AudioLanguageItems);
            string audioLanguagesOrder = string.Join(",", listAudioLangOrder.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Audio", "languagesOrder", audioLanguagesOrder);

            // Selected
            List<string> listAudioLangSelected = new List<string>();
            foreach (string item in mainwindow.listViewAudioLanguages.SelectedItems)
            {
                // add checked item name to list
                listAudioLangSelected.Add(item);
            }
            string audioLanguagesSelected = string.Join(",", listAudioLangSelected.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Audio", "languagesSelected", audioLanguagesSelected);

            inif.Write("Audio", "channels", mainwindow.cboChannels.SelectedItem.ToString());
            inif.Write("Audio", "volume", mainwindow.tbxVolume.Text.ToString());
            inif.Write("Audio", "volumeMax", mainwindow.tbxVolumeMax.Text.ToString());
            inif.Write("Audio", "softVolume", mainwindow.cboSoftVolume.Text.ToString());
            inif.Write("Audio", "softVolumeMax", mainwindow.tbxSoftVolumeMax.Text.ToString());
            inif.Write("Audio", "normalize", mainwindow.cboNormalize.SelectedItem.ToString());
            inif.Write("Audio", "scaleTempo", mainwindow.cboScaleTempo.SelectedItem.ToString());
            inif.Write("Audio", "loadFiles", mainwindow.cboAudioLoadFiles.SelectedItem.ToString());

            // --------------------------------------------------
            // Subtitle
            // --------------------------------------------------
            inif.Write("Subtitles", "subtitles", mainwindow.cboSubtitles.SelectedItem.ToString());

            // -------------------------
            // Languages
            // -------------------------
            // Order
            List<string> listSubtitlesLangOrder = new List<string>(MainWindow.SubtitlesLanguageItems);
            string subtitlesLanguagesOrder = string.Join(",", listSubtitlesLangOrder.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Subtitles", "languagesOrder", subtitlesLanguagesOrder);

            // Selected
            List<string> listSubtitlesLang = new List<string>();
            foreach (string item in mainwindow.listViewSubtitlesLanguages.SelectedItems)
            {
                listSubtitlesLang.Add(item);
            }
            string subtitlesLanguages = string.Join(",", listSubtitlesLang.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Subtitles", "languagesSelected", subtitlesLanguages);

            //inif.Write("Subtitles", "embeddedFonts", mainwindow.cboAudioLoadFiles.SelectedItem.ToString());
            inif.Write("Subtitles", "loadFiles", mainwindow.cboSubtitlesLoadFiles.SelectedItem.ToString());
            inif.Write("Subtitles", "position", mainwindow.tbxSubtitlePosition.Text.ToString());
            inif.Write("Subtitles", "font", mainwindow.cboSubtitlesFont.SelectedItem.ToString());
            inif.Write("Subtitles", "fontSize", mainwindow.cboSubtitlesFontSize.SelectedItem.ToString());

            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesFontColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("Subtitles", "fontColor", selected);

            inif.Write("Subtitles", "borderSize", mainwindow.cboSubtitlesBorderSize.SelectedItem.ToString());

            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesBorderColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("Subtitles", "borderColor", selected);

            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesShadowColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("Subtitles", "shadowColor", selected);

            inif.Write("Subtitles", "shadowOffset", mainwindow.tbxSubtitlesShadowOffset.Text.ToString());
            inif.Write("Subtitles", "blend", mainwindow.cboSubtitlesBlend.SelectedItem.ToString());

            // --------------------------------------------------
            // Stream
            // --------------------------------------------------
            inif.Write("Stream", "demuxThread", mainwindow.cboDemuxerThread.SelectedItem.ToString());
            inif.Write("Stream", "demuxerBufferSize", mainwindow.tbxDemuxerBuffersize.Text.ToString());
            inif.Write("Stream", "demuxerReadAhead", mainwindow.tbxDemuxerReadahead.Text.ToString());
            inif.Write("Stream", "demuxerMKVSubtitlePreroll", mainwindow.cboDemuxerMKVSubPreroll.SelectedItem.ToString());
            inif.Write("Stream", "cache", mainwindow.cboCache.SelectedItem.ToString());
            inif.Write("Stream", "cacheDefault", mainwindow.tbxCacheDefault.Text.ToString());
            inif.Write("Stream", "initial", mainwindow.tbxCacheInitial.Text.ToString());
            inif.Write("Stream", "seekMin", mainwindow.tbxCacheSeekMin.Text.ToString());
            inif.Write("Stream", "backBuffer", mainwindow.tbxCacheBackbuffer.Text.ToString());
            inif.Write("Stream", "seconds", mainwindow.tbxCacheSeconds.Text.ToString());
            inif.Write("Stream", "file", mainwindow.cboCacheFile.SelectedItem.ToString());
            inif.Write("Stream", "fileSize", mainwindow.tbxCacheFileSize.Text.ToString());

            // --------------------------------------------------
            // OSD
            // --------------------------------------------------
            inif.Write("OSD", "videoOSD", mainwindow.cboOSD.SelectedItem.ToString());
            inif.Write("OSD", "fractions", mainwindow.tbxCacheFileSize.Text.ToString());
            inif.Write("OSD", "duration", mainwindow.tbxOSDDuration.Text.ToString());
            inif.Write("OSD", "level", mainwindow.cboOSDLevel.SelectedItem.ToString());
            inif.Write("OSD", "scale", mainwindow.tbxOSDScale.Text.ToString());
            inif.Write("OSD", "barWidth", mainwindow.tbxOSDBarWidth.Text.ToString());
            inif.Write("OSD", "barHeight", mainwindow.tbxOSDBarHeight.Text.ToString());
            inif.Write("OSD", "font", mainwindow.cboOSDFont.SelectedItem.ToString());
            inif.Write("OSD", "fontSize", mainwindow.cboOSDFontSize.SelectedItem.ToString());

            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("OSD", "fontColor", selected);

            inif.Write("OSD", "borderSize", mainwindow.cboOSDFontBorderSize.SelectedItem.ToString());

            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontBorderColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("OSD", "borderColor", selected);

            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontShadowColor.SelectedValue);
            selected = (string)(selectedItem.Content);
            inif.Write("OSD", "shadowColor", selected);

            inif.Write("OSD", "shadowOffset", mainwindow.tbxOSDShadowOffset.Text.ToString());
        }


        /// <summary>
        ///    Import Preset
        /// </summary>
        public static void ImportProfile(MainWindow mainwindow, string inputDir, string inputFileName, string inputExt)
        {
            // Import's ini file path
            // Get from Select File Dialog Path
            string input = inputDir + inputFileName + inputExt;

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
            //mainwindow.cboPriority.SelectedItem = inif.Read("General", "priority");

            // Save Position
            string savePositiOnQuit = inif.Read("General", "savePositiOnQuit");
            if (mainwindow.cboSavePositionQuit.Items.Contains(savePositiOnQuit))
                mainwindow.cboSavePositionQuit.SelectedItem = savePositiOnQuit;
            else
                listFailedImports.Add("General: Save Position");
            //mainwindow.cboSavePositionQuit.SelectedItem = inif.Read("General", "savePositiOnQuit");

            // Keep Open
            string keepOpen = inif.Read("General", "keepOpen");
            if (mainwindow.cboKeepOpen.Items.Contains(keepOpen))
                mainwindow.cboKeepOpen.SelectedItem = keepOpen;
            else
                listFailedImports.Add("General: Keep Open");
            //mainwindow.cboKeepOpen.SelectedItem = inif.Read("General", "keepOpen");

            // On Top
            string onTop = inif.Read("General", "onTop");
            if (mainwindow.cboOnTop.Items.Contains(onTop))
                mainwindow.cboOnTop.SelectedItem = onTop;
            else
                listFailedImports.Add("General: On Top");
            //mainwindow.cboOnTop.SelectedItem = inif.Read("General", "onTop");

            // OSC
            string osc = inif.Read("General", "osc");
            if (mainwindow.cboOSC.Items.Contains(osc))
                mainwindow.cboOSC.SelectedItem = osc;
            else
                listFailedImports.Add("General: OSC");
            //mainwindow.cboOSC.SelectedItem = inif.Read("General", "osc");

            // Screenshot
            string screenshot = inif.Read("General", "screenshot");
            if (mainwindow.cboScreenshot.Items.Contains(screenshot))
                mainwindow.cboScreenshot.SelectedItem = screenshot;
            else
                listFailedImports.Add("General: Screenshot");
            //mainwindow.cboScreenshot.SelectedItem = inif.Read("General", "screenshot");

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            // Hardware

            // Video Driver
            string videoDriver = inif.Read("Video", "videoDriver");
            if (mainwindow.cboVideoDriver.Items.Contains(videoDriver))
                mainwindow.cboVideoDriver.SelectedItem = videoDriver;
            else
                listFailedImports.Add("Video: Video Driver");
            //mainwindow.cboVideoDriver.SelectedItem = inif.Read("Video", "videoDriver");

            // OpenGL PBO
            string openglPBO = inif.Read("Video", "openglPBO");
            if (mainwindow.cboOpenGLPBO.Items.Contains(openglPBO))
                mainwindow.cboOpenGLPBO.SelectedItem = openglPBO;
            else
                listFailedImports.Add("Video: OpenGL PBO");
            //mainwindow.cboOpenGLPBO.SelectedItem = inif.Read("Video", "openglPBO");

            // HW Decoder
            string hwdec = inif.Read("Video", "hwdec");
            if (mainwindow.cboHWDecoder.Items.Contains(hwdec))
                mainwindow.cboHWDecoder.SelectedItem = hwdec;
            else
                listFailedImports.Add("Video: HW Decoder");
            //mainwindow.cboHWDecoder.SelectedItem = inif.Read("Video", "hwdec");


            // Display

            // Display Primaries
            string displayPrimaries = inif.Read("Video", "displayPrimaries");
            if (mainwindow.cboDisplayPrimaries.Items.Contains(displayPrimaries))
                mainwindow.cboDisplayPrimaries.SelectedItem = displayPrimaries;
            else
                listFailedImports.Add("Video: Display Primaries");
            //mainwindow.cboDisplayPrimaries.SelectedItem = inif.Read("Video", "displayPrimaries");

            // Color Space
            string colorSpace = inif.Read("Video", "colorSpace");
            if (mainwindow.cboColorSpace.Items.Contains(colorSpace))
                mainwindow.cboColorSpace.SelectedItem = colorSpace;
            else
                listFailedImports.Add("Video: Color Space");
            //mainwindow.cboColorSpace.SelectedItem = inif.Read("Video", "colorSpace");

            // Color Range
            string colorRange = inif.Read("Video", "colorRange");
            if (mainwindow.cboColorRange.Items.Contains(colorRange))
                mainwindow.cboColorRange.SelectedItem = colorRange;
            else
                listFailedImports.Add("Video: Color Range");
            //mainwindow.cboColorRange.SelectedItem = inif.Read("Video", "colorRange");

            // Deinterlace
            string deinterlace = inif.Read("Video", "deinterlace");
            if (mainwindow.cboDeinterlace.Items.Contains(deinterlace))
                mainwindow.cboDeinterlace.SelectedItem = deinterlace;
            else
                listFailedImports.Add("Video: Deinterlace");
            //mainwindow.cboDeinterlace.SelectedItem = inif.Read("Video", "deinterlace");

            // Video Sync
            string videoSync = inif.Read("Video", "videoSync");
            if (mainwindow.cboVideoSync.Items.Contains(videoSync))
                mainwindow.cboVideoSync.SelectedItem = videoSync;
            else
                listFailedImports.Add("Video: Video Sync");
            //mainwindow.cboVideoSync.SelectedItem = inif.Read("Video", "videoSync");

            // Frame Drop
            string frameDrop = inif.Read("Video", "frameDrop");
            if (mainwindow.cboFramedrop.Items.Contains(frameDrop))
                mainwindow.cboFramedrop.SelectedItem = frameDrop;
            else
                listFailedImports.Add("Video: Frame Drop");
            //mainwindow.cboFramedrop.SelectedItem = inif.Read("Video", "frameDrop");


            // Image
            mainwindow.tbxBrightness.Text = inif.Read("Video", "brightness");
            mainwindow.tbxContrast.Text = inif.Read("Video", "contrast");
            mainwindow.tbxHue.Text = inif.Read("Video", "hue");
            mainwindow.tbxSaturation.Text = inif.Read("Video", "saturation");
            mainwindow.tbxGamma.Text = inif.Read("Video", "gamma");


            // Deband
            string deband = inif.Read("Video", "deband");
            if (mainwindow.cboDeband.Items.Contains(deband))
                mainwindow.cboDeband.SelectedItem = deband;
            else
                listFailedImports.Add("Video: Deband");
            //mainwindow.cboDeband.SelectedItem = inif.Read("Video", "deband");

            // Deband Grain
            mainwindow.tbxDebandGrain.Text = inif.Read("Video", "debandGrain");

            // Dither
            string dither = inif.Read("Video", "dither");
            if (mainwindow.cboDither.Items.Contains(dither))
                mainwindow.cboDither.SelectedItem = dither;
            else
                listFailedImports.Add("Video: Dither");
            //mainwindow.cboDither.SelectedItem = inif.Read("Video", "dither");

            // Scaling

            // Sigmoid Upscaling
            string sigmoidUpscaling = inif.Read("Video", "sigmoidUpscaling");
            if (mainwindow.cboSigmoid.Items.Contains(sigmoidUpscaling))
                mainwindow.cboSigmoid.SelectedItem = sigmoidUpscaling;
            else
                listFailedImports.Add("Video: Sigmoid");
            //mainwindow.cboSigmoid.SelectedItem = inif.Read("Video", "sigmoidUpscaling");

            // Scale
            string scale = inif.Read("Video", "scale");
            if (mainwindow.cboScale.Items.Contains(scale))
                mainwindow.cboScale.SelectedItem = scale;
            else
                listFailedImports.Add("Video: Scale");
            //mainwindow.cboScale.SelectedItem = inif.Read("Video", "scale");

            // Scale Antiring
            mainwindow.tbxScaleAntiring.Text = inif.Read("Video", "scaleAntiring");

            // Chroma Scale
            string chromaScale = inif.Read("Video", "chromaScale");
            if (mainwindow.cboChromaScale.Items.Contains(chromaScale))
                mainwindow.cboChromaScale.SelectedItem = chromaScale;
            else
                listFailedImports.Add("Video: Chroma Scale");
            //mainwindow.cboChromaScale.SelectedItem = inif.Read("Video", "chromaScale");

            // Chroma Antiring
            mainwindow.tbxChromaAntiring.Text = inif.Read("Video", "chromaScaleAntiring");

            // Downscale
            string downscale = inif.Read("Video", "downscale");
            if (mainwindow.cboDownscale.Items.Contains(downscale))
                mainwindow.cboDownscale.SelectedItem = downscale;
            else
                listFailedImports.Add("Video: Downscale");
            //mainwindow.cboDownscale.SelectedItem = inif.Read("Video", "downscale");

            // Downscale Antiring
            mainwindow.tbxDownscaleAntiring.Text = inif.Read("Video", "downscaleAntiring");

            // Software Scaler
            string softwareScaler = inif.Read("Video", "softwareScaler");
            if (mainwindow.cboSoftwareScaler.Items.Contains(softwareScaler))
                mainwindow.cboSoftwareScaler.SelectedItem = softwareScaler;
            else
                listFailedImports.Add("Video: Software Scaler");
            //mainwindow.cboSoftwareScaler.SelectedItem = inif.Read("Video", "softwareScaler");

            // --------------------------------------------------
            // Audio
            // --------------------------------------------------
            // Audio Driver
            string audioDriver = inif.Read("Audio", "driver");
            if (mainwindow.cboAudioDriver.Items.Contains(audioDriver))
                mainwindow.cboAudioDriver.SelectedItem = audioDriver;
            else
                listFailedImports.Add("Audio: Audio Driver");
            //mainwindow.cboAudioDriver.SelectedItem = inif.Read("Audio", "driver");

            // Channels
            string channels = inif.Read("Audio", "channels");
            if (mainwindow.cboChannels.Items.Contains(channels))
                mainwindow.cboChannels.SelectedItem = channels;
            else
                listFailedImports.Add("Audio: Channels");
            //mainwindow.cboChannels.SelectedItem = inif.Read("Audio", "channels");

            // Volume
            mainwindow.tbxVolume.Text = inif.Read("Audio", "volume");
            mainwindow.tbxVolumeMax.Text = inif.Read("Audio", "volumeMax");

            // Soft Volume
            string softVolume = inif.Read("Audio", "softVolume");
            if (mainwindow.cboSoftVolume.Items.Contains(softVolume))
                mainwindow.cboSoftVolume.SelectedItem = softVolume;
            else
                listFailedImports.Add("Audio: Soft Volume");
            //mainwindow.cboSoftVolume.SelectedItem = inif.Read("Audio", "softVolume");

            // Soft Volume Max
            mainwindow.tbxSoftVolumeMax.Text = inif.Read("Audio", "softVolumeMax");

            // -------------------------
            // Normalize
            // -------------------------
            string normalize = inif.Read("Audio", "normalize");
            if (mainwindow.cboNormalize.Items.Contains(normalize))
                mainwindow.cboNormalize.SelectedItem = normalize;
            else
                listFailedImports.Add("Audio: Normalize");
            //mainwindow.cboNormalize.SelectedItem = inif.Read("Audio", "normalize");

            // -------------------------
            // Load Files
            // -------------------------
            string AudioLoadFiles = inif.Read("Audio", "loadFiles");
            if (mainwindow.cboAudioLoadFiles.Items.Contains(AudioLoadFiles))
                mainwindow.cboAudioLoadFiles.SelectedItem = AudioLoadFiles;
            else
                listFailedImports.Add("Audio: Load Files");
            //mainwindow.cboAudioLoadFiles.SelectedItem = inif.Read("Audio", "loadFiles");

            // -------------------------
            // languages
            // -------------------------
            // Order
            // import full list new order
            string audioLangOrder = inif.Read("Audio", "languagesOrder");
            string[] arrAudioLangOrder = audioLangOrder.Split(',');
            // recreate the list
            MainWindow.listAudioLang = new List<string>(arrAudioLangOrder);
            // recreate item sources
            MainWindow._audioLangItems = new ObservableCollection<string>(MainWindow.listAudioLang);
            mainwindow.listViewAudioLanguages.ItemsSource = MainWindow._audioLangItems;

            // Selected
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
            //mainwindow.cboSubtitles.SelectedItem = inif.Read("Subtitles", "subtitles");

            // Subtitles Load Files
            string SubtitlesLoadFiles = inif.Read("Subtitles", "loadFiles");
            if (mainwindow.cboSubtitlesLoadFiles.Items.Contains(SubtitlesLoadFiles))
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = SubtitlesLoadFiles;
            else
                listFailedImports.Add("Subtitles: Load Files");
            //mainwindow.cboSubtitlesLoadFiles.SelectedItem = inif.Read("Subtitles", "loadFiles");

            // Subtitles Position
            mainwindow.tbxSubtitlePosition.Text = inif.Read("Subtitles", "position");

            // Subtitles Font
            string Subtitlesfont = inif.Read("Subtitles", "font");
            if (mainwindow.cboSubtitlesFont.Items.Contains(Subtitlesfont))
                mainwindow.cboSubtitlesFont.SelectedItem = Subtitlesfont;
            else
                listFailedImports.Add("Subtitles: Font");
            //mainwindow.cboSubtitlesFont.SelectedItem = inif.Read("Subtitles", "font");

            // Font Size
            string fontSize = inif.Read("Subtitles", "fontSize");
            if (mainwindow.cboSubtitlesFontSize.Items.Contains(fontSize))
                mainwindow.cboSubtitlesFontSize.SelectedItem = fontSize;
            else
                listFailedImports.Add("Subtitles: Font Size");
            //mainwindow.cboSubtitlesFontSize.SelectedItem = inif.Read("Subtitles", "fontSize");

            // Font Color
            string SubtitlesFontColor = inif.Read("Subtitles", "fontColor");
            if (mainwindow.cboSubtitlesFontColor.Items.Contains(SubtitlesFontColor))
                mainwindow.cboSubtitlesFontColor.SelectedItem = SubtitlesFontColor;
            else
                listFailedImports.Add("Subtitles: Font Color");
            //mainwindow.cboSubtitlesFontColor.SelectedItem = inif.Read("Subtitles", "fontColor");

            // Border Color
            string SubtitlesBorderColor = inif.Read("Subtitles", "borderColor");
            if (mainwindow.cboSubtitlesBorderColor.Items.Contains(SubtitlesBorderColor))
                mainwindow.cboSubtitlesBorderColor.SelectedItem = SubtitlesBorderColor;
            else
                listFailedImports.Add("Subtitles: Border Color");
            //mainwindow.cboSubtitlesBorderColor.SelectedItem = inif.Read("Subtitles", "borderColor");

            // Border Size
            string SubtitlesBorderSize = inif.Read("Subtitles", "borderSize");
            if (mainwindow.cboSubtitlesBorderSize.Items.Contains(SubtitlesBorderSize))
                mainwindow.cboSubtitlesBorderSize.SelectedItem = SubtitlesBorderSize;
            else
                listFailedImports.Add("Subtitles: Border Size");
            //mainwindow.cboSubtitlesBorderSize.SelectedItem = inif.Read("Subtitles", "borderSize");

            // Shadow Color
            string SubtitlesShadowColor = inif.Read("Subtitles", "shadowColor");
            if (mainwindow.cboSubtitlesShadowColor.Items.Contains(SubtitlesShadowColor))
                mainwindow.cboSubtitlesShadowColor.SelectedItem = SubtitlesShadowColor;
            else
                listFailedImports.Add("Subtitles: Shadow Color");
            //mainwindow.cboSubtitlesShadowColor.SelectedItem = inif.Read("Subtitles", "shadowColor");

            // Shadow Offset
            mainwindow.tbxSubtitlesShadowOffset.Text = inif.Read("Subtitles", "shadowOffset");

            // Blend
            string blend = inif.Read("Subtitles", "blend");
            if (mainwindow.cboSubtitlesBlend.Items.Contains(blend))
                mainwindow.cboSubtitlesBlend.SelectedItem = blend;
            else
                listFailedImports.Add("Subtitles: Blend");
            //mainwindow.cboSubtitlesBlend.SelectedItem = inif.Read("Subtitles", "blend");

            // -------------------------
            // languages
            // -------------------------
            // Order
            // import full list new order
            string subtitlesLangOrder = inif.Read("Subtitles", "languagesOrder");
            string[] arrSubtitlesLangOrder = subtitlesLangOrder.Split(',');
            // recreate the list
            MainWindow.listSubtitlesLang = new List<string>(arrSubtitlesLangOrder);
            // recreate item sources
            MainWindow._subsLangItems = new ObservableCollection<string>(MainWindow.listSubtitlesLang);
            mainwindow.listViewSubtitlesLanguages.ItemsSource = MainWindow._subsLangItems;

            // Selected
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
            //mainwindow.cboDemuxerThread.SelectedItem = inif.Read("Stream", "demuxThread");

            mainwindow.tbxDemuxerBuffersize.Text = inif.Read("Stream", "demuxerBufferSize");

            mainwindow.tbxDemuxerReadahead.Text = inif.Read("Stream", "demuxerReadAhead");

            mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = inif.Read("Stream", "demuxerMKVSubtitlePreroll");

            // Cache
            string cache = inif.Read("Stream", "cache");
            if (mainwindow.cboCache.Items.Contains(cache))
                mainwindow.cboCache.SelectedItem = cache;
            else
                listFailedImports.Add("Stream: Cache");
            //mainwindow.cboCache.SelectedItem = inif.Read("Stream", "cache");

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
            //mainwindow.cboCacheFile.SelectedItem = inif.Read("Stream", "file");


            mainwindow.tbxCacheFileSize.Text = inif.Read("Stream", "fileSize");

            // --------------------------------------------------
            // OSD
            // --------------------------------------------------
            // OSD
            string videoOSD = inif.Read("OSD", "videoOSD");
            if (mainwindow.cboOSD.Items.Contains(videoOSD))
                mainwindow.cboOSD.SelectedItem = videoOSD;
            else
                listFailedImports.Add("OSD: OSD");
            //mainwindow.cboOSD.SelectedItem = inif.Read("OSD", "videoOSD");

            mainwindow.tbxCacheFileSize.Text = inif.Read("OSD", "fractions");
            mainwindow.tbxOSDDuration.Text = inif.Read("OSD", "duration");

            // Level
            string osdLevel = inif.Read("OSD", "level");
            if (mainwindow.cboOSDLevel.Items.Contains(osdLevel))
                mainwindow.cboOSDLevel.SelectedItem = osdLevel;
            else
                listFailedImports.Add("OSD: Level");
            //mainwindow.cboOSDLevel.SelectedItem = inif.Read("OSD", "level");


            mainwindow.tbxOSDScale.Text = inif.Read("OSD", "scale");
            mainwindow.tbxOSDBarWidth.Text = inif.Read("OSD", "barWidth");
            mainwindow.tbxOSDBarHeight.Text = inif.Read("OSD", "barHeight");

            // Font
            string osdFont = inif.Read("OSD", "font");
            if (mainwindow.cboOSDFont.Items.Contains(osdFont))
                mainwindow.cboOSDFont.SelectedItem = osdFont;
            else
                listFailedImports.Add("OSD: Font");
            //mainwindow.cboOSDFont.SelectedItem = inif.Read("OSD", "font");

            // Font Size
            string osdFontSize = inif.Read("OSD", "fontSize");
            if (mainwindow.cboOSDFontSize.Items.Contains(osdFontSize))
                mainwindow.cboOSDFontSize.SelectedItem = osdFontSize;
            else
                listFailedImports.Add("OSD: Font Size");
            //mainwindow.cboOSDFontSize.SelectedItem = inif.Read("OSD", "fontSize");

            // Font Color
            string osdFontColor = inif.Read("OSD", "fontColor");
            if (mainwindow.cboOSDFontColor.Items.Contains(osdFontColor))
                mainwindow.cboOSDFontColor.SelectedItem = osdFontColor;
            else
                listFailedImports.Add("OSD: Font Color");
            //mainwindow.cboOSDFontColor.SelectedItem = inif.Read("OSD", "fontColor");

            // Border Size
            string osdFontBorderSize = inif.Read("OSD", "borderSize");
            if (mainwindow.cboOSDFontBorderSize.Items.Contains(osdFontBorderSize))
                mainwindow.cboOSDFontBorderSize.SelectedItem = osdFontBorderSize;
            else
                listFailedImports.Add("OSD: Border Size");
            //mainwindow.cboOSDFontBorderSize.SelectedItem = inif.Read("OSD", "borderSize");

            // Border Color
            string osdFontBorderColor = inif.Read("OSD", "borderColor");
            if (mainwindow.cboOSDFontBorderColor.Items.Contains(osdFontBorderColor))
                mainwindow.cboOSDFontBorderColor.SelectedItem = osdFontBorderColor;
            else
                listFailedImports.Add("OSD: Border Color");
            //mainwindow.cboOSDFontBorderColor.SelectedItem = inif.Read("OSD", "borderColor");

            // Shadow Color
            string osdFontShadowColor = inif.Read("OSD", "shadowColor");
            if (mainwindow.cboOSDFontShadowColor.Items.Contains(osdFontShadowColor))
                mainwindow.cboOSDFontShadowColor.SelectedItem = osdFontShadowColor;
            else
                listFailedImports.Add("OSD: Shadow Color");
            //mainwindow.cboOSDFontShadowColor.SelectedItem = inif.Read("OSD", "shadowColor");

            // Shadow Offset
            mainwindow.tbxOSDShadowOffset.Text = inif.Read("OSD", "shadowOffset");


            // --------------------------------------------------
            // Failed Imports
            // --------------------------------------------------
            if (listFailedImports.Count() > 0 && listFailedImports != null)
            {
                var message = string.Join(Environment.NewLine, listFailedImports);
                MessageBox.Show(message, "Failed To Import", MessageBoxButton.OK, MessageBoxImage.Information);
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

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32")]
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
