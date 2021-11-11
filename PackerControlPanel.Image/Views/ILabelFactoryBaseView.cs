using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Data.Common;
using PackerControlPanel.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Views
{
    public interface ILabelFactoryBaseView<TLabelOrder> : IView
        where TLabelOrder : ILabelOrder
    {
        event EventHandler UpdateImgPreview;
        event AddPartEventHandler CreatePart;
        event GetPartEventHandler PartNameChanged;
        event GetJobEventHandler JobNameChanged;
        event ActionEventHandler Action;

        LabelFactoryProcessor<TLabelOrder> Processor { get; }

        string PackerName { get; set; }
        string PartName { get; set; }
        string PartDescription { get; }
        Part GetPart { get; }


        int[] Boxes { get; set; }
        int[] BoxCount { get; set; }
        string WorkOrder { get; set; }
        Job GetJob { get; }
        string LotOrder { get; set; }
        char[] Shift { get; set; }

        string MfrDates { get; set; }
        Dictionary<DateTime[], int>[] MfrDatesProcessed { get; }

        Bitmap PreviewImg { get; set; }

        void Reset();
    }
}
