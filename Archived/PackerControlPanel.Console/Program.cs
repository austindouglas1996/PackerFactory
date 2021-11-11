namespace PackerControlPanel.Win32Console
{
    using PackerControlPanel.Data;
    using PackerControlPanel.Win32Console.Windows;
    using System;
    using System.Windows.Forms;

    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PackerConsoleWin(Settings.Default, null));
        }
    }
}
