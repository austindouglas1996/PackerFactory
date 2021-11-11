using System;
using System.Drawing;

namespace PackerControlPanel.Image.Drawings
{
    public interface ILabelDrawing
    {
        string Name { get; }

        void DrawPreview(Graphics g, Rectangle imgBounds);
        void Draw(Graphics g, Rectangle imgBounds, ILabel info);
    }
}