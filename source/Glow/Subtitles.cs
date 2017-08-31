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
using System.Windows.Controls;

namespace Glow
{
    public partial class Subtitles
    {
        // Selected Item
        private static ComboBoxItem selectedItem;
        private static string selected;


        /// <summary>
        ///    Subtitle Config
        /// </summary>
        public static String SubtitleConfig(MainWindow mainwindow)
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
            string subtitles = "sub=" + (mainwindow.cboSubtitles.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Languages
            // -------------------------
            List<string> listSubtitlesLanguages = new List<string>();

            // Add Each Language In Priority Order from the top to Audio Languages List
            // Regardless of Order checked in
            foreach (string item in mainwindow.listViewSubtitlesLanguages.Items)
            {
                // If list contains a checked item
                if (mainwindow.listViewSubtitlesLanguages.SelectedItems.Contains(item))
                {
                    // Convert Selected Language (e.g. English) into (eng,en,enUS,en-US)
                    string language = Languages.LanguageCode(item);

                    // Add language code to list
                    listSubtitlesLanguages.Add(language);
                }
            }

            string languages = string.Empty;
            if (listSubtitlesLanguages.Count() != 0)
                languages = "slang=" + string.Join(",", listSubtitlesLanguages.Where(s => !string.IsNullOrEmpty(s)));

            // -------------------------
            // Load Files
            // -------------------------
            string loadFiles = "sub-auto=" + (mainwindow.cboSubtitlesLoadFiles.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Position
            // -------------------------
            string position = "sub-pos=" + mainwindow.tbxSubtitlePosition.Text.ToString();

            // -------------------------
            // Timing
            // -------------------------
            string fixTiming = "sub-fix-timing=" + (mainwindow.cboSubtitlesFixTiming.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Margins
            // -------------------------
            string margins = string.Empty;

            if ((string)(mainwindow.cboSubtitlesMargins.SelectedItem ?? string.Empty) == "yes")
                margins = "sub-use-margins";

            // --------------------------------------------------
            // Blend
            // --------------------------------------------------
            string blend = "blend-subtitles=" + (mainwindow.cboSubtitlesBlend.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Font
            // --------------------------------------------------

            // -------------------------
            // Embedded Fonts
            // -------------------------
            string embeddedFonts = string.Empty;

            // yes
            if ((string)(mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem ?? string.Empty) == "yes")
                embeddedFonts = "embeddedfonts";
            // no
            else if ((string)(mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem ?? string.Empty) == "no")
                embeddedFonts = "no-embeddedfonts";

            // -------------------------
            // Font
            // -------------------------
            string font = string.Empty;

            // only if Embedded Fonts is off
            if ((string)(mainwindow.cboSubtitlesEmbeddedFonts.SelectedItem ?? string.Empty) == "no")
                font = "sub-text-font=" + "\"" + (mainwindow.cboSubtitlesFont.SelectedItem ?? string.Empty).ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = "sub-text-font-size=" + (mainwindow.cboSubtitlesFontSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Font Color
            // -------------------------
            //selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesFontColor.SelectedValue ?? string.Empty);
            //string fontColor = "sub-text-color=" + "\"" + "#FF" + ColorConverter.HexColor(selectedItem) + "\"";
            string fontColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxSubtitlesFontColor.Text))
                fontColor = "sub-text-color=" + "\"" + "#FF" + mainwindow.tbxSubtitlesFontColor.Text + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = "sub-text-border-size=" + (mainwindow.cboSubtitlesBorderSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Border Color
            // -------------------------
            //selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesBorderColor.SelectedValue ?? string.Empty);
            //string borderColor = "sub-text-border-color=" + "\"" + "#FF" + ColorConverter.HexColor(selectedItem) + "\"";
            string borderColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxSubtitlesBorderColor.Text))
                borderColor = "sub-text-border-color=" + "\"" + "#FF" + mainwindow.tbxSubtitlesBorderColor.Text + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            string shadowColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxSubtitlesShadowColor.Text))
                shadowColor = "sub-text-shadow-color=" + "\"" + "#33" + mainwindow.tbxSubtitlesShadowColor.Text + "\"";
            //selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesShadowColor.SelectedValue ?? string.Empty);
            //selected = (string)(selectedItem.Content);

            //string shadowColor = string.Empty;

            //if (selected != "None")
            //{
            //    shadowColor = "sub-text-shadow-color=" + "\"" + "#33" + ColorConverter.HexColor(selectedItem) + "\"";
            //}


            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowOffset = string.Empty;

            // only if shadow color is on
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxSubtitlesShadowColor.Text))
                shadowOffset = "sub-shadow-offset=" + mainwindow.tbxSubtitlesShadowOffset.Text.ToString();


            // --------------------------------------------------
            // ASS Advanced SSA
            // --------------------------------------------------

            // -------------------------
            // ASS
            // -------------------------
            string ass = string.Empty;
            
            if ((string)(mainwindow.cboSubtitlesASS.SelectedItem ?? string.Empty) == "yes")
                ass = "sub-ass";
            else if ((string)(mainwindow.cboSubtitlesASS.SelectedItem ?? string.Empty) == "no")
                ass = "no-sub-ass";

            // -------------------------
            // ASS Override
            // -------------------------
            string assOverride = "sub-ass-override=" + (mainwindow.cboSubtitlesASSOverride.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // ASS Force Margins
            // -------------------------
            string assForceMargins = "sub-ass-force-margins=" + (mainwindow.cboSubtitlesASSForceMargins.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // ASS Hinting
            // -------------------------
            string assHinting = "sub-ass-hinting=" + (mainwindow.cboSubtitlesASSHinting.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // ASS Kerning
            // -------------------------
            string assKerning = "sub-ass-force-style=Kerning=" + (mainwindow.cboSubtitlesASSKerning.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listSubtitle = new List<string>()
            {
                title,
                languages,
                subtitles,
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
            string subtitle = string.Join("\r\n", listSubtitle
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return subtitle;
        }

    }
}
