using CommandHandlerLib;
using CommandHandlerLib.Commands;
using CommandHandlerLib.Helpers;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Helpers;
using PackerControlPanel.Win32Console;
using PackerControlPanel.Win32Console.Commands;
using PackerControlPanel.Win32Console.Win.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Win32Console
{
    public class PackerConsoleWin : Form
    {
        // Constants.
        private readonly Point OutputOffset = new Point(-15, -90);

        // Controls.
        private IConsole _Console;
        private StackPanel _Output;
        private TextBox _Input;

        // Repository.
        private PackerContext _AlkonContext;
        private PackerUnitOfWork _AlkonInventory;

        // Command handling.
        private CommandHandler _CMDHandler;

        // IO.
        private Settings _Settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackerConsoleWin"/> class.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        public PackerConsoleWin(Settings settings, string[] args)
        {
            if (Instance == null)
                Instance = this;

            this._Settings = settings;

            // Initialize will already initialize components and database.
            Initialize(args);       
        }

        /// <summary>
        /// Gets an instance of the <see cref="PackerConsoleWin"/> class.
        /// </summary>
        internal static PackerConsoleWin Instance
        {
            get; private set;
        }

        /// <summary>
        /// Gets the unit of work that contains the inventory.
        /// </summary>
        public PackerUnitOfWork AlkonInventory
        {
            get { return this._AlkonInventory; }
        }

        /// <summary>
        /// Gets the console to read or write from.
        /// </summary>
        public IConsole Console
        {
            get { return this._Console; }
            private set { this._Console = value; }
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        public Settings Settings
        {
            get { return this._Settings; }
            set { this._Settings = value; }
        }

        public void RunCommand(string input)
        {
            if (input == "close")
            {
                _AlkonInventory.Complete();
                Environment.Exit(0);
            }

            try
            {
                CommandResult result = _CMDHandler.ProcessInput(input);

                if (result.ResultType == CommandResultType.ErrorByException)
                    throw result.ExceptionThrown;

                ConsoleFlags flags = ConsoleFlags.None;

                if (result.ResultType == CommandResultType.Error || result.ResultType == CommandResultType.ErrorByException)
                    flags = ConsoleFlags.Error;
                else if (result.ResultType == CommandResultType.Warning)
                    flags = ConsoleFlags.Warning;
                else if (result.ResultType == CommandResultType.Success)
                    flags = ConsoleFlags.Success;

                this.Console.WriteLine("\n" + result.Message);

                _AlkonInventory.Complete();

            }
            catch (Exception e)
            {
                string exceptionFormat = "[{0}] {1}";
                Utility.Write(string.Format(exceptionFormat, e.GetType().Name, e.Message), ConsoleFlags.Error);
            }
        }

        private void Initialize(string[] args)
        {
            InitializeComponents();

            // Initialize components before creating the console.
            this.Console = new PackerConsole(this._Output, this._Input, this.Settings);

            //this.Console.WriteLine(Resources.About);

            InitializeDatabase(args);

            _CMDHandler = new CommandHandler();

            _CMDHandler.AddCommand(
                new AboutCommand(),
                new ImportCommand(),
                new FontChangeCommand(this.Settings),

                new XmlExportCommand((IXmlRepository)_AlkonInventory.Parts, "Parts"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.Jobs, "Jobs"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.Receivers, "Receiver"),
                new XmlExportCommand((IXmlRepository)_AlkonInventory.ReceiverEntries, "Entries"));

            var commandLibs = from c in Assembly.GetExecutingAssembly().GetTypes()
                              where c.IsClass && c.Namespace == typeof(CommandUtility).Namespace
                              select c;
            foreach (var commandLib in commandLibs)
            {
                var mCommands = MethodCommandHelper.GetCommandsFromAssembly(commandLib.Assembly, commandLib.Namespace, commandLib.Name);
                _CMDHandler.AddCommand(mCommands);
            }

            CommandUtility.AlkonInventory = _AlkonInventory;
            CommandUtility.CmdHandler = _CMDHandler;
        }

        private void InitializeComponents()
        {
            // Output.
            this._Output = new StackPanel(0, 0, 0, 0);
            this._Output.Height = this.Height - OutputOffset.Y;
            this._Output.Width = this.Width - OutputOffset.X;
            this._Output.BackColor = this._Settings.DefaultColours.Background;
            this.Controls.Add(this._Output);

            // Input.
            this._Input = new TextBox();
            this._Input.Width = this._Input.Width;
            this._Input.Font = this._Settings.DefaultFont;
            this._Input.BackColor = this._Settings.DefaultColours.Foreground;
            this._Input.BorderStyle = BorderStyle.None;
            this._Input.ForeColor = this._Settings.DefaultInputColours.Foreground;
            this.Controls.Add(this._Input);

            // Events.
            this.SizeChanged += Window_SizeChanged;

            // Properties.
            this.BackColor = this._Settings.DefaultColours.Foreground;
            this.Size = new Size(1000, 600);
        }

        private void InitializeDatabase(string[] args)
        {
            bool connectionEstablished = false;
            Dictionary<string, Exception> errorList = new Dictionary<string, Exception>();

            Utility.Write("Initiating Database Connection...", ConsoleFlags.Warning);

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    _AlkonContext = new PackerContext();

                    // Create the database if it does not exist.
                    if (!_AlkonContext.Database.Exists())
                    {
                        Utility.Write("Unable to locate existing database. Attempting database creation...", ConsoleFlags.Warning);
                        bool result = _AlkonContext.Database.CreateIfNotExists();

                        if (result)
                            Utility.Write("Database creation returned with 0 errors.", ConsoleFlags.Success);
                        else
                            Utility.Write("Database creation has failed.", ConsoleFlags.Error);
                    }

                    if (args != null)
                    {
                        if (args.Contains("forceSeed"))
                        {
                            Utility.Write("Forcing Database seed.", ConsoleFlags.Warning);
                            _AlkonContext.Database.Initialize(true);
                        }
                    }

                    _AlkonInventory = new PackerUnitOfWork(_AlkonContext);

                    Utility.Write("Database Initialized Successfully.", ConsoleFlags.Success);
                    connectionEstablished = true;
                    break;
                }
                catch (Exception e)
                {
                    Utility.Write("Database connection failed.", ConsoleFlags.Error);
                    errorList.Add(string.Format("Database connection attempt: {0}", i), e);
                }
            }

            // Did connection fail?
            if (!connectionEstablished)
            {
                Utility.Write("A fatal error occured. Database connection was unsuccessfull. Please see ErrorLog.txt for details.");

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

                Environment.Exit(1);
            }
        }

        private void Window_SizeChanged(object sender, EventArgs e)
        {
            this._Output.Height = this.Height + OutputOffset.Y;
            this._Output.Width = this.Width + OutputOffset.X;

            Point inputPos = new Point(10, _Output.Top + _Output.Height + 20);
            _Input.Location = inputPos;

            _Input.Width = _Output.Width;
        }

        /// <summary>
        /// The default console, uses a <see cref="StackPanel"/> to organize it's children and uses a textbox to handle input.
        /// </summary>
        private class PackerConsole : IConsole
        {
            private const int BufferMin = 100;
            private const int BufferMax = Int32.MaxValue;

            private bool IgnoreInput = false;
            private string LastInput = "";

            private StackPanel Out;
            private TextBox In;
            private Settings Settings;

            /// <summary>
            /// Initializes a new instance of the <see cref="PackerConsole"/> class.
            /// </summary>
            /// <param name="output"></param>
            /// <param name="input"></param>
            /// <param name="settings"></param>
            public PackerConsole(StackPanel output, TextBox input, Settings settings)
            {
                this.Out = output;
                this.In = input;
                this.Settings = settings;
                this.Settings.FontChange += (o,e) =>
                {
                    foreach (Control child in this.Out.Controls)
                        child.Font = this.Settings.DefaultFont;

                    this.Out.Invalidate();
                };

                this.In.KeyDown += In_KeyDown;
            }

            /// <summary>
            /// Gets the size of the buffer.
            /// </summary>
            public int BufferSize { get; private set; }

            /// <summary>
            /// Clear the console.
            /// </summary>
            /// <returns></returns>
            public bool Clear()
            {
                this.Out.Controls.Clear();
                return true;
            }

            /// <summary>
            /// Dispose of the console.
            /// </summary>
            public void Dispose()
            {
                Out.Dispose();
                In.Dispose();
            }

            /// <summary>
            /// Return the next key the user presses in the console.
            /// </summary>
            /// <returns></returns>
            public char ReadKey()
            {
                var result = InitReadOp(0);
                return result[0];
            }

            /// <summary>
            /// Return the next line the user sends by pressing enter.
            /// </summary>
            /// <returns></returns>
            public string ReadLine()
            {
                var result = InitReadOp(1);
                return new string(result);
            }

            /// <summary>
            /// Set the buffer size.
            /// </summary>
            /// <param name="newBufferSize"></param>
            public void SetBuffer(int newBufferSize)
            {
                if (newBufferSize < BufferMin)
                    throw new ArgumentException("Size must be bigger than 100.");
                   
                this.BufferSize = newBufferSize;
            }

            /// <summary>
            /// Write line to console output.
            /// </summary>
            /// <param name="text"></param>
            public void WriteLine(string text)
            {
                this.WriteLine(text, this.Settings.DefaultFont, this.Settings.DefaultInputColours.Foreground);
            }

            /// <summary>
            ///  Write line to console output.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="foreColor"></param>
            public void WriteLine(string text, Color foreColor)
            {
                this.WriteLine(text, this.Settings.DefaultFont, foreColor);
            }

            /// <summary>
            ///  Write line to console output.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="font"></param>
            /// <param name="foreColor"></param>
            public void WriteLine(string text, Font font, Color foreColor)
            {
                ConsoleLine line = new ConsoleLine(text, font, new Colours() { Background = Color.Transparent, Foreground = foreColor });
                this.Out.Controls.Add(line);
            }

            /// <summary>
            ///  Write line to console output.
            /// </summary>
            /// <param name="format"></param>
            /// <param name="args"></param>
            public void WriteLine(string format, object[] args)
            {
                this.WriteLine(string.Format(format, args));
            }

            private char[] InitReadOp(int readType)
            {
                var result = new List<Char>();
                bool finished = false;

                // Ignore further input.
                this.IgnoreInput = true;

                KeyEventHandler keyHandler = new KeyEventHandler((o, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        result.Add(this.LastInput[0]);
                        finished = true;
                    }
                });

                KeyEventHandler lineHandler = new KeyEventHandler((o, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        result.AddRange(this.LastInput.ToCharArray());
                        finished = true;
                    }
                });

                switch (readType)
                {
                    case 0:
                        this.In.KeyDown += keyHandler;
                        break;
                    case 1:
                        this.In.KeyDown += lineHandler;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Use 0 for char reading, or 1 for line reading.");
                }

                while (!finished)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                // Remove events.
                switch (readType)
                {
                    case 0:
                        this.In.KeyDown -= keyHandler;
                        break;
                    case 1:
                        this.In.KeyDown -= lineHandler;
                        break;
                }

                // No longer ignore input.
                this.IgnoreInput = false;

                // Reset input.
                this.In.Text = "";

                return result.ToArray();
            }

            private void In_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string text = In.Text;

                    // Write to console.
                    this.WriteLine(text);

                    // Set last sent line.
                    this.LastInput = this.In.Text;

                    // Reset input.
                    this.In.Text = "";

                    if (!IgnoreInput)
                    {
                        PackerConsoleWin.Instance.RunCommand(text);
                    }

                    // Scroll to element.
                    Out.Invalidate();
                    Out.ScrollControlIntoView(Out.Controls[Out.Controls.Count - 1]);
                }
            }
        }
    }
}
