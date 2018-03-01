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
            string priority = string.Empty;

            // must not be default
            if ((string)(mainwindow.cboPriority.SelectedItem ?? string.Empty) != "default")
                priority = "priority=" + (mainwindow.cboPriority.SelectedItem ?? string.Empty).ToString();


            // --------------------------------------------------
            // Window
            // --------------------------------------------------

            // -------------------------
            // Save Position on Quit
            // -------------------------
            string savePositiOnQuit = string.Empty;

            if ((string)(mainwindow.cboSavePositionQuit.SelectedItem ?? string.Empty) != "default"
                && (string)(mainwindow.cboSavePositionQuit.SelectedItem ?? string.Empty) == "yes")
                savePositiOnQuit = "save-position-on-quit";

            // -------------------------
            // Keep Open
            // -------------------------
            string keepOpen = string.Empty;

            // must not be default
            if ((string)(mainwindow.cboKeepOpen.SelectedItem ?? string.Empty) != "default")
                keepOpen = "keep-open=" + (mainwindow.cboKeepOpen.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // On Top
            // -------------------------
            string onTop = string.Empty;

            // must not be default
            if ((string)(mainwindow.cboOnTop.SelectedItem ?? string.Empty) == "yes")
                onTop = "ontop";
                //onTop = "ontop" + (mainwindow.cboOnTop.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Geometry
            // -------------------------
            string geometry = string.Empty;

            // if not 0
            if (mainwindow.slGeometryX.Value != 0 && mainwindow.slGeometryY.Value != 0)
                geometry = "geometry=" + mainwindow.tbxGeometryX.Text.ToString() + "%" + ":" + mainwindow.tbxGeometryY.Text.ToString() + "%";

            // -------------------------
            // Auto-Fit
            // -------------------------
            string autoFit = string.Empty;

            // if not 0
            if (mainwindow.slAutofitWidth.Value != 0 && mainwindow.slAutofitHeight.Value != 0)
                //autoFit = "autofit-larger=" + mainwindow.tbxAutofitWidth.Text.ToString() + "%" + ":" + mainwindow.tbxAutofitHeight.Text.ToString() + "%";
                autoFit = "autofit=" + mainwindow.tbxAutofitWidth.Text.ToString() + "%" + ":" + mainwindow.tbxAutofitHeight.Text.ToString() + "%";

            // -------------------------
            // Screensaver
            // -------------------------
            string screensaver = string.Empty;
            // empty if default

            // Keep
            if ((string)(mainwindow.cboScreensaver.SelectedItem ?? string.Empty) == "on")
                screensaver = "no-stop-screensaver";
            // Stop
            else if ((string)(mainwindow.cboScreensaver.SelectedItem ?? string.Empty) == "off")
                screensaver = "stop-screensaver";

            // -------------------------
            // Window Title
            // -------------------------
            string windowTitle = string.Empty;           
            // empty if default

            // Filename
            if ((string)(mainwindow.cboWindowTitle.SelectedItem ?? string.Empty) == "Filename")
                windowTitle = "title=\"${filename}\"";
            // Media Title
            else if ((string)(mainwindow.cboWindowTitle.SelectedItem ?? string.Empty) == "Media Title")
                windowTitle = "title=\"${media-title}\"";

            // -------------------------
            // Log
            // -------------------------
            // Log Path
            string logPath = string.Empty;
            // only if not empty
            if (!string.IsNullOrWhiteSpace(mainwindow.tbxLogPath.Text))
                logPath = "log-file=" + "\"" + mainwindow.tbxLogPath.Text.ToString() + "log.txt\"";


            // --------------------------------------------------
            // Screenshot
            // --------------------------------------------------

            // -------------------------
            // Path
            // -------------------------
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


            // -------------------------
            // Tag Colorspace
            // -------------------------
            // must not be default
            string screenshotTagColorspace = string.Empty;

            if ((string)(mainwindow.cboScreenshotTagColorspace.SelectedItem ?? string.Empty) != "default")
                screenshotTagColorspace = "screenshot-tag-colorspace=" + (mainwindow.cboScreenshotTagColorspace.SelectedItem ?? string.Empty).ToString();


            // -------------------------
            // Format
            // -------------------------
            string screenshotFormat = string.Empty;

            // must not be default
            if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) != "default")
                screenshotFormat = "screenshot-format=" + (mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Qulaity
            // -------------------------
            string screenshotQuality = string.Empty;

            // format must not be default
            if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) != "default")
            {
                // jpg
                if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "jpg"
                || (string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "jpeg")
                    screenshotQuality = "screenshot-jpeg-quality=" + mainwindow.tbxScreenshotQuality.Text.ToString();
                // png
                else if ((string)(mainwindow.cboScreenshotFormat.SelectedItem ?? string.Empty) == "png")
                    screenshotQuality = "screenshot-png-compression=" + mainwindow.tbxScreenshotQuality.Text.ToString();
            }



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
                logPath,

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
