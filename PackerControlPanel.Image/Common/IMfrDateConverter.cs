using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public interface IMfrDateConverter
    {
        Dictionary<DateTime[], int>[] DecipherString(string value);
        Tuple<DateTime[], int> DecipherLine(string line);
    }
}
