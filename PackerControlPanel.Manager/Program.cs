using PackerControlPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Manager
{
    static class Program
    {
        internal static PackerContext Context { get; private set; }
        internal static PackerUnitOfWork Inventory { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Context = new PackerContext();
            Inventory = new PackerUnitOfWork(Context);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PartMan());
        }
    }
}
