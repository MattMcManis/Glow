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

namespace ViewModel
{
    public class Stream : INotifyPropertyChanged
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
        ///     View Model Main
        /// </summary>
        public Stream()
        {
            // -------------------------
            // Defaults
            // -------------------------
            DemuxerThread_SelectedItem = "default";
            DemuxerBuffersize_Text = string.Empty;
            DemuxerReadahead_Text = string.Empty;
            DemuxerMKVSubPreroll_SelectedItem = "default";

            YouTubeDL_SelectedItem = "default";
            YouTubeDLQuality_SelectedItem = "default";

            Cache_SelectedItem = "default";
            CacheDefault_Text = string.Empty;
            CacheInitial_Text = string.Empty;
            CacheSeekMin_Text = string.Empty;
            CacheBackbuffer_Text = string.Empty;
            CacheSeconds_Text = string.Empty;
            CacheFile_SelectedItem = "default";
            CacheFileSize_Text = string.Empty;
        }


        // ----------------------------------------------------------------------------------------------------
        // Stream
        // ----------------------------------------------------------------------------------------------------
        // -------------------------
        // Demuxer Thread
        // -------------------------
        // Item Source
        private List<string> _DemuxerThread_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> DemuxerThread_Items
        {
            get { return _DemuxerThread_Items; }
            set
            {
                _DemuxerThread_Items = value;
                OnPropertyChanged("DemuxerThread_Items");
            }
        }

        // Selected Item
        private string _DemuxerThread_SelectedItem { get; set; }
        public string DemuxerThread_SelectedItem
        {
            get { return _DemuxerThread_SelectedItem; }
            set
            {
                if (_DemuxerThread_SelectedItem == value)
                {
                    return;
                }

                _DemuxerThread_SelectedItem = value;
                OnPropertyChanged("DemuxerThread_SelectedItem");
            }
        }

        // Controls Enable
        private bool _DemuxerThread_IsEnabled = true;
        public bool DemuxerThread_IsEnabled
        {
            get { return _DemuxerThread_IsEnabled; }
            set
            {
                if (_DemuxerThread_IsEnabled == value)
                {
                    return;
                }

                _DemuxerThread_IsEnabled = value;
                OnPropertyChanged("DemuxerThread_IsEnabled");
            }
        }


        // -------------------------
        // Demuxer Buffersize
        // -------------------------
        // Text
        private string _DemuxerBuffersize_Text;
        public string DemuxerBuffersize_Text
        {
            get { return _DemuxerBuffersize_Text; }
            set
            {
                if (_DemuxerBuffersize_Text == value)
                {
                    return;
                }

                _DemuxerBuffersize_Text = value;
                OnPropertyChanged("DemuxerBuffersize_Text");
            }
        }

        // Controls Enable
        private bool _DemuxerBuffersize_IsEnabled = true;
        public bool DemuxerBuffersize_IsEnabled
        {
            get { return _DemuxerBuffersize_IsEnabled; }
            set
            {
                if (_DemuxerBuffersize_IsEnabled == value)
                {
                    return;
                }

                _DemuxerBuffersize_IsEnabled = value;
                OnPropertyChanged("DemuxerBuffersize_IsEnabled");
            }
        }


        // -------------------------
        // Demuxer Readahead
        // -------------------------
        // Text
        private string _DemuxerReadahead_Text;
        public string DemuxerReadahead_Text
        {
            get { return _DemuxerReadahead_Text; }
            set
            {
                if (_DemuxerReadahead_Text == value)
                {
                    return;
                }

                _DemuxerReadahead_Text = value;
                OnPropertyChanged("DemuxerReadahead_Text");
            }
        }

        // Controls Enable
        private bool _DemuxerReadahead_IsEnabled = true;
        public bool DemuxerReadahead_IsEnabled
        {
            get { return _DemuxerReadahead_IsEnabled; }
            set
            {
                if (_DemuxerReadahead_IsEnabled == value)
                {
                    return;
                }

                _DemuxerReadahead_IsEnabled = value;
                OnPropertyChanged("DemuxerReadahead_IsEnabled");
            }
        }


