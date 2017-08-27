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
            string title = "## GENERAL ##";

            // -------------------------
            // Priority
            // -------------------------
            string priority = "priority=" + (mainwindow.cboPriority.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Window
            // --------------------------------------------------

            // -------------------------
            // Save Position on Quit
            // -------------------------
            string savePositiOnQuit = string.Empty;

            if ((string)(mainwindow.cboSavePositionQuit.SelectedItem ?? string.Empty) == "yes")
                savePositiOnQuit = "save-position-on-quit";

            // -------------------------
            // Keep Open
            // -------------------------
            string keepOpen = "keep-open=" + (mainwindow.cboKeepOpen.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // On Top
            // -------------------------
            string onTop = "ontop=" + (mainwindow.cboOnTop.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Geometry
            // -------------------------
            string geometry = "geometry=" + mainwindow.tbxGeometryX.Text.ToString() + "%" + ":" + mainwindow.tbxGeometryY.Text.ToString() + "%";

            // -------------------------
            // Auto-Fit
            // -------------------------
            string autoFit = "autofit-larger=" + mainwindow.tbxAutofitWidth.Text.ToString() + "%" + ":" + mainwindow.tbxAutofitHeight.Text.ToString() + "%";

            // -------------------------
            // Screensaver
            // -------------------------
            string screensaver = string.Empty;

            // Keep
            if ((string)(mainwindow.cboScreensaver.SelectedItem ?? string.Empty) == "on")
                screensaver = "no-stop-screensaver";
            // Stop
            else if ((string)(mainwindow.cboScreensaver.SelectedItem ?? string.Empty) == "off")
                screensaver = "stop-screensaver";

            // -------------------------
            // Window Title
            // -------------------------
            string windowTitle = "title=\"${filename}\"";


            // --------------------------------------------------
            // Screenshot
            // --------------------------------------------------

            // -------------------------
            // Screenshot
            // -------------------------
            // Path
            string screenshotPath = string.Empty;
            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxScreenshotPath.Text))
                screenshotPath = "screenshot-directory=" + "\"" + mainwindow.tbxScreenshotPath.Text.ToString() + "\"";

            // Template
            string screenshotTemplate = string.Empty;

            if ((string)(mainwindow.cboScreenshotTemplate.SelectedItem ?? string.Empty) == "Playback Time")
                screenshotTemplate = "screenshot-template=\"%F-%wHh%wMm%wSs%wTt\"";
            else if ((string)(mainwindow.cboScreenshotTemplate.SelectedItem ?? string.Empty) == "Date Time")
                screenshotTemplate = "screenshot-template=\"%F-%ty-%tm-%td_%tH.%tM.%tS.%wT\"";
            else if ((string)(mainwindow.cboScreenshotTemplate.SelectedItem ?? string.Empty) == "Numbered")
                    screenshotTemplate = "screenshot-template=\"%F-%n\"";

            // Tag Colorspace
            string screenshotTagColorspace = "screenshot-tag-colorspace=" + (mainwindow.cboScreenshotTagColorspace.SelectedItem ?? string.Empty).ToString();

            // Format
            string screenshotFormat = "screenshot-format=" + (mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty).ToString();

            // Qulaity
            string screenshotQuality = string.Empty;
            // jpg
            if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "jpg"
                || (string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "jpeg")
                screenshotQuality = "screenshot-jpeg-quality=" + mainwindow.tbxScreenshotQuality.Text.ToString();
            // png
            else if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "png")
                screenshotQuality = "screenshot-png-compression=" + mainwindow.tbxScreenshotQuality.Text.ToString();


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listGeneral = new List<string>()
            {
                title,
                priority,
                savePositiOnQuit,
                keepOpen,
                onTop,
                geometry,
                autoFit,
                screensaver,
                windowTitle,

                // Screenshot
                screenshotPath,
                screenshotTemplate,
                screenshotTagColorspace,
                screenshotFormat,
                screenshotQuality,
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
