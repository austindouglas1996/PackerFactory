using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryConsole.UserControls
{
    public class ConsoleHyperLink : ConsoleLabel
    {
        public ConsoleHyperLink(string text, string fontName, int fontSize, Colours colours)
            : base(text, new Font(fontName, fontSize, FontStyle.Italic | FontStyle.Underline), colours)
        {
            // Set default colours.
            MouseOverColour = new Colours() { Background = Color.Transparent, Foreground = Color.Blue };
            MouseClickColour = new Colours() { Background = Color.Transparent, Foreground = Color.Blue };

            this.DefaultColours = colours;
        }

        public Colours DefaultColours { get; set; }
        public Colours MouseOverColour { get; set; }
        public Colours MouseClickColour { get; set; }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetColours(MouseOverColour);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetColours(DefaultColours);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            SetColours(MouseClickColour);
            base.OnMouseClick(e);
        }

        private void SetColours(Colours newColours)
        {
            this.BackColor = newColours.Background;
            this.ForeColor = newColours.Foreground;
        }
    }
}
