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
        ///     Geometry X
        /// </summary>
        private void slGeometryX_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.GeneralView.GeometryX_Value = 50;
        }

        /// <summary>
        ///     Geometry X
        /// </summary>
        private void slGeometryY_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.GeneralView.GeometryY_Value = 50;
        }

        /// <summary>
        ///     Autofit Width
        /// </summary>
        private void slAutofitWidth_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.GeneralView.AutofitWidth_Value = 100;
        }

        /// <summary>
        ///     Autofit Height
        /// </summary>
        private void slAutofitHeight_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.GeneralView.AutofitHeight_Value = 95;
        }

        /// <summary>
        ///     Log Label Reset
        /// </summary>
        private void lbLogPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            VM.GeneralView.LogPath_Text = "";
        }

        /// <summary>
        ///     Log Path
        /// </summary>
        private void tbxLogPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            // Open Folder Browser
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            // If OK
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                VM.GeneralView.LogPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
            }
        }

        /// <summary>
        ///     Screenshot Label Reset
        /// </summary>
        private void lbScreenshotPath_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VM.GeneralView.ScreenshotPath_Text = "";
        }

        /// <summary>
        ///     Screenshot Path
        /// </summary>
        private void tbxScreenshotPath_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open Folder Browser
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            // If OK
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                VM.GeneralView.ScreenshotPath_Text = folderBrowserDialog.SelectedPath.TrimEnd('\\') + @"\";
            }
        }

        /// <summary>
        ///     Screenshot Format
        /// </summary>
        private void cboScreenshotFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Change Label
            // Change Quality Slider Maximum

            // jpg
            if (VM.GeneralView.ScreenshotFormat_SelectedItem == "jpg" ||
                VM.GeneralView.ScreenshotFormat_SelectedItem == "jpeg")
            {
                VM.GeneralView.ScreenshotQuality_Content = "Quality";
                VM.GeneralView.ScreenshotQuality_Maximum = 100;
                VM.GeneralView.ScreenshotQuality_Value = 95;
            }

            // png
            else if (VM.GeneralView.ScreenshotFormat_SelectedItem == "png")
            {
                VM.GeneralView.ScreenshotQuality_Content = "Compression";
                VM.GeneralView.ScreenshotQuality_Maximum = 9;
                VM.GeneralView.ScreenshotQuality_Value = 7;
            }

        }

        /// <summary>
        ///     Screenshot Quality DoubleClick
        /// </summary>
        private void slScreenshotQuality_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // jpg
            if (VM.GeneralView.ScreenshotFormat_SelectedItem == "jpg" ||
                VM.GeneralView.ScreenshotFormat_SelectedItem == "jpeg")
            {
                // return to default
                VM.GeneralView.ScreenshotQuality_Value = 95;
            }

            // png
            else if (VM.GeneralView.ScreenshotFormat_SelectedItem == "png")
            {
                // return to default
                VM.GeneralView.ScreenshotQuality_Value = 7;
            }
        }
    }
}