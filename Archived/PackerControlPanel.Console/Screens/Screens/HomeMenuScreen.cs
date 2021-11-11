using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    public class HomeMenuScreen : Screen
    {
        public HomeMenuScreen(ScreenManager manager)
            : base(manager)
        {

        }

        public override string Title => "PackerControlPanel -> Win32Console -> Home";

        public override void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }

        protected override void OnInitialize()
        {
            base.AddOption("View Part Collection", new ScreenItemEventHandler((o,e) => { base.Manager.Push(new PartHomeMenuScreen(this.Manager)); }));
            base.AddOption("View Job Collection", null);
            base.AddOption("View Receiver Collection", null);
            base.AddOption("View Receiver Entries Collection", null);
            base.AddOption("Database Options", null);
        }
    }
}
