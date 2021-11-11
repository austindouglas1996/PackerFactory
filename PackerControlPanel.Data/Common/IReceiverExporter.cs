using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Common
{
    public interface IReceiverExporter
    {
        string Export(Receiver document);
    }
}
