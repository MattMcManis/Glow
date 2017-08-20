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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Glow
{
    public partial class Audio
    {
        /// <summary>
        ///    Audio Config
        /// </summary>
        public static String AudioConfig(MainWindow mainwindow)
        {
            // -------------------------
            // Title
            // -------------------------
            string title = "# [ AUDIO ]";

            // -------------------------
            // Audio Driver
            // -------------------------
            string driver = "ao=" + mainwindow.cboAudioDriver.SelectedItem.ToString();

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

            // -------------------------
            // Channels
            // -------------------------
            string channels = "audio-channels=" + mainwindow.cboChannels.SelectedItem.ToString();

            // -------------------------
            // Volume
            // -------------------------
            string volume = "volume=" + mainwindow.cboVolume.SelectedItem.ToString();

            // -------------------------
            // Soft Volume
            // -------------------------
            string softvolume = "softvol=" + mainwindow.cboSoftVolume.SelectedItem.ToString();

            // -------------------------
            // Normalize
            // -------------------------
            string normalize = "audio-normalize-downmix=" + mainwindow.cboNormalize.SelectedItem.ToString();

            // -------------------------
            // Scale Tempo
            // -------------------------
            string scaletempo = "audio-pitch-correction=" + mainwindow.cboScaleTempo.SelectedItem.ToString();

            // -------------------------
            // Normalize
            // -------------------------
            string loadfiles = "audio-file-auto=" + mainwindow.cboAudioLoadFiles.SelectedItem.ToString();

            // -------------------------
            // Combine
            // -------------------------
            List<string> listAudio = new List<string>()
            {
                title,
                driver,
                languages,
                channels,
                volume,
                softvolume,
                normalize,
                scaletempo,
                loadfiles,
            };

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
