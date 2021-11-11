using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Helpers;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.Image;
using PackerControlPanel.Image.Repository;
using PackerControlPanel.RPCP.Forms;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP
{
    static class Program
    {
        private static PackerUnitOfWork inventory;

        public static Settings Settings
        {
            get;
            private set;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists("Settings.xml"))
                Settings = Settings.LoadFromFile("Settings.xml");
            else
                Settings = new Settings();

            if (!Settings.OfflineNoDb)
            {
                try
                {
                    inventory = new PackerUnitOfWork(new PackerContext());
                }
                catch (Exception e)
                {
                    Logger.GetLogger().Log(e);
                    MessageBox.Show(e.Message, "FATAL ERROR");
                    throw e;
                }
            }

            Application.Run(new Home(inventory));

            Settings.SaveToFile("Settings.xml", Settings);
        }
    }
}
