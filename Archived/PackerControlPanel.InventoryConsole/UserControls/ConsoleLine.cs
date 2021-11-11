using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryConsole.UserControls
{
    public class ConsoleLabel : Label
    {
        public ConsoleLabel(string text, Font font, Colours colours)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Font = font;
            this.BackColor = colours.Background;
            this.ForeColor = colours.Foreground;

            base.Text = text;
        }

        /// <summary>
        /// Counts the number of lines.
        /// </summary>
        public virtual int GetLineCount
        {
            get
            {
                int nL = this.Text.Split('\n').Length;

                foreach (Control child in this.Controls)
                {
                    nL += child.Text.Split('\n').Length;
                }

                return nL;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ResizeLabel();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResizeLabel();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeLabel();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        private void ResizeLabel()
        {
            if (this.Text == "")
                return;

            Size ControlSize = new Size(this.Width, Int32.MaxValue);
            Size TextSize = TextRenderer.MeasureText(base.Text, this.Font, ControlSize, TextFormatFlags.Default);

            this.Width = TextSize.Width;
            this.Height = TextSize.Height;
        }
    }
}
