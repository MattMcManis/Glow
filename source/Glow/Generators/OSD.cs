﻿/* ----------------------------------------------------------------------
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
    public class OSD
    {
        /// <summary>
        ///    OSD Config
        /// </summary>
        public static IEnumerable<string> Config()
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // OSD Heading
            // -------------------------
            string osdHeading = "## OSD ##";

            // -------------------------
            // OSD On Screen Display
            // -------------------------
            string videoOSD = string.Empty;

            if (VM.DisplayView.OSD_SelectedItem != "default")
                videoOSD = "video-osd=" + VM.DisplayView.OSD_SelectedItem;

            // -------------------------
            // Fractions
            // -------------------------
            string fractions = string.Empty;

            if (VM.DisplayView.OSD_SelectedItem != "no" &&
                VM.DisplayView.OSD_Fractions_SelectedItem != "default")
                fractions = "osd-fractions=" + VM.DisplayView.OSD_Fractions_SelectedItem;

            // -------------------------
            // Level
            // -------------------------
            string level = string.Empty;

            if (VM.DisplayView.OSD_SelectedItem != "no" &&
                VM.DisplayView.OSD_Level_SelectedItem != "default")
                level = "osd-level=" + VM.DisplayView.OSD_Level_SelectedItem;

            // -------------------------
            // Duration
            // -------------------------
            string duration = string.Empty;

            if (!string.IsNullOrEmpty(VM.DisplayView.OSD_Duration_Text))
                duration = "osd-duration=" + VM.DisplayView.OSD_Duration_Text;


            // --------------------------------------------------
            // Text
            // --------------------------------------------------

            // -------------------------
            // Font Name
            // -------------------------
            string font = string.Empty;

            if (VM.DisplayView.OSD_Font_SelectedItem != "default")
                font = "osd-font=" + "\"" + VM.DisplayView.OSD_Font_SelectedItem + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = string.Empty;

            if (VM.DisplayView.OSD_FontSize_SelectedItem != "default")
                fontSize = "osd-font-size=" + VM.DisplayView.OSD_FontSize_SelectedItem;

            // -------------------------
            // Font Color
            // -------------------------
            string fontColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrEmpty(VM.DisplayView.OSD_FontColor_Text))
                fontColor = "osd-color=" + "\"" + "#FF" + VM.DisplayView.OSD_FontColor_Text + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = string.Empty;

            if (VM.DisplayView.OSD_FontBorderSize_SelectedItem != "default")
                borderSize = "osd-border-size=" + VM.DisplayView.OSD_FontBorderSize_SelectedItem;

            // -------------------------
            // Border Color
            // -------------------------
            string borderColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrEmpty(VM.DisplayView.OSD_BorderColor_Text))
                borderColor = "osd-border-color=" + "\"" + "#FF" + VM.DisplayView.OSD_BorderColor_Text + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            string shadowColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrEmpty(VM.DisplayView.OSD_ShadowColor_Text))
                shadowColor = "osd-shadow-color=" + "\"" + "#33" + VM.DisplayView.OSD_ShadowColor_Text + "\"";


            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowOffset = string.Empty;

            // only if shadow color is on
            if (VM.DisplayView.OSD_ShadowOffset_Value != 0)
                shadowOffset = "osd-shadow-offset=" + VM.DisplayView.OSD_ShadowOffset_Value
                                                      .ToString("0.##", CultureInfo.GetCultureInfo("en-US"));

            // --------------------------------------------------
            // Combine
            // --------------------------------------------------

            return new List<string>()
            {
                // OSD
                osdHeading,
                videoOSD,
                fractions,
                duration,
                level,

                // Text
                font,
                fontSize,
                fontColor,
                borderSize,
                borderColor,
                shadowColor,
                shadowOffset,
            };
        }

    }
}
