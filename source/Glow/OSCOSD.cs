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
    public partial class OSCOSD
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
            // OSC Title
            // -------------------------
            string oscTitle = "# [ OSC ]";

            // -------------------------
            // OSC On Screen Controller
            // -------------------------
            string oscEnable = "osc=" + (mainwindow.cboOSC.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Layout
            // -------------------------
            string oscLayout = "layout=" + (mainwindow.cboOSCLayout.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Layout
            // -------------------------
            string oscSeekbar = "seekbarstyle=" + (mainwindow.cboOSCSeekbar.SelectedItem ?? string.Empty).ToString();


            // -------------------------
            // OSD Title
            // -------------------------
            string osdTitle = "# [ OSD ]";

            // -------------------------
            // OSD On Screen Display
            // -------------------------
            string videoOSD = "video-osd=" + (mainwindow.cboOSD.SelectedItem ?? string.Empty).ToString();

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
            string level = "osd-level=" + (mainwindow.cboOSDLevel.SelectedItem ?? string.Empty).ToString();


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
            string font = "osd-font=" + "\"" + (mainwindow.cboOSDFont.SelectedItem ?? string.Empty).ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontSize = "osd-font-size=" + (mainwindow.cboOSDFontSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Font Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue ?? string.Empty);
            string fontColor = "osd-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Border Size
            // -------------------------
            string borderSize = "osd-border-size=" + (mainwindow.cboOSDFontBorderSize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Border Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDBorderColor.SelectedValue ?? string.Empty);
            string borderColor = "osd-border-color=" + "\"" + "#FF" + ColorPicker.HexColor(selectedItem) + "\"";

            // -------------------------
            // Shadow Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDShadowColor.SelectedValue ?? string.Empty);
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
            List<string> listOSC = new List<string>()
            {
                // OSC
                oscTitle,
                oscEnable,
                oscLayout,
                oscSeekbar,
            };

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
            // OSC
            string osc = string.Join("\r\n", listOSC
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // OSC
            string osd = string.Join("\r\n", listOSD
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // OSC+OSD
            string osc_osd = string.Join("\r\n\r\n", osc, osd);

            // -------------------------
            // Return
            // -------------------------
            return osc_osd;
        }

    }
}
