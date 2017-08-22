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
using System.Windows;

namespace Glow
{
    public partial class Video
    {
        /// <summary>
        ///    Video Config
        /// </summary>
        public static String VideoConfig(MainWindow mainwindow)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "# [ VIDEO ]";

            // --------------------------------------------------
            // Hardware
            // --------------------------------------------------

            // -------------------------
            // Video Driver
            // -------------------------
            string driver = "vo=" + mainwindow.cboVideoDriver.SelectedItem.ToString();

            // special rule
            if ((string)mainwindow.cboVideoDriver.SelectedItem == "opengl-hq")
                driver = "profile=opengl-hq";

            // -------------------------
            // OpenGL PBO
            // -------------------------
            string openglpbo = string.Empty;

            // only if on
            if ((string)mainwindow.cboOpenGLPBO.SelectedItem == "on")
                openglpbo = "opengl-pbo";

            // -------------------------
            // Hardware Decoder
            // -------------------------
            string hwdec = "hwdec=" + mainwindow.cboHWDecoder.SelectedItem.ToString();

            // --------------------------------------------------
            // Display
            // --------------------------------------------------

            // -------------------------
            // Primaries
            // -------------------------
            string displayPrimaries = "target-prim=" + mainwindow.cboDisplayPrimaries.SelectedItem.ToString();

            // -------------------------
            // Transfer Characteristics
            // -------------------------
            string displayTransChar = "target-trc=" + mainwindow.cboTransferCharacteristics.SelectedItem.ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorspace = "format=colormatrix=" + mainwindow.cboColorSpace.SelectedItem.ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorrange = "video-output-levels=" + mainwindow.cboColorRange.SelectedItem.ToString();

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


            // --------------------------------------------------
            // Image
            // --------------------------------------------------

            // -------------------------
            // Brightness
            // -------------------------
            string brightness = string.Empty;

            // only if not 0
            if (mainwindow.tbxBrightness.Text != "0")
                brightness = "brightness=" + mainwindow.tbxBrightness.Text.ToString();

            // -------------------------
            // Contrast
            // -------------------------
            string contrast = string.Empty;

            // only if not 0
            if (mainwindow.tbxContrast.Text != "0")
                contrast = "contrast=" + mainwindow.tbxContrast.Text.ToString();

            // -------------------------
            // Hue
            // -------------------------
            string hue = string.Empty;

            // only if not 0
            if (mainwindow.tbxHue.Text != "0")
                hue = "hue=" + mainwindow.tbxHue.Text.ToString();

            // -------------------------
            // Saturation
            // -------------------------
            string saturation = string.Empty;

            // only if not 0
            if (mainwindow.tbxSaturation.Text != "0")
                saturation = "saturation=" + mainwindow.tbxSaturation.Text.ToString();

            // -------------------------
            // Gamma
            // -------------------------
            string gamma = string.Empty;

            // only if not 0
            if (mainwindow.tbxGamma.Text != "0")
                gamma = "gamma=" + mainwindow.tbxGamma.Text.ToString();

            // auto
            if ((string)mainwindow.cboGammaAuto.SelectedItem == "on")
                gamma = "gamma-auto";

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
            // Dither
            // -------------------------
            string dither = "dither-depth=" + mainwindow.cboDither.SelectedItem.ToString();


            // --------------------------------------------------
            // Scaling
            // --------------------------------------------------

            // -------------------------
            // Resize Only
            // -------------------------
            // always on
            string scalerResizeOnly = "scaler-resizes-only";

            // -------------------------
            // Sigmoid Upscaling
            // -------------------------
            string sigmoidUpscaling = string.Empty;

            if ((string)mainwindow.cboSigmoid.SelectedItem == "on")

                sigmoidUpscaling = "sigmoid-upscaling";

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


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listVideo = new List<string>()
            {
                title,

                // Hardware
                driver,
                openglpbo,
                hwdec,

                // Display
                displayPrimaries,
                displayTransChar,
                colorspace,
                colorrange,
                deinterlace,
                videosync,
                framedrop,

                // Image
                brightness,
                contrast,
                hue,
                saturation,
                gamma,
                deband,
                debandgrain,
                dither,

                // Scaling
                scalerResizeOnly,
                sigmoidUpscaling,
                scale,
                scaleAntiring,
                chromascale,
                chromascaleAntiring,
                downscale,
                downscaleAntiring,
                softwarescaler,
            };

            // -------------------------
            // Join
            // -------------------------
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