        // -------------------------
        // Demuxer MKV Sub Preroll
        // -------------------------
        // Item Source
        private List<string> _DemuxerMKVSubPreroll_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> DemuxerMKVSubPreroll_Items
        {
            get { return _DemuxerMKVSubPreroll_Items; }
            set
            {
                _DemuxerMKVSubPreroll_Items = value;
                OnPropertyChanged("DemuxerMKVSubPreroll_Items");
            }
        }

        // Selected Item
        private string _DemuxerMKVSubPreroll_SelectedItem { get; set; }
        public string DemuxerMKVSubPreroll_SelectedItem
        {
            get { return _DemuxerMKVSubPreroll_SelectedItem; }
            set
            {
                if (_DemuxerMKVSubPreroll_SelectedItem == value)
                {
                    return;
                }

                _DemuxerMKVSubPreroll_SelectedItem = value;
                OnPropertyChanged("DemuxerMKVSubPreroll_SelectedItem");
            }
        }

        // Controls Enable
        private bool _DemuxerMKVSubPreroll_IsEnabled = true;
        public bool DemuxerMKVSubPreroll_IsEnabled
        {
            get { return _DemuxerMKVSubPreroll_IsEnabled; }
            set
            {
                if (_DemuxerMKVSubPreroll_IsEnabled == value)
                {
                    return;
                }

                _DemuxerMKVSubPreroll_IsEnabled = value;
                OnPropertyChanged("DemuxerMKVSubPreroll_IsEnabled");
            }
        }


        // -------------------------
        // YouTube-DL
        // -------------------------
        // Item Source
        private List<string> _YouTubeDL_Items = new List<string>()
        {
            "default",
            "yes",
            "no",
        };
        public List<string> YouTubeDL_Items
        {
            get { return _YouTubeDL_Items; }
            set
            {
                _YouTubeDL_Items = value;
                OnPropertyChanged("YouTubeDL_Items");
            }
        }

        // Selected Item
        private string _YouTubeDL_SelectedItem { get; set; }
        public string YouTubeDL_SelectedItem
        {
            get { return _YouTubeDL_SelectedItem; }
            set
            {
                if (_YouTubeDL_SelectedItem == value)
                {
                    return;
                }

                _YouTubeDL_SelectedItem = value;
                OnPropertyChanged("YouTubeDL_SelectedItem");
            }
        }

        // Controls Enable
        private bool _YouTubeDL_IsEnabled = true;
        public bool YouTubeDL_IsEnabled
        {
            get { return _YouTubeDL_IsEnabled; }
            set
            {
                if (_YouTubeDL_IsEnabled == value)
                {
                    return;
                }

                _YouTubeDL_IsEnabled = value;
                OnPropertyChanged("YouTubeDL_IsEnabled");
            }
        }

        // -------------------------
        // YouTube-DL Quality
        // -------------------------
        // Item Source
        private List<string> _YouTubeDLQuality_Items = new List<string>()
        {
            "default",
            "best",
            "good",
            "worst"
        };
        public List<string> YouTubeDLQuality_Items
        {
            get { return _YouTubeDLQuality_Items; }
            set
            {
                _YouTubeDLQuality_Items = value;
                OnPropertyChanged("YouTubeDLQuality_Items");
            }
        }

        // Selected Item
        private string _YouTubeDLQuality_SelectedItem { get; set; }
        public string YouTubeDLQuality_SelectedItem
        {
            get { return _YouTubeDLQuality_SelectedItem; }
            set
            {
                if (_YouTubeDLQuality_SelectedItem == value)
                {
                    return;
                }

                _YouTubeDLQuality_SelectedItem = value;
                OnPropertyChanged("YouTubeDLQuality_SelectedItem");
            }
        }

