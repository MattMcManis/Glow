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
using System.Windows;

namespace Glow
{
    public partial class Audio
    {
        /// <summary>
        ///    Audio Config
        /// </summary>
        public static String AudioConfig(MainWindow mainwindow)
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

            if ((string)(mainwindow.cboAudioDriver.SelectedItem ?? string.Empty) != "default")
                driver = "ao=" + (mainwindow.cboAudioDriver.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Load Files
            // -------------------------
            string loadFiles = string.Empty;

            if ((string)(mainwindow.cboAudioLoadFiles.SelectedItem ?? string.Empty) != "default")
                loadFiles = "audio-file-auto=" + (mainwindow.cboAudioLoadFiles.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Channels
            // -------------------------
            string channels = string.Empty;

            if ((string)(mainwindow.cboChannels.SelectedItem ?? string.Empty) != "default")
                channels = "audio-channels=" + (mainwindow.cboChannels.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Volume
            // -------------------------
            string volume = "volume=" + mainwindow.tbxVolume.Text.ToString();

            // -------------------------
            // Max Volume
            // -------------------------
            string volumeMax = "volume-max=" + mainwindow.tbxVolumeMax.Text.ToString();

            // -------------------------
            // Soft Volume
            // -------------------------
            string softVolume = string.Empty;

            if ((string)(mainwindow.cboSoftVolume.SelectedItem ?? string.Empty) != "default")
                softVolume = "softvol=" + (mainwindow.cboSoftVolume.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Soft Volume Max
            // -------------------------
            string softVolumeMax = "softvol-max=" + mainwindow.tbxSoftVolumeMax.Text.ToString();

            // -------------------------
            // Normalize
            // -------------------------
            string normalize = string.Empty;

            if ((string)(mainwindow.cboNormalize.SelectedItem ?? string.Empty) != "default")
                normalize = "audio-normalize-downmix=" + (mainwindow.cboNormalize.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Scale Tempo
            // -------------------------
            string scaleTempo = string.Empty;

            if ((string)(mainwindow.cboScaleTempo.SelectedItem ?? string.Empty) != "default")
                scaleTempo = "audio-pitch-correction=" + (mainwindow.cboScaleTempo.SelectedItem ?? string.Empty).ToString();

            // -------------------------
            // Languages
            // -------------------------
            List<string> listAudioLanguages = new List<string>();

            // Add Each Language In Priority Order from the top to Audio Languages List
            // Regardless of Order checked in
            foreach (string item in mainwindow.listViewAudioLanguages.Items)
            {
                // If list contains a checked item
                if (mainwindow.listViewAudioLanguages.SelectedItems.Contains(item))
                {
                    // Convert Selected Language (e.g. English) into (eng,en,enUS,en-US)
                    string language = Languages.LanguageCode(item);

                    // Add language code to list
                    listAudioLanguages.Add(language);
                }
            }

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
                softVolume,
                softVolumeMax,
                normalize,
                scaleTempo,
                languages,
            };

            // -------------------------
            // Join
            // -------------------------
            string audio = string.Join("\r\n", listAudio
                .Where(s => !string.IsNullOrEmpty(s))
                );

            // -------------------------
            // Return
            // -------------------------
            return audio;
        }
     }
}
