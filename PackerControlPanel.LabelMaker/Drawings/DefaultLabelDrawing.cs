using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using PackerControlPanel.Image.Helpers;
using PackerControlPanel.Image.Drawings;
using PackerControlPanel.Image.Drawings.Elements;

namespace PackerControlPanel.Image.Drawings
{
    public class DefaultLabelDrawing : ILabelDrawing
    {
        public DefaultLabelDrawing()
        {
        }

        public string Name
        {
            get { return "Default Label Drawing."; }
        }

        public void DrawPreview(Graphics g, Rectangle imgBounds)
        {
            // Draw background.
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 600, 400));

            // Create label.
            Label label = new LabelBuilder()
                .SetPacker("Preview.")
                .SetPart("PREVIEW", "A simple description about a part.")
                .SetJob("PREV01")
                .SetLot("PREVLOT01")
                .SetCount(1)
                .SetShift('1')
                .SetType(LabelOrderEntryType.Box)
                .SetDates(new DateTime[] { DateTime.Now }, DateTime.Now)
                .Build();

            this.Draw(g, imgBounds, label);
        }

        public void Draw(Graphics g, Rectangle imgBounds, ILabel info)
        {
            Rectangle margin = imgBounds;

            LineStacker stack = new LineStacker();
            stack.Position = new Point(10, 10);
            stack.Bounds = new Size(margin.Width, margin.Height);

            Font nameFont = new Font("Arial", 14);
            Size nameSize = TextRenderer.MeasureText(info.PackerName, nameFont);
            Point namePos = new Point(margin.Width - nameSize.Width - 40, 10);

            // Draw the packer name.
            g.DrawString(info.PackerName, nameFont, Brushes.Black, namePos, new StringFormat());

            stack.AddNewLine(info.PartName, new Font("Arial", 36, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(0, 0, 0, 5));
            stack.AddNewLine(String.Format("*{0}*", info.PartName), new Font("Free 3 Of 9 Extended", 40), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(0, 0, 0, 10));

            // Box Qty.
            stack.AddNewLine("Box Qty:", new Font("Arial", 20, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Left, new Size(0, 0), new Rectangle(5, 0, 0, 0));
            stack.AddLine(info.Count + "pc", new Font("Arial", 36, FontStyle.Italic | FontStyle.Bold), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(0, 0, 0, 5));
            stack.AddNewLine(string.Format("*{0}*", info.Count), new Font("Free 3 Of 9 Extended", 40), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(0, 0, 0, 5));

            // Description.
            stack.AddNewLine("Description:", new Font("Arial", 14, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Left, new Size(0, 0), new Rectangle(5, 0, 10, 0));
            stack.AddLine(info.PartDescription, new Font("Arial", 16, FontStyle.Bold), HorizontalAlignment.Left, new Size(350, 60), new Rectangle(0, 0, 10, 0));

            // Work order.
            stack.AddNewLine("#" + info.WorkOrder, new Font("Arial", 24, FontStyle.Bold | FontStyle.Italic), HorizontalAlignment.Right, new Size(0, 0), new Rectangle(0, 0, 20, 5));
            stack.AddLine("Work Order:", new Font("Arial", 14, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Right, new Size(0, 0), new Rectangle(5, 0, 0, 0));

            stack.AddLine("Mfr. Dates:", new Font("Arial", 14, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Left, new Size(0, 0), new Rectangle(5, 0, 0, 0));
            stack.AddLine(string.Format("Shift:{0}", info.Shift), new Font("Arial", 14, FontStyle.Underline | FontStyle.Bold), HorizontalAlignment.Left, new Size(0, 0), new Rectangle(35, 0, 0, 0));

            stack.AddNewLine(string.Format("*{0}*", info.WorkOrder), new Font("Free 3 Of 9 Extended", 40), HorizontalAlignment.Right, new Size(0, 0), new Rectangle(20, -10, 20, 0));
            stack.AddLine(Helper.DateTimeToString(info.MfrDates), new Font("Arial", 12), HorizontalAlignment.Left, new Size(180, 80), new Rectangle(5, -10, 0, 0));


            stack.AddLine(DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Italic), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(35, 10, 0, 0));
            stack.AddLine("Pack Date:", new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline), HorizontalAlignment.Center, new Size(0, 0), new Rectangle(-60, 10, 0, 0));

            stack.Draw(g);
        }
    }
}