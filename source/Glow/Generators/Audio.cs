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
using System.Windows;
using ViewModel;

namespace Generate
{
    public class Audio
    {
        /// <summary>
        ///    Audio Config
        /// </summary>
        public static String Config(/*MainWindow mainwindow*/)
        {
            // --------------------------------------------------
            // Main
            // --------------------------------------------------

            // -------------------------
            // Title
            // -------------------------
            string title = "## AUDIO ##";

            // -------------------------
            // Audio Driver
            // -------------------------
            string driver = string.Empty;

            if (VM.AudioView.AudioDriver_SelectedItem != "default")
                driver = "ao=" + VM.AudioView.AudioDriver_SelectedItem;

            // -------------------------
            // Load Files
            // -------------------------
            string loadFiles = string.Empty;

            if (VM.AudioView.AudioLoadFiles_SelectedItem != "default")
                loadFiles = "audio-file-auto=" + VM.AudioView.AudioLoadFiles_SelectedItem;

            // -------------------------
            // Channels
            // -------------------------
            string channels = string.Empty;

            if (VM.AudioView.Channels_SelectedItem != "default")
                channels = "audio-channels=" + VM.AudioView.Channels_SelectedItem;

            // -------------------------
            // Volume
            // -------------------------
            string volume = string.Empty;

            if (VM.AudioView.Volume_Value != 0)
                volume = "volume=" + VM.AudioView.Volume_Value/*Volume_Text*/;

            // -------------------------
            // Max Volume
            // -------------------------
            string volumeMax = string.Empty;

            if (VM.AudioView.VolumeMax_Value != 0)
                volumeMax = "volume-max=" + VM.AudioView.VolumeMax_Value/*VolumeMax_Text*/;


            // -------------------------
            // Soft Volume Max
            // -------------------------
            //string softVolumeMax = string.Empty;

            //if (VM.AudioView.SoftVolumeMax_Value != 0)
            //    softVolumeMax = "softvol-max=" + VM.AudioView.SoftVolumeMax_Text;

            // -------------------------
            // Normalize
            // -------------------------
            string normalize = string.Empty;

            if (VM.AudioView.Normalize_SelectedItem != "default")
                normalize = "audio-normalize-downmix=" + VM.AudioView.Normalize_SelectedItem;

            // -------------------------
            // Scale Tempo
            // -------------------------
            string scaleTempo = string.Empty;

            if (VM.AudioView.ScaleTempo_SelectedItem != "default")
                scaleTempo = "audio-pitch-correction=" + VM.AudioView.ScaleTempo_SelectedItem;

            // -------------------------
            // Languages
            // -------------------------
            List<string> listAudioLanguages = new List<string>();

            // Add Each Language In Priority Order from the top to Audio Languages List
            // Regardless of Order checked in
            //foreach (string item in mainwindow.listViewAudioLanguages_Items)
            //{
            //    // If list contains a checked item
            //    if (mainwindow.listViewAudioLanguages_SelectedItems.Contains(item))
            //    {
            //        // Convert Selected Language (e.g. English) into (eng,en,enUS,en-US)
            //        string language = Languages.LanguageCode(item);

            //        // Add language code to list
            //        listAudioLanguages.Add(language);
            //    }
            //}

            string languages = string.Empty;
            if (listAudioLanguages.Count() != 0)
                languages = "alang=" + string.Join(",", listAudioLanguages.Where(s => !string.IsNullOrEmpty(s)));

            // --------------------------------------------------
            // Combine
            // --------------------------------------------------
            List<string> listAudio = new List<string>()
            {
                title,
                driver,
                loadFiles,
                channels,
                volume,
                volumeMax,
                //softVolume,
                //softVolumeMax,
                normalize,
                scaleTempo,
                languages,
            };

            // -------------------------
            // Join
            // -------------------------
            return string.Join("\r\n", listAudio
                                       .Where(s => !string.IsNullOrEmpty(s))
                              );
        }

     }
}
