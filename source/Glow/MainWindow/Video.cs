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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;

namespace Glow
{
    public partial class MainWindow : Window
    {
        /// <summary>
        ///    Video Driver
        /// </summary>
        private void cboVideoDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable OpenGL PBO
            // Enable/Disable Scaling

            // Default
            if (VM.VideoView.VideoDriver_SelectedItem == "default")
            {
                // Video Driver API
                VM.VideoView.VideoDriverAPI_SelectedItem = "default";
                // Scaling On
                VM.VideoView.Sigmoid_SelectedItem = "default";
                // Scale
                VM.VideoView.Scale_SelectedItem = "default";
                // Chroma Scale
                VM.VideoView.ChromaScale_SelectedItem = "default";
                // Downscale
                VM.VideoView.Downscale_SelectedItem = "default";
                // Interpolation Scale
                VM.VideoView.InterpolationScale_SelectedItem = "default";
            }

            // Enabled
            if (VM.VideoView.VideoDriver_SelectedItem == "default" ||
                VM.VideoView.VideoDriver_SelectedItem == "gpu" ||
                VM.VideoView.VideoDriver_SelectedItem == "gpu-hq"
                //vm.VideoDriver_SelectedItem == "opengl" || // old
                //vm.VideoDriver_SelectedItem == "opengl-hq" // old
                //vm.VideoDriver_SelectedItem == "direct3d"
                //vm.VideoDriver_SelectedItem == "vaapi"
                //vm.VideoDriver_SelectedItem == "caca"
                )
            {
                // PBO On
                VM.VideoView.OpenGLPBO_IsEnabled = true;
                VM.VideoView.OpenGLPBO_SelectedItem = "default";

                // Scaling On
                VM.VideoView.Sigmoid_IsEnabled = true;
                //cboSigmoid_SelectedItem = "default";
                // Scale
                VM.VideoView.Scale_IsEnabled = true;
                //cboScale_SelectedItem = "default";
                VM.VideoView.ScaleAntiring_IsEnabled = true;
                //vm.ScaleAntiring_IsEnabled = true;
                // Chroma Scale
                VM.VideoView.ChromaScale_IsEnabled = true;
                //cboChromaScale_SelectedItem = "default";
                VM.VideoView.ChromaAntiring_IsEnabled = true;
                //vm.ChromaAntiring_IsEnabled = true;
                // Downscale
                VM.VideoView.Downscale_IsEnabled = true;
                //cboDownscale_SelectedItem = "default";
                VM.VideoView.DownscaleAntiring_IsEnabled = true;
                //vm.DownscaleAntiring_IsEnabled = true;
                // Interpolation Scale
                VM.VideoView.InterpolationScale_IsEnabled = true;
                //cboInterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_IsEnabled = true;
                //vm.InterpolationScaleAntiring_IsEnabled = true;
            }
            // Disabled
            else
            {
                // PBO Off
                VM.VideoView.OpenGLPBO_SelectedItem = "off";
                VM.VideoView.OpenGLPBO_IsEnabled = false;

                // Scaling Off
                VM.VideoView.Sigmoid_IsEnabled = false;
                VM.VideoView.Sigmoid_SelectedItem = "no";
                // Scale
                VM.VideoView.Scale_IsEnabled = false;
                VM.VideoView.Scale_SelectedItem = "off";
                VM.VideoView.ScaleAntiring_IsEnabled = false;
                //vm.ScaleAntiring_IsEnabled = false;
                // Chroma Scale
                VM.VideoView.ChromaScale_IsEnabled = false;
                VM.VideoView.ChromaScale_SelectedItem = "off";
                VM.VideoView.ChromaAntiring_IsEnabled = false;
                //vm.ChromaAntiring_IsEnabled = false;
                // Downscale
                VM.VideoView.Downscale_IsEnabled = false;
                VM.VideoView.Downscale_SelectedItem = "off";
                VM.VideoView.DownscaleAntiring_IsEnabled = false;
                //vm.DownscaleAntiring_IsEnabled = false;
                // Interpolation Scale
                VM.VideoView.InterpolationScale_IsEnabled = false;
                VM.VideoView.InterpolationScale_SelectedItem = "off";
                VM.VideoView.InterpolationScaleAntiring_IsEnabled = false;
                //vm.InterpolationScaleAntiring_IsEnabled = false;
            }
        }


        /// <summary>
        ///    Video Driver API
        /// </summary>
        private void cboVideoDriverAPI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable OpenGL PBO
            // Enable/Disable Scaling

