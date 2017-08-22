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

namespace Glow
{
    public partial class General
    {
        /// <summary>
        ///    General Config
        /// </summary>
        public static String GeneralConfig(MainWindow mainwindow)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "# [ GENERAL ]";

            // -------------------------
            // Priority
            // -------------------------
            string priority = "priority=" + mainwindow.cboPriority.SelectedItem.ToString();


            // --------------------------------------------------
            // Window
            // --------------------------------------------------

            // -------------------------
            // Save Position on Quit
            // -------------------------
            string savepositionquit = string.Empty;

            if ((string)mainwindow.cboSavePositionQuit.SelectedItem == "yes")
                savepositionquit = "save-position-on-quit";

            // -------------------------
            // Keep Open
            // -------------------------
            string keepopen = "keep-open=" + mainwindow.cboKeepOpen.SelectedItem.ToString();

            // -------------------------
            // On Top
            // -------------------------
            string ontop = "ontop=" + mainwindow.cboOnTop.SelectedItem.ToString();

            // -------------------------
            // On Screen Display
            // -------------------------
            string osc = "osc=" + mainwindow.cboOSC.SelectedItem.ToString();

            // -------------------------
            // Auto-Fit
            // -------------------------
            string autofit = "autofit-larger=100%x95%";

            // -------------------------
            // Geometry
            // -------------------------
            string geometry = "geometry=50%:50%";

            // -------------------------
            // Window Title
            // -------------------------
            string windowtitle = "title=\"${ filename}\"";


            // --------------------------------------------------
            // Screenshot
            // --------------------------------------------------

            // -------------------------
            // Screenshot
            // -------------------------
            string screenshot = "screenshot-format=" + mainwindow.cboScreenshot.SelectedItem.ToString();
            string screenshot_template = "screenshot-template=mpvsnap-%tY.%tm.%td-%tHh%tMm%tSs%00n";
            string screenshot_tag_colorspace = "screenshot-tag-colorspace=yes";


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listGeneral = new List<string>()
            {
                title,
                priority,
                savepositionquit,
                keepopen,
                ontop,
                autofit,
                geometry,
                windowtitle,
                screenshot,
                screenshot_template,
                screenshot_tag_colorspace,
            };

            // -------------------------
            // Join
            // -------------------------
            string general = string.Join("\r\n", listGeneral
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return general;
        }
    }
}
