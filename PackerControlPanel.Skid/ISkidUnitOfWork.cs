using PackerControlPanel.Skids.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids
{
    public interface ISkidUnitOfWork
    {
        ISkidRepository Skids { get; }
    }
}