            // Enabled
            if (VM.VideoView.VideoDriverAPI_SelectedItem == "default" ||
                VM.VideoView.VideoDriver_SelectedItem == "gpu"
                //vm.VideoDriverAPI_SelectedItem == "opengl" // old
                //|| vm.VideoDriverAPI_SelectedItem == "vulkan"
                //|| vm.VideoDriverAPI_SelectedItem == "d3d11"
                )
            {
                // PBO On
                VM.VideoView.OpenGLPBO_IsEnabled = true;
                VM.VideoView.OpenGLPBO_SelectedItem = "default";

                // Scaling On
                VM.VideoView.Sigmoid_IsEnabled = true;
                VM.VideoView.Sigmoid_SelectedItem = "default";
                // Scale
                VM.VideoView.Scale_IsEnabled = true;
                VM.VideoView.Scale_SelectedItem = "default";
                VM.VideoView.ScaleAntiring_IsEnabled = true;
                //vm.ScaleAntiring_IsEnabled = true;
                // Chroma Scale
                VM.VideoView.ChromaScale_IsEnabled = true;
                VM.VideoView.ChromaScale_SelectedItem = "default";
                VM.VideoView.ChromaAntiring_IsEnabled = true;
                //vm.ChromaAntiring_IsEnabled = true;
                // Downscale
                VM.VideoView.Downscale_IsEnabled = true;
                VM.VideoView.Downscale_SelectedItem = "default";
                VM.VideoView.DownscaleAntiring_IsEnabled = true;
                //vm.DownscaleAntiring_IsEnabled = true;
                // Interpolation Scale
                VM.VideoView.InterpolationScale_IsEnabled = true;
                VM.VideoView.InterpolationScale_SelectedItem = "default";
                VM.VideoView.InterpolationScaleAntiring_IsEnabled = true;
                //vm.InterpolationScaleAntiring_IsEnabled = true;

            }
            // Disabled
            else
            {
                // PBO Off
                VM.VideoView.OpenGLPBO_SelectedItem = "off";
                VM.VideoView.OpenGLPBO_IsEnabled = false;

                // Scaling Off
                VM.VideoView.Sigmoid_IsEnabled = false;
                VM.VideoView.Sigmoid_SelectedItem = "no";
                // Scale
                VM.VideoView.Scale_IsEnabled = false;
                VM.VideoView.Scale_SelectedItem = "off";
                VM.VideoView.ScaleAntiring_IsEnabled = false;
                //vm.ScaleAntiring_IsEnabled = false;
                // Chroma Scale
                VM.VideoView.ChromaScale_IsEnabled = false;
                VM.VideoView.ChromaScale_SelectedItem = "off";
                VM.VideoView.ChromaAntiring_IsEnabled = false;
                //vm.ChromaAntiring_IsEnabled = false;
                // Downscale
                VM.VideoView.Downscale_IsEnabled = false;
                VM.VideoView.Downscale_SelectedItem = "off";
                VM.VideoView.DownscaleAntiring_IsEnabled = false;
                //vm.DownscaleAntiring_IsEnabled = false;
                // Interpolation Scale
                VM.VideoView.InterpolationScale_IsEnabled = false;
                VM.VideoView.InterpolationScale_SelectedItem = "off";
                VM.VideoView.InterpolationScaleAntiring_IsEnabled = false;
                //vm.InterpolationScaleAntiring_IsEnabled = false;
            }
        }

        /// <summary>
        ///    OpenGL PBO
        /// </summary>
        private void cboOpenGLPBO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable / Disable PBO Formats

            // Enabled
            if (VM.VideoView.OpenGLPBO_SelectedItem == "yes")
            {
                VM.VideoView.OpenGLPBOFormat_IsEnabled = true;
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "default";
            }
            // Disabled
            else
            {
                VM.VideoView.OpenGLPBOFormat_SelectedItem = "off";
                VM.VideoView.OpenGLPBOFormat_IsEnabled = false;
            }
        }

        /// <summary>
        ///     Interpolation
        /// </summary>
        private void cboInterpolation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VM.VideoView.Interpolation_SelectedItem == "yes")
                VM.VideoView.VideoSync_SelectedItem = "display-resample";
            else
                VM.VideoView.VideoSync_SelectedItem = "default";
        }

        /// <summary>
        ///    Gamma Auto
        /// </summary>
        //private void cboGammaAuto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Enable/Disable Gamma

        //    // Enabled
        //    if (vm.GammaAuto_SelectedItem == "yes")
        //    {
        //        // Slider
        //        slGamma_Value = 0;
        //        slGamma_IsEnabled = false;
        //        // TextBox
        //        tbxGamma_IsEnabled = false;
        //    }
        //    // Disabled
        //    else if (vm.GammaAuto_SelectedItem == "no")
        //    {
        //        // Slider
        //        slGamma_IsEnabled = true;
        //        // TextBox
        //        tbxGamma_IsEnabled = true;
        //    }
        //}

        /// <summary>
        ///     ICC Profile Path
        /// </summary>
        private void lbICCProfilePath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Clear
            //tbxICCProfilePath_Text = "";

            //if (VM.VideoView.ICCProfile_IsEditable == true)
            //    VM.VideoView.ICCProfile_Text = "";
        }
        private void cboICCProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Custom ComboBox Editable
            if (VM.VideoView.ICCProfile_SelectedItem == "select")
            {
                VM.VideoView.ICCProfile_IsEditable = true;

                // Clear Text
                //cboICCProfile.SelectedIndex = -1;

                // Open 'Select File'
                Microsoft.Win32.OpenFileDialog selectFile = new Microsoft.Win32.OpenFileDialog();
                selectFile.RestoreDirectory = true;
                // Show save file dialog box
                Nullable<bool> result = selectFile.ShowDialog();

                // Process dialog box
                if (result == true)
                {
                    VM.VideoView.ICCProfile_Items.Add(selectFile.FileName);
                    VM.VideoView.ICCProfile_SelectedItem = selectFile.FileName;
                    VM.VideoView.ICCProfile_IsEditable = true;
                }
            }

            // Other Items Disable Editable
            else if (VM.VideoView.ICCProfile_SelectedItem != "select" &&
                !string.IsNullOrEmpty(VM.VideoView.ICCProfile_SelectedItem))
            {
                //cboICCProfile_Items[cboICCProfile.SelectedIndex] = "select";
                VM.VideoView.ICCProfile_IsEditable = false;
            }
        }
        //private void tbxICCProfilePath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Open 'Select File'
        //    Microsoft.Win32.OpenFileDialog selectFile = new Microsoft.Win32.OpenFileDialog();

        //    selectFile.RestoreDirectory = true;

        //    // Show save file dialog box
        //    Nullable<bool> result = selectFile.ShowDialog();

        //    // Process dialog box
        //    if (result == true)
        //    {
        //        tbxICCProfilePath_Text = selectFile.FileName;
        //    }
        //}

        /// <summary>
        ///    Deband
        /// </summary>
        private void cboDeband_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Deband Grain

            // Enabled
            if (VM.VideoView.Deband_SelectedItem == "yes")
            {
                VM.VideoView.DebandGrain_IsEnabled = true;
            }
            // Disabled
            else if (VM.VideoView.Deband_SelectedItem == "no")
            {
                VM.VideoView.DebandGrain_IsEnabled = false;
                VM.VideoView.DebandGrain_Text = "";
            }
            else if (VM.VideoView.Deband_SelectedItem == "default")
            {
                VM.VideoView.DebandGrain_IsEnabled = false;
                VM.VideoView.DebandGrain_Text = "";
            }
        }

        /// <summary>
        ///    Scale
        /// </summary>
        private void cboScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Scale Antiring

            // Off
            // Turn off Scale Antiring
            if (VM.VideoView.Scale_SelectedItem == "off")
            {
                //vm.ScaleAntiring_IsEnabled = false;
                VM.VideoView.ScaleAntiring_Value = 0;
                VM.VideoView.ScaleAntiring_IsEnabled = false;
            }
            // On
            // Enable Scale Antiring
            else
            {
                VM.VideoView.ScaleAntiring_IsEnabled = true;
                //vm.ScaleAntiring_IsEnabled = true;
            }
        }

        /// <summary>
        ///    Chroma Scale
        /// </summary>
        private void cboChromaScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Chroma Scale Antiring

            // Off
            // Turn off Chroma Scale Antiring
            if (VM.VideoView.ChromaScale_SelectedItem == "off")
            {
                //vm.ChromaAntiring_IsEnabled = false;
                VM.VideoView.ChromaAntiring_Value = 0;
                VM.VideoView.ChromaAntiring_IsEnabled = false;
            }
            // On
            // Enable Chroma Scale Antiring
            else
            {
                VM.VideoView.ChromaAntiring_IsEnabled = true;
                //vm.ChromaAntiring_IsEnabled = true;
            }
        }

        /// <summary>
        ///    Downscale
        /// </summary>
        private void cboDownscale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Downscale Antiring

            // Off
            // Turn off Downscale Antiring
            if (VM.VideoView.Downscale_SelectedItem == "off")
            {
                //vm.DownscaleAntiring_IsEnabled = false;
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.DownscaleAntiring_IsEnabled = false;
            }
            // On
            // Enable Downscale Antiring
            else
            {
                VM.VideoView.DownscaleAntiring_IsEnabled = true;
                //tbxDownscaleAntiring_IsEnabled = true;
            }
        }

        /// <summary>
        ///    Software Scaler
        /// </summary>
        private void cboSoftwareScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable/Disable Hardware Scaling if Software Scaling is on

            // Default (Enabled)
            if (VM.VideoView.SoftwareScaler_SelectedItem == "default")
            {
                // Sigmoid
                VM.VideoView.Sigmoid_IsEnabled = true;
                VM.VideoView.Sigmoid_SelectedItem = "default";

                // Scale
                VM.VideoView.Scale_IsEnabled = true;
                VM.VideoView.ScaleAntiring_IsEnabled = true;
                //tbxScaleAntiring_IsEnabled = true;

                // Chroma
                VM.VideoView.ChromaScale_IsEnabled = true;
                VM.VideoView.ChromaAntiring_IsEnabled = true;
                //tbxChromaAntiring_IsEnabled = true;

                // Downscale
                VM.VideoView.Downscale_IsEnabled = true;
                VM.VideoView.DownscaleAntiring_IsEnabled = true;
                //tbxDownscaleAntiring_IsEnabled = true;
            }
            // Enabled
            else if (VM.VideoView.SoftwareScaler_SelectedItem == "off")
            {
                // Sigmoid
                VM.VideoView.Sigmoid_IsEnabled = true;
                //cboSigmoid_SelectedItem = "default";

                // Scale
                VM.VideoView.Scale_IsEnabled = true;
                VM.VideoView.ScaleAntiring_IsEnabled = true;
                //vm.ScaleAntiring_IsEnabled = true;

                // Chroma
                VM.VideoView.ChromaScale_IsEnabled = true;
                VM.VideoView.ChromaAntiring_IsEnabled = true;
                //tbxChromaAntiring_IsEnabled = true;

                // Downscale
                VM.VideoView.Downscale_IsEnabled = true;
                VM.VideoView.DownscaleAntiring_IsEnabled = true;
                //tbxDownscaleAntiring_IsEnabled = true;
            }
            // Disabled
            else
            {
                // Sigmoid
                VM.VideoView.Sigmoid_IsEnabled = false;
                VM.VideoView.Sigmoid_SelectedItem = "no";

                // Scale
                VM.VideoView.Scale_IsEnabled = false;
                //vm.ScaleAntiring_IsEnabled = false;
                VM.VideoView.ScaleAntiring_Value = 0;
                VM.VideoView.ScaleAntiring_IsEnabled = false;

                // Chroma
                VM.VideoView.ChromaScale_IsEnabled = false;
                //vm.ChromaAntiring_IsEnabled = false;
                VM.VideoView.ChromaAntiring_Value = 0;
                VM.VideoView.ChromaAntiring_IsEnabled = false;

                // Downscale
                VM.VideoView.Downscale_IsEnabled = false;
                //vm.DownscaleAntiring_IsEnabled = false;
                VM.VideoView.DownscaleAntiring_Value = 0;
                VM.VideoView.DownscaleAntiring_IsEnabled = false;
            }

            //if (vm.SoftwareScaler_SelectedItem != "default")
            //{

            //}
        }

        /// <summary>
        ///     Video Brightness DoubleClick
        /// </summary>
        private void slBrightness_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.Brightness_Value = 0;
        }

        /// <summary>
        ///     Video Contrast DoubleClick
        /// </summary>
        private void slContrast_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.Contrast_Value = 0;
        }

        /// <summary>
        ///     Video Hue DoubleClick
        /// </summary>
        private void slHue_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.Hue_Value = 0;
        }

        /// <summary>
        ///     Video Saturation DoubleClick
        /// </summary>
        private void slSaturation_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.Saturation_Value = 0;
        }

        /// <summary>
        ///     Video Gamma DoubleClick
        /// </summary>
        private void slGamma_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.Gamma_Value = 0;
        }

        /// <summary>
        ///     Video Scale Antiring
        /// </summary>
        private void slScaleAntiring_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.ScaleAntiring_Value = 0;
        }

        /// <summary>
        ///     Video Chroma Antiring
        /// </summary>
        private void slChromaAntiring_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.ChromaAntiring_Value = 0;
        }

        /// <summary>
        ///     Video Downscale Antiring
        /// </summary>
        private void cboDownscaleAntiring_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.DownscaleAntiring_Value = 0;
        }

        /// <summary>
        ///     Video Interpolation Antiring
        /// </summary>
        private void slInterpolationAntiring_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // return to default
            VM.VideoView.InterpolationScaleAntiring_Value = 0;
        }
    }
}