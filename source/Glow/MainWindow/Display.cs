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
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;

namespace Glow
{
    public partial class MainWindow : Window
    {
        /// <summary>
        ///    Preview OSD Font Color
        /// </summary>
        public static void PreviewOSD_FontColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.DisplayView.OSD_FontColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.DisplayView.OSD_FontColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdFontColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdFontColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///    Preview OSD Border Color
        /// </summary>
        public static void PreviewOSDBorderColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.DisplayView.OSD_FontColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.DisplayView.OSD_BorderColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdBorderColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdBorderColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///    Preview OSD Shadow Color
        /// </summary>
        public static void PreviewOSDShadowColor(MainWindow mainwindow)
        {
            try
            {
                // Color
                if (VM.DisplayView.OSD_ShadowColor_Text.Length == 6)
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#" + VM.DisplayView.OSD_ShadowColor_Text);
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdShadowColorPreview.Fill = brushPreview;
                }
                // Transparent
                else
                {
                    System.Drawing.Color color = ColorPickerWindow.ConvertHexToRGB("#000000");
                    System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(0, color.R, color.G, color.B);
                    System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(mediaColor);
                    mainwindow.osdShadowColorPreview.Fill = brushPreview;
                }
            }
            catch
            {

            }
        }


        // --------------------------------------------------
        // OSD Controls
        // --------------------------------------------------
        /// <summary>
        ///     OSD
        /// </summary>
        private void cboOSD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Disabling OSD disables its options           
            if (VM.DisplayView.OSD_SelectedItem == "no")
            {
                // Fractions
                VM.DisplayView.OSD_Fractions_SelectedItem = "default";
                // Duration
                VM.DisplayView.OSD_Duration_Text = "";
                // Level
                VM.DisplayView.OSD_Level_SelectedItem = "default";
            }
        }

        /// <summary>
        ///     OSD Fractions
        /// </summary>
        private void cboOSD_Fractions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enables OSD
            if (VM.DisplayView.OSD_Fractions_SelectedItem == "yes")
            {
                VM.DisplayView.OSD_SelectedItem = "yes";
            }
        }

        /// <summary>
        ///     OSD Duration
        /// </summary>
        private void tbxOSDDuration_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Enables OSD
            if (VM.DisplayView.OSD_Duration_Text != string.Empty)
            {
                VM.DisplayView.OSD_SelectedItem = "yes";
            }
        }

        /// <summary>
        ///     OSD Level
        /// </summary>
        private void cboOSD_Level_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enables OSD
            if (VM.DisplayView.OSD_Level_SelectedItem != "default")
            {
                VM.DisplayView.OSD_SelectedItem = "yes";
            }
        }

        /// <summary>
        ///    OSD Font Button
        /// </summary>
        private void btnOSD_FontColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("osdFont");
        }

        /// <summary>
        ///     OSD Font Color TextBox
        /// </summary>
        private void tbxOSD_FontColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewOSD_FontColor(this);
        }
        private void tbxOSD_FontColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxOSD_FontColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }


        /// <summary>
        ///    OSD Border Button
        /// </summary>
        private void btnOSDBorderColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("osdBorder");
        }

        /// <summary>
        ///     OSD Font Color TextBox
        /// </summary>
        private void tbxOSDBorderColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewOSDBorderColor(this);
        }
        private void tbxOSDBorderColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxOSDBorderColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }


        /// <summary>
        ///    OSD Shadow Button
        /// </summary>
        private void btnOSDShadowColor_Click(object sender, RoutedEventArgs e)
        {
            OpenColorPickerWindow("osdShadow");
        }

        /// <summary>
        ///     OSD Shadow Color TextBox
        /// </summary>
        private void tbxOSDShadowColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            PreviewOSDShadowColor(this);
        }
        private void tbxOSDShadowColor_KeyDown(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }
        private void tbxOSDShadowColor_KeyUp(object sender, KeyEventArgs e)
        {
            AllowOnlyAlphaNumeric(e);
        }

        /// <summary>
        ///    OSD Shadow
        /// </summary>
        //private void cboOSD_FontShadowColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Get Selected Item
        //    ComboBoxItem selectedItem = (ComboBoxItem)(cboOSDShadowColor.SelectedValue);
        //    string selected = (string)(selectedItem.Content);

        //    // Disable
        //    if (selected == "None")
        //    {
        //        // slider
        //        slOSDShadowOffset_IsEnabled = false;
        //        tbxOSDShadowOffset_IsEnabled = false;
        //        // textbox
        //        tbxOSDShadowOffset_Text = "0.00";
        //    }
        //    // Enable
        //    else
        //    {
        //        // slider
        //        slOSDShadowOffset_IsEnabled = true;
        //        // textbox
        //        tbxOSDShadowOffset_IsEnabled = true;
        //    }

        //}

        /// <summary>
        ///     OSD Scale DoubleClick
        /// </summary>
        private void slOSC_Scale_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.DisplayView.OSC_Scale_Value = 0.5;
        }

        /// <summary>
        ///     OSD Bar Width DoubleClick
        /// </summary>
        private void slOSC_BarWidth_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.DisplayView.OSC_BarWidth_Value = 95;
        }

        /// <summary>
        ///     OSD Bar Height DoubleClick
        /// </summary>
        private void slOSC_BarHeight_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.DisplayView.OSC_BarHeight_Value = 2;
        }

        /// <summary>
        ///     OSD Shadow Offset DoubleClick
        /// </summary>
        private void slOSDShadowOffset_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.DisplayView.OSD_ShadowOffset_Value = 1.25;
        }
    }
}