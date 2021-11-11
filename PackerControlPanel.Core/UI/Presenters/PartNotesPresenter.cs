using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI.Views;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Presenters
{
    public class PartNotesPresenter : IPresenter<IPartNotesView>
    {
        private IPartNotesView _view;
        private IPartRepository _parts;
        private Part _part;

        public PartNotesPresenter(IPartNotesView view, IPartRepository parts, Part part)
        {
            this.View = view;
            this._parts = parts;
            this._part = part;
        }

        public IPartNotesView View
        {
            get { return this._view; }
            set { this._view = value; SetupView(); }
        }

        private void SetupView()
        {
            _view.AddNote += _view_AddNote;
            _view.RemoveNote += _view_RemoveNote;
            _view.ModifyNote += _view_ModifyNote;
            //_view.UpdatePart += _view_UpdatePart;
            _view.Load += _view_LoadNotes;
        }

        private void _view_LoadNotes(object sender, EventArgs e)
        {
            _view.Model = _part.Notes.ToList();
        }

        private void _view_UpdatePart(object sender, EventArgs e)
        {
            _part.Notes = _view.Model.ToArray();
            _parts.Edit(_part);
        }

        private void _view_ModifyNote(object sender, PartNoteModifyEventArgs e)
        {
            _view.Model[e.Index] = e.Note;
        }

        private void _view_RemoveNote(object sender, PartNoteEventArgs e)
        {
            _view.Model.Remove(e.Note);
        }

        private void _view_AddNote(object sender, PartNoteEventArgs e)
        {
            _view.Model.Add(e.Note);
        }
    }
}