        // Controls Enable
        private bool _YouTubeDLQuality_IsEnabled = true;
        public bool YouTubeDLQuality_IsEnabled
        {
            get { return _YouTubeDLQuality_IsEnabled; }
            set
            {
                if (_YouTubeDLQuality_IsEnabled == value)
                {
                    return;
                }

                _YouTubeDLQuality_IsEnabled = value;
                OnPropertyChanged("YouTubeDLQuality_IsEnabled");
            }
        }


        // -------------------------
        // Cache
        // -------------------------
        // Item Source
        private List<string> _Cache_Items = new List<string>()
        {
            "default",
            "auto",
            "yes",
            "no",
            "worst"
        };
        public List<string> Cache_Items
        {
            get { return _Cache_Items; }
            set
            {
                _Cache_Items = value;
                OnPropertyChanged("Cache_Items");
            }
        }

        // Selected Item
        private string _Cache_SelectedItem { get; set; }
        public string Cache_SelectedItem
        {
            get { return _Cache_SelectedItem; }
            set
            {
                if (_Cache_SelectedItem == value)
                {
                    return;
                }

                _Cache_SelectedItem = value;
                OnPropertyChanged("Cache_SelectedItem");
            }
        }

        // Controls Enable
        private bool _Cache_IsEnabled = true;
        public bool Cache_IsEnabled
        {
            get { return _Cache_IsEnabled; }
            set
            {
                if (_Cache_IsEnabled == value)
                {
                    return;
                }

                _Cache_IsEnabled = value;
                OnPropertyChanged("Cache_IsEnabled");
            }
        }


        // -------------------------
        // Cache Default
        // -------------------------
        // Text
        private string _CacheDefault_Text;
        public string CacheDefault_Text
        {
            get { return _CacheDefault_Text; }
            set
            {
                if (_CacheDefault_Text == value)
                {
                    return;
                }

                _CacheDefault_Text = value;
                OnPropertyChanged("CacheDefault_Text");
            }
        }

        // Controls Enable
        private bool _CacheDefault_IsEnabled = true;
        public bool CacheDefault_IsEnabled
        {
            get { return _CacheDefault_IsEnabled; }
            set
            {
                if (_CacheDefault_IsEnabled == value)
                {
                    return;
                }

                _CacheDefault_IsEnabled = value;
                OnPropertyChanged("CacheDefault_IsEnabled");
            }
        }


        // -------------------------
        // Cache Initial
        // -------------------------
        // Text
        private string _CacheInitial_Text;
        public string CacheInitial_Text
        {
            get { return _CacheInitial_Text; }
            set
            {
                if (_CacheInitial_Text == value)
                {
                    return;
                }

                _CacheInitial_Text = value;
                OnPropertyChanged("CacheInitial_Text");
            }
        }

        // Controls Enable
        private bool _CacheInitial_IsEnabled = true;
        public bool CacheInitial_IsEnabled
        {
            get { return _CacheInitial_IsEnabled; }
            set
            {
                if (_CacheInitial_IsEnabled == value)
                {
                    return;
                }

                _CacheInitial_IsEnabled = value;
                OnPropertyChanged("CacheInitial_IsEnabled");
            }
        }


        // -------------------------
        // Cache Seek Min
        // -------------------------
        // Text
        private string _CacheSeekMin_Text;
        public string CacheSeekMin_Text
        {
            get { return _CacheSeekMin_Text; }
            set
            {
                if (_CacheSeekMin_Text == value)
                {
                    return;
                }

                _CacheSeekMin_Text = value;
                OnPropertyChanged("CacheSeekMin_Text");
            }
        }

        // Controls Enable
        private bool _CacheSeekMin_IsEnabled = true;
        public bool CacheSeekMin_IsEnabled
        {
            get { return _CacheSeekMin_IsEnabled; }
            set
            {
                if (_CacheSeekMin_IsEnabled == value)
                {
                    return;
                }

                _CacheSeekMin_IsEnabled = value;
                OnPropertyChanged("CacheSeekMin_IsEnabled");
            }
        }


