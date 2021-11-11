using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.RPCP
{
    public class Settings
    {
        public bool OfflineNoDb = false;
        public bool PrintEntries = false;
        public bool PrintEntriesDev = false;

        public static void SaveToFile(string path, Settings instance)
        {
            bool fExists = File.Exists(path);
            using (var sw = new StreamWriter(new FileStream(path, fExists ? FileMode.Truncate : FileMode.CreateNew)))
            {
                XmlSerializer serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(sw, instance);
            }
        }

        public static Settings LoadFromFile(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                return (Settings)serializer.Deserialize(fs);
            }
        }
    }
}
