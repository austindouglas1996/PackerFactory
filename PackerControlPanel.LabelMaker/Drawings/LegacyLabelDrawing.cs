
using System;
using System.Drawing;

namespace PackerControlPanel.Image.Drawings
{
    public class LegacyLabelDrawing : ILabelDrawing
    {
        public LegacyLabelDrawing()
        {
        }

        public string Name
        {
            get { return "Legacy Drawing - Pre Feb-2019."; }
        }

        public void DrawPreview(Graphics g, Rectangle imgBounds)
        {
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
            //TODO: Wrtie logic so a label is created that looks like the labels before we wrote this program.
        }
    }
}