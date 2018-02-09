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

            // Arabic
            else if (input == "Arabic")
                language = "ar,ara,Arabic";

            // Bengali
            else if (input == "Bengali")
                language = "bn,ben,Bengali";

            // Chinese
            else if (input == "Chinese")
                language = "chi,zh,zho,Chinese";

            // Dutch
            else if (input == "Dutch")
                language = "nl,nld,dut,Dutch";

            // Finnish
            else if (input == "Finnish")
                language = "fi,fin,Finnish";

            // French
            else if (input == "French")
                language = "fr,fra,fre,fra,French";

            // German
            else if (input == "German")
                language = "de,ger,deu,German";

            // Hindi
            else if (input == "Hindi")
                language = "hi,hin,Hindi";

            // Italian
            else if (input == "Italian")
                language = "it,ita,Italian";

            // Japanese
            else if (input == "Japanese")
                language = "jpn,jp,jap,Japanese";

            // Korean
            else if (input == "Korean")
                language = "kor,ko,Korean";

            // Portuguese
            else if (input == "Portuguese")
                language = "pt,por,Portuguese";

            // Russian
            else if (input == "Russian")
                language = "ru,rus,Russian";

            // Spanish
            else if (input == "Spanish")
                language = "es,spa,Spanish";

            // Swedish
            else if (input == "Swedish")
                language = "sv,swe,Swedish";

            // Vietnamese
            else if (input == "Vietnamese")
                language = "vi,vie,Vietnamese";


            // Return
            return language;
        }
    }
}
