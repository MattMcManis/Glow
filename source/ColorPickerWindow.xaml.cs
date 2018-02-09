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
using System.Windows.Threading;
using System.Windows.Input;

namespace Glow
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        // Set Spectrum Color based on Slider Value using Hue Filter
        // Set Shade Base Color using Spectrum Color
        // Get the Shade Color from Ellipse position, sets the Saturation (X), Luminosity (Y) values
        // Run Saturation/Luminosity Filters based on X/Y values
        // Set Preview Color
        // Preview Color converts to Hex Code Textbox
        // Typed Hex Code converts to RGB Preview

        private MainWindow mainwindow;

        private string textBoxKey; // Pass Keyword from MainWindow

        //private ColorPickerWindow colorpickerwindow;

        public DispatcherTimer shadePickerTimer = new DispatcherTimer(DispatcherPriority.Render);


        //[DllImport("gdi32")]
        //private static extern int GetPixel(int hdc, int nXPos, int nYPos);

        //[DllImport("user32")]
        //private static extern int GetWindowDC(int hwnd);

        //[DllImport("user32")]
        //private static extern int ReleaseDC(int hWnd, int hDC);

        // Spectrum Color
        System.Drawing.Color spectrumColor;

        // Spectrum Value
        public static double spectrumValue = 0;

        // Shade Ellipse Canvas Position X/Y
        public static double ellipseX = 0;
        public static double ellipseY = 0;


        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Methods
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        /// <summary>
        ///    Color Picker Window
        /// </summary>
        public ColorPickerWindow(MainWindow mainwindow, string textBoxKey)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;

            this.textBoxKey = textBoxKey; // Pass Keyword from MainWindow

            shadePickerTimer.Tick += new EventHandler(shadePickerTimer_Tick);
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
                Canvas.SetLeft(shadePickerElipse, (shadeCanvas.Height / 2) - 6);
                Canvas.SetTop(shadePickerElipse, (shadeCanvas.Height / 2) - 6);
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
            // If null, default
            if (ColorPickerWindow.spectrumValue == 0)
            {
                GetSpectrumColor();
            }
            // Load last used color position
            else
            {
                slHue.Value = ColorPickerWindow.spectrumValue;
            }
                

            // -------------------------
            // Set Color
            // -------------------------
            SetColor(spectrumColor);
        }


        /// <summary>
        ///    Set Color
        /// </summary>
        public void SetColor(System.Drawing.Color color)
        {
            // -------------------------
            // Normalize Value
            // -------------------------
            // Shift value 6 pixels to account for half of ellipse
            // White corner must be shifted more towards left
            double modifier = 0;
            if (Canvas.GetLeft(shadePickerElipse) < 2 && Canvas.GetTop(shadePickerElipse) < 2)
                modifier = 3;
            else
            {
                modifier = 6;
            }

            // 0-255, -6 to account for ellipse width/height
            // Saturation
            double x = ((Canvas.GetLeft(shadePickerElipse) + modifier) - 0) / (240 - 0);
            // Luminosity
            double y = 1 - (((Canvas.GetTop(shadePickerElipse) + modifier) - 0) / (240 - 0)); //reverse value

            // -------------------------
            // Filter
            // -------------------------
            // Saturation
            color = Saturation(color, x);

            // Luminosity
            color = Luminosity(color, y);

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
            System.Windows.Media.Brush brushPreview = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B));

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
            return hex = pickedColor.R.ToString("X2") + pickedColor.G.ToString("X2") + pickedColor.B.ToString("X2");
        }


        /// <summary>
        ///   Hue Slider
        /// </summary>
        private void slHue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GetSpectrumColor();
        }



        /// <summary>
        ///   Get Spectrum Color
        /// </summary>
        public void GetSpectrumColor()
        {
            spectrumValue = slHue.Value;

            // Change Hue
            spectrumColor = Hue(spectrumColor, slHue.Value);

            // Change Base Color
            SetShadeBaseColor(spectrumColor);

            // Preview Color
            SetColor(spectrumColor);
        }



        /// <summary>
        ///   Set Shade Base Color
        /// </summary>
        public void SetShadeBaseColor(System.Drawing.Color color)
        {
            // -------------------------
            // Shade Base Color
            // -------------------------
            // Gradient White to Color
            System.Windows.Media.LinearGradientBrush brushBaseColor = new System.Windows.Media.LinearGradientBrush();
            brushBaseColor.StartPoint = new System.Windows.Point(0, 0);
            brushBaseColor.EndPoint = new System.Windows.Point(1, 0);
            brushBaseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 255, 255, 255), 0)); // white
            brushBaseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), 1)); // base color

            shadeBase.Fill = brushBaseColor;

            // -------------------------
            // Set Color
            // -------------------------
            SetColor(color);
        }



        /// <summary>
        ///   Get Shade Color
        /// </summary>
        public void GetShadeColor()
        {
            // -------------------------
            // Get Mouse Position on Canvas
            // -------------------------
            System.Windows.Point mouse = Mouse.GetPosition(shadeCanvas);

            // Keep Ellipse in bounds of Canvas
            if (mouse.X < 0)
                mouse.X = 0;
            if (mouse.X > shadeCanvas.Width)
                mouse.X = shadeCanvas.Width;
            if (mouse.Y < 0)
                mouse.Y = 0;
            if (mouse.Y > shadeCanvas.Height)
                mouse.Y = shadeCanvas.Height;

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
            if (Canvas.GetLeft(shadePickerElipse) < (shadeCanvas.Height / 2.5) - 6)
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.Black);
            }
            // White
            else
            {
                shadePickerElipse.Stroke = new SolidColorBrush(Colors.White);
            }

            // Set Ellipse Top/Left Corner to Black
            if (Canvas.GetTop(shadePickerElipse) < (shadeCanvas.Height / 2.5) - 6
                && Canvas.GetLeft(shadePickerElipse) < (shadeCanvas.Height / 2.5) - 6)
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
        ///   Hex Color Textbox
        /// </summary>
        public static System.Drawing.Color ConvertHexToRGB(string hexCode)
        {
            System.Drawing.Color typedColor = new System.Drawing.Color();

            try
            {
                if (hexCode.Length == 7)
                {
                    System.Windows.Media.Color hexColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(hexCode);
                    typedColor = System.Drawing.Color.FromArgb(255, hexColor.R, hexColor.G, hexColor.B);
                    //ColorPreview(typedColor);

                    // Set Ellipse Position
                    //double saturation = typedColor.GetSaturation() * 255;
                    //double luminosity = (1 - typedColor.GetBrightness()) * 255;

                    //Canvas.SetLeft(shadePickerElipse, saturation - 6);
                    //Canvas.SetTop(shadePickerElipse, luminosity - 6);
                }
            }
            catch
            {

            }

            return typedColor;
        }





        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Controls
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

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
            //IsMouseButtonUp = false;

            // -------------------------
            // Capture Mouse
            // -------------------------
            UIElement el = (UIElement)sender;
            el.CaptureMouse();

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
            // -------------------------
            // Release Mouse
            // -------------------------
            UIElement el = (UIElement)sender;
            el.ReleaseMouseCapture();

            // -------------------------
            // Disable Timer
            // -------------------------
            shadePickerTimer.Stop();

            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
        /// <summary>
        ///   Color Shade - Mouse Enter
        /// </summary>
        //public bool IsMouseEnteredShade = false;
        //public bool IsMouseButtonUp = false;
        private void colorShadePicker_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //if (IsMouseEnteredShade == false)
            shadePickerTimer.Stop();

            //IsMouseEnteredShade = true;
        }
        /// <summary>
        ///   Color Shade - Mouse Leave
        /// </summary>
        private void colorShadePicker_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ReleaseMouseCapture();

            //IsMouseEnteredShade = false;

            // Disable Timer
            //shadePickerTimer.Stop();

            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }



        /// <summary>
        ///   Hex TextBox
        /// </summary>
        // Key Up
        private void tbxHexColorCode_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MainWindow.AllowOnlyAlphaNumeric(mainwindow, e);

            ColorPreview(ConvertHexToRGB("#" + tbxHexColorCode.Text.ToString()));
        }
        // Key Down
        private void tbxHexColorCode_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MainWindow.AllowOnlyAlphaNumeric(mainwindow, e);

            ColorPreview(ConvertHexToRGB("#" + tbxHexColorCode.Text.ToString()));
        }



        /// <summary>
        ///   Swatch White
        /// </summary>
        private void swatchWhite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "FFFFFF";

            ColorPreview(ConvertHexToRGB("#" + swatch));

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Black
        /// </summary>
        private void swatchBlack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "000000";

            ColorPreview(ConvertHexToRGB("#" + swatch));

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

            ColorPreview(ConvertHexToRGB("#" + swatch));

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Gray
        /// </summary>
        private void swatchGray_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "A9A9A9";

            ColorPreview(ConvertHexToRGB("#" + swatch));

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Dark Gray
        /// </summary>
        private void swatchDarkGray_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "262626";

            ColorPreview(ConvertHexToRGB("#" + swatch));

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Yellow
        /// </summary>
        private void swatchYellow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "FDFD02";

            ColorPreview(ConvertHexToRGB("#" + swatch));

            tbxHexColorCode.Text = swatch;
        }

        /// <summary>
        ///   Swatch Blue
        /// </summary>
        private void swatchBlue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string swatch = "9AAFE4";

            ColorPreview(ConvertHexToRGB("#" + swatch));

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
            if (textBoxKey == "osdFont")
            {
                mainwindow.tbxOSDFontColor.Text = HexColorCode;
                MainWindow.PreviewOSDFontColor(mainwindow);
            }

            else if (textBoxKey == "osdBorder")
            {
                mainwindow.tbxOSDBorderColor.Text = HexColorCode;
                MainWindow.PreviewOSDBorderColor(mainwindow);
            }

            else if (textBoxKey == "osdShadow")
            {
                mainwindow.tbxOSDShadowColor.Text = HexColorCode;
                MainWindow.PreviewOSDShadowColor(mainwindow);
            }

            else if (textBoxKey == "subtitlesFont")
            {
                mainwindow.tbxSubtitlesFontColor.Text = HexColorCode;
                MainWindow.PreviewSubtitlesFontColor(mainwindow);
            }
                
            else if (textBoxKey == "subtitlesBorder")
            {
                mainwindow.tbxSubtitlesBorderColor.Text = HexColorCode;
                MainWindow.PreviewSubtitlesBorderColor(mainwindow);
            }
                
            else if (textBoxKey == "subtitlesShadow")
            {
                mainwindow.tbxSubtitlesShadowColor.Text = HexColorCode;
                MainWindow.PreviewSubtitlesShadowColor(mainwindow);
            }
                              
            // Preview Picked Color in MainWindow button
            //MainWindow.PreviewPickedColors(mainwindow);

            this.Close();
        }






        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        ///    Filters
        /// </summary>
        // --------------------------------------------------------------------------------------------------------

        /// <summary>
        ///    Saturation
        /// </summary>
        // Fix Saturation Luminosity
        // Ease the Luminosity as it approaches white

        //t: current time
        //b: start value
        //c: change in value
        //d: duration
        double LinearTween(double t, double b, double c, double d)
        {
            return c * t / d + b;
        }
        double EaseOutCubic(double t, double b, double c, double d)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }
        public System.Drawing.Color Saturation(System.Drawing.Color color, double x)
        {
            // Saturation
            // 240 <--------> 0
            HSLColor hslColor = new HSLColor(color);
            hslColor.Saturation *= x;
            hslColor.Saturation *= LinearTween(0, x + 0.085, 1, 1);

            // Saturation Luminosity
            // 240 <--------> 120
            hslColor.Luminosity *= 1 - (EaseOutCubic(0, (x - 0.0667), 1, 1) / 2);

            return hslColor;
        }


        /// <summary>
        ///    Luminosity
        /// </summary>
        public System.Drawing.Color Luminosity(System.Drawing.Color color, double y)
        {
            // 240 ^--------v 0
            HSLColor hslColor = new HSLColor(color);
            hslColor.Luminosity *= y * 2;

            return hslColor;
        }


        /// <summary>
        ///    Hue
        /// </summary>
        public System.Drawing.Color Hue(System.Drawing.Color color, double value)
        {
            // 240 ^--------v 0
            HSLColor hslColor = new HSLColor(hue: value, saturation: 240, luminosity: 120);

            return hslColor;
        }

    }



    // --------------------------------------------------------------------------------------------------------
    /*
     * HSL Color
     * Copyright Richard Newman
     * https://richnewman.wordpress.com/about/code-listings-and-diagrams/hslcolor-class/
     */
    // --------------------------------------------------------------------------------------------------------
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
