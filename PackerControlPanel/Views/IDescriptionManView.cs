using System;
using System.Collections.Generic;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Presenters;
using PackerControlPanel.UI;
using PackerControlPanel.Data.Common;

namespace PackerControlPanel.Data.Views
{
    public interface IDescriptionManView : IView<List<PartDescInfo>>
    {
        List<PartDescInfo> Descriptions { get; set; }
        
        event AddPartDescEventHandler AddPart;
        event RemovePartDescEventHandler RemovePart;
        event ModifyPartDescEventHandler EditPart;
    }
}