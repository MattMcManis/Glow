/* ----------------------------------------------------------------------
Glow
Copyright (C) 2017, 2018 Matt McManis
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
    public partial class OSD
    {
        //private static ComboBoxItem selectedItem;
        //private static string selected;

        /// <summary>
        ///    OSD Config
        /// </summary>
        public static String OSDConfig(MainWindow mainwindow)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // OSD Title
            // -------------------------
            string osdTitle = "## OSD ##";

            // -------------------------
            // OSD On Screen Display
            // -------------------------
            string videoOSD = string.Empty;

            if ((string)(mainwindow.cboOSD.SelectedItem ?? string.Empty) != "default")
                videoOSD = "video-osd=" + (mainwindow.cboOSD.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Fractions
            // -------------------------
            string fractions = string.Empty;

            if ((string)(mainwindow.cboOSD.SelectedItem ?? string.Empty) != "no"
                && (string)(mainwindow.cboOSDFractions.SelectedItem ?? string.Empty) != "default")
                fractions = "osd-fractions=" + (mainwindow.cboOSDFractions.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Level
            // -------------------------
            string level = string.Empty;

            if ((string)(mainwindow.cboOSD.SelectedItem ?? string.Empty) != "no"
                && (string)(mainwindow.cboOSDLevel.SelectedItem ?? string.Empty) != "default")
                level = "osd-level=" + (mainwindow.cboOSDLevel.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Duration
            // -------------------------
            string duration = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDDuration.Text))
                duration = "osd-duration=" + mainwindow.tbxOSDDuration.Text.ToString();


            // --------------------------------------------------
            // Controls
            // --------------------------------------------------

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            if (mainwindow.slOSDScale.Value != 0.0 
                && !string.IsNullOrWhiteSpace(mainwindow.tbxOSDScale.Text))
                scale = "osd-scale=" + mainwindow.tbxOSDScale.Text.ToString();

            // -------------------------
            // Bar Width
            // -------------------------
            string barWidth = string.Empty;

            if (mainwindow.slOSDBarWidth.Value != 0.0
                && !string.IsNullOrWhiteSpace(mainwindow.tbxOSDBarWidth.Text))
                barWidth = "osd-bar-w=" + mainwindow.tbxOSDBarWidth.Text.ToString();

            // -------------------------
            // Bar Height
            // -------------------------
            string barHeight = string.Empty;

            if (mainwindow.slOSDBarHeight.Value != 0.0
                && !string.IsNullOrWhiteSpace(mainwindow.tbxOSDBarHeight.Text))
                barHeight = "osd-bar-h=" + mainwindow.tbxOSDBarHeight.Text.ToString();


            // --------------------------------------------------
            // Text
            // --------------------------------------------------

            // -------------------------
            // Font Name
            // -------------------------
            string font = string.Empty;

            if ((string)(mainwindow.cboOSDFont.SelectedItem ?? string.Empty) != "default")
                font = "osd-font=" + "\"" + (mainwindow.cboOSDFont.SelectedItem ?? string.Empty).ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = string.Empty;

            if ((string)(mainwindow.cboOSDFontSize.SelectedItem ?? string.Empty) != "default")
                fontSize = "osd-font-size=" + (mainwindow.cboOSDFontSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Font Color
            // -------------------------
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue ?? string.Empty);
            //string fontColor = "osd-color=" + "\"" + "#FF" + ColorConverter.HexColor(selectedItem) + "\"";
            string fontColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDFontColor.Text))
                fontColor = "osd-color=" + "\"" + "#FF" + mainwindow.tbxOSDFontColor.Text + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = string.Empty;

            if ((string)(mainwindow.cboOSDFontBorderSize.SelectedItem ?? string.Empty) != "default")
                borderSize = "osd-border-size=" + (mainwindow.cboOSDFontBorderSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Border Color
            // -------------------------
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDBorderColor.SelectedValue ?? string.Empty);
            //string borderColor = "osd-border-color=" + "\"" + "#FF" + ColorConverter.HexColor(selectedItem) + "\"";
            string borderColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDBorderColor.Text))
                borderColor = "osd-border-color=" + "\"" + "#FF" + mainwindow.tbxOSDBorderColor.Text + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            string shadowColor = string.Empty;

            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDShadowColor.Text))
                shadowColor = "osd-shadow-color=" + "\"" + "#33" + mainwindow.tbxOSDShadowColor.Text + "\"";
            //selectedItem = (ComboBoxItem)(mainwindow.cboOSDShadowColor.SelectedValue ?? string.Empty);
            //selected = (string)(selectedItem.Content);

            //string shadowColor = string.Empty;

            //if (selected != "None")
            //{
            //    shadowColor = "osd-shadow-color=" + "\"" + "#33" + ColorConverter.HexColor(selectedItem) + "\"";
            //}

            // -------------------------
            // Shadow Offset
            // -------------------------
            string shadowOffset = string.Empty;

            // only if shadow color is on
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxOSDShadowColor.Text))
                shadowOffset = "osd-shadow-offset=" + mainwindow.tbxOSDShadowOffset.Text.ToString();

            // --------------------------------------------------
            // Combine
            // --------------------------------------------------

            List <string> listOSD = new List<string>()
            {
                // OSD
                osdTitle,
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
            // OSD
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
