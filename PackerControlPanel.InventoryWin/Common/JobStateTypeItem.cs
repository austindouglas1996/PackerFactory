using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryWin
{
    internal class JobStateTypeItem
    {
        public JobStateTypeItem(int index, JobStateType type)
        {
            this.Index = index;
            this.Type = type;
        }

        public int Index { get; set; }
        public JobStateType Type { get; set; }

        public string Name
        {
            get { return Type.ToString(); }
        }

        public string GetDesc
        {
            get { return EnumHelper.GetDescAttr(typeof(JobStateType), Name).Description; ; }
        }

        public override string ToString()
        {
            return Name; //+ "-" + GetDesc;
        }
    }
}
