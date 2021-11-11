using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.InventoryConsole.Console
{
    public class ConsoleStyle
    {
        public Color Backcolor { get; set; }
        public Color Forecolor { get; set; }

        public Color FontBackColor { get; set; }
        public Color FontForeColor { get; set; }

        public Color FontMouseOverColor { get; set; }
        public Color FontMouseClickColor { get; set; }

        public Color Warning { get; set; }
        public Color Error { get; set; }
        public Color Success { get; set; }

        public Font HeadingFont { get; set; }

        public Font InputFont { get; set; }

        public Font OutputFont { get; set; }

        public static ConsoleStyle DefaultGray
        {
            get
            {
                return new ConsoleStyle()
                {
                    Backcolor = Color.FromArgb(33, 32, 32),
                    Forecolor = Color.FromArgb(27, 26, 26),

                    FontForeColor = Color.FromArgb(255, 255, 255),
                    FontBackColor = Color.Transparent,

                    FontMouseOverColor = Color.Purple,
                    FontMouseClickColor = Color.DarkGray,

                    Error = Color.Red,
                    Success = Color.Green,
                    Warning = Color.Yellow,

                    HeadingFont = new Font("Consolas", 24),
                    InputFont = new Font("Consolas", 16, FontStyle.Regular),
                    OutputFont = new Font("Consolas", 12, FontStyle.Regular)
                };
            }
        }
    }
}
