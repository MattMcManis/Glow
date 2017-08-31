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
            string title = "## VIDEO ##";

            // --------------------------------------------------
            // Hardware
            // --------------------------------------------------

            // -------------------------
            // Video Driver
            // -------------------------
            string driver = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboVideoDriver.SelectedItem ?? string.Empty) != "default")
                driver = "vo=" + (mainwindow.cboVideoDriver.SelectedItem ?? string.Empty).ToString();
                //string driver = "vo=" + (ViewModel.VideoDriverSelectedItem ?? string.Empty);

            // opengl-hq special rule
            if ((string)(mainwindow.cboVideoDriver.SelectedItem ?? string.Empty) == "opengl-hq")
                driver = "profile=opengl-hq";

            // -------------------------
            // OpenGL PBO
            // -------------------------
            string openglPBO = string.Empty;

            // only if on
            if ((string)(mainwindow.cboOpenGLPBO.SelectedItem ?? string.Empty) == "yes")
                openglPBO = "opengl-pbo";

            // -------------------------
            // OpenGL PBO Formats
            // -------------------------
            string openglPBOFormat = string.Empty;

            // only if on
            // only if OpenGL PBO yes
            if ((string)(mainwindow.cboOpenGLPBOFormat.SelectedItem ?? string.Empty) != "off"
                && (string)(mainwindow.cboOpenGLPBO.SelectedItem ?? string.Empty) == "yes")
                openglPBOFormat = "opengl-fbo-format=" + (mainwindow.cboOpenGLPBOFormat.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Hardware Decoder
            // -------------------------
            string hwdec = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboHWDecoder.SelectedItem ?? string.Empty) != "default")
                hwdec = "hwdec=" + (mainwindow.cboHWDecoder.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Display
            // --------------------------------------------------

            // -------------------------
            // Primaries
            // -------------------------
            string displayPrimaries = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboDisplayPrimaries.SelectedItem ?? string.Empty) != "default")
                displayPrimaries = "target-prim=" + (mainwindow.cboDisplayPrimaries.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Transfer Characteristics
            // -------------------------
            string displayTransChar = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboTransferCharacteristics.SelectedItem ?? string.Empty) != "default")
                displayTransChar = "target-trc=" + (mainwindow.cboTransferCharacteristics.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorSpace = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboColorSpace.SelectedItem ?? string.Empty) != "default")
                colorSpace = "format=colormatrix=" + (mainwindow.cboColorSpace.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Color Space
            // -------------------------
            string colorRange = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboColorRange.SelectedItem ?? string.Empty) != "default")
                colorRange = "video-output-levels=" + (mainwindow.cboColorRange.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Deinterlace
            // -------------------------
            string deinterlace = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboDeinterlace.SelectedItem ?? string.Empty) != "default")
                deinterlace = "deinterlace=" + (mainwindow.cboDeinterlace.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Video Sync
            // -------------------------          
            string videosync = string.Empty;

            // only if video sync is on
            if ((string)(mainwindow.cboVideoSync.SelectedItem ?? string.Empty) != "default" 
                    && (string)(mainwindow.cboVideoSync.SelectedItem ?? string.Empty) != "off")
                videosync = "video-sync=" + (mainwindow.cboVideoSync.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Framedrop
            // -------------------------
            string framedrop = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboFramedrop.SelectedItem ?? string.Empty) != "default")
                framedrop = "framedrop=" + (mainwindow.cboFramedrop.SelectedItem ?? string.Empty).ToString();


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
            if ((string)(mainwindow.cboGammaAuto.SelectedItem ?? string.Empty) == "yes")
                gamma = "gamma-auto";

            // -------------------------
            // Deband
            // -------------------------
            string deband = string.Empty;

            if ((string)(mainwindow.cboDeband.SelectedItem ?? string.Empty) == "yes")
                deband = "deband";

            // -------------------------
            // Deband Grain
            // -------------------------
            string debandgrain = string.Empty;

            // only use if deband is on
            // and deband grain is not empty
            if ((string)(mainwindow.cboDeband.SelectedItem ?? string.Empty) == "yes" && !string.IsNullOrWhiteSpace(mainwindow.tbxDebandGrain.Text))
                debandgrain = "deband-grain=" + mainwindow.tbxDebandGrain.Text.ToString();

            // -------------------------
            // Dither
            // -------------------------
            string dither = string.Empty;

            // only if enabled
            if ((string)(mainwindow.cboDither.SelectedItem ?? string.Empty) != "default")
                dither = "dither-depth=" + (mainwindow.cboDither.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Scaling
            // --------------------------------------------------

            // -------------------------
            // Resize Only
            // -------------------------
            string scalerResizeOnly = string.Empty;

            // only if scalers are not default
            if ((string)(mainwindow.cboScale.SelectedItem ?? string.Empty) != "default"
                && (string)(mainwindow.cboChromaScale.SelectedItem ?? string.Empty) != "default"
                && (string)(mainwindow.cboDownscale.SelectedItem ?? string.Empty) != "default"
                && (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) != "default")

                // else always on
                scalerResizeOnly = "scaler-resizes-only";

            // -------------------------
            // Sigmoid Upscaling
            // -------------------------
            string sigmoidUpscaling = string.Empty;

            if ((string)(mainwindow.cboSigmoid.SelectedItem ?? string.Empty) == "yes")

                sigmoidUpscaling = "sigmoid-upscaling";

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            // software scaler must be default or off
            // scale must be on
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboScale.SelectedItem ?? string.Empty) != "default"
                    && (string)(mainwindow.cboScale.SelectedItem ?? string.Empty) != "off" ) 

                    scale = "scale=" + (mainwindow.cboScale.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Scale Antiring
            // -------------------------
            string scaleAntiring = string.Empty;

            // software scaler must be default or off
            // scale must be on
            // antitring must be above 0
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboScale.SelectedItem ?? string.Empty) != "off"
                    && mainwindow.slScaleAntiring.Value != 0)

                    scaleAntiring = "scale-antiring=" + mainwindow.tbxScaleAntiring.Text.ToString();

            // -------------------------
            // Chroma Scale
            // -------------------------
            string chromascale = string.Empty;

            // software scaler must be default or off
            // must not be default
            // chrome scale must be on
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboChromaScale.SelectedItem ?? string.Empty) != "default"
                    && (string)(mainwindow.cboChromaScale.SelectedItem ?? string.Empty) != "off")

                    chromascale = "cscale=" + (mainwindow.cboChromaScale.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Chroma Antiring
            // -------------------------
            // software scaler must be default or off
            // chrome scale must be on
            // antitring must be above 0
            string chromascaleAntiring = string.Empty;

            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboChromaScale.SelectedItem ?? string.Empty) != "off"
                    && mainwindow.slChromaAntiring.Value != 0)

                    chromascaleAntiring = "cscale-antiring=" + mainwindow.tbxChromaAntiring.Text.ToString();

            // -------------------------
            // Downscale
            // -------------------------
            string downscale = string.Empty;

            // software scaler must be default or off
            // must not be default
            // downscale must be on
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboDownscale.SelectedItem ?? string.Empty) != "default"
                    && (string)(mainwindow.cboDownscale.SelectedItem ?? string.Empty) != "off")

                    downscale = "dscale=" + (mainwindow.cboDownscale.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Downscale Antiring
            // -------------------------
            string downscaleAntiring = string.Empty;

            // software scaler must be default or off
            // downscale must be on
            // antitring must be above 0
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "default"
                || (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) == "off")

                if ((string)(mainwindow.cboDownscale.SelectedItem ?? string.Empty) != "off"
                    && mainwindow.slDownscaleAntiring.Value != 0)

                    downscaleAntiring = "dscale-antiring=" + mainwindow.tbxDownscaleAntiring.Text.ToString();

            // -------------------------
            // Software Scaler
            // -------------------------
            string softwarescaler = string.Empty;

            // must not be default of off
            if ((string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) != "default"
                && (string)(mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty) != "off")

                softwarescaler = "sws-scaler=" + (mainwindow.cboSoftwareScaler.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listVideo = new List<string>()
            {
                title,

                // Hardware
                driver,
                openglPBO,
                openglPBOFormat,
                hwdec,

                // Display
                displayPrimaries,
                displayTransChar,
                colorSpace,
                colorRange,
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
