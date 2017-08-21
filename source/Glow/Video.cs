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

            if ((string)mainwindow.cboVideoDriver.SelectedItem == "opengl-hq")
                driver = "profile=opengl-hq"; // special rule

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

            if ((string)mainwindow.cboGamma.SelectedItem == "auto")
                gamma = "gamma-auto"; // special rule

            // -------------------------
            // Scale
            // -------------------------
            string scale = "scale=" + mainwindow.cboScale.SelectedItem.ToString();

            // Antiring
            if (mainwindow.cboAntiring.SelectedItem.ToString() == "yes")
                scale = scale + ":scale-antiring=1";

            // -------------------------
            // Chroma Scale
            // -------------------------
            string chromascale = "cscale=" + mainwindow.cboChromaScale.SelectedItem.ToString();

            // Antiring
            if (mainwindow.cboAntiring.SelectedItem.ToString() == "yes")
                chromascale = chromascale + ":scale-antiring=1";

            // -------------------------
            // Downscale
            // -------------------------
            string downscale = "dscale=" + mainwindow.cboDownscale.SelectedItem.ToString();

            // Antiring
            if (mainwindow.cboAntiring.SelectedItem.ToString() == "yes")
                downscale = downscale + ":scale-antiring=1";

            // -------------------------
            // Dither
            // -------------------------
            string dither = "dither-depth=" + mainwindow.cboDither.SelectedItem.ToString();

            // -------------------------
            // Deband
            // -------------------------
            string deband = string.Empty;

            if ((string)mainwindow.cboDeband.SelectedItem == "yes")
                deband = "deband"; // special rule

            // -------------------------
            // Deband Grain
            // -------------------------
            // only use if deband is on
            // and deband grain is not empty

            string debandgrain = string.Empty;

            if ((string)mainwindow.cboDeband.SelectedItem == "yes"
                && !string.IsNullOrWhiteSpace(mainwindow.tbxDebandGrain.Text))
                debandgrain = "deband-grain=" + mainwindow.tbxDebandGrain.Text.ToString();

            // -------------------------
            // Deinterlace
            // -------------------------
            string deinterlace = "deinterlace=" + mainwindow.cboDeinterlace.SelectedItem.ToString();

            // -------------------------
            // Video Sync
            // -------------------------
            // only if video sync is on

            string videosync = string.Empty;

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
                colorspace,
                colorrange,
                gamma,
                scale,
                chromascale,
                downscale,
                dither,
                deband,
                debandgrain,
                videosync,
                framedrop,
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
