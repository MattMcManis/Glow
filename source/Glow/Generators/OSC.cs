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
using System.Globalization;
using System.Linq;
using ViewModel;

namespace Generate
{
    public class OSC
    {
        /// <summary>
        ///    OSD Config
        /// </summary>
        public static IEnumerable<string> Config()
        {
            // -------------------------
            // OSC Heading
            // -------------------------
            string oscHeading = "## OSC ##";

            // -------------------------
            // OSC On Screen Controller
            // -------------------------
            string oscEnable = string.Empty;

            if (VM.DisplayView.OSC_SelectedItem != "default")
                oscEnable = "osc=" + VM.DisplayView.OSC_SelectedItem;

            // -------------------------
            // Layout
            // -------------------------
            string oscLayout = string.Empty;

            if (ViewModel.VM.DisplayView.OSC_Layout_SelectedItem != "default")
                oscLayout = "osc-layout=" + VM.DisplayView.OSC_Layout_SelectedItem;

            // -------------------------
            // Seekbar
            // -------------------------
            string oscSeekbar = string.Empty;

            if (VM.DisplayView.OSC_Seekbar_SelectedItem != "default")
                oscSeekbar = "osc-seekbarstyle=" + VM.DisplayView.OSC_Seekbar_SelectedItem;

            // -------------------------
            // Scale
            // -------------------------
            string scale = string.Empty;

            if (VM.DisplayView.OSC_Scale_Value != 0.0)
                scale = "osd-scale=" + VM.DisplayView.OSC_Scale_Value
                                       .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Bar Width
            // -------------------------
            string barWidth = string.Empty;

            if (VM.DisplayView.OSC_BarWidth_Value != 0.0)
                barWidth = "osd-bar-w=" + VM.DisplayView.OSC_BarWidth_Value
                                          .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Bar Height
            // -------------------------
            string barHeight = string.Empty;

            if (VM.DisplayView.OSC_BarHeight_Value != 0.0)
                barHeight = "osd-bar-h=" + VM.DisplayView.OSC_BarHeight_Value
                                          .ToString("0.#", CultureInfo.GetCultureInfo("en-US"));

            // -------------------------
            // Script Opts
            // -------------------------
            // Join Layout, Seekbar
            List<string> listOSCScriptOpts = new List<string>()
            {
                oscLayout,
                oscSeekbar,
            };

            // only if list is not empty
            string oscScriptOpts = string.Empty;

            if (listOSCScriptOpts[0] != string.Empty || listOSCScriptOpts[1] != string.Empty)
            {
                oscScriptOpts = "script-opts=" + string.Join(",", listOSCScriptOpts
                .Where(s => !string.IsNullOrEmpty(s))
                );
            }


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            return new List<string>()
            {
                oscHeading,
                oscEnable,
                oscScriptOpts,

                scale,
                barWidth,
                barHeight
            };
        }
    }
}
