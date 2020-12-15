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
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using ViewModel;
using System.Collections.ObjectModel;

namespace Glow
{
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     Volume Slider DoubleClick
        /// </summary>
        private void slVolume_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.AudioView.Volume_Value = 100;
        }

        /// <summary>
        ///     Volume Max Slider DoubleClick
        /// </summary>
        private void slVolumeMax_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.AudioView.VolumeMax_Value = 100;
        }

        /// <summary>
        ///     Soft Volume Max Slider DoubleClick
        /// </summary>
        //private void slSoftVolumeMax_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    // return to default
        //    slSoftVolumeMax_Value = 150;
        //}

        /// <summary>
        ///    Audio Languages
        /// </summary>
        private void listViewAudioLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If ListView Selected Items Contains Any Items
            // Clear before adding new Selected Items
            if (VM.AudioView.LanguagePriority_ListView_SelectedItems.Any())
            {
                VM.AudioView.LanguagePriority_ListView_SelectedItems.Clear();
                VM.AudioView.LanguagePriority_ListView_SelectedItems.TrimExcess();
            }

            // Create Selected Items List for ViewModel
            //VM.AudioView.LanguagePriority_ListView_SelectedItems = listViewAudioLanguages.SelectedItems
            //                                                                       .Cast<string>()
            //                                                                       .ToList();

            // Remove ListView Items Duplicates
            VM.AudioView.LanguagePriority_ListView_Items = new ObservableCollection<string>(VM.AudioView.LanguagePriority_ListView_Items
                                                                                            .Distinct()
                                                                                            .ToList()
                                                                                            .AsEnumerable()
                                                                                            );
            //VM.AudioView.LanguagePriority_ListView_Items = VM.AudioView.LanguagePriority_ListView_Items.Distinct().ToList();

            // Build the list by Order Arranged
            for (var i = 0; i < VM.AudioView.LanguagePriority_ListView_Items.Count; i++)
            {
                if (listViewAudioLanguages.SelectedItems//VM.AudioView.LanguagePriority_ListView_SelectedItems
                                          .Cast<string>()
                                          .ToList()
                                          .Contains(VM.AudioView.LanguagePriority_ListView_Items[i]))
                {
                    VM.AudioView.LanguagePriority_ListView_SelectedItems.Add(VM.AudioView.LanguagePriority_ListView_Items[i]);
                }
            }

            // Remove ListView Selected Items Duplicates
            VM.AudioView.LanguagePriority_ListView_SelectedItems = VM.AudioView.LanguagePriority_ListView_SelectedItems
                                                                   .Distinct()
                                                                   .ToList();
            //MessageBox.Show(string.Join("\n", listViewAudioLanguages.SelectedItems.Cast<string>().ToList())); //debug
        }

        /// <summary>
        ///    Audio Language Up
        /// </summary>
        private void buttonAudioLanguageUp_Click(object sender, RoutedEventArgs e)
        {
            if (VM.AudioView.LanguagePriority_ListView_SelectedItems.Count > 0)
            {
                var selectedIndex = VM.AudioView.LanguagePriority_ListView_SelectedIndex;

                if (selectedIndex > 0)
                {
                    // ListView Items
                    var itemlsvItems = VM.AudioView.LanguagePriority_ListView_Items[selectedIndex];
                    VM.AudioView.LanguagePriority_ListView_Items.RemoveAt(selectedIndex);
                    VM.AudioView.LanguagePriority_ListView_Items.Insert(selectedIndex - 1, itemlsvItems);

                    // Highlight Selected Index
                    VM.AudioView.LanguagePriority_ListView_SelectedIndex = selectedIndex - 1;
                }
            }
        }
        /// <summary>
        ///    Audio Language Down
        /// </summary>
        private void buttonAudioLanguageDown_Click(object sender, RoutedEventArgs e)
        {
            if (VM.AudioView.LanguagePriority_ListView_SelectedItems.Count > 0)
            {
                var selectedIndex = VM.AudioView.LanguagePriority_ListView_SelectedIndex;

                if (selectedIndex + 1 < VM.AudioView.LanguagePriority_ListView_Items.Count)
                {
                    // ListView Items
                    var itemlsvItems = VM.AudioView.LanguagePriority_ListView_Items[selectedIndex];
                    VM.AudioView.LanguagePriority_ListView_Items.RemoveAt(selectedIndex);
                    VM.AudioView.LanguagePriority_ListView_Items.Insert(selectedIndex + 1, itemlsvItems);

                    // Highlight Selected Index
                    VM.AudioView.LanguagePriority_ListView_SelectedIndex = selectedIndex + 1;
                }
            }
        }
        /// <summary>
        ///    Audio Select All
        /// </summary>
        private void buttonAudioLanguageSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewAudioLanguages.SelectAll();
        }
        /// <summary>
        ///    Audio Deselect All
        /// </summary>
        private void buttonAudioLanguageDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewAudioLanguages.SelectedIndex = -1;
        }
    }
}