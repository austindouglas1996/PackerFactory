using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Common
{
    public class SkidExporterHtml
    {
        private string _SavePath = "";

        public SkidExporterHtml(string savePath)
        {
            this._SavePath = savePath;
        }

        public string Export(Skid skid)
        {
            string output = Resources.SkidTemplate;

            StringBuilder contents = new StringBuilder();
            for (int i = 0; i < skid.Boxes.Count(); i++)
            {
                bool moreThanOne = skid.Boxes[i] > 1;
                contents.AppendLine(string.Format("<h1>{0} {1} @ {2}pc</h1>",  skid.Boxes[i], moreThanOne ? "boxes" : "box", skid.BoxCounts[i]));
            }

            output = output.Replace("{SKID_ID}", skid.ID.ToString())
                .Replace("{PART_NAME}", skid.Part.Name)
                .Replace("{WORK_ORDER}", "#" + skid.Job.Name)
                .Replace("{CONTENTS}", contents.ToString())
                .Replace("{DATE}", DateTime.Today.ToShortDateString());

            string fileNameSafe = skid.Part + skid.ID.ToString();
            foreach (var l in Path.GetInvalidFileNameChars())
                fileNameSafe = fileNameSafe.Replace(l, '.');

            string path = _SavePath + "\\" + (fileNameSafe == null ? "noname" : fileNameSafe) + ".html";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(output);
            }

            return path;
        }
    }
}
