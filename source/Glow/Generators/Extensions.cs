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
    public class Extensions
    {
        /// <summary>
        ///    Extensions Config
        /// </summary>
        public static String Config()
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

            if (VM.GeneralView.ExtMKV_SelectedItem == "loop")
                mkv = "[extension.mkv]"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // MP4
            // -------------------------
            string mp4 = string.Empty;

            if (VM.GeneralView.ExtMP4_SelectedItem == "loop")
                mp4 = "[extension.mp4]"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // WebM
            // -------------------------
            string webm = string.Empty;

            if (VM.GeneralView.ExtWebM_SelectedItem == "loop")
                webm = "[extension.webm]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // GIF
            // -------------------------
            string gif = string.Empty;

            if (VM.GeneralView.ExtGIF_SelectedItem == "loop")
                gif = "[extension.gif]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "loop-file=inf";

            // -------------------------
            // JPG
            // -------------------------
            string jpg = string.Empty;

            if (VM.GeneralView.ExtJPG_SelectedItem == "pause")
                jpg = "[extension.jpg]"
                        + "\r\n"
                        + "cache=no"
                        + "\r\n"
                        + "pause";

            // -------------------------
            // PNG
            // -------------------------
            string png = string.Empty;

            if (VM.GeneralView.ExtPNG_SelectedItem == "pause")
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
            return string.Join("\r\n", listExtensions
                                       .Where(s => !string.IsNullOrEmpty(s))
                              );

        }
    }
}
