using PackerControlPanel.InventoryConsole.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.InventoryConsole
{
    public class Settings
    {
        public Settings()
        {
        }

        public static Settings DeserializeFile(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            using (var fs = new FileStream(file, FileMode.Open))
            {
                return (Settings)serializer.Deserialize(fs);
            }
        }

        public static void SerializeToFile(string savePath, Settings instance)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            using (var fs = new StreamWriter(new FileStream(savePath, FileMode.OpenOrCreate)))
            {
                serializer.Serialize(fs, instance);
            }
        }
    }
}
