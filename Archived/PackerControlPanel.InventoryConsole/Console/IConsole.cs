using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Console
{
    public interface IConsole : IDisposable
    {
        ConsoleStyle StyleOptions { get; set; }

        bool Enabled { get; set; }

        bool Clear();

        char ReadKey();
        string ReadLine();

        void Write(string text);
        void Write(string text, Color forecolor);
        void Write(string text, Font font, Color foreColor);
        void Write(string format, object[] args);

        void WriteLine(string text);
        void WriteLine(string text, Color foreColor);
        void WriteLine(string text, Font font, Color foreColor);
        void WriteLine(string format, object[] args);
    }
}
