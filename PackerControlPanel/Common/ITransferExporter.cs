using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Common
{
    interface ITransferExporter
    {
        string Export(Transfer transfer);
    }
}
