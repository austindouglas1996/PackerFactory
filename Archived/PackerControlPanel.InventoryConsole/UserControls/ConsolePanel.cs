namespace PackerControlPanel.InventoryConsole.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class ConsolePanel : Panel
    {
        private const int DefaultBuffer = 500;
        private int _BufferSize = DefaultBuffer;

        public ConsolePanel(int w, int h, int x, int y)
          : this(new Rectangle(x, y, w, h))
        {
        }

        public ConsolePanel(Size size, Point location)
          : this(new Rectangle(location.X, location.Y, size.Width, size.Height))
        {
        }

        public ConsolePanel(Rectangle bounds)
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

        public int BufferSize
        {
            get { return this._BufferSize; }
            set { this._BufferSize = value; }
        }

        public void Add(ConsoleLabel line)
        {
            this.Controls.Add(line);
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


            int calBufferSize = 0;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                var control = (ConsoleLabel)this.Controls[i];
                if (control == null)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                }

                // Add to lines.
                calBufferSize += control.GetLineCount;
            }

            if (calBufferSize > BufferSize)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    var control = (ConsoleLabel)this.Controls[i];
                    calBufferSize -= control.GetLineCount;

                    Controls.RemoveAt(i);

                    if (calBufferSize < BufferSize)
                        break;
                }
            }

            this.Refresh();
        }
    }
}
