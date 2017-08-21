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

namespace Glow
{
    public partial class Presets
    {
        public static void Preset(MainWindow mainwindow)
        {
            // -------------------------
            // Default
            // -------------------------
            if ((string)mainwindow.cboPreset.SelectedItem == "Default")
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
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboGamma.SelectedItem = "auto";

                mainwindow.cboScale.SelectedItem = "bicubic";
                mainwindow.slScaleAntiring.Value = 0;
                mainwindow.cboChromaScale.SelectedItem = "bicubic";
                mainwindow.slChromaAntiring.Value = 0;
                mainwindow.cboDownscale.SelectedItem = "bicubic";
                mainwindow.slDownscaleAntiring.Value = 0;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.tbxDebandGrain.Text = "";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                mainwindow.cboVideoSync.SelectedItem = "off";
                mainwindow.cboFramedrop.SelectedItem = "vo";

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
                mainwindow.slOSDBarWidth.Value = 100;
                mainwindow.slOSDBarHeight.Value = 0.1;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "44";
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "2";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }

            // -------------------------
            // Ultra
            // -------------------------
            else if ((string)mainwindow.cboPreset.SelectedItem == "Ultra")
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
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboGamma.SelectedItem = "auto";

                mainwindow.cboScale.SelectedItem = "ewa_lanczossharp";
                mainwindow.slScaleAntiring.Value = 1;
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.slChromaAntiring.Value = 1;
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.slDownscaleAntiring.Value = 1;
                mainwindow.cboSoftwareScaler.SelectedItem = "off";

                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.tbxDebandGrain.Text = "80";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";

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
                mainwindow.slOSDBarWidth.Value = 100;
                mainwindow.slOSDBarHeight.Value = 0.1;
                // Font
                mainwindow.cboOSDFontSize.SelectedItem = "44";
                mainwindow.cboOSDFontColor.SelectedIndex = 0; //white
                // Border
                mainwindow.cboOSDFontBorderSize.SelectedItem = "2";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2; //dark gray
                // Shadow
                mainwindow.cboOSDFontShadowColor.SelectedIndex = 3; //dark gray
                mainwindow.slOSDShadowOffset.Value = 1.25;
            }
        }
    }
}
