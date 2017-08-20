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
using System.Text;
using System.Threading.Tasks;

namespace Glow
{
    public partial class Stream
    {
        /// <summary>
        ///    Stream Config
        /// </summary>
        public static String StreamConfig(MainWindow mainwindow)
        {
            // -------------------------
            // Stream
            // -------------------------
            string title = "# [ STREAM ]";

            string cache = "cache=" + mainwindow.cboCache.SelectedItem.ToString();

            string cachedefault = "cache-default=" + mainwindow.tbxCacheDefault.Text.ToString();

            string initial = "cache-initial=" + mainwindow.tbxCacheInitial.Text.ToString();

            string seekmin = "cache-seek-min=" + mainwindow.tbxCacheSeekMin.Text.ToString();

            string backbuffer = "cache-backbuffer=" + mainwindow.tbxCacheBackbuffer.Text.ToString();

            string seconds = "cache-secs=" + mainwindow.tbxCacheSeconds.Text.ToString();

            string file = "cache-file=" + mainwindow.cboCacheFile.SelectedItem.ToString();

            string filesize = "cache-file-size=" + mainwindow.tbxCacheFileSize.Text.ToString();

            string extra = @"ytdl=yes
ytdl-format=(bestvideo[ext=webm]/bestvideo[fps=60])+(bestaudio[acodec=opus]/bestaudio)/best";

            // Combine
            List <string> listStream = new List<string>()
            {
                title,
                cache,
                cachedefault,
                initial,
                seekmin,
                backbuffer,
                seconds,
                file,
                filesize,
                extra,
            };

            string stream = string.Join("\r\n", listStream
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // Return
            return stream;
        }
    }
}
