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

            List<string> listLangAudio = new List<string>();
            foreach (string item in mainwindow.listViewAudioLanguages.SelectedItems)
            {
                listLangAudio.Add(item);
            }
            string languagesAudio = string.Join(",", listLangAudio.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Audio", "languages", languagesAudio);

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

            List<string> listLangSubtitles = new List<string>();
            foreach (string item in mainwindow.listViewSubtitlesLanguages.SelectedItems)
            {
                listLangSubtitles.Add(item);
            }
            string languagesSubtitles = string.Join(",", listLangAudio.Where(s => !string.IsNullOrEmpty(s)));
            inif.Write("Subtitles", "languages", languagesSubtitles);

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

            // OSC
            string osc = inif.Read("General", "osc");
            if (mainwindow.cboOSC.Items.Contains(osc))
                mainwindow.cboOSC.SelectedItem = osc;
            else
                listFailedImports.Add("General: OSC");

            // Screenshot
            string screenshot = inif.Read("General", "screenshot");
            if (mainwindow.cboScreenshot.Items.Contains(screenshot))
                mainwindow.cboScreenshot.SelectedItem = screenshot;
            else
                listFailedImports.Add("General: Screenshot");

            //mainwindow.cboSavePositionQuit.SelectedItem = inif.Read("General", "savePositiOnQuit");
            //mainwindow.cboKeepOpen.SelectedItem = inif.Read("General", "keepOpen");
            //mainwindow.cboOnTop.SelectedItem = inif.Read("General", "onTop");
            //mainwindow.cboOSC.SelectedItem = inif.Read("General", "osc");
            //mainwindow.cboScreenshot.SelectedItem = inif.Read("General", "screenshot");

            // --------------------------------------------------
            // Video
            // --------------------------------------------------
            // Hardware
            mainwindow.cboVideoDriver.SelectedItem = inif.Read("Video", "videoDriver");
            mainwindow.cboOpenGLPBO.SelectedItem = inif.Read("Video", "openglPBO");
            mainwindow.cboHWDecoder.SelectedItem = inif.Read("Video", "hwdec");
            // Display
            mainwindow.cboDisplayPrimaries.SelectedItem = inif.Read("Video", "displayPrimaries");
            mainwindow.cboColorSpace.SelectedItem = inif.Read("Video", "colorSpace");
            mainwindow.cboColorRange.SelectedItem = inif.Read("Video", "colorRange");
            mainwindow.cboDeinterlace.SelectedItem = inif.Read("Video", "deinterlace");
            mainwindow.cboVideoSync.SelectedItem = inif.Read("Video", "videoSync");
            mainwindow.cboFramedrop.SelectedItem = inif.Read("Video", "frameDrop");
            // Image
            mainwindow.tbxBrightness.Text = inif.Read("Video", "brightness");
            mainwindow.tbxContrast.Text = inif.Read("Video", "contrast");
            mainwindow.tbxHue.Text = inif.Read("Video", "hue");
            mainwindow.tbxSaturation.Text = inif.Read("Video", "saturation");
            mainwindow.tbxGamma.Text = inif.Read("Video", "gamma");
            mainwindow.cboDeband.SelectedItem = inif.Read("Video", "deband");
            mainwindow.tbxDebandGrain.Text = inif.Read("Video", "debandGrain");
            mainwindow.cboDither.SelectedItem = inif.Read("Video", "dither");
            // Scaling
            mainwindow.cboSigmoid.SelectedItem = inif.Read("Video", "sigmoidUpscaling");
            mainwindow.cboScale.SelectedItem = inif.Read("Video", "scale");
            mainwindow.tbxScaleAntiring.Text = inif.Read("Video", "scaleAntiring");
            mainwindow.cboChromaScale.SelectedItem = inif.Read("Video", "chromaScale");
            mainwindow.tbxChromaAntiring.Text = inif.Read("Video", "chromaScaleAntiring");
            mainwindow.cboDownscale.SelectedItem = inif.Read("Video", "downscale");
            mainwindow.tbxDownscaleAntiring.Text = inif.Read("Video", "downscaleAntiring");
            mainwindow.cboSoftwareScaler.SelectedItem = inif.Read("Video", "softwareScaler");

            // --------------------------------------------------
            // Audio
            // --------------------------------------------------
            mainwindow.cboAudioDriver.SelectedItem = inif.Read("Audio", "driver");
            mainwindow.cboChannels.SelectedItem = inif.Read("Audio", "channels");
            mainwindow.tbxVolume.Text = inif.Read("Audio", "volume");
            mainwindow.tbxVolumeMax.Text = inif.Read("Audio", "volumeMax");
            mainwindow.cboSoftVolume.SelectedItem = inif.Read("Audio", "softVolume");
            mainwindow.tbxSoftVolumeMax.Text = inif.Read("Audio", "softVolumeMax");
            mainwindow.cboNormalize.SelectedItem = inif.Read("Audio", "normalize");
            mainwindow.cboAudioLoadFiles.SelectedItem = inif.Read("Audio", "loadFiles");
            // languages
            string languagesAudio = inif.Read("Audio", "languages");
            string[] arrLangAudio = languagesAudio.Split(',');
            foreach (string item in arrLangAudio)
            {
                mainwindow.listViewAudioLanguages.SelectedItems.Add(item);
            }

            // --------------------------------------------------
            // Subtitles
            // --------------------------------------------------
            mainwindow.cboSubtitles.SelectedItem = inif.Read("Subtitles", "subtitles");
            mainwindow.cboSubtitlesLoadFiles.SelectedItem = inif.Read("Subtitles", "loadFiles");
            mainwindow.tbxSubtitlePosition.Text = inif.Read("Subtitles", "position");
            mainwindow.cboSubtitlesFont.SelectedItem = inif.Read("Subtitles", "font");
            mainwindow.cboSubtitlesFontSize.SelectedItem = inif.Read("Subtitles", "fontSize");
            mainwindow.cboSubtitlesFontColor.SelectedItem = inif.Read("Subtitles", "fontColor");
            mainwindow.cboSubtitlesBorderColor.SelectedItem = inif.Read("Subtitles", "borderColor");
            mainwindow.cboSubtitlesBorderSize.SelectedItem = inif.Read("Subtitles", "borderSize");
            mainwindow.cboSubtitlesShadowColor.SelectedItem = inif.Read("Subtitles", "shadowColor");
            mainwindow.tbxSubtitlesShadowOffset.Text = inif.Read("Subtitles", "shadowOffset");
            mainwindow.cboSubtitlesBlend.SelectedItem = inif.Read("Subtitles", "blend");
            // languages
            string languagesSubtitles = inif.Read("Subtitles", "languages");
            string[] arrLangSubtitles = languagesAudio.Split(',');
            foreach (string item in arrLangAudio)
            {
                mainwindow.listViewSubtitlesLanguages.SelectedItems.Add(item);
            }

            // --------------------------------------------------
            // Stream
            // --------------------------------------------------
            mainwindow.cboDemuxerThread.SelectedItem = inif.Read("Stream", "demuxThread");
            mainwindow.tbxDemuxerBuffersize.Text = inif.Read("Stream", "demuxerBufferSize");
            mainwindow.tbxDemuxerReadahead.Text = inif.Read("Stream", "demuxerReadAhead");
            mainwindow.cboDemuxerMKVSubPreroll.SelectedItem = inif.Read("Stream", "demuxerMKVSubtitlePreroll");
            mainwindow.cboCache.SelectedItem = inif.Read("Stream", "cache");
            mainwindow.tbxCacheDefault.Text = inif.Read("Stream", "cacheDefault");
            mainwindow.tbxCacheInitial.Text = inif.Read("Stream", "initial");
            mainwindow.tbxCacheSeekMin.Text = inif.Read("Stream", "seekMin");
            mainwindow.tbxCacheBackbuffer.Text = inif.Read("Stream", "backBuffer");
            mainwindow.tbxCacheSeconds.Text = inif.Read("Stream", "seconds");
            mainwindow.cboCacheFile.SelectedItem = inif.Read("Stream", "file");
            mainwindow.tbxCacheFileSize.Text = inif.Read("Stream", "fileSize");

            // --------------------------------------------------
            // OSD
            // --------------------------------------------------
            mainwindow.cboOSD.SelectedItem = inif.Read("OSD", "videoOSD");
            mainwindow.tbxCacheFileSize.Text = inif.Read("OSD", "fractions");
            mainwindow.tbxOSDDuration.Text = inif.Read("OSD", "duration");
            mainwindow.cboOSDLevel.SelectedItem = inif.Read("OSD", "level");
            mainwindow.tbxOSDScale.Text = inif.Read("OSD", "scale");
            mainwindow.tbxOSDBarWidth.Text = inif.Read("OSD", "barWidth");
            mainwindow.tbxOSDBarHeight.Text = inif.Read("OSD", "barHeight");
            mainwindow.cboOSDFont.SelectedItem = inif.Read("OSD", "font");
            mainwindow.cboOSDFontSize.SelectedItem = inif.Read("OSD", "fontSize");
            mainwindow.cboOSDFontColor.SelectedItem = inif.Read("OSD", "fontColor");
            mainwindow.cboOSDFontBorderSize.SelectedItem = inif.Read("OSD", "borderSize");
            mainwindow.cboOSDFontBorderColor.SelectedItem = inif.Read("OSD", "borderColor");
            mainwindow.cboOSDFontShadowColor.SelectedItem = inif.Read("OSD", "shadowColor");
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
