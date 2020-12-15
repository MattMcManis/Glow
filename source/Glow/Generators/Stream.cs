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
using Glow;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace Generate
{
    public class Stream
    {
        /// <summary>
        ///    Stream Config
        /// </summary>
        public static String Config()
        {
            // -------------------------
            // Title
            // -------------------------
            string title = "## STREAM ##";

            // --------------------------------------------------
            // Demuxer
            // --------------------------------------------------

            // -------------------------
            // Demuxer Thread
            // -------------------------
            string demuxThread = string.Empty;

            if (VM.StreamView.DemuxerThread_SelectedItem != "default")
                demuxThread = "demuxer-thread=" + VM.StreamView.DemuxerThread_SelectedItem;

            // -------------------------
            // Demuxer Buffersize
            // -------------------------
            string demuxerBufferSize = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.DemuxerBuffersize_Text))
                demuxerBufferSize = "demuxer-lavf-buffersize=" + VM.StreamView.DemuxerBuffersize_Text;

            // -------------------------
            // Demuxer Readahead
            // -------------------------
            string demuxerReadAhead = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.DemuxerReadahead_Text))
                demuxerReadAhead = "demuxer-readahead-secs=" + VM.StreamView.DemuxerReadahead_Text;

            // -------------------------
            // Demuxer MKV Subtitle Preroll
            // -------------------------
            string demuxerMKVSubtitlePreroll = string.Empty;

            if (VM.StreamView.DemuxerMKVSubPreroll_SelectedItem == "yes")
                demuxerMKVSubtitlePreroll = "demuxer-mkv-subtitle-preroll";


            // --------------------------------------------------
            // YouTube
            // --------------------------------------------------

            // -------------------------
            // youtube-dl
            // -------------------------
            string youtubedl = string.Empty;
            // ignore default

            if (VM.StreamView.YouTubeDL_SelectedItem == "yes")
                youtubedl = "ytdl=yes";

            // -------------------------
            // Quality
            // -------------------------
            string youTubeQuality = string.Empty;
            // ignore default

            // Best
            if (VM.StreamView.YouTubeDLQuality_SelectedItem == "best")
                youTubeQuality = "ytdl-format=bestvideo[ext=mp4][width<=1920][height<=1080]+bestaudio[ext=m4a]/best[ext=mp4]/best";
            // Good
            else if (VM.StreamView.YouTubeDLQuality_SelectedItem == "good")
                youTubeQuality = "ytdl-format=bestvideo[ext=webm][height<=?720]";
            // Worst
            else if (VM.StreamView.YouTubeDLQuality_SelectedItem == "worst")
                youTubeQuality = "ytdl-format=worst";


            // --------------------------------------------------
            // Cache
            // --------------------------------------------------

            // -------------------------
            // Cache
            // -------------------------
            string cache = string.Empty;

            if (VM.StreamView.Cache_SelectedItem != "default")
                cache = "cache=" + VM.StreamView.Cache_SelectedItem;

            // -------------------------
            // Cache Default
            // -------------------------
            string cacheDefault = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheDefault_Text))
                cacheDefault = "cache-default=" + VM.StreamView.CacheDefault_Text;

            // -------------------------
            // Cache Initial
            // -------------------------
            string initial = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheInitial_Text))
                initial = "cache-initial=" + VM.StreamView.CacheInitial_Text;

            // -------------------------
            // Cache Seek Min
            // -------------------------
            string seekMin = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheSeekMin_Text))
                seekMin = "cache-seek-min=" + VM.StreamView.CacheSeekMin_Text;

            // -------------------------
            // Cache Backbuffer
            // -------------------------
            string backBuffer = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheBackbuffer_Text))
                backBuffer = "cache-backbuffer=" + VM.StreamView.CacheBackbuffer_Text;

            // -------------------------
            // Second
            // -------------------------
            string seconds = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheSeconds_Text))
                seconds = "cache-secs=" + VM.StreamView.CacheSeconds_Text;

            // -------------------------
            // Cache File
            // -------------------------
            string file = string.Empty;

            if (VM.StreamView.CacheFile_SelectedItem != "default")
                file = "cache-file=" + VM.StreamView.CacheFile_SelectedItem;

            // -------------------------
            // Cache File Size
            // -------------------------
            string fileSize = string.Empty;

            if (!string.IsNullOrWhiteSpace(VM.StreamView.CacheFileSize_Text))
                fileSize = "cache-file-size=" + VM.StreamView.CacheFileSize_Text;

            // -------------------------
            // YouTube
            // -------------------------
            //string youTube = "ytdl=yes"
            //                + "\r\n"
            //                + "ytdl-format=(bestvideo[ext=webm]/bestvideo[fps=60])+(bestaudio[acodec=opus]/bestaudio)/best";


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

                // YouTube
                youtubedl,
                youTubeQuality,

                // Cache
                cache,
                //cacheDefault,
                //initial,
                //seekMin,
                //backBuffer,
                //seconds,
                //file,
                //fileSize
            };

            // -------------------------
            // Join
            // -------------------------
            return string.Join("\r\n", listStream
                                       .Where(s => !string.IsNullOrEmpty(s))
                              );
        }
    }
}
