using CommandHandlerLib;
using CommandHandlerLib.Helpers;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Helpers;
using PackerControlPanel.InventoryConsole.Commands;
using PackerControlPanel.InventoryConsole.Console;
using PackerControlPanel.InventoryConsole.Extensions;
using PackerControlPanel.InventoryConsole.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryConsole
{
    public partial class Form1 : Form
    {
        // Constants.
        private readonly Point OutputOffset = new Point(-15, -90);

        // Repository.
        private PackerContext _AlkonContext;
        private PackerUnitOfWork _AlkonInventory;

        // Controls.
        private ConsolePanel _Output;
        private TextBox _Input;

        // Console.
        private CommandHandler _CMDHandler;
        private static PackerConsole _Console;

        // IO.
        private Settings _Settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        /// <param name="args"></param>
        public Form1(string[] args)
        {
            InitializeComponent();
            this.Text = "PackerControlPanel.InventoryConsole - Created by Austin Douglas. 2016-2018";

            // Command handler.
            _CMDHandler = new CommandHandler();
            _CMDHandler.ThrowExceptions = true;

            this._Output = new ConsolePanel(0, 0, 0, 0);
            this._Input = new TextBox();

            // Console.
            _Console = new PackerConsole(this._CMDHandler, ConsoleStyle.DefaultGray);
            _Console.Enabled = false;

            _Console.Output = this._Output;
            _Console.Input = this._Input;

            LoadSettings();

            this.BackColor = _Console.StyleOptions.Forecolor;

            // Output.
            this._Output.Height = this.Height - OutputOffset.Y;
            this._Output.Width = this.Width - OutputOffset.X;
            this._Output.BackColor = _Console.StyleOptions.Backcolor;
            this.Controls.Add(this._Output);

            // Input.
            this._Input.Width = this._Input.Width;
            this._Input.Font = _Console.StyleOptions.OutputFont;
            this._Input.BackColor = _Console.StyleOptions.Forecolor;
            this._Input.BorderStyle = BorderStyle.None;
            this._Input.ForeColor = _Console.StyleOptions.FontForeColor;
            this.Controls.Add(this._Input);

            // Events.
            this.SizeChanged += Window_SizeChanged;

            // Properties.
            this.Size = new Size(1000, 600);

            _CMDHandler.AddCommand(
                new AboutCommand(),
                new ImportCommand(),
                new CreateHyperLink(this._Output));

            var commandLibs = from c in Assembly.GetExecutingAssembly().GetTypes()
                              where c.IsClass && c.Namespace == typeof(CommandUtility).Namespace
                              select c;
            foreach (var commandLib in commandLibs)
            {
                var mCommands = MethodCommandHelper.GetCommandsFromAssembly(commandLib.Assembly, commandLib.Namespace, commandLib.Name);
                _CMDHandler.AddCommand(mCommands);
            }

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DatabaseConnection_Work;
            worker.ProgressChanged += DatabaseConnection_ProgressChanged;
            worker.RunWorkerCompleted += DatabaseConnection_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        public static IConsole Console
        {
            get { return _Console; }
        }

        private void DatabaseConnection_Work(object sender, DoWorkEventArgs e)
        {
            bool connectionEstablished = false;
            Dictionary<string, Exception> errorList = new Dictionary<string, Exception>();

            // Get the caller.
            BackgroundWorker worker = (BackgroundWorker)sender;

            worker.ReportProgress(0, CreateProgressArg("Initiating Database Connection...", ConsoleFlags.Warning));

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    worker.ReportProgress(0, CreateProgressArg("Creating store instance...", ConsoleFlags.None));

                    _AlkonContext = new PackerContext("ReceivingPackerDb");

                    // Create the database if it does not exist.
                    if (!_AlkonContext.Database.Exists())
                    {
                        worker.ReportProgress(0, CreateProgressArg("Unable to locate existing database. Attempting database creation...", ConsoleFlags.Warning));
                        bool result = _AlkonContext.Database.CreateIfNotExists();

                        if (result)
                            worker.ReportProgress(0, CreateProgressArg("Database creation returned with 0 errors.", ConsoleFlags.Success));
                        else
                            worker.ReportProgress(0, CreateProgressArg("Database creation has failed.", ConsoleFlags.Error));
                    }

                    _AlkonInventory = new PackerUnitOfWork(_AlkonContext);

                    worker.ReportProgress(0, CreateProgressArg("Database Initialized Successfully.", ConsoleFlags.Success));
                    connectionEstablished = true;
                    break;
                }
                catch (Exception error)
                {
                    worker.ReportProgress(0, CreateProgressArg("Database connection failed.", ConsoleFlags.Error));
                    errorList.Add(string.Format("Database connection attempt: {0}", i), error);
                }
            }

            // Did connection fail?
            if (!connectionEstablished)
            {
                worker.ReportProgress(0, CreateProgressArg("A fatal error occured. Database connection was unsuccessfull. Please see ErrorLog.txt for details.", ConsoleFlags.Error));

                using (var fs = new FileStream("ErrorLog.txt", FileMode.OpenOrCreate))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        foreach (var error in errorList)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(error.Key);
                            sb.AppendLine(string.Format("Message: {0} {3} StackTrace: {1} {3} Date: {2}", error.Value.Message, error.Value.StackTrace, DateTime.Now.ToString(), Environment.NewLine));
                            sb.AppendLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);

                            sw.WriteLine(sb.ToString());
                        }
                    }
                }

                Console.ReadLine();
                Environment.Exit(1);
            }
        }

        private void DatabaseConnection_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tuple<string, ConsoleFlags> arg = (Tuple<string, ConsoleFlags>)e.UserState;
            Console.WriteLine(arg.Item1, arg.Item2);
        }

        private void DatabaseConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CommandUtility.AlkonInventory = _AlkonInventory;
            CommandUtility.CmdHandler = this._CMDHandler;

            this._CMDHandler.AddCommand(
                new XmlExportCommand((IXmlRepository)_AlkonInventory.Parts, "Parts"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.Jobs, "Jobs"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.Receivers, "Receiver"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.ReceiverEntries, "Entries"));


            _Console.Enabled = true;
        }

        private Tuple<string, ConsoleFlags> CreateProgressArg(string text, ConsoleFlags flag)
        {
            return new Tuple<string, ConsoleFlags>(text, flag);
        }

        /// <summary>
        /// Invoked when the window size has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, EventArgs e)
        {
            this._Output.Height = this.Height + OutputOffset.Y;
            this._Output.Width = this.Width + OutputOffset.X;

            Point inputPos = new Point(10, _Output.Top + _Output.Height + 20);
            _Input.Location = inputPos;

            _Input.Width = _Output.Width;
        }

        private void LoadSettings()
        {
            try
            {
                if (!File.Exists("Settings.xml"))
                {
                    _Console.WriteLine("Settings file not found. Creating new instance.", ConsoleFlags.Error);

                    _Settings = new Settings();

                    // Save.
                    Settings.SerializeToFile("Settings.xml", _Settings);

                    while (!File.Exists("Settings.xml"))
                    {
                        Settings.SerializeToFile("Settings.xml", _Settings);
                    }
                }
                else
                {
                    _Settings = Settings.DeserializeFile("Settings.xml");
                }
            }
            catch (Exception e)
            {
                _Console.WriteLine("Error loading settings. See errorlog for details.", ConsoleFlags.Error);
                Logger.GetLogger().Log(new LogEntry(LoggingEventType.Error, e.Message, e));
            }
        }
    }
}
