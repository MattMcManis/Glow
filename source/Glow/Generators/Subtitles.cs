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
using System.Windows.Controls;
using ViewModel;

namespace Generate
{
    public class Subtitles
    {
        /// <summary>
        ///    Subtitle Config
        /// </summary>
        public static String Config()
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "## SUBTITLES ##";

            // -------------------------
            // Subtitles
            // -------------------------
            //string subtitles = string.Empty;

            //if (VM.SubtitlesView.Subtitles_SelectedItem != "default")
            //    subtitles = "sub";

            // -------------------------
            // Languages
            // -------------------------
            List<string> listSubtitleLanguages = new List<string>();

            // Add Each Language In Priority Order from the top to Audio Languages List
            // Regardless of Order checked in
            foreach (string item in VM.SubtitlesView.LanguagePriority_ListView_Items)
            {
                // If list contains a checked item
                if (VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Contains(item))
                {
                    // Add language code to list
                    listSubtitleLanguages.Add(Languages.LanguageCode(item));
                }
            }

            string languages = string.Empty;
            if (listSubtitleLanguages != null && listSubtitleLanguages.Count > 0)
                languages = "slang=" + string.Join(",", listSubtitleLanguages.Where(s => !string.IsNullOrEmpty(s)));

            // -------------------------
            // Load Files
            // -------------------------
            string loadFiles = string.Empty;

            if (VM.SubtitlesView.LoadFiles_SelectedItem != "default")
                loadFiles = "sub-auto=" + VM.SubtitlesView.LoadFiles_SelectedItem;

            // -------------------------
            // Position
            // -------------------------
            string position = string.Empty;

            if (VM.SubtitlesView.Position_Value != 0.0)
                position = "sub-pos=" + VM.SubtitlesView.Position_Value;

            // -------------------------
            // Timing
            // -------------------------
            string fixTiming = string.Empty;

            if (VM.SubtitlesView.FixTiming_SelectedItem != "default")
                fixTiming = "sub-fix-timing=" + VM.SubtitlesView.FixTiming_SelectedItem;

            // -------------------------
            // Margins
            // -------------------------
            string margins = string.Empty;

            if (VM.SubtitlesView.Margins_SelectedItem != "default" &&
                VM.SubtitlesView.Margins_SelectedItem == "yes")
                margins = "sub-use-margins";

            // -------------------------
            // Blend
            // -------------------------
            string blend = string.Empty;

            if (VM.SubtitlesView.Blend_SelectedItem != "default")

                blend = "blend-subtitles=" + VM.SubtitlesView.Blend_SelectedItem;


            // --------------------------------------------------
            // ASS Advanced SSA
            // --------------------------------------------------

            // -------------------------
            // ASS
            // -------------------------
            string ass = string.Empty;

            if (VM.SubtitlesView.ASS_SelectedItem == "yes")
                ass = "sub-ass";
            else if (VM.SubtitlesView.ASS_SelectedItem == "no")
                ass = "no-sub-ass";

            // -------------------------
            // ASS Override
            // -------------------------
            string assOverride = string.Empty;

            if (VM.SubtitlesView.ASSOverride_SelectedItem != "default")
                assOverride = "sub-ass-override=" + VM.SubtitlesView.ASSOverride_SelectedItem;

            // -------------------------
            // ASS Force Margins
            // -------------------------
            string assForceMargins = string.Empty;

            if (VM.SubtitlesView.ASSForceMargins_SelectedItem != "default")
                assForceMargins = "sub-ass-force-margins=" + VM.SubtitlesView.ASSForceMargins_SelectedItem;

            // -------------------------
            // ASS Hinting
            // -------------------------
            string assHinting = string.Empty;

            if (VM.SubtitlesView.ASSHinting_SelectedItem != "default")
                assHinting = "sub-ass-hinting=" + VM.SubtitlesView.ASSHinting_SelectedItem;

            // -------------------------
            // ASS Kerning
            // -------------------------
            string assKerning = string.Empty;

            if (VM.SubtitlesView.ASSKerning_SelectedItem != "default")
                assKerning = "sub-ass-force-style=Kerning=" + VM.SubtitlesView.ASSKerning_SelectedItem;


            // --------------------------------------------------
            // Font
            // --------------------------------------------------

            // -------------------------
            // Embedded Fonts
            // -------------------------
            string embeddedFonts = string.Empty;

            // yes
            if (VM.SubtitlesView.EmbeddedFonts_SelectedItem == "yes")
                embeddedFonts = "embeddedfonts";
            // no
            else if (VM.SubtitlesView.EmbeddedFonts_SelectedItem == "no")
                embeddedFonts = "no-embeddedfonts";

            // -------------------------
            // Font
            // -------------------------
            string font = string.Empty;

            // only if Embedded Fonts is off
            // and font is not default
            if (VM.SubtitlesView.EmbeddedFonts_SelectedItem == "no"
                && VM.SubtitlesView.Font_SelectedItem != "default")
                font = "sub-font=" + "\"" + VM.SubtitlesView.Font_SelectedItem + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = string.Empty;

            if (VM.SubtitlesView.FontSize_SelectedItem != "default")
                fontSize = "sub-font-size=" + VM.SubtitlesView.FontSize_SelectedItem;

            // -------------------------
            // Font Color
            // -------------------------
            string fontColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(VM.SubtitlesView.FontColor_Text))
                fontColor = "sub-color=" + "\"" + "#FF" + VM.SubtitlesView.FontColor_Text + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = string.Empty;

            if (VM.SubtitlesView.BorderSize_SelectedItem != "default")
                borderSize = "sub-border-size=" + VM.SubtitlesView.BorderSize_SelectedItem;

            // -------------------------
            // Border Color
            // -------------------------
            string borderColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(VM.SubtitlesView.BorderColor_Text))
                borderColor = "sub-border-color=" + "\"" + "#FF" + VM.SubtitlesView.BorderColor_Text + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            string shadowColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(VM.SubtitlesView.ShadowColor_Text))
                shadowColor = "sub-shadow-color=" + "\"" + "#33" + VM.SubtitlesView.ShadowColor_Text + "\"";

            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowOffset = string.Empty;

            if (VM.SubtitlesView.ShadowOffset_Value != 0)
                shadowOffset = "sub-shadow-offset=" + VM.SubtitlesView.ShadowOffset_Value
                                                      .ToString("0.##", CultureInfo.GetCultureInfo("en-US"));



            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listSubtitle = new List<string>()
            {
                title,
                languages,
                //subtitles,
                loadFiles,
                position,
                fixTiming,
                margins,
                blend,

                // Font
                embeddedFonts,
                font,
                fontSize,
                fontColor,
                borderSize,
                borderColor,
                shadowColor,
                shadowOffset,

                // ASS
                ass,
                assOverride,
                assForceMargins,
                assHinting,
                assKerning,
            };

            // -------------------------
            // Join
            // -------------------------
            return string.Join("\r\n", listSubtitle
                                       .Where(s => !string.IsNullOrEmpty(s))
                              );
        }

    }
}
