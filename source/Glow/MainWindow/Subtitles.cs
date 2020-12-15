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
using System.IO;
using System.Windows;
using System.Configuration;
using Glow.Properties;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Text;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Net;
using ViewModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Glow
{
    public partial class MainWindow : Window
    {
        /// <summary>
        ///    Preview Subtitle Font Color
        /// </summary>
        public static void PreviewFontColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.SubtitlesView.FontColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.SubtitlesView.FontColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesFontColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesFontColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///    Preview Subtitle Border Color
        /// </summary>
        public static void PreviewBorderColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.SubtitlesView.BorderColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.SubtitlesView.BorderColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesBorderColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesBorderColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///    Preview Subtitle Shadow Color
        /// </summary>
        public static void PreviewShadowColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.SubtitlesView.ShadowColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.SubtitlesView.ShadowColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesShadowColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.subtitlesShadowColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }


        /// <summary>
        ///     Subtitles
        /// </summary>
        private void cboSubtitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Embedded Fonts Enabled
            if (VM.SubtitlesView.Subtitles_SelectedItem == "yes")
                // Disable Custom Font
                VM.SubtitlesView.LoadFiles_SelectedItem = "fuzzy";
            else if (VM.SubtitlesView.Subtitles_SelectedItem == "no")
                VM.SubtitlesView.LoadFiles_SelectedItem = "no";
            else
                VM.SubtitlesView.LoadFiles_SelectedItem = "default";
        }

        /// <summary>
        ///    Subtitle Embedded Fonts
        /// </summary>
        private void cboEmbeddedFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Embedded Fonts Enabled
            if (VM.SubtitlesView.EmbeddedFonts_SelectedItem == "yes")
                // Disable Custom Font
                VM.SubtitlesView.EmbeddedFonts_IsEnabled = false;

            // Embedded Fonts Disabled
            else if (VM.SubtitlesView.EmbeddedFonts_SelectedItem == "no")
                // Enable Custom Font
                VM.SubtitlesView.EmbeddedFonts_IsEnabled = true;
        }


        /// <summary>
        ///     Subtitle Font Color Button
        /// </summary>
        private void btnSubtitleFontColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("subtitlesFont");
        }
        /// <summary>
        ///     Subtitles Font Color TextBox
        /// </summary>
        private void tbxFontColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewFontColor(this);
        }
        private void tbxFontColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxFontColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }


        /// <summary>
        ///    Subtitle Border Color Button
        /// </summary>
        private void btnSubtitleBorderColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("subtitlesBorder");
        }
        /// <summary>
        ///     Subtitles Border Color TextBox
        /// </summary>
        private void tbxBorderColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewBorderColor(this);
        }
        private void tbxBorderColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxBorderColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }


        /// <summary>
        ///    Subtitle Shadow Color Button
        /// </summary>
        private void btnSubtitleShadowColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("subtitlesShadow");
        }
        /// <summary>
        ///     Subtitles Shadow Color TextBox
        /// </summary>
        private void tbxShadowColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewShadowColor(this);
        }
        private void tbxShadowColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxShadowColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }


        /// <summary>
        ///    Subtitle Shadow Color
        /// </summary>
        //private void cboSubtitleShadowColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Get Selected Item
        //    ComboBoxItem selectedItem = (ComboBoxItem)(cboShadowColor.SelectedValue);
        //    string selected = (string)(selectedItem.Content);

        //    // Disable
        //    if (selected == "None")
        //    {
        //        // slider
        //        slShadowOffset_IsEnabled = false;
        //        // textbox
        //        tbxShadowOffset_IsEnabled = false;
        //        tbxShadowOffset_Text = "0.00";
        //    }
        //    // Enable
        //    else
        //    {
        //        // slider
        //        slShadowOffset_IsEnabled = true;
        //        // textbox
        //        tbxShadowOffset_IsEnabled = true;
        //    }
        //}

        /// <summary>
        ///     Subtitle Position DoubleClick
        /// </summary>
        private void slPosition_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.SubtitlesView.Position_Value = 95;
        }

        /// <summary>
        ///     Subtitle Shadow Offset DoubleClick
        /// </summary>
        private void slShadowOffset_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.SubtitlesView.ShadowOffset_Value = 1.25;
        }

        /// <summary>
        ///    Subtitle Languages
        /// </summary>
        private void listViewSubtitleLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If ListView Selected Items Contains Any Items
            // Clear before adding new Selected Items
            if (VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Any())
            {
                VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Clear();
                VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.TrimExcess();
            }

            // Create Selected Items List for ViewModel
            //VM.SubtitlesView.LanguagePriority_ListView_SelectedItems = lstvLanguagePriority.SelectedItems
            //                                                                       .Cast<string>()
            //                                                                       .ToList();

            // Remove ListView Items Duplicates
            VM.SubtitlesView.LanguagePriority_ListView_Items = new ObservableCollection<string>(VM.SubtitlesView.LanguagePriority_ListView_Items
                                                                                                .Distinct()
                                                                                                .ToList()
                                                                                                .AsEnumerable()
                                                                                                );
            //VM.SubtitlesView.LanguagePriority_ListView_Items = VM.SubtitlesView.LanguagePriority_ListView_Items.Distinct().ToList();

            // Build the list by Order Arranged
            for (var i = 0; i < VM.SubtitlesView.LanguagePriority_ListView_Items.Count; i++)
            {
                if (/*VM.SubtitlesView.LanguagePriority_ListView_SelectedItems*/listViewSubtitlesLanguages.SelectedItems
                                    .Cast<string>()
                                    .ToList()
                                    .Contains(VM.SubtitlesView.LanguagePriority_ListView_Items[i]))
                {
                    VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Add(VM.SubtitlesView.LanguagePriority_ListView_Items[i]);
                }
            }

            // Remove ListView Selected Items Duplicates
            VM.SubtitlesView.LanguagePriority_ListView_SelectedItems = VM.SubtitlesView.LanguagePriority_ListView_SelectedItems
                                                                       .Distinct()
                                                                       .ToList();
            //MessageBox.Show(string.Join("\n", lstvLanguagePriority.SelectedItems.Cast<string>().ToList())); //debug
        }

        /// <summary>
        ///    Subtitle Language Up
        /// </summary>
        private void buttonSubtitleLanguageUp_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Count > 0)
            {
                var selectedIndex = VM.SubtitlesView.LanguagePriority_ListView_SelectedIndex;

                if (selectedIndex > 0)
                {
                    // ListView Items
                    var itemlsvItems = VM.SubtitlesView.LanguagePriority_ListView_Items[selectedIndex];
                    VM.SubtitlesView.LanguagePriority_ListView_Items.RemoveAt(selectedIndex);
                    VM.SubtitlesView.LanguagePriority_ListView_Items.Insert(selectedIndex - 1, itemlsvItems);

                    // Highlight Selected Index
                    VM.SubtitlesView.LanguagePriority_ListView_SelectedIndex = selectedIndex - 1;
                }
            }
        }
        /// <summary>
        ///    Subtitle Language Down
        /// </summary>
        private void buttonSubtitleLanguageDown_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SubtitlesView.LanguagePriority_ListView_SelectedItems.Count > 0)
            {
                var selectedIndex = VM.SubtitlesView.LanguagePriority_ListView_SelectedIndex;

                if (selectedIndex + 1 < VM.SubtitlesView.LanguagePriority_ListView_Items.Count)
                {
                    // ListView Items
                    var itemlsvItems = VM.SubtitlesView.LanguagePriority_ListView_Items[selectedIndex];
                    VM.SubtitlesView.LanguagePriority_ListView_Items.RemoveAt(selectedIndex);
                    VM.SubtitlesView.LanguagePriority_ListView_Items.Insert(selectedIndex + 1, itemlsvItems);

                    // Highlight Selected Index
                    VM.SubtitlesView.LanguagePriority_ListView_SelectedIndex = selectedIndex + 1;
                }
            }
        }
        /// <summary>
        ///    Subtitle Select All
        /// </summary>
        private void buttonSubtitleLanguageSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitlesLanguages.SelectAll();
        }
        /// <summary>
        ///    Subtitle Deselect All
        /// </summary>
        private void buttonSubtitleLanguageDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            listViewSubtitlesLanguages.SelectedIndex = -1;
        }

    }
}