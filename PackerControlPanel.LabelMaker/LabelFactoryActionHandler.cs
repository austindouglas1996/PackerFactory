using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public class LabelFactoryActionHandler
    {
        public LabelFactoryActionHandler()
        {
            this.Actions = new List<ILabelFactoryAction>();
        }

        public List<ILabelFactoryAction> Actions { get; set; }
        public void Execute(ILabelOrder[] orders, params object[] args)
        {
            foreach (var action in Actions)
            {
                action.ExecuteAction(orders, args);
            }
        }
    }
}
