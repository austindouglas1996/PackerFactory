namespace PackerControlPanel.Image.Drawings.Elements
{
    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Drawing;

    public abstract class DrawableObject
    {
        public DockStyle Dock { get; set; }
        public Size Bounds { get; set; }
        public Rectangle Buffer { get; set; }
        public Point Position { get; set; }

        public virtual Rectangle GetBounds()
        {
            return new Rectangle(Position.X + Buffer.X, Position.Y + Buffer.Y, Bounds.Width + Buffer.Width, Bounds.Height + Buffer.Height);
        }
    }
}