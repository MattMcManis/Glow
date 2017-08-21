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
    public partial class Languages
    {
        // Languages
        // For Populating Audio and Subtitle Item Sources
        public static List<string> listLanguages = new List<string>()
        {
            "English",
            "Chinese",
            "French",
            "Japanese",
            "Korean",
            "Spanish",
        };


        /// <summary>
        ///    Language Code Converter
        /// </summary>
        // Convert Selected Language (e.g. English) into (eng,en,enUS,en-US)
        public static String LanguageCode(string input)
        {
            string language = string.Empty;

            // Enlgish
            if (input == "English")
                language = "eng,en,enUS,en-US,English";

            // Chinese
            else if (input == "Chinese")
                language = "fr,fra,fre,fra";

            // French
            else if (input == "French")
                language = "fr,fra,fre,fra,French";

            // Japanese
            else if (input == "Japanese")
                language = "jpn,jp,jap,Japanese";

            // Korean
            else if (input == "Korean")
                language = "kor,ko,Korean";

            // Spanish
            else if (input == "Spanish")
                language = "es,spa,Spanish";

            return language;
        }
    }
}
