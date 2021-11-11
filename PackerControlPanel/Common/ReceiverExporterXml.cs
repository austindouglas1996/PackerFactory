using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PackerControlPanel.Data.Common
{
    using PackerControlPanel.Core;
    using PackerControlPanel.Core.Domain;
    using System.IO;
    using System.Xml.Serialization;

    public class ReceiverExporterXml : IReceiverExporter
    {
        private string _savePath = "";

        public ReceiverExporterXml(string savePath)
        {
            if (!Directory.Exists(savePath))
                throw new DirectoryNotFoundException(savePath);

            this._savePath = savePath;
        }

        /// <summary>
        /// Exports the receiver as a XML document then returns the XML data.
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public string Export(Receiver receiver)
        {
            string filePath = _savePath + receiver.Name + ".XML";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Receiver));

            bool fileExists = File.Exists(filePath);
            using (var fs = new FileStream(filePath, fileExists ? FileMode.Truncate : FileMode.CreateNew))
            {
                using (var sw = new StreamWriter(fs))
                {
                    xmlSerializer.Serialize(sw, receiver);
                }
            }

            return filePath;
        }
    }
}
