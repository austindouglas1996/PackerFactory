using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Win32Console.Win.Controls
{
    public class ConsoleLine : Label
    {
        public ConsoleLine(string text, Font font, Colours colours)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Font = font;
            this.BackColor = colours.Background;
            this.ForeColor = colours.Foreground;

            base.Text = text;     
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            var size = TextRenderer.MeasureText(base.Text, this.Font);
            this.Size = new Size(size.Width, size.Height);

            base.OnTextChanged(e);
        }
    }
}
