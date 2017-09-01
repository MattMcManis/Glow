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
    public partial class Extensions
    {
        /// <summary>
        ///    Extensions Config
        /// </summary>
        public static String ExtensionsConfig(MainWindow mainwindow)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "## EXTENSIONS ##";

            // -------------------------
            // MKV
            // -------------------------
            string mkv = string.Empty;

            if ((string)(mainwindow.cboExtMKV.SelectedItem ?? string.Empty) == "loop")
                mkv = "[extension.mkv]"
                        +"\r\n"
                        + "loop-file=inf";

            // -------------------------
            // MP4
            // -------------------------
            string mp4 = string.Empty;

            if ((string)(mainwindow.cboExtMP4.SelectedItem ?? string.Empty) == "loop")
                mp4 = "[extension.mp4]"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // WebM
            // -------------------------
            string webm = string.Empty;

            if ((string)(mainwindow.cboExtWebM.SelectedItem ?? string.Empty) == "loop")
                webm = "[extension.webm]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // GIF
            // -------------------------
            string gif = string.Empty;

            if ((string)(mainwindow.cboExtGIF.SelectedItem ?? string.Empty) == "loop")
                gif = "[extension.gif]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // JPG
            // -------------------------
            string jpg = string.Empty;

            if ((string)(mainwindow.cboExtJPG.SelectedItem ?? string.Empty) == "pause")
                jpg = "[extension.jpg]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "pause";

            // -------------------------
            // PNG
            // -------------------------
            string png = string.Empty;

            if ((string)(mainwindow.cboExtPNG.SelectedItem ?? string.Empty) == "pause")
                png = "[extension.png]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "pause";


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listExtensions = new List<string>()
            {
                title,
                mkv,
                mp4,
                webm,
                gif,
                jpg,
                png,
            };

            // -------------------------
            // Join
            // -------------------------
            string extensions = string.Join("\r\n", listExtensions
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return extensions;
        }
    }
}
