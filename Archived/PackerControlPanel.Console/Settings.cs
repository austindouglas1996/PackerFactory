using PackerControlPanel.Win32Console;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.InventoryConsole
{
    public class Settings
    {
        public static Color Warning { get; set; }
        public static Color Error { get; set; }
        public static Color Success { get; set; }

        public static Font OutputFont { get; set; }
        public static Font InputFont { get; set; }

        public static Colours InputColours { get; set; }
        public static Colours OutputColours { get; set; }



        public static Settings Default
        {
            get
            {
                // Sen
                OutputFont = new Font("Consolas", 12, FontStyle.Regular);
                InputFont = new Font("Consolas", 12, FontStyle.Regular);

                OutputColours = new Colours()
                {
                    Foreground = Color.FromArgb(35, 40, 50),
                    Background = Color.FromArgb(30, 34, 43)
                };

                InputColours = new Colours()
                {
                    Foreground = Color.FromArgb(255, 255, 255),
                    Background = Color.Transparent
                };

                Error = Color.Red;
                Success = Color.Green;
                Warning = Color.Yellow;

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

        [XmlElement("Default_Colours")]
        public Colours DefaultColours { get; set; }

        [XmlElement("Default_Input_Colours")]
        public Colours DefaultInputColours { get; set; }

        [XmlElement("Default_Font")]
        public Font DefaultFont
        {
            get { return this._DefaultFont; }
            set { this._DefaultFont = value; }
        }
        private Font _DefaultFont;
    }
}
