using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace PackerControlPanel.Image.Drawings.Elements
{
    public class LineStacker : DrawableObject
    {
        private List<Line> _lines;
        private List<int> _lineType;

        public LineStacker()
        {
            _lines = new List<Line>();
            _lineType = new List<int>();
        }

        public IReadOnlyList<Line> Lines
        {
            get { return _lines; }
        }

        public void AddLine(string text, Font font, HorizontalAlignment hAlign, Size? bounds = null, Rectangle? buffer = null)
        {
            if (bounds == null)
                bounds = new Size(0, 0);

            Line newLine = new Line(text, font, bounds.Value);
            newLine.HAlignment = hAlign;
            newLine.Buffer = buffer.Value;

            _lines.Add(newLine);
            _lineType.Add(0);
        }

        public void AddNewLine(string text, Font font, HorizontalAlignment hAlign, Size? bounds = null, Rectangle? buffer = null)
        {
            if (bounds == null)
                bounds = new Size(0, 0);

            Line newLine = new Line(text, font, bounds.Value);
            newLine.HAlignment = hAlign;
            newLine.Buffer = buffer.Value;

            _lines.Add(newLine);
            _lineType.Add(1);
        }

        public void Draw(Graphics g)
        {
            // Bounds of this element.
            Rectangle bounds = GetBounds();

            // Position of this element.
            int x = bounds.X;
            int y = bounds.Y;

            // Last drawing position of the previous element.
            int[] lastX = new int[2] { 0, x + bounds.Width };
            int lastY = 0;

            // The highest element on the current line.
            int highestY = 0;

            for (int i = 0; i < _lines.Count; i++)
            {
                // Position to draw this element at.
                Point position = new Point(0, 0);

                // The current element to draw and the type of line it is.
                Line line = _lines[i];
                int lineType = _lineType[i];

                // Reset the X position if it's a new line.
                if (lineType == 1)
                {
                    lastX[0] = 0;
                    lastX[1] = 0;
                }

                switch (line.HAlignment)
                {
                    case HorizontalAlignment.Left:
                        position = new Point(x + lastX[0], y + lastY);
                        lastX[0] = line.GetBounds().Width;
                        break;
                    case HorizontalAlignment.Center:
                        position = new Point(x + (bounds.Width / 2 - line.GetBounds().Width / 2), y + lastY);
                        lastX[0] = line.GetBounds().Width;
                        break;
                    case HorizontalAlignment.Right:
                        position = new Point(x + bounds.Width - line.GetBounds().Width - lastX[1], y + lastY);
                        lastX[1] = line.GetBounds().Width;
                        break;
                }

                int height = line.GetBounds().Height;
                if (height > highestY)
                    highestY = height;

                if (_lineType.Count - 1 != i &&
                    _lineType[i + 1] == 1)
                {
                    lastY += highestY;
                    highestY = 0;
                }

                Rectangle lBounds = new Rectangle(position.X + line.Buffer.X, position.Y + line.Buffer.Y, line.Bounds.Width, line.Bounds.Height);
                g.DrawString(line.Text, line.Font, Brushes.Black, lBounds, new StringFormat());
            }
        }
    }
}