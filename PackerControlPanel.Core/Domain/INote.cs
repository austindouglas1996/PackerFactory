using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Domain
{
    public interface INote
    {
        ICollection<Note> Notes { get; set; }
    }
}
