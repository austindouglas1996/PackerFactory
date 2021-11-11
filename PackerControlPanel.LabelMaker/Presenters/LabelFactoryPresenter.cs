using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PackerControlPanel.Image.Views;
using PackerControlPanel.Image.Repository;
using PackerControlPanel.Image.Drawings;
using PackerControlPanel.Image.Helpers;
using PackerControlPanel.Core.UI;
using PackerControlPanel.UI;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.Data.Common;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Image.Presenters
{
    public class LabelFactoryPresenter<TLabelOrder> : IPresenter<ILabelFactoryBaseView<TLabelOrder>>
        where TLabelOrder : ILabelOrder
    {
        private bool Offline = false;
        private PackerUnitOfWork Domain;
        private IPartDescRepository DescDomain;
        private ILabelDrawing _Drawing;
        private ILabelFactoryBaseView<TLabelOrder> _view;

        public LabelFactoryPresenter(ILabelFactoryBaseView<TLabelOrder> view, PackerUnitOfWork domain, IPartDescRepository descDomain, ILabelDrawing drawing)
        {
            this.View = view;
            this.Domain = domain;
            this.DescDomain = descDomain;
            this._Drawing = drawing;
        }

        public LabelFactoryPresenter(ILabelFactoryBaseView<TLabelOrder> view, IPartDescRepository descDomain, ILabelDrawing drawing)
            : this(view, null, descDomain, drawing)
        {
            this.Offline = true;
        }

        public ILabelFactoryBaseView<TLabelOrder> View
        {
            get { return _view; }
            private set { _view = value; InitView(value); }
        }

        public ILabelDrawing Drawing
        {
            get { return _Drawing; }
        }

        ILabelFactoryBaseView<TLabelOrder> IPresenter<ILabelFactoryBaseView<TLabelOrder>>.View => throw new NotImplementedException();

        private void InitView(ILabelFactoryBaseView<TLabelOrder> view)
        {
            // Events.
            this.View.CreatePart += View_CreatePart;
            this.View.UpdateImgPreview += View_UpdateImgPreview;
        }

        private void View_CreatePart(object sender, AddPartEventArgs e)
        {
            if (Offline)
                return;

            Domain.Parts.Add(e.Part);
            Domain.Complete();

            e.Handled = true;
        }

        private void View_UpdateImgPreview(object sender, EventArgs e)
        {
            // Graphics.
            Bitmap img = new Bitmap(600, 400);
            Graphics g = Graphics.FromImage(img);

            // Draw background.
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 600, 400));

            // Label info.
            string partName = _view.PartName == "" ? "Preview" : _view.PartName;
            string description = _view.PartDescription == "" ? "Preview description." : _view.PartDescription;

            PartDescInfo part = new PartDescInfo(partName, description);
            int boxCount = _view.BoxCount.Length > 0 ? _view.BoxCount[0] : 0;
            char shift = _view.Shift.Length > 0 ? _view.Shift[0] : 'N';
            DateTime[] dates = _view.MfrDatesProcessed.Length > 0 ? new DateTime[] { _view.MfrDatesProcessed[0].Keys.ToList()[0][0] } : new DateTime[] { };

            Label label = new LabelBuilder()
                .SetPacker(_view.PackerName)
                .SetPart(part.PartName, part.FormalDescription)
                .SetJob(_view.WorkOrder)
                .SetLot(_view.LotOrder)
                .SetCount(boxCount)
                .SetShift(shift)
                .SetType(LabelOrderEntryType.Box)
                .SetDates(dates, DateTime.Now)
                .Build();

            // Draw label.
            _Drawing.Draw(g, new Rectangle(0, 0, 600, 400), label);

            _view.PreviewImg = img;

            g.Dispose();
        }
    }
}