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
            switch (input)
            {
                case "English":
                    return "eng,en,enUS,en-US,English";

                case "Arabic":
                    return "ar,ara,Arabic";

                case "Bengali":
                    return "bn,ben,Bengali";

                case "Chinese":
                    return "chi,zh,zho,Chinese";

                case "Dutch":
                    return "nl,nld,dut,Dutch";

                case "Finnish":
                    return "fi,fin,Finnish";

                case "French":
                    return "fr,fra,fre,fra,French";

                case "German":
                    return "de,ger,deu,German";

                case "Hindi":
                    return "hi,hin,Hindi";

                case "Italian":
                    return "it,ita,Italian";

                case "Japanese":
                    return "jpn,jp,jap,Japanese";

                case "Korean":
                    return "kor,ko,Korean";

                case "Portuguese":
                    return "pt,por,Portuguese";

                case "Russian":
                    return "ru,rus,Russian";

                case "Spanish":
                    return "es,spa,Spanish";

                case "Swedish":
                    return "sv,swe,Swedish";

                case "Vietnamese":
                    return "vi,vie,Vietnamese";

                default:
                    return "eng,en,enUS,en-US,English";
            }

        }
    }
}
