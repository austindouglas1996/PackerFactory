using PackerControlPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PackerControlPanel.Data.Helpers;

namespace PackerControlPanel.v3Importer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionPath = "ReceivingPackerDb";
            if (args.Length > 0)
                connectionPath = args[0];

            try
            {
                bool directoryFound = false;

                WriteText("Creating connection...", ConsoleColor.Yellow);

                PackerContext context = new PackerContext(connectionPath);
                PackerUnitOfWork worker = new PackerUnitOfWork(context);

                WriteText("Connection established.", ConsoleColor.Green);

                string responce = "";
                do
                {
                    WriteText("Please provide the directory path to the folder containing the v3 files.");
                    WriteText("Note: Files *MUST* be named pc.xml,jc.xml,jce.xml", ConsoleColor.Yellow);

                    bool foundp = false;
                    bool foundj = false;
                    bool foundje = false;

                    responce = Console.ReadLine();
                    if (!Directory.Exists(responce))
                    {
                        WriteText("Invalid directory provided. Failed to find that directory.", ConsoleColor.Red);
                        continue;
                    }

                    var files = Directory.GetFiles(responce, "*.xml");
                    foreach (var file in files)
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.Name == "pc.xml")
                            foundp = true;
                        if (info.Name == "jc.xml")
                            foundj = true;
                        if (info.Name == "jce.xml")
                            foundje = true;
                    }

                    if (!foundp ||
                        !foundj ||
                        !foundje)
                    {
                        WriteText("Failed to find all 3 files in that directory. Please try again.", ConsoleColor.Red);
                    }

                    directoryFound = true;

                }
                while (!directoryFound);

                WriteText("Pre-conditions met. Creating new instance of V3ResourceImporter.", ConsoleColor.Green);
                WriteText("Note: This program will not run in a new thread due to shear lazyness. WIll take a large amount of time to process.", ConsoleColor.Yellow);

                // Import.
                string result = V3ResourceImporter.Import(worker, responce);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine(e.Message);
                Console.WriteLine("FATAL ERROR. PRESS ANY BUTTON TO EXIT.");
                Console.ReadKey();
                throw e;
            }
        }

        private static void WriteText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToShortDateString(), text));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