        // -------------------------
        // Cache Backbuffer
        // -------------------------
        // Text
        private string _CacheBackbuffer_Text;
        public string CacheBackbuffer_Text
        {
            get { return _CacheBackbuffer_Text; }
            set
            {
                if (_CacheBackbuffer_Text == value)
                {
                    return;
                }

                _CacheBackbuffer_Text = value;
                OnPropertyChanged("CacheBackbuffer_Text");
            }
        }

        // Controls Enable
        private bool _CacheBackbuffer_IsEnabled = true;
        public bool CacheBackbuffer_IsEnabled
        {
            get { return _CacheBackbuffer_IsEnabled; }
            set
            {
                if (_CacheBackbuffer_IsEnabled == value)
                {
                    return;
                }

                _CacheBackbuffer_IsEnabled = value;
                OnPropertyChanged("CacheBackbuffer_IsEnabled");
            }
        }


        // -------------------------
        // Cache Seconds
        // -------------------------
        // Text
        private string _CacheSeconds_Text;
        public string CacheSeconds_Text
        {
            get { return _CacheSeconds_Text; }
            set
            {
                if (_CacheSeconds_Text == value)
                {
                    return;
                }

                _CacheSeconds_Text = value;
                OnPropertyChanged("CacheSeconds_Text");
            }
        }

        // Controls Enable
        private bool _CacheSeconds_IsEnabled = true;
        public bool CacheSeconds_IsEnabled
        {
            get { return _CacheSeconds_IsEnabled; }
            set
            {
                if (_CacheSeconds_IsEnabled == value)
                {
                    return;
                }

                _CacheSeconds_IsEnabled = value;
                OnPropertyChanged("CacheSeconds_IsEnabled");
            }
        }


        // -------------------------
        // Cache File
        // -------------------------
        // Item Source
        private List<string> _CacheFile_Items = new List<string>()
        {
            "default",
            "TMP"
        };
        public List<string> CacheFile_Items
        {
            get { return _CacheFile_Items; }
            set
            {
                _CacheFile_Items = value;
                OnPropertyChanged("CacheFile_Items");
            }
        }

        // Selected Item
        private string _CacheFile_SelectedItem { get; set; }
        public string CacheFile_SelectedItem
        {
            get { return _CacheFile_SelectedItem; }
            set
            {
                if (_CacheFile_SelectedItem == value)
                {
                    return;
                }

                _CacheFile_SelectedItem = value;
                OnPropertyChanged("CacheFile_SelectedItem");
            }
        }

        // Controls Enable
        private bool _CacheFile_IsEnabled = true;
        public bool CacheFile_IsEnabled
        {
            get { return _CacheFile_IsEnabled; }
            set
            {
                if (_CacheFile_IsEnabled == value)
                {
                    return;
                }

                _CacheFile_IsEnabled = value;
                OnPropertyChanged("CacheFile_IsEnabled");
            }
        }


        // -------------------------
        // Cache File Size
        // -------------------------
        // Text
        private string _CacheFileSize_Text;
        public string CacheFileSize_Text
        {
            get { return _CacheFileSize_Text; }
            set
            {
                if (_CacheFileSize_Text == value)
                {
                    return;
                }

                _CacheFileSize_Text = value;
                OnPropertyChanged("CacheFileSize_Text");
            }
        }

        // Controls Enable
        private bool _CacheFileSize_IsEnabled = true;
        public bool CacheFileSize_IsEnabled
        {
            get { return _CacheFileSize_IsEnabled; }
            set
            {
                if (_CacheFileSize_IsEnabled == value)
                {
                    return;
                }

                _CacheFileSize_IsEnabled = value;
                OnPropertyChanged("CacheFileSize_IsEnabled");
            }
        }

    }
}
