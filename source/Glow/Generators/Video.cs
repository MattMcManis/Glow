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
using Glow;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ViewModel;

namespace Generate
{
    public class Video
    {
        /// <summary>
        ///    Video Config
        /// </summary>
        public static IEnumerable<string> Config()
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Heading
            // -------------------------
            string heading = "## VIDEO ##";

            // --------------------------------------------------
            // Hardware
            // --------------------------------------------------

            // -------------------------
            // Video Driver
            // -------------------------
            string driver = string.Empty;

            // only if enabled
            if (VM.VideoView.VideoDriver_SelectedItem != "default" && 
                VM.VideoView.VideoDriver_SelectedItem != "gpu-hq")
                driver = "vo=" + VM.VideoView.VideoDriver_SelectedItem;

            // opengl-hq special rule
            if (VM.VideoView.VideoDriver_SelectedItem == "gpu-hq")
                driver = "profile=gpu-hq";

            // -------------------------
            // Video Driver API
            // -------------------------
            string driverAPI = string.Empty;

            // only if enabled
            if (VM.VideoView.VideoDriverAPI_SelectedItem != "default")
                driverAPI = "gpu-api=" + VM.VideoView.VideoDriverAPI_SelectedItem;

            // -------------------------
            // OpenGL PBO
            // -------------------------
            string openglPBO = string.Empty;

            // only if on
            if (VM.VideoView.OpenGLPBO_SelectedItem == "yes")
                openglPBO = "opengl-pbo";

            // -------------------------
            // OpenGL PBO Formats
            // -------------------------
            string openglPBOFormat = string.Empty;

            // only if on
            // only if OpenGL PBO yes
            if (VM.VideoView.OpenGLPBOFormat_SelectedItem != "default" &&
                VM.VideoView.OpenGLPBOFormat_SelectedItem != "off" &&
                VM.VideoView.OpenGLPBO_SelectedItem == "yes")

                openglPBOFormat = /*"opengl-fbo-format="*/ "fbo-format=" + VM.VideoView.OpenGLPBOFormat_SelectedItem;

            // -------------------------
            // Hardware Decoder
            // -------------------------
            string hwdec = string.Empty;

            // only if enabled
            if (VM.VideoView.HWDecoder_SelectedItem != "default")
                hwdec = "hwdec=" + VM.VideoView.HWDecoder_SelectedItem;


            // --------------------------------------------------
            // Display
            // --------------------------------------------------

            // -------------------------
            // ICC Profile Path
            // -------------------------
            string iccProfile = string.Empty;

            // auto
            if (VM.VideoView.ICCProfile_SelectedItem == "auto")
                iccProfile = "icc-profile-auto";
            // Select
            else if (VM.VideoView.ICCProfile_IsEditable)
                iccProfile = "icc-profile=" + "\"" + VM.VideoView.ICCProfile_SelectedItem + "\"";
            //string ICCProfilePath = string.Empty;
            //// only if not empty
            //if (!string.IsNullOrWhiteSpace(VM.VideoView.ICCProfilePath_Text))
            //    ICCProfilePath = "icc-profile=" + "\"" + VM.VideoView.ICCProfilePath_Text + "\"";

            // -------------------------
            // Primaries
            // -------------------------
            string displayPrimaries = string.Empty;

            // only if enabled
            if (VM.VideoView.DisplayPrimaries_SelectedItem != "default")
                displayPrimaries = "target-prim=" + VM.VideoView.DisplayPrimaries_SelectedItem;

            // -------------------------
            // Transfer Characteristics
            // -------------------------
            string displayTransChar = string.Empty;

            // only if enabled
            if (VM.VideoView.TransferCharacteristics_SelectedItem != "default")
                displayTransChar = "target-trc=" + VM.VideoView.TransferCharacteristics_SelectedItem;

            // -------------------------
            // Color Space
            // -------------------------
            string colorSpace = string.Empty;

            // only if enabled
            if (VM.VideoView.ColorSpace_SelectedItem != "default")
                colorSpace = "format=default:colormatrix=" + VM.VideoView.ColorSpace_SelectedItem;

            // -------------------------
            // Color Range
            // -------------------------
            string colorRange = string.Empty;

            // only if enabled
            if (VM.VideoView.ColorRange_SelectedItem != "default")
                colorRange = "video-output-levels=" + VM.VideoView.ColorRange_SelectedItem;

