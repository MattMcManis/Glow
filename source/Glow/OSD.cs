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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Glow
{
    public partial class OSD
    {
        private static ComboBoxItem selectedItem;
        //private static string selected;

        /// <summary>
        ///    OSD Config
        /// </summary>
        public static String OSDConfig(MainWindow mainwindow)
        {
            // -------------------------
            // Title
            // -------------------------
            string title = "# [ OSD ]";

            // -------------------------
            // OSD
            // -------------------------
            string videoosd = "video-osd=" + mainwindow.cboOSD.SelectedItem.ToString();

            // -------------------------
            // Duration
            // -------------------------
            string duration = "osd-duration=" + mainwindow.tbxOSDDuration.Text.ToString();

            // -------------------------
            // Level
            // -------------------------
            string level = "osd-level=" + mainwindow.cboOSDLevel.SelectedItem.ToString();

            // -------------------------
            // Scale
            // -------------------------
            string scale = "osd-scale=" + mainwindow.tbxOSDScale.Text.ToString();

            // -------------------------
            // Font Name
            // -------------------------
            string font = "osd-font=" + "\"" + mainwindow.cboOSDFont.SelectedItem.ToString() + "\"";

            // -------------------------
            // Font Size
            // -------------------------
            string fontsize = "osd-font-size=" + mainwindow.cboOSDFontSize.SelectedItem.ToString();

            // -------------------------
            // Font Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontColor.SelectedValue);
            string fontcolor = "osd-color=" + ColorPicker.HexColor(selectedItem);

            // -------------------------
            // Border Size
            // -------------------------
            string bordersize = "osd-border-size=" + mainwindow.cboOSDFontBorderSize.SelectedItem.ToString();

            // -------------------------
            // Border Color
            // -------------------------
            selectedItem = (ComboBoxItem)(mainwindow.cboOSDFontBorderColor.SelectedValue);
            string bordercolor = "osd-border-color=" + ColorPicker.HexColor(selectedItem);

            // -------------------------
            // Fractions
            // -------------------------
            string fractions = "osd-fractions=" + mainwindow.tbxCacheFileSize.Text.ToString();

            // -------------------------
            // Combine
            // -------------------------
            List<string> listOSD = new List<string>()
            {
                title,
                videoosd,
                duration,
                level,
                scale,
                font,
                fontsize,
                fontcolor,
                bordersize,
                bordercolor,
                fractions
            };

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
