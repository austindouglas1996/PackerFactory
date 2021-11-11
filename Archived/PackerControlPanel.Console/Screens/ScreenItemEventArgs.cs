using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    public class ScreenItemEventArgs : EventArgs
    {
        public ScreenItemEventArgs(string[] args)
            : base()
        {
            this.Arguments = args;
        }

        public string[] Arguments { get; }
    }
}