            // -------------------------
            // Deinterlace
            // -------------------------
            string deinterlace = string.Empty;

            // only if enabled
            if (VM.VideoView.Deinterlace_SelectedItem != "default")
                deinterlace = "deinterlace=" + VM.VideoView.Deinterlace_SelectedItem;

            // -------------------------
            // Interpolation
            // -------------------------
            string interpolation = string.Empty;

            // only if enabled
            if (VM.VideoView.Interpolation_SelectedItem == "yes")
                interpolation = "interpolation";

            // -------------------------
            // Video Sync
            // -------------------------          
            string videosync = string.Empty;

            // only if video sync is on
            if (VM.VideoView.VideoSync_SelectedItem != "default" &&
                VM.VideoView.VideoSync_SelectedItem != "off")
                videosync = "video-sync=" + VM.VideoView.VideoSync_SelectedItem;

            // -------------------------
            // Framedrop
            // -------------------------
            string framedrop = string.Empty;

            // only if enabled
            if (VM.VideoView.Framedrop_SelectedItem != "default")
                framedrop = "framedrop=" + VM.VideoView.Framedrop_SelectedItem;


            // --------------------------------------------------
            // Image
            // --------------------------------------------------

            // -------------------------
            // Brightness
            // -------------------------
            string brightness = string.Empty;

            // only if not 0
            if (VM.VideoView.Brightness_Value != 0)
                brightness = "brightness=" + VM.VideoView.Brightness_Value;

            // -------------------------
            // Contrast
            // -------------------------
            string contrast = string.Empty;

            // only if not 0
            if (VM.VideoView.Contrast_Value != 0)
                contrast = "contrast=" + VM.VideoView.Contrast_Value;

            // -------------------------
            // Hue
            // -------------------------
            string hue = string.Empty;

            // only if not 0
            if (VM.VideoView.Hue_Value != 0)
                hue = "hue=" + VM.VideoView.Hue_Value;

            // -------------------------
            // Saturation
            // -------------------------
            string saturation = string.Empty;

            // only if not 0
            if (VM.VideoView.Saturation_Value != 0)
                saturation = "saturation=" + VM.VideoView.Saturation_Value;

            // -------------------------
            // Gamma
            // -------------------------
            string gamma = string.Empty;

            // only if not 0
            if (VM.VideoView.Gamma_Value != 0)
                gamma = "gamma=" + VM.VideoView.Gamma_Value;

            // auto
            //if (VM.VideoView.GammaAuto_SelectedItem == "yes")
            //    gamma = "gamma-auto";

            // -------------------------
            // Deband
            // -------------------------
            string deband = string.Empty;

            if (VM.VideoView.Deband_SelectedItem == "yes")
                deband = "deband";

            // -------------------------
            // Deband Grain
            // -------------------------
            string debandgrain = string.Empty;

            // only use if deband is on
            // and deband grain is not empty
            if (VM.VideoView.Deband_SelectedItem == "yes" 
                && !string.IsNullOrWhiteSpace(VM.VideoView.DebandGrain_Text))
                debandgrain = "deband-grain=" + VM.VideoView.DebandGrain_Text;

            // -------------------------
            // Dither
            // -------------------------
            string dither = string.Empty;

            // only if enabled
            if (VM.VideoView.Dither_SelectedItem != "default")
                dither = "dither-depth=" + VM.VideoView.Dither_SelectedItem;


            // --------------------------------------------------
            // Scaling
            // --------------------------------------------------

            // -------------------------
            // Resize Only
            // -------------------------
            string scalerResizeOnly = string.Empty;

            // only if scalers are not default
            if (VM.VideoView.Scale_SelectedItem != "default" &&
                VM.VideoView.ChromaScale_SelectedItem != "default" &&
                VM.VideoView.Downscale_SelectedItem != "default" &&
                VM.VideoView.SoftwareScaler_SelectedItem != "default")

                // else always on
                scalerResizeOnly = "scaler-resizes-only";

            // -------------------------
            // Sigmoid Upscaling
            // -------------------------
            string sigmoidUpscaling = string.Empty;

            if (VM.VideoView.Sigmoid_SelectedItem == "yes")
                sigmoidUpscaling = "sigmoid-upscaling";

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            // software scaler must be default or off
            // scale must be on
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.Scale_SelectedItem != "default"
                    && VM.VideoView.Scale_SelectedItem != "off" ) 

