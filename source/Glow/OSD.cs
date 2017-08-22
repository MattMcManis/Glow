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
    public partial class OSD
    {
        private static ComboBoxItem selectedItem;
        private static string selected;

        /// <summary>
        ///    OSD Config
        /// </summary>
        public static String OSDConfig(MainWindow mainwindow)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "# [ OSD ]";

            // -------------------------
            // OSD
            // -------------------------
            string videoOSD = "video-osd=" + mainwindow.cboOSD.SelectedItem.ToString();

            // -------------------------
            // Fractions
            // -------------------------
            string fractions = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheFileSize.Text))
                fractions = "osd-fractions=" + mainwindow.tbxCacheFileSize.Text.ToString();

            // -------------------------
            // Duration
            // -------------------------
            string duration = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDDuration.Text))
                duration = "osd-duration=" + mainwindow.tbxOSDDuration.Text.ToString();

            // -------------------------
            // Level
            // -------------------------
            string level = "osd-level=" + mainwindow.cboOSDLevel.SelectedItem.ToString();


            // --------------------------------------------------
            // Controls
            // --------------------------------------------------

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDScale.Text))
                scale = "osd-scale=" + mainwindow.tbxOSDScale.Text.ToString();

            // -------------------------
            // Bar Width
            // -------------------------
            string barWidth = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDBarWidth.Text))
                barWidth = "osd-bar-w=" + mainwindow.tbxOSDBarWidth.Text.ToString();

            // -------------------------
            // Bar Height
            // -------------------------
            string barHeight = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDBarHeight.Text))
                barHeight = "osd-bar-h=" + mainwindow.tbxOSDBarHeight.Text.ToString();


            // --------------------------------------------------
            // Text
            // --------------------------------------------------

            // -------------------------
            // Font Name
            // -------------------------
            string font = "osd-font=" + "\"" + mainwindow.cboOSDFont.SelectedItem.ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = "osd-font-size=" + mainwindow.cboOSDFontSize.SelectedItem.ToString();

            // -------------------------
            // Font Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue);
            string fontColor = "osd-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = "osd-border-size=" + mainwindow.cboOSDFontBorderSize.SelectedItem.ToString();

            // -------------------------
            // Border Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontBorderColor.SelectedValue);
            string borderColor = "osd-border-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontShadowColor.SelectedValue);
            selected = (string)(selectedItem.Content);

            string shadowColor = string.Empty;

            if (selected != "None")
            {
                shadowColor = "osd-shadow-color=" + "\"" + "#33" + ColorPicker.HexColor(selectedItem) + "\"";
            }

            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowOffset = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDShadowOffset.Text))
                shadowOffset = "osd-shadow-offset=" + mainwindow.tbxOSDShadowOffset.Text.ToString();

            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listOSD = new List<string>()
            {
                title,
                videoOSD,
                fractions,
                duration,
                level,

                // Controls
                scale,
                barWidth,
                barHeight,

                // Text
                font,
                fontSize,
                fontColor,
                borderSize,
                borderColor,
                shadowColor,
                shadowOffset,
            };

            // -------------------------
            // Join
            // -------------------------
            string osd = string.Join("\r\n", listOSD
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return osd;
        }

    }
}
