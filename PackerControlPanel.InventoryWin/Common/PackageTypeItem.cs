using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryWin
{
    internal class PackageTypeItem
    {
        internal PackageTypeItem(int index, PackageType pType)
        {
            this.Index = index;
            this.PackageType = pType;
        }

        public int Index { get; set; }

        public PackageType PackageType { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.PackageType.ToString();
            }
        }

        /// <summary>
        /// Gets the description about the package type.
        /// </summary>
        public string GetDesc
        {
            get
            {
                return EnumHelper.GetDescAttr(typeof(PackageType), Name).Description;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - ({1})", Name, GetDesc);
        }
    }

}
