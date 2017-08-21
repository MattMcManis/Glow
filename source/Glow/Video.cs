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

namespace Glow
{
    public partial class Video
    {
        /// <summary>
        ///    Video Config
        /// </summary>
        public static String VideoConfig(MainWindow mainwindow)
        {
            // -------------------------
            // Title
            // -------------------------
            string title = "# [ VIDEO ]";

            // -------------------------
            // Video Driver
            // -------------------------
            string driver = "vo=" + mainwindow.cboVideoDriver.SelectedItem.ToString();

            // special rule
            if ((string)mainwindow.cboVideoDriver.SelectedItem == "opengl-hq")
                driver = "profile=opengl-hq";

            // -------------------------
            // Hardware Decoder
            // -------------------------
            string hwdec = "hwdec=" + mainwindow.cboHWDecoder.SelectedItem.ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorspace = "format=colormatrix=" + mainwindow.cboColorSpace.SelectedItem.ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorrange = "video-output-levels=" + mainwindow.cboColorRange.SelectedItem.ToString();

            // -------------------------
            // Gamma
            // -------------------------
            string gamma = "target-trc=" + mainwindow.cboGamma.SelectedItem.ToString();

            // auto
            if ((string)mainwindow.cboGamma.SelectedItem == "auto")
                gamma = "gamma-auto";

            // -------------------------
            // Dither
            // -------------------------
            string dither = "dither-depth=" + mainwindow.cboDither.SelectedItem.ToString();

            // -------------------------
            // Deband
            // -------------------------
            string deband = string.Empty;

            if ((string)mainwindow.cboDeband.SelectedItem == "yes")
                deband = "deband";

            // -------------------------
            // Deband Grain
            // -------------------------
            string debandgrain = string.Empty;

            // only use if deband is on
            // and deband grain is not empty
            if ((string)mainwindow.cboDeband.SelectedItem == "yes" && !string.IsNullOrWhiteSpace(mainwindow.tbxDebandGrain.Text))
                debandgrain = "deband-grain=" + mainwindow.tbxDebandGrain.Text.ToString();

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            // scale must be on
            // software scaler must be off
            if ((string)mainwindow.cboScale.SelectedItem != "off" 
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off") 

                scale = "scale=" + mainwindow.cboScale.SelectedItem.ToString();

            // -------------------------
            // Scale Antiring
            // -------------------------
            string scaleAntiring = string.Empty;

            // scale must be on
            // antitring must be above 0
            // software scaler must be off
            if ((string)mainwindow.cboScale.SelectedItem != "off"
                && mainwindow.slScaleAntiring.Value != 0 
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off")
                scaleAntiring = "scale-antiring=" + mainwindow.tbxScaleAntiring.Text.ToString();

            // -------------------------
            // Chroma Scale
            // -------------------------
            string chromascale = string.Empty;

            // chrome scale must be on
            // software scaler must be off
            if ((string)mainwindow.cboChromaScale.SelectedItem != "off"
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off")

                chromascale = "cscale=" + mainwindow.cboChromaScale.SelectedItem.ToString();

            // -------------------------
            // Chroma Antiring
            // -------------------------
            // chrome scale must be on
            // antitring must be above 0
            // software scaler must be off
            string chromascaleAntiring = string.Empty;

            if ((string)mainwindow.cboChromaScale.SelectedItem != "off"
                && mainwindow.slChromaAntiring.Value != 0 
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off")

                chromascaleAntiring = "cscale-antiring=" + mainwindow.tbxChromaAntiring.Text.ToString();

            // -------------------------
            // Downscale
            // -------------------------
            string downscale = string.Empty;

            // downscale must be on
            // software scaler must be off
            if ((string)mainwindow.cboDownscale.SelectedItem != "off"
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off")

                downscale = "dscale=" + mainwindow.cboDownscale.SelectedItem.ToString();

            // -------------------------
            // Downscale Antiring
            // -------------------------
            string downscaleAntiring = string.Empty;

            // downscale must be on
            // antitring must be above 0
            // software scaler must be off
            if ((string)mainwindow.cboDownscale.SelectedItem != "off"
                && mainwindow.slDownscaleAntiring.Value != 0 
                && (string)mainwindow.cboSoftwareScaler.SelectedItem == "off")
                downscaleAntiring = "dscale-antiring=" + mainwindow.tbxDownscaleAntiring.Text.ToString();

            // -------------------------
            // Software Scaler
            // -------------------------
            string softwarescaler = string.Empty;

            // software scaler must be off
            if ((string)mainwindow.cboSoftwareScaler.SelectedItem != "off")
                softwarescaler = "sws-scaler=" + mainwindow.cboSoftwareScaler.SelectedItem.ToString();

            // -------------------------
            // Deinterlace
            // -------------------------
            string deinterlace = "deinterlace=" + mainwindow.cboDeinterlace.SelectedItem.ToString();

            // -------------------------
            // Video Sync
            // -------------------------          
            string videosync = string.Empty;

            // only if video sync is on
            if ((string)mainwindow.cboVideoSync.SelectedItem != "off")
                videosync = "video-sync=" + mainwindow.cboVideoSync.SelectedItem.ToString();

            // -------------------------
            // Framedrop
            // -------------------------
            string framedrop = "framedrop=" + mainwindow.cboFramedrop.SelectedItem.ToString();

            // -------------------------
            // Combine
            // -------------------------
            List<string> listVideo = new List<string>()
            {
                title,
                driver,
                hwdec,
                deinterlace,
                videosync,
                framedrop,

                colorspace,
                colorrange,
                gamma,
                dither,
                deband,
                debandgrain,

                scale,
                scaleAntiring,
                chromascale,
                chromascaleAntiring,
                downscale,
                downscaleAntiring,
                softwarescaler,
            };

            string video = string.Join("\r\n", listVideo
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return video;
        }
    }
}
