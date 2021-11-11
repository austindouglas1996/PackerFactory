using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI;
using PackerControlPanel.Core.UI.Presenters;
using PackerControlPanel.UI;

namespace PackerControlPanel.Core.UI.Views
{
    public interface IPartNotesView : IView<List<Note>>
    {
        PartNotesPresenter Presenter { get; set; }
        
        event EventHandler<PartNoteEventArgs> AddNote;
        event EventHandler<PartNoteEventArgs> RemoveNote;
        event EventHandler<PartNoteModifyEventArgs> ModifyNote;
        event EventHandler<PartNoteModifyEventArgs> SaveChanges;

        void LoadPart(Part part);
    }
}
