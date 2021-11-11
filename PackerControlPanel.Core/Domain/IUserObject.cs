using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain
{
    interface IUserObject
    {
        List<Tuple<string, string>> UserObjects { get; set; }
    }
}
