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
using System.Linq;
using ViewModel;

namespace Generate
{
    public class General
    {
        /// <summary>
        ///    General Config
        /// </summary>
        public static String Config()
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
            if (VM.GeneralView.Priority_SelectedItem != "default")
                priority = "priority=" + VM.GeneralView.Priority_SelectedItem;


            // --------------------------------------------------
            // Window
            // --------------------------------------------------

            // -------------------------
            // Save Position on Quit
            // -------------------------
            string savePositiOnQuit = string.Empty;

            if (VM.GeneralView.SavePositionQuit_SelectedItem != "default" &&
                VM.GeneralView.SavePositionQuit_SelectedItem == "yes")
                savePositiOnQuit = "save-position-on-quit";

            // -------------------------
            // Keep Open
            // -------------------------
            string keepOpen = string.Empty;

            // must not be default
            if (VM.GeneralView.KeepOpen_SelectedItem != "default")
                keepOpen = "keep-open=" + VM.GeneralView.KeepOpen_SelectedItem;

            // -------------------------
            // On Top
            // -------------------------
            string onTop = string.Empty;

            // must not be default
            if (VM.GeneralView.OnTop_SelectedItem == "yes")
                onTop = "ontop";
            //onTop = "ontop" + (VM.GeneralView.OnTop_SelectedItem;

            // -------------------------
            // Border
            // -------------------------
            string border = string.Empty;

            // must not be default
            if (VM.GeneralView.WindowBorder_SelectedItem != "default")
                border = "border=" + VM.GeneralView.WindowBorder_SelectedItem;

            // -------------------------
            // Geometry
            // -------------------------
            string geometry = string.Empty;

            // if not 0
            if (VM.GeneralView.GeometryX_Value != 0 && VM.GeneralView.GeometryY_Value != 0)
                geometry = "geometry=" + VM.GeneralView.GeometryX_Value/*GeometryX_Text*/ + "%" + ":" + VM.GeneralView.GeometryY_Value/*GeometryY_Text*/ + "%";

            // -------------------------
            // Auto-Fit
            // -------------------------
            string autoFit = string.Empty;

            // if not 0
            if (VM.GeneralView.AutofitWidth_Value != 0 && VM.GeneralView.AutofitHeight_Value != 0)
                //autoFit = "autofit-larger=" + VM.GeneralView.AutofitWidth_Text + "%" + ":" + VM.GeneralView.AutofitHeight_Text + "%";
                autoFit = "autofit-larger=" + VM.GeneralView.AutofitWidth_Value/*AutofitWidth_Text*/ + "%" + "x" + VM.GeneralView.AutofitHeight_Value/*AutofitHeight_Text*/ + "%";

            // -------------------------
            // Screensaver
            // -------------------------
            string screensaver = string.Empty;
            // empty if default

            // Keep
            if (VM.GeneralView.Screensaver_SelectedItem == "on")
                screensaver = "no-stop-screensaver";
            // Stop
            else if (VM.GeneralView.Screensaver_SelectedItem == "off")
                screensaver = "stop-screensaver";

            // -------------------------
            // Window Title
            // -------------------------
            string windowTitle = string.Empty;
            // empty if default

            // Filename
            if (VM.GeneralView.WindowTitle_SelectedItem == "Filename")
                windowTitle = "title=\"${filename}\"";
            // Media Title
            else if (VM.GeneralView.WindowTitle_SelectedItem == "Media Title")
                windowTitle = "title=\"${media-title}\"";

            // -------------------------
            // Log
            // -------------------------
            // Log Path
            string logPath = string.Empty;
            // only if not empty
            if (!string.IsNullOrWhiteSpace(VM.GeneralView.LogPath_Text))
                logPath = "log-file=" + "\"" + VM.GeneralView.LogPath_Text + "log.txt\"";


            // --------------------------------------------------
            // Screenshot
            // --------------------------------------------------

            // -------------------------
            // Path
            // -------------------------
            string screenshotPath = string.Empty;
            // only if not empty
            if (!string.IsNullOrWhiteSpace(VM.GeneralView.ScreenshotPath_Text))
                screenshotPath = "screenshot-directory=" + "\"" + VM.GeneralView.ScreenshotPath_Text + "\"";

            // Template
            string screenshotTemplate = string.Empty;

            if (VM.GeneralView.ScreenshotTemplate_SelectedItem == "Playback Time")
                screenshotTemplate = "screenshot-template=\"%F-%wHh%wMm%wSs%wTt\"";
            else if (VM.GeneralView.ScreenshotTemplate_SelectedItem == "Date Time")
                screenshotTemplate = "screenshot-template=\"%F-%ty-%tm-%td_%tH.%tM.%tS.%wT\"";
            else if (VM.GeneralView.ScreenshotTemplate_SelectedItem == "Numbered")
                screenshotTemplate = "screenshot-template=\"%F-%n\"";


            // -------------------------
            // Tag Colorspace
            // -------------------------
            // must not be default
            string screenshotTagColorspace = string.Empty;

            if (VM.GeneralView.ScreenshotTagColorspace_SelectedItem != "default")
                screenshotTagColorspace = "screenshot-tag-colorspace=" + VM.GeneralView.ScreenshotTagColorspace_SelectedItem;


            // -------------------------
            // Format
            // -------------------------
            string screenshotFormat = string.Empty;

            // must not be default
            if (VM.GeneralView.ScreenshotFormat_SelectedItem != "default")
                screenshotFormat = "screenshot-format=" + VM.GeneralView.ScreenshotFormat_SelectedItem;

            // -------------------------
            // Qulaity
            // -------------------------
            string screenshotQuality = string.Empty;

            // format must not be default
            if (VM.GeneralView.ScreenshotFormat_SelectedItem != "default")
            {
                // jpg
                if (VM.GeneralView.ScreenshotFormat_SelectedItem == "jpg" ||
                    VM.GeneralView.ScreenshotFormat_SelectedItem == "jpeg")
                    screenshotQuality = "screenshot-jpeg-quality=" + VM.GeneralView.ScreenshotQuality_Value;//VM.GeneralView.ScreenshotQuality_Text;
                // png
                else if (VM.GeneralView.ScreenshotFormat_SelectedItem == "png")
                    screenshotQuality = "screenshot-png-compression=" + VM.GeneralView.ScreenshotQuality_Value;//VM.GeneralView.ScreenshotQuality_Text;
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
                border,
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
            return string.Join("\r\n", listGeneral
                                       .Where(s => !string.IsNullOrEmpty(s))
                               );
        }

    }
}
