using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    /// <summary>
    /// Handles menu item events.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void ScreenItemEventHandler(object sender, ScreenItemEventArgs args);

    public class ScreenItem
    {
        /// <summary>
        /// Item text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Event executed on item call.
        /// </summary>
        public event ScreenItemEventHandler Execute;

        /// <summary>
        /// Execute the event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        internal void OnExecute(object sender, string[] args)
        {
            this.Execute?.Invoke(this, new ScreenItemEventArgs(args));
        }
    }
}
