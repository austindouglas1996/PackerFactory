using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console
{
    public interface IConsole : IDisposable
    {
        bool Clear();

        char ReadKey();
        string ReadLine();

        void WriteLine(string text);
        void WriteLine(string text, Color foreColor);
        void WriteLine(string text, Font font, Color foreColor);
        void WriteLine(string format, object[] args);
    }
}
