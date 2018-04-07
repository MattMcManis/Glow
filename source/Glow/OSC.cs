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
    public partial class OSC
    {
        /// <summary>
        ///    OSD Config
        /// </summary>
        public static String OSCConfig(MainWindow mainwindow)
        {
            // -------------------------
            // OSC Title
            // -------------------------
            string oscTitle = "## OSC ##";

            // -------------------------
            // OSC On Screen Controller
            // -------------------------
            string oscEnable = string.Empty;

            if ((string)(mainwindow.cboOSC.SelectedItem ?? string.Empty) != "default")
                oscEnable = "osc=" + (mainwindow.cboOSC.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Layout
            // -------------------------
            string oscLayout = string.Empty;

            if ((string)(mainwindow.cboOSCLayout.SelectedItem ?? string.Empty) != "default")
                oscLayout = "osc-layout=" + (mainwindow.cboOSCLayout.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Seekbar
            // -------------------------
            string oscSeekbar = string.Empty;

            if ((string)(mainwindow.cboOSCSeekbar.SelectedItem ?? string.Empty) != "default")
                oscSeekbar = "osc-seekbarstyle=" + (mainwindow.cboOSCSeekbar.SelectedItem ?? string.Empty).ToString();

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
            List<string> listOSC = new List<string>()
            {
                oscTitle,
                oscEnable,
                oscScriptOpts,
            };

            // -------------------------
            // Join
            // -------------------------
            // OSC
            string osc = string.Join("\r\n", listOSC
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return osc;
        }
    }
}
