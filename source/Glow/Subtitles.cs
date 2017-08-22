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
            string title = "# [ SUBTITLE ]";

            // -------------------------
            // Subtitles
            // -------------------------
            string subtitles = "sub=" + mainwindow.cboSubtitles.SelectedItem.ToString();

            // -------------------------
            // Languages
            // -------------------------
            List<string> listSubtitlesLanguages = new List<string>();

            // Add Each Language In Priority Order from the top to Audio Languages List
            // Regardless of Order checked in
            foreach (string item in mainwindow.listViewSubtitleLanguages.Items)
            {
                // If list contains a checked item
                if (mainwindow.listViewSubtitleLanguages.SelectedItems.Contains(item))
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
            // Embedded Fonts
            // -------------------------
            string embeddedfonts = "embeddedfonts=no";

            // -------------------------
            // Load Files
            // -------------------------
            string loadfiles = "sub-auto=" + mainwindow.cboSubtitlesLoadFiles.SelectedItem.ToString();

            // -------------------------
            // Position
            // -------------------------
            string position = "sub-pos=" + mainwindow.tbxSubtitlePosition.Text.ToString();

            // -------------------------
            // Timing
            // -------------------------
            string timing = "sub-fix-timing=no";

            // -------------------------
            // Margins
            // -------------------------
            string margins = "sub-use-margins";


            // --------------------------------------------------
            // Font
            // --------------------------------------------------

            // -------------------------
            // Font
            // -------------------------
            string font = "sub-text-font=" + "\"" + mainwindow.cboSubtitlesFont.SelectedItem.ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontsize = "sub-text-font-size=" + mainwindow.cboSubtitlesFontSize.SelectedItem.ToString();

            // -------------------------
            // Font Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesFontColor.SelectedValue);
            string fontcolor = "sub-text-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string bordersize = "sub-text-border-size=" + mainwindow.cboSubtitlesBorderSize.SelectedItem.ToString();

            // -------------------------
            // Border Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesBorderColor.SelectedValue);
            string bordercolor = "sub-text-border-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboSubtitlesShadowColor.SelectedValue);
            selected = (string)(selectedItem.Content);

            string shadowcolor = string.Empty;

            if (selected != "None")
            {
                shadowcolor = "sub-text-shadow-color=" + "\"" + "#33" + ColorPicker.HexColor(selectedItem) + "\"";
            }
                

            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowoffset = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxSubtitlesShadowOffset.Text))
                shadowoffset = "sub-shadow-offset=" + mainwindow.tbxSubtitlesShadowOffset.Text.ToString();


            // --------------------------------------------------
            // ASS Advanced SSA
            // --------------------------------------------------

            // -------------------------
            // ass
            // -------------------------
            string ass = "sub-ass-force-margins"
                        + "\r\n"
                        + "ass-style-override=force"
                        + "\r\n"
                        + "ass-force-style=Kerning=yes"
                        + "\r\n"
                        + "ass-shaper=simple";


            // --------------------------------------------------
            // Blend
            // --------------------------------------------------
            string blend = "blend-subtitles=" + mainwindow.cboSubtitlesBlend.SelectedItem.ToString();


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listSubtitle = new List<string>()
            {
                title,
                languages,
                subtitles,
                loadfiles,
                position,
                timing,
                margins,
                font,
                fontsize,
                fontcolor,
                bordersize,
                bordercolor,
                shadowcolor,
                shadowoffset,
                ass,
                embeddedfonts,
                blend,
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
