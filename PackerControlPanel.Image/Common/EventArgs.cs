using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public delegate void ActionEventHandler(object sender, ActionEventArgs e);

    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs(LabelFactoryActionHandler handler)
        {
            this.Handler = handler;
        }

        public LabelFactoryActionHandler Handler { get; set; }
    }
}
