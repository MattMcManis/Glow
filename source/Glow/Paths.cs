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
using System.Text;
using System.Threading.Tasks;

namespace Glow
{
    public class Paths
    {
        // Path Defaults
        public static string appDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\"; // Glow.exe path
        public static string userDir = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%").TrimEnd('\\') + @"\";
        public static string configINIDir = appDir; // Glow main config.ini path (Can't change location)
        public static string configINIFile = appDir + "config.ini"; // Glow main config.ini (Can't change location)
        public static string mpvDir = string.Empty; // mpv.exe path
        public static string mpvConfigDir = userDir + @"AppData\Roaming\mpv\"; // mpv.conf directory
        public static string profilesDir = appDir + @"profiles\"; // Custom User ini profiles
    }
}
