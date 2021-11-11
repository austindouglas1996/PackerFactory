using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel
{
    /// <summary>
    /// Holds the app settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            ReceiverSavePath = "Receivers";
            WinWidth = 180;
            WinHeight = 300;
        }

        /// <summary>
        /// Path to save receivers at.
        /// </summary>
        public string ReceiverSavePath { get; set; }

        /// <summary>
        /// Width of the window.
        /// </summary>
        public int WinWidth { get; set; }

        /// <summary>
        /// Height of the window.
        /// </summary>
        public int WinHeight { get; set; }

        /// <summary>
        /// Window & app colors. colors.
        /// </summary>
        public ConsoleColor[] Colors = new ConsoleColor[6]
        {
            ConsoleColor.Black, // Background color.
            ConsoleColor.White, // Font color.
            ConsoleColor.Yellow, // Special color
            ConsoleColor.Red, // Error color.
            ConsoleColor.Yellow, // Warning color.
            ConsoleColor.Green // Success color.           
        };

        /// <summary>
        /// Load an instance of the <see cref="AppSettings"/> class from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static AppSettings LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                return (AppSettings)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Save an instance of the <see cref="AppSettings"/> class to a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="settings"></param>
        public static void SaveToFile(string filePath, AppSettings settings)
        {
            using (var sw = new StreamWriter(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(sw, settings);
            }
        }
    }
}
