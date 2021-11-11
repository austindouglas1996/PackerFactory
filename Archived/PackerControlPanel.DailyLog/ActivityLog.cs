using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.DailyLog
{
    public class ActivityLog
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public int CheckedPans { get; set; }
        public int UnCheckedPans { get; set; }

        public int SecondOPPans { get; set; }
        public int RedTaggedPans { get; set; }

        public string Remarks { get; set; }
    }
}
