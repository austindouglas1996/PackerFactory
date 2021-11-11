using PackerControlPanel.Skids.Domain;
using PackerControlPanel.Skids.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids.Common
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
                contents.AppendLine(string.Format("{0} @ {1}", skid.Boxes[i], skid.BoxCounts[i]));
            }

            output = output.Replace("{SKID_ID}", skid.ID.ToString())
                .Replace("{PART_NAME}", skid.Part)
                .Replace("{WORK_ORDER}", "#" + skid.Job)
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
