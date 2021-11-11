using PackerControlPanel.Win32Console.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    public class PartHomeMenuScreen : Screen
    {
        public PartHomeMenuScreen(ScreenManager manager)
            : base(manager)
        {

        }

        public override string Title => "PackerControlPanel -> Win32Console -> Home -> Part Options";

        public override void Exit()
        {
            Console.WriteLine("Exiting part home screen...");
            base.Exit();
        }

        protected override void OnInitialize()
        {
            base.AddOption("Add New part", null);
            base.AddOption("Get part Info", new ScreenItemEventHandler((o, e) => { Console.WriteLine(PartCommands.FindPart(e.Arguments[0])); }));
            base.AddOption("Remove a part", null);
            base.AddOption("Remove all parts", null);
        }
    }
}
