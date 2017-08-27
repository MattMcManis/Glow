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
            // Title
            // -------------------------
            string title = "# [ STREAM ]";

            // --------------------------------------------------
            // Demuxer
            // --------------------------------------------------

            // -------------------------
            // Demuxer Thread
            // -------------------------
            string demuxThread = "demuxer-thread=" + (mainwindow.cboDemuxerThread.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Demuxer Buffersize
            // -------------------------
            string demuxerBufferSize = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxDemuxerBuffersize.Text))
                demuxerBufferSize = "demuxer-lavf-buffersize=" + mainwindow.tbxDemuxerBuffersize.Text.ToString();

            // -------------------------
            // Demuxer Readahead
            // -------------------------
            string demuxerReadAhead = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxDemuxerReadahead.Text))
                demuxerReadAhead = "demuxer-readahead-secs=" + mainwindow.tbxDemuxerReadahead.Text.ToString();

            // -------------------------
            // Demuxer MKV Subtitle Preroll
            // -------------------------
            string demuxerMKVSubtitlePreroll = string.Empty;

            if ((string)(mainwindow.cboDemuxerMKVSubPreroll.SelectedItem ?? string.Empty) == "yes")
                demuxerMKVSubtitlePreroll = "demuxer-mkv-subtitle-preroll";


            // --------------------------------------------------
            // Cache
            // --------------------------------------------------

            // -------------------------
            // Cache
            // -------------------------
            string cache = "cache=" + (mainwindow.cboCache.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Cache Default
            // -------------------------
            string cacheDefault = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheDefault.Text))
                cacheDefault = "cache-default=" + mainwindow.tbxCacheDefault.Text.ToString();

            // -------------------------
            // Cache Initial
            // -------------------------
            string initial = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheInitial.Text))
                initial = "cache-initial=" + mainwindow.tbxCacheInitial.Text.ToString();

            // -------------------------
            // Cache Seek Min
            // -------------------------
            string seekMin = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheSeekMin.Text))
                seekMin = "cache-seek-min=" + mainwindow.tbxCacheSeekMin.Text.ToString();

            // -------------------------
            // Cache Backbuffer
            // -------------------------
            string backBuffer = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheBackbuffer.Text))
                backBuffer = "cache-backBuffer=" + mainwindow.tbxCacheBackbuffer.Text.ToString();

            // -------------------------
            // Second
            // -------------------------
            string seconds = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheSeconds.Text))
                seconds = "cache-secs=" + mainwindow.tbxCacheSeconds.Text.ToString();

            // -------------------------
            // Cache File
            // -------------------------
            string file = "cache-file=" + (mainwindow.cboCacheFile.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Cache File Size
            // -------------------------
            string fileSize = string.Empty;

            if (!string.IsNullOrWhiteSpace(mainwindow.tbxCacheFileSize.Text))
                fileSize = "cache-file-size=" + mainwindow.tbxCacheFileSize.Text.ToString();

            // -------------------------
            // YouTube
            // -------------------------
            string youTube = "ytdl=yes"
                            + "\r\n"
                            + "ytdl-format=(bestvideo[ext=webm]/bestvideo[fps=60])+(bestaudio[acodec=opus]/bestaudio)/best";


            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listStream = new List<string>()
            {
                title,

                // Demuxer
                demuxThread,
                demuxerBufferSize,
                demuxerReadAhead,
                demuxerMKVSubtitlePreroll,

                // Cache
                cache,
                cacheDefault,
                initial,
                seekMin,
                backBuffer,
                seconds,
                file,
                fileSize,
                youTube,
            };

            // -------------------------
            // Join
            // -------------------------
            string stream = string.Join("\r\n", listStream
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return stream;
        }
    }
}
