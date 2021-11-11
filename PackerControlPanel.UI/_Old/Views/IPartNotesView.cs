using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.UI;

namespace PackerControlPanel.UI.Views
{
    using PackerControlPanel.Core.UI;
    using PackerControlPanel.UI.Presenters;
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
