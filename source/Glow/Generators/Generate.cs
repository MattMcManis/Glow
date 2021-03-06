﻿/* ----------------------------------------------------------------------
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
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace Generate
{
    public class Generator
    {
        /// <summary>
        ///    Generate Config
        /// </summary>
        public static String Config()
        {
            // -------------------------
            // Create Master List
            // -------------------------
            IEnumerable<string> listConfig = new List<string>()
            {
                string.Join("\r\n", General.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", Video.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", Audio.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", Subtitles.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", Stream.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", OSC.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", OSD.Config().Where(s => !string.IsNullOrEmpty(s))),
                string.Join("\r\n", Extensions.Config().Where(s => !string.IsNullOrEmpty(s))),
            };

            // Combine
            return string.Join("\r\n\r\n", listConfig
                                          .Where(s => !string.IsNullOrEmpty(s))
                              );
        }
    }
}
