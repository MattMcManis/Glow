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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Text;
// Disable XML Comment warnings
#pragma warning disable 1591
#pragma warning disable 1587
#pragma warning disable 1570

namespace ViewModel
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        ///     ViewModel Base
        /// </summary>
        public VM()
        {
            // -------------------------
            // Defaults
            // -------------------------

        }

        // Main
        public static Main MainView { get; set; } = new Main();

        // Color Picker
        public static ColorPicker ColorPickerView { get; set; } = new ColorPicker();

        // General
        public static General GeneralView { get; set; } = new General();
        // Video
        public static Video VideoView { get; set; } = new Video();
        // Subtitle
        public static Subtitles SubtitlesView { get; set; } = new Subtitles();
        // Audio
        public static Audio AudioView { get; set; } = new Audio();
        // Stream
        public static Stream StreamView { get; set; } = new Stream();
        // Display
        public static Display DisplayView { get; set; } = new Display();
        // Configure
        public static Configure ConfigureView { get; set; } = new Configure();

    }
}
