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
                // General
                mainwindow.cboPriority.SelectedItem = "normal";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // Video
                mainwindow.cboVideoDriver.SelectedIndex = 0;
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboGamma.SelectedIndex = 0;
                mainwindow.cboScale.SelectedItem = "bicubic";
                mainwindow.cboChromaScale.SelectedItem = "bicubic";
                mainwindow.cboDownscale.SelectedItem = "bicubic";
                mainwindow.cboAntiring.SelectedItem = "no";
                mainwindow.cboDither.SelectedItem = "no";
                mainwindow.cboDeband.SelectedItem = "no";
                mainwindow.cboDebandGrain.SelectedItem = "off";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                mainwindow.cboVideoSync.SelectedItem = "off";
                mainwindow.cboFramedrop.SelectedItem = "vo";

                // Audio
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                //mainwindow.cboAudioLanguages.SelectedIndex = 0;
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.cboVolume.SelectedItem = "100";
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";

                // Subtitles
                mainwindow.cboSubtitles.SelectedItem = "yes";
                //mainwindow.cboSubtitlesLanguages.SelectedIndex = 0;
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlePosition.SelectedItem = "95";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                mainwindow.cboSubtitlesFont.SelectedItem = "Arial";
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0;
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2;

                // Stream
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // OSD
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.tbxOSDScale.Text = "0.5";
                mainwindow.cboOSDFontSize.SelectedItem = "44";
                mainwindow.cboOSDFontColor.SelectedIndex = 0;
                mainwindow.cboOSDFontBorderSize.SelectedItem = "2";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2;
                mainwindow.cboOSDFractions.SelectedItem = "yes";
            }

            // -------------------------
            // Ultra
            // -------------------------
            else if ((string)mainwindow.cboPreset.SelectedItem == "Ultra")
            {
                // General
                mainwindow.cboPriority.SelectedItem = "high";
                mainwindow.cboKeepOpen.SelectedItem = "yes";
                mainwindow.cboOnTop.SelectedItem = "no";
                mainwindow.cboOSC.SelectedItem = "yes";
                mainwindow.cboScreenshot.SelectedItem = "png";

                // Video
                mainwindow.cboVideoDriver.SelectedItem = "opengl-hq";
                mainwindow.cboHWDecoder.SelectedItem = "auto-copy";
                mainwindow.cboColorSpace.SelectedIndex = 0;
                mainwindow.cboColorRange.SelectedIndex = 0;
                mainwindow.cboGamma.SelectedIndex = 0;
                mainwindow.cboScale.SelectedItem = "ewa_lanczossharp";
                mainwindow.cboChromaScale.SelectedItem = "ewa_lanczossoft";
                mainwindow.cboDownscale.SelectedItem = "mitchell";
                mainwindow.cboAntiring.SelectedItem = "yes";
                mainwindow.cboDither.SelectedItem = "8";
                mainwindow.cboDeband.SelectedItem = "yes";
                mainwindow.cboDebandGrain.SelectedItem = "off";
                mainwindow.cboDeinterlace.SelectedItem = "auto";
                mainwindow.cboVideoSync.SelectedItem = "display-resample";
                mainwindow.cboFramedrop.SelectedItem = "vo";

                // Audio
                mainwindow.cboAudioDriver.SelectedItem = "wasapi";
                //mainwindow.cboAudioLanguages.SelectedIndex = 0;
                mainwindow.cboChannels.SelectedItem = "auto";
                mainwindow.cboVolume.SelectedItem = "100";
                mainwindow.cboSoftVolume.SelectedItem = "yes";
                mainwindow.cboNormalize.SelectedItem = "yes";
                mainwindow.cboScaleTempo.SelectedItem = "yes";
                mainwindow.cboAudioLoadFiles.SelectedItem = "fuzzy";

                // Subtitles
                mainwindow.cboSubtitles.SelectedItem = "yes";
                //mainwindow.cboSubtitlesLanguages.SelectedIndex = 0;
                mainwindow.cboSubtitlesLoadFiles.SelectedItem = "fuzzy";
                mainwindow.cboSubtitlePosition.SelectedItem = "95";
                mainwindow.cboSubtitlesBlend.SelectedItem = "yes";
                mainwindow.cboSubtitlesFont.SelectedItem = "Arial";
                mainwindow.cboSubtitlesFontSize.SelectedItem = "44";
                mainwindow.cboSubtitlesFontColor.SelectedIndex = 0;
                mainwindow.cboSubtitlesBorderSize.SelectedItem = "2";
                mainwindow.cboSubtitlesBorderColor.SelectedIndex = 2;

                // Stream
                mainwindow.cboCache.SelectedItem = "auto";
                mainwindow.tbxCacheDefault.Text = "100000";
                mainwindow.tbxCacheInitial.Text = "1024";
                mainwindow.tbxCacheSeekMin.Text = "1024";
                mainwindow.tbxCacheBackbuffer.Text = "25000";
                mainwindow.tbxCacheSeconds.Text = "30";
                mainwindow.cboCacheFile.SelectedItem = "TMP";
                mainwindow.tbxCacheFileSize.Text = "1048576";

                // OSD
                mainwindow.cboOSD.SelectedItem = "yes";
                mainwindow.tbxOSDDuration.Text = "1500";
                mainwindow.cboOSDLevel.SelectedItem = "1";
                mainwindow.tbxOSDScale.Text = "0.5";
                mainwindow.cboOSDFontSize.SelectedItem = "44";
                mainwindow.cboOSDFontColor.SelectedIndex = 0;
                mainwindow.cboOSDFontBorderSize.SelectedItem = "2";
                mainwindow.cboOSDFontBorderColor.SelectedIndex = 2;
                mainwindow.cboOSDFractions.SelectedItem = "yes";
            }
        }
    }
}
