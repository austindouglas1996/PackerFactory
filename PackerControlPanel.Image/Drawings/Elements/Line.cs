using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace PackerControlPanel.Image.Drawings.Elements
{
    public class Line : DrawableObject
    {
        public Line(string text, Font font)
            : this(text, font, new Size(0,0))
        {
            this.Text = text;
            this.Font = font;
        }

        public Line(string text, Font font, Size bounds)
        {
            this.Text = text;
            this.Font = font;      
            this.Bounds = bounds;
        }

        public string Text { get; set; }
        public Font Font { get; set; }
        public HorizontalAlignment HAlignment { get; set; }
        public VerticalAlignment VAlignment { get; set; }

        public Size GetSize()
        {
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
            return new Size(Math.Max(textSize.Width, Bounds.Width) + Buffer.Width, Math.Max(textSize.Height, Bounds.Height) + Buffer.Height);
        }

        public override Rectangle GetBounds()
        {
            Size size = GetSize();
            return new Rectangle(Position.X + Buffer.X, Position.Y + Buffer.Y, size.Width + Buffer.Width, size.Height + Buffer.Height);
        }
    }
}