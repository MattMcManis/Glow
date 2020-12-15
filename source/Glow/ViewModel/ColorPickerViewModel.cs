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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Media;

namespace ViewModel
{
    public class ColorPicker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string prop)
        {
            //PropertyChangedEventHandler handler = PropertyChanged;
            //handler(this, new PropertyChangedEventArgs(name));

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        ///     Main Model Main
        /// </summary>
        public ColorPicker()
        {
            // -------------------------
            // Defaults
            // -------------------------
            //ShadeBase_Fill = "#FFFFFFFF";

            System.Windows.Media.LinearGradientBrush brushBaseColor = new System.Windows.Media.LinearGradientBrush();
            brushBaseColor.StartPoint = new System.Windows.Point(0, 0);
            brushBaseColor.EndPoint = new System.Windows.Point(1, 0);
            brushBaseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 255, 255, 255), 0)); // white
            brushBaseColor.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 255, 0, 0), 1)); // red
            ShadeBase_Fill = brushBaseColor;

            Hue_Value = 0;

            HexColorCode_Text = string.Empty;

            Ellipse_Left_Value = 121.5;
            Ellipse_Top_Value = 121.5;
        }

        // -------------------------
        // Ellipse Left
        // -------------------------
        // Value
        private double _Ellipse_Left_Value;
        public double Ellipse_Left_Value
        {
            get { return _Ellipse_Left_Value; }
            set
            {
                if (_Ellipse_Left_Value == value)
                {
                    return;
                }

                _Ellipse_Left_Value = value;
                OnPropertyChanged("Ellipse_Left_Value");
            }
        }


        // -------------------------
        // Ellipse Top
        // -------------------------
        // Value
        private double _Ellipse_Top_Value;
        public double Ellipse_Top_Value
        {
            get { return _Ellipse_Top_Value; }
            set
            {
                if (_Ellipse_Top_Value == value)
                {
                    return;
                }

                _Ellipse_Top_Value = value;
                OnPropertyChanged("Ellipse_Top_Value");
            }
        }


        // -------------------------
        // Hue
        // -------------------------
        // Value
        private double _Hue_Value;
        public double Hue_Value
        {
            get { return _Hue_Value; }
            set
            {
                if (_Hue_Value == value)
                {
                    return;
                }

                _Hue_Value = value;
                OnPropertyChanged("Hue_Value");
            }
        }

        // Controls Enable
        private bool _Hue_IsEnabled = true;
        public bool Hue_IsEnabled
        {
            get { return _Hue_IsEnabled; }
            set
            {
                if (_Hue_IsEnabled == value)
                {
                    return;
                }

                _Hue_IsEnabled = value;
                OnPropertyChanged("Hue_IsEnabled");
            }
        }


        // -------------------------
        // Hex Color Code
        // -------------------------
        // Text
        private string _HexColorCode_Text;
        public string HexColorCode_Text
        {
            get { return _HexColorCode_Text; }
            set
            {
                if (_HexColorCode_Text == value)
                {
                    return;
                }

                _HexColorCode_Text = value;
                OnPropertyChanged("HexColorCode_Text");
            }
        }

        // Controls Enable
        private bool _HexColorCode_IsEnabled = true;
        public bool HexColorCode_IsEnabled
        {
            get { return _HexColorCode_IsEnabled; }
            set
            {
                if (_HexColorCode_IsEnabled == value)
                {
                    return;
                }

                _HexColorCode_IsEnabled = value;
                OnPropertyChanged("HexColorCode_IsEnabled");
            }
        }

        // Shade Base Fill
        private LinearGradientBrush _ShadeBase_Fill;
        public LinearGradientBrush ShadeBase_Fill
        {
            get { return _ShadeBase_Fill; }
            set
            {
                if (_ShadeBase_Fill == value)
                {
                    return;
                }

                _ShadeBase_Fill = value;
                OnPropertyChanged("ShadeBase_Fill");
            }
        }


    }
}
