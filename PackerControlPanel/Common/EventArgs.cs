using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Common
{

    public delegate void CanExecuteEventHandler(object sender, CanExecuteEventArgs e);
    public delegate void PartDescEventHandler(object sender, PartDescEventArgs e);
    public delegate void AddPartDescEventHandler(object sender, AddPartDescEventArgs e);
    public delegate void RemovePartDescEventHandler(object sender, RemovePartDescEventArgs e);
    public delegate void ModifyPartDescEventHandler(object sender, ModifyPartDescEventArgs e);

    public class CanExecuteEventArgs : EventArgs
    {
        public bool CanExecute { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class PartDescEventArgs : EventArgs
    {
        public PartDescEventArgs(PartDescInfo descInfo)
        {
            this.PartDesc = descInfo;
        }

        public PartDescInfo PartDesc { get; set; }
    }

    public class AddPartDescEventArgs : PartDescEventArgs
    {
        public AddPartDescEventArgs(PartDescInfo descInfo)
            : base(descInfo)
        {
        }

        public bool Handled { get; set; }
    }

    public class RemovePartDescEventArgs : PartDescEventArgs
    {
        public RemovePartDescEventArgs(PartDescInfo descInfo)
            : base(descInfo)
        {
        }

        public bool Handled { get; set; }
    }

    public class ModifyPartDescEventArgs : PartDescEventArgs
    {
        public ModifyPartDescEventArgs(int index, PartDescInfo descInfo)
            : base(descInfo)
        {
            this.Index = index;
        }

        public int Index { get; set; }
        public bool Handled { get; set; }
    }
}