                    scale = "scale=" + VM.VideoView.Scale_SelectedItem;

            // -------------------------
            // Scale Antiring
            // -------------------------
            string scaleAntiring = string.Empty;

            // software scaler must be default or off
            // scale must be on
            // antitring must be above 0
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.Scale_SelectedItem != "default" &&
                    VM.VideoView.Scale_SelectedItem != "off" &&
                    VM.VideoView.ScaleAntiring_Value != 0)

                    scaleAntiring = "scale-antiring=" + VM.VideoView.ScaleAntiring_Value
                                                        .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Chroma Scale
            // -------------------------
            string chromascale = string.Empty;

            // software scaler must be default or off
            // must not be default
            // chrome scale must be on
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.ChromaScale_SelectedItem != "default" &&
                    VM.VideoView.ChromaScale_SelectedItem != "off")

                    chromascale = "cscale=" + VM.VideoView.ChromaScale_SelectedItem;

            // -------------------------
            // Chroma Antiring
            // -------------------------
            // software scaler must be default or off
            // chrome scale must be on
            // antitring must be above 0
            string chromascaleAntiring = string.Empty;

            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.ChromaScale_SelectedItem != "default" &&
                    VM.VideoView.ChromaScale_SelectedItem != "off" &&
                    VM.VideoView.ChromaAntiring_Value != 0)

                    chromascaleAntiring = "cscale-antiring=" + VM.VideoView.ChromaAntiring_Value
                                                               .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Downscale
            // -------------------------
            string downscale = string.Empty;

            // software scaler must be default or off
            // must not be default
            // downscale must be on
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.Downscale_SelectedItem != "default" &&
                    VM.VideoView.Downscale_SelectedItem != "off")

                    downscale = "dscale=" + VM.VideoView.Downscale_SelectedItem;

            // -------------------------
            // Downscale Antiring
            // -------------------------
            string downscaleAntiring = string.Empty;

            // software scaler must be default or off
            // downscale must be on
            // antitring must be above 0
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.Downscale_SelectedItem != "default" &&
                    VM.VideoView.Downscale_SelectedItem != "off" &&
                    VM.VideoView.DownscaleAntiring_Value != 0)

                    downscaleAntiring = "dscale-antiring=" + VM.VideoView.DownscaleAntiring_Value
                                                             .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Inerpolation Scale
            // -------------------------
            string tscale = string.Empty;

            // software scaler must be default or off
            // must not be default
            // inerpolation acale must be on
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                VM.VideoView.SoftwareScaler_SelectedItem == "off")

                if (VM.VideoView.InterpolationScale_SelectedItem != "default" &&
                    VM.VideoView.InterpolationScale_SelectedItem != "off")

                    tscale = "tscale=" + VM.VideoView.InterpolationScale_SelectedItem;

            // -------------------------
            // Inerpolation Antiring
            // -------------------------
            string tscaleAntiring = string.Empty;

            // software scaler must be default or off
            // downscale must be on
            // antitring must be above 0
            if ((VM.VideoView.SoftwareScaler_SelectedItem == "default" ||
                 VM.VideoView.SoftwareScaler_SelectedItem == "off")

                &&

                (VM.VideoView.InterpolationScale_SelectedItem != "default" &&
                 VM.VideoView.InterpolationScale_SelectedItem != "off" &&
                 VM.VideoView.InterpolationScaleAntiring_Value != 0)
                )

                tscaleAntiring = "tscale-antiring=" + VM.VideoView.InterpolationScaleAntiring_Value
                                                        .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Software Scaler
            // -------------------------
            string softwarescaler = string.Empty;

            // must not be default of off
            if (VM.VideoView.SoftwareScaler_SelectedItem != "default" &&
                VM.VideoView.SoftwareScaler_SelectedItem != "off")

                softwarescaler = "sws-scaler=" + VM.VideoView.SoftwareScaler_SelectedItem;


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            return new List<string>()
            {
                heading,

                // Hardware
                driver,
                driverAPI,
                openglPBO,
                openglPBOFormat,
                hwdec,

                // Display
                //ICCProfilePath,
                iccProfile,
                displayPrimaries,
                displayTransChar,
                colorSpace,
                colorRange,
                deinterlace,
                interpolation,
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
                tscale,
                tscaleAntiring,
                softwarescaler,
            };
        }
    }
}
