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
using System.Linq;
using System.Windows.Controls;

namespace Glow
{
    public partial class ColorConverter
    {
        /// <summary>
        ///    Hex Color Converter
        /// </summary>
        public static String HexColor(ComboBoxItem selectedItem)
        {
            // ComboBox Selected Item
            string selected = (string)(selectedItem.Content);

            // Hex Color
            string color = string.Empty;

            // Convert ComboBox Selected Color to Hex
            if (selected == "White")
                color = "FFFFFF";

            else if (selected == "Gray")
                color = "A9A9A9";

            else if (selected == "Dark Gray")
                color = "262626";

            else if (selected == "Black")
                color = "000000";

            else if (selected == "Yellow")
                color = "FDFD02";

            else if (selected == "Blue")
                color = "9AAFE4";

            else if (selected == "Pink")
                color = "FFB0B0";

            return color;
        }
    }
}
