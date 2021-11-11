using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Win32Console
{
    public class Settings
    {
        public static Settings Default
        {
            get
            {
                return new Settings()
                {
                    DefaultColours = new Colours()
                    {
                        Foreground = Color.FromArgb(35, 40, 50),
                        Background = Color.FromArgb(30, 34, 43)
                    },

                    DefaultInputColours = new Colours()
                    {
                        Foreground = Color.FromArgb(255, 255, 255),
                        Background = Color.Transparent
                    },

                    // Sen
                    DefaultFont = new Font("Consolas", 12, FontStyle.Regular)
                };
            }
        }

        public static Settings DefaultGrey
        {
            get
            {
                return new Settings()
                {
                    DefaultColours = new Colours()
                    {
                        Foreground = Color.FromArgb(33, 32, 32),
                        Background = Color.FromArgb(27, 26, 26)
                    },

                    DefaultInputColours = new Colours()
                    {
                        Foreground = Color.FromArgb(255, 255, 255),
                        Background = Color.Transparent
                    },

                    DefaultFont = new Font("Consolas", 10, FontStyle.Regular)
                };
            }
        }

        public event EventHandler FontChange;

        [XmlElement("Default_Colours")]
        public Colours DefaultColours { get; set; }

        [XmlElement("Default_Input_Colours")]
        public Colours DefaultInputColours { get; set; }

        [XmlElement("Default_Font")]
        public Font DefaultFont
        {
            get { return this._DefaultFont; }
            set { this._DefaultFont = value; OnFontChange(EventArgs.Empty); }
        }
        private Font _DefaultFont;

        /// <summary>
        /// Invoke fontchange.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFontChange(EventArgs e)
        {
            if (this.FontChange != null)
                this.FontChange(this, e);
        }
    }
}
