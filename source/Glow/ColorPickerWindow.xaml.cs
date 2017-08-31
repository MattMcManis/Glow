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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;

namespace Glow
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        private MainWindow mainwindow;

        private string textBoxKey; // Pass Keyword from MainWindow

        //private ColorPickerWindow colorpickerwindow;

        public DispatcherTimer shadePickerTimer = new DispatcherTimer(DispatcherPriority.Render);
        public DispatcherTimer spectrumPickerTimer = new DispatcherTimer(DispatcherPriority.Render);


        [DllImport("gdi32")]
        private static extern int GetPixel(int hdc, int nXPos, int nYPos);

        [DllImport("user32")]
        private static extern int GetWindowDC(int hwnd);

        [DllImport("user32")]
        private static extern int ReleaseDC(int hWnd, int hDC);


        /// <summary>
        ///    Color Picker Window
        /// </summary>
        public ColorPickerWindow(MainWindow mainwindow, string textBoxKey)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;

            this.textBoxKey = textBoxKey; // Pass Keyword from MainWindow

            InitializeComponent();

            shadePickerTimer.Tick += new EventHandler(shadePickerTimer_Tick);
            spectrumPickerTimer.Tick += new EventHandler(spectrumPickerTimer_Tick);
        }


        /// <summary>
        ///    Window Loaded
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // -------------------------
            // Color the Pallette
            // -------------------------
            // Darkness   
            System.Windows.Media.LinearGradientBrush gradientBlack = new System.Windows.Media.LinearGradientBrush();
            gradientBlack.StartPoint = new System.Windows.Point(0, 0);
            gradientBlack.EndPoint = new System.Windows.Point(0, 1);
            gradientBlack.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(0, 0, 0, 0), 0)); // transparent black
            gradientBlack.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 0, 0, 0), 1)); // black

            shadeDarkness.Fill = gradientBlack;

            // -------------------------
            // Set Shade Ellipse Position
            // -------------------------
            // If null, default Center
            if (ellipseX == 0 || ellipseY == 0)
            {
                // Center Middle
                //double x = shadeCanvas.Height / 2;
                //double y = shadeCanvas.Width / 2;
                Canvas.SetLeft(shadePickerElipse, 121.5);
                Canvas.SetTop(shadePickerElipse, 121.5);
            }
            // Load last position
            else
            {
                Canvas.SetLeft(shadePickerElipse, ColorPickerWindow.ellipseX);
                Canvas.SetTop(shadePickerElipse, ColorPickerWindow.ellipseY);
            }


            // -------------------------
            // Ellipse Dark Light
            // -------------------------
            // Change Ellipse color based on location
            shadeEllipseDarkLight();

            // -------------------------
            // Initial Color
            // -------------------------
            // If null, default Red
            if (spectrumIntColor == 0)
            {
                spectrumIntColor = 255;

                spectrumColor = System.Drawing.Color.FromArgb((int)spectrumIntColor);

                SetShadeBaseColor(spectrumColor);
            }
            // Load last used color
            else
            {
                SetShadeBaseColor(ColorPickerWindow.spectrumColor);
            }


            // -------------------------
            // Set Color
            // -------------------------
            SetColor(spectrumColor);
        }







        // Shade Ellipse Screen Position X/Y
        //System.Windows.Point shadeEllipsePosition = new System.Windows.Point(0, 0);

        // Shade Ellipse Canvas Position X/Y
        public static double ellipseX = 0;
        public static double ellipseY = 0;

        // Picked Spectrum IntColor
        public static long spectrumIntColor = 0;
        public static System.Drawing.Color spectrumColor;



        /// <summary>
        ///    Spectrum Position IntColor
        /// </summary>
        public void SpectrumPositionIntColor()
        {
            // -------------------------
            // Window Device Context
            // -------------------------
            int DC = GetWindowDC(0);

            // -------------------------
            // Get Color at Mouse Position
            // -------------------------
            System.Drawing.Point mouse = System.Windows.Forms.Control.MousePosition;

            // -------------------------
            // Set IntColor
            // -------------------------
            spectrumIntColor = GetPixel(DC, (int)mouse.X, (int)mouse.Y);

            // -------------------------
            // Release DC
            // -------------------------
            ReleaseDC(0, DC);

            // -------------------------
            // Return
            // -------------------------
            //return spectrumIntColor;
        }



        /// <summary>
        ///    Set Color
        /// </summary>
        public void SetColor(System.Drawing.Color color)
        {
            // -------------------------
            // Normalize Value
            // -------------------------
            // 0-255, -6 to account for ellipse width/height
            // sat 359
            // luminosity 220
            double saturation = (Canvas.GetLeft(shadePickerElipse) - 0) / (246 - 0); //reverse
            double luminosity = 1 - ((Canvas.GetTop(shadePickerElipse) - 0) / (248 - 0));

            // -------------------------
            // Filter
            // -------------------------
            // Desaturate
            color = Saturation(color, saturation);

            // Brightness
            color = Luminance(color, luminosity);

            // -------------------------
            // Preview
            // -------------------------
            ColorPreview(color);

            // -------------------------
            // Hex Code
            // -------------------------
            tbxHexColorCode.Text = HexCode(color).ToString();
        }


        /// <summary>
        ///    Color Preview
        /// </summary>
        public void ColorPreview(System.Drawing.Color color)
        {
            // Color Preview
            // Need to check if same value or it reverses itself
            System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromArgb(255, color.B, color.G, color.R));

            colorPreview.Fill = brushPreview;
        }


        /// <summary>
        ///   Hex Code
        /// </summary>
        public String HexCode(System.Drawing.Color pickedColor)
        {
            // Convert RGB to Hex
            // Reversed BGR for hex
            string hex = string.Empty;
            return hex = pickedColor.B.ToString("X2") + pickedColor.G.ToString("X2") + pickedColor.R.ToString("X2");
        }






        /// <summary>
        ///   Hue Slider
        /// </summary>
        //private void slHue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    spectrumColor = Hue(spectrumColor, slHue.Value);

        //    SetColor(spectrumColor);

        //    tbxHue.Text = slHue.Value.ToString();
        //}




        public Thread thread = null;
        //public BackgroundWorker worker;

        /// <summary>
        ///   Color Spectrum
        /// </summary>
        public void GetSpectrumColor()
        {
            // Only if mouse is within Spectrum Rectangle
            if (IsMouseEnteredSpectrum == true)
            {
                // -------------------------
                // Change Shade Base Color
                // -------------------------
                SpectrumPositionIntColor();
                spectrumColor = System.Drawing.Color.FromArgb((int)spectrumIntColor);

                // Base Color
                // Gradient White to Color
                SetShadeBaseColor(spectrumColor);
            }
        }


        /// <summary>
        ///   Shade Base Color
        /// </summary>
        public void SetShadeBaseColor(System.Drawing.Color color)
        {
            // Base Color
            // Gradient White to Color
            System.Windows.Media.LinearGradientBrush baseColor = new System.Windows.Media.LinearGradientBrush();
            baseColor.StartPoint = new System.Windows.Point(0, 0);
            baseColor.EndPoint = new System.Windows.Point(1, 0);
            baseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 255, 255, 255), 0)); // white
            baseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, color.B, color.G, color.R), 1)); // base color

            colorShade.Fill = baseColor;

            SetColor(spectrumColor);
        }


        /// <summary>
        ///   Color Spectrum - Held Down (Timer)
        /// </summary>
        private void spectrumPickerTimer_Tick(object sender, EventArgs e)
        {
            GetSpectrumColor();
        }
        /// <summary>
        ///   Color Spectrum - Button Down
        /// </summary>
        private void colorSpectrumPicker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // -------------------------
            // Mouse Clicked Once
            // -------------------------
            GetSpectrumColor();

            // -------------------------
            // Mouse is Held Down
            // -------------------------
            // Start Timer
            spectrumPickerTimer.Interval = new TimeSpan(0, 0, 0, 0, 001); //milliseconds
            spectrumPickerTimer.Start();
        }
        /// <summary>
        ///   Color Spectrum - Button Up
        /// </summary>
        private void colorSpectrumPicker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Disable Timer
            spectrumPickerTimer.Stop();
        }
        /// <summary>
        ///   Color Spectrum - Mouse Enter
        /// </summary>
        public bool IsMouseEnteredSpectrum = false;
        private void colorSpectrum_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsMouseEnteredSpectrum = true;
        }
        /// <summary>
        ///   Color Spectrum - Mouse Leave
        /// </summary>
        private void colorSpectrum_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsMouseEnteredSpectrum = false;

            // Disable Timer
            spectrumPickerTimer.Stop();
        }















        /// <summary>
        ///   Shade Ellipse Dark Light
        /// </summary>
        // Change Ellipse color based on location
        public void shadeEllipseDarkLight()
        {
            // -------------------------
            // Color Ellipse
            // -------------------------
            // Set Ellipse Left to Black
            if (Canvas.GetLeft(shadePickerElipse) < 121.5)
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.Black);
            }
            // White
            else
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.White);
            }

            // Set Ellipse Top/Left Corner to Black
            if (Canvas.GetTop(shadePickerElipse) < 121.5
                && Canvas.GetLeft(shadePickerElipse) < 121.5)
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.Black);
            }
            // White
            else
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.White);
            }
        }

        /// <summary>
        ///   Shade Get Color
        /// </summary>
        public void GetShadeColor()
        {
            // Only if mouse is within Shade Rectangle
            if (IsMouseEnteredShade == true)
            {
                // -------------------------
                // Get Mouse Position on Canvas
                // -------------------------
                System.Windows.Point mouse = Mouse.GetPosition(shadeCanvas);

                // Set Ellipse to Mouse Position
                // Subtract half of Ellipse width/height to Center
                Canvas.SetLeft(shadePickerElipse, mouse.X - 6);
                Canvas.SetTop(shadePickerElipse, mouse.Y - 6);

                // -------------------------
                // Save ellipse Position for Initial Load
                // -------------------------
                ellipseX = Canvas.GetLeft(shadePickerElipse);
                ellipseY = Canvas.GetTop(shadePickerElipse);

                // -------------------------
                // Ellipse Dark Light
                // -------------------------
                // Change Ellipse color based on location
                shadeEllipseDarkLight();

                // -------------------------
                // Set Color
                // -------------------------
                SetColor(spectrumColor);
            }
        }
        /// <summary>
        ///   Color Shade - Held Down (Timer)
        /// </summary>
        private void shadePickerTimer_Tick(object sender, EventArgs e)
        {
            GetShadeColor();
        }

        /// <summary>
        ///   Color Shade - Button Down
        /// </summary>
        private void colorShadePicker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // -------------------------
            // Mouse Clicked Once
            // -------------------------
            GetShadeColor();

            // -------------------------
            // Mouse is Held Down
            // -------------------------
            // Start Timer
            shadePickerTimer.Interval = new TimeSpan(0, 0, 0, 0, 001); //milliseconds
            shadePickerTimer.Start();
        }
        /// <summary>
        ///   Color Shade - Button Down
        /// </summary>
        private void colorShadePicker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Disable Timer
            shadePickerTimer.Stop();

            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
        /// <summary>
        ///   Color Shade - Mouse Enter
        /// </summary>
        public bool IsMouseEnteredShade = false;
        private void colorShadePicker_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsMouseEnteredShade = true;
        }
        /// <summary>
        ///   Color Shade - Mouse Leave
        /// </summary>
        private void colorShadePicker_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsMouseEnteredShade = false;

            // Disable Timer
            shadePickerTimer.Stop();

            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }









        /// <summary>
        ///    Saturation
        /// </summary>
        // Fix Saturation Luminosity
        // Ease the Luminosity as it approaches white
        double InOutQuadBlend(double t)
        {
            if (t <= 0.5)
                return 2.0f * Math.Pow(t, 2);
            t -= 0.5;
            return 2.0 * t * (1.0 - t) + 0.5;
        }
        double BezierBlend(double t)
        {
            return Math.Pow(t, 2) * (3.0 - 2.0 * t);
        }
        double ParametricBlend(double t)
        {
            double sqt = Math.Pow(t, 2);
            return sqt / (2.0 * (sqt - t) + 1.0);
        }
        public System.Drawing.Color Saturation(System.Drawing.Color color, double saturation)
        {
            // Saturation
            HSLColor hslColor = new HSLColor(color);
            hslColor.Saturation *= saturation;
            //hslColor.Saturation *= Math.Max(Math.Min(InOutQuadBlend(saturation), 1), 0);
            

            // Saturation Luminosity
            hslColor = new HSLColor(hslColor);
            //hslColor.Luminosity *= 2 - saturation;
            hslColor.Luminosity *= 2 - InOutQuadBlend(saturation);
            //hslColor.Luminosity *= Math.Max(Math.Min(2 - InOutQuadBlend(saturation), 2), 0);

            return hslColor;
        }


        /// <summary>
        ///    Luminance
        /// </summary>
        public System.Drawing.Color Luminance(System.Drawing.Color color, double luminosity)
        {
            HSLColor hslColor = new HSLColor(color);
            hslColor.Luminosity *= luminosity; // 0 to 1

            return hslColor;
        }


        /// <summary>
        ///    Hue
        /// </summary>
        public System.Drawing.Color Hue(System.Drawing.Color color, double hue)
        {
            HSLColor hslColor = new HSLColor(color);
            hslColor.Hue *= hue; // 0 to 1

            return hslColor;
        }





        /// <summary>
        ///   Hex Color Textbox
        /// </summary>
        public void ConvertHexToRGB(string hexCode)
        {
            try
            {
                if (hexCode.Length == 7)
                {
                    System.Windows.Media.Color hexColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(hexCode);
                    System.Drawing.Color typedColor = System.Drawing.Color.FromArgb(255, hexColor.B, hexColor.G, hexColor.R);
                    ColorPreview(typedColor);

                    //// Set Ellipse Position
                    //double saturation = typedColor.GetSaturation() * 255;
                    //double luminosity = (1 - typedColor.GetBrightness()) * 255;

                    //Canvas.SetLeft(shadePickerElipse, saturation - 6);
                    //Canvas.SetTop(shadePickerElipse, luminosity  - 6);
                }
            }
            catch
            {

            }
        }
        // Key Up
        private void tbxHexColorCode_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ConvertHexToRGB("#" + tbxHexColorCode.Text.ToString());
        }
        // Key Down
        private void tbxHexColorCode_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ConvertHexToRGB("#" + tbxHexColorCode.Text.ToString());
        }



        /// <summary>
        ///   Swatch White
        /// </summary>
        private void swatchWhite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Canvas.SetLeft(shadePickerElipse, -5);
            //Canvas.SetTop(shadePickerElipse, -5);

            //// -------------------------
            //// Ellipse Dark Light
            //// -------------------------
            //shadeEllipseDarkLight();

            //// -------------------------
            //// Set
            //// -------------------------
            //SetColor(spectrumColor);

            string swatch = "FFFFFF";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Black
        /// </summary>
        private void swatchBlack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Canvas.SetLeft(shadePickerElipse, 248);
            //Canvas.SetTop(shadePickerElipse, 248);

            //// -------------------------
            //// Ellipse Dark Light
            //// -------------------------
            //shadeEllipseDarkLight();

            //// -------------------------
            //// Set Color
            //// -------------------------
            //SetColor(spectrumColor);

            string swatch = "000000";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Pink
        /// </summary>
        private void swatchPink_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //// -------------------------
            //// Set Ellipse
            //// -------------------------
            //Canvas.SetLeft(shadePickerElipse, 100);
            //Canvas.SetTop(shadePickerElipse, -6);

            //// -------------------------
            //// Ellipse Dark Light
            //// -------------------------
            //shadeEllipseDarkLight();

            //// -------------------------
            //// Set Base Color
            //// -------------------------
            //spectrumIntColor = 255;
            //spectrumColor = System.Drawing.Color.FromArgb((int)spectrumIntColor);
            //SetShadeBaseColor(spectrumColor);

            //// -------------------------
            //// Set Color
            //// -------------------------
            //SetColor(spectrumColor);

            string swatch = "FFB0B0";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Gray
        /// </summary>
        private void swatchGray_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "A9A9A9";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Dark Gray
        /// </summary>
        private void swatchDarkGray_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "262626";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Yellow
        /// </summary>
        private void swatchYellow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "FDFD02";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Blue
        /// </summary>
        private void swatchBlue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "9AAFE4";

            ConvertHexToRGB("#" + swatch);

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch None
        /// </summary>
        private void swatchNone_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxHexColorCode.Text = "";
        }




        /// <summary>
        ///   OK Button
        /// </summary>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string HexColorCode = tbxHexColorCode.Text.ToString();
            
            // Return Hex Code to TextBox based on Passed Keyword
            if (textBoxKey == "subtitlesFont")
                mainwindow.tbxSubtitlesFontColor.Text = HexColorCode;
            else if (textBoxKey == "subtitlesBorder")
                mainwindow.tbxSubtitlesBorderColor.Text = HexColorCode;
            else if (textBoxKey == "subtitlesShadow")
                mainwindow.tbxSubtitlesShadowColor.Text = HexColorCode;
            else if (textBoxKey == "osdFont")
                mainwindow.tbxOSDFontColor.Text = HexColorCode;
            else if (textBoxKey == "osdBorder")
                mainwindow.tbxOSDBorderColor.Text = HexColorCode;
            else if (textBoxKey == "osdShadow")
                mainwindow.tbxOSDShadowColor.Text = HexColorCode;

            this.Close();
        }





    /*
     * HSL Color
     * Copyright Richard Newman
     * https://richnewman.wordpress.com/about/code-listings-and-diagrams/hslcolor-class/
     */
        public class HSLColor
        {
            // Private data members below are on scale 0-1
            // They are scaled for use externally based on scale
            private double hue = 1.0;
            private double saturation = 1.0;
            private double luminosity = 1.0;

            private const double scale = 240.0;

            public double Hue
            {
                get { return hue * scale; }
                set { hue = CheckRange(value / scale); }
            }
            public double Saturation
            {
                get { return saturation * scale; }
                set { saturation = CheckRange(value / scale); }
            }
            public double Luminosity
            {
                get { return luminosity * scale; }
                set { luminosity = CheckRange(value / scale); }
            }

            private double CheckRange(double value)
            {
                if (value < 0.0)
                    value = 0.0;
                else if (value > 1.0)
                    value = 1.0;
                return value;
            }

            public override string ToString()
            {
                return String.Format("H: {0:#0.##} S: {1:#0.##} L: {2:#0.##}", Hue, Saturation, Luminosity);
            }

            public string ToRGBString()
            {
                System.Drawing.Color color = (System.Drawing.Color)this;
                return String.Format("R: {0:#0.##} G: {1:#0.##} B: {2:#0.##}", color.R, color.G, color.B);
            }

            #region Casts to/from System.Drawing.Color
            public static implicit operator System.Drawing.Color(HSLColor hslColor)
            {
                double r = 0, g = 0, b = 0;
                if (hslColor.luminosity != 0)
                {
                    if (hslColor.saturation == 0)
                        r = g = b = hslColor.luminosity;
                    else
                    {
                        double temp2 = GetTemp2(hslColor);
                        double temp1 = 2.0 * hslColor.luminosity - temp2;

                        r = GetColorComponent(temp1, temp2, hslColor.hue + 1.0 / 3.0);
                        g = GetColorComponent(temp1, temp2, hslColor.hue);
                        b = GetColorComponent(temp1, temp2, hslColor.hue - 1.0 / 3.0);
                    }
                }
                return System.Drawing.Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
            }

            private static double GetColorComponent(double temp1, double temp2, double temp3)
            {
                temp3 = MoveIntoRange(temp3);
                if (temp3 < 1.0 / 6.0)
                    return temp1 + (temp2 - temp1) * 6.0 * temp3;
                else if (temp3 < 0.5)
                    return temp2;
                else if (temp3 < 2.0 / 3.0)
                    return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
                else
                    return temp1;
            }
            private static double MoveIntoRange(double temp3)
            {
                if (temp3 < 0.0)
                    temp3 += 1.0;
                else if (temp3 > 1.0)
                    temp3 -= 1.0;
                return temp3;
            }
            private static double GetTemp2(HSLColor hslColor)
            {
                double temp2;
                if (hslColor.luminosity < 0.5)  //<=??
                    temp2 = hslColor.luminosity * (1.0 + hslColor.saturation);
                else
                    temp2 = hslColor.luminosity + hslColor.saturation - (hslColor.luminosity * hslColor.saturation);
                return temp2;
            }

            public static implicit operator HSLColor(System.Drawing.Color color)
            {
                HSLColor hslColor = new HSLColor();
                hslColor.hue = color.GetHue() / 360.0; // we store hue as 0-1 as opposed to 0-360 
                hslColor.luminosity = color.GetBrightness();
                hslColor.saturation = color.GetSaturation();
                return hslColor;
            }
            #endregion

            public void SetRGB(int red, int green, int blue)
            {
                HSLColor hslColor = (HSLColor)System.Drawing.Color.FromArgb(red, green, blue);
                this.hue = hslColor.hue;
                this.saturation = hslColor.saturation;
                this.luminosity = hslColor.luminosity;
            }

            public HSLColor() { }
            public HSLColor(System.Drawing.Color color)
            {
                SetRGB(color.R, color.G, color.B);
            }
            public HSLColor(int red, int green, int blue)
            {
                SetRGB(red, green, blue);
            }
            public HSLColor(double hue, double saturation, double luminosity)
            {
                this.Hue = hue;
                this.Saturation = saturation;
                this.Luminosity = luminosity;
            }

        }

 
    }
}
