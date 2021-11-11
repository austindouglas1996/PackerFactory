namespace PackerControlPanel.Win32Console.Win.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class StackPanel : Panel
    {
        public StackPanel(int w, int h, int x, int y)
          : this(new Rectangle(x, y, w, h))
        {
        }

        public StackPanel(Size size, Point location)
          : this(new Rectangle(location.X, location.Y, size.Width, size.Height))
        {
        }

        public StackPanel(Rectangle bounds)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            base.Top = bounds.Y;
            base.Left = bounds.X;
            base.Width = bounds.Width;
            base.Height = bounds.Height;

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(500, 1000);

            this.PerformLayout();
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            base.OnPaint(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            ArrangeChildren();
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            ArrangeChildren();
            base.OnControlRemoved(e);
        }

        private void ArrangeChildren()
        {
            int lastY = 0;

            foreach (Control child in this.Controls)
            {
                child.Location = new Point(10, lastY + this.AutoScrollPosition.Y);
                lastY += child.Height + 10;
            }

            // Buffer.
            lastY += 50;

            // Increase panel size if required.
            if (this.AutoScrollMinSize.Height < lastY)
                this.AutoScrollMinSize = new Size(this.AutoScrollMinSize.Width, lastY);

            this.Refresh();
        }
    }
}
