using CommandHandlerLib;
using CommandHandlerLib.Commands;
using PackerControlPanel.InventoryConsole.Extensions;
using PackerControlPanel.InventoryConsole.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryConsole.Console
{
    public class PackerConsole : IConsole
    {
        /// <summary>
        /// Ignore user input and any input should not be handled as a command.
        /// </summary>
        private bool IgnoreInput = false;

        /// <summary>
        /// Last input collected from <see cref="Input"/>.
        /// </summary>
        private string LastInput = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="PackerConsole"/> class.
        /// </summary>
        /// <param name="handler"></param>
        public PackerConsole(CommandHandler handler, ConsoleStyle style)
        {
            this.CMDHandler = handler;
            this.StyleOptions = style;

            this.Output = new ConsolePanel(1,1,0,0);
            this.Input = new TextBox();
        }

        /// <summary>
        /// Gets or sets the default style options.
        /// </summary>
        public ConsoleStyle StyleOptions
        {
            get { return this._StyleOptions; }
            set { this._StyleOptions = value; }
        }
        private ConsoleStyle _StyleOptions;

        /// <summary>
        /// Gets or sets a value indicating whether to accept input from the user.
        /// </summary>
        public bool Enabled
        {
            get { return this._Enabled; }
            set
            {
                this._Enabled = value;
                this._Input.Enabled = value;
            }
        }
        private bool _Enabled = true;

        /// <summary>
        /// Gets the command handler.
        /// </summary>
        public CommandHandler CMDHandler
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the output panel.
        /// </summary>
        public ConsolePanel Output
        {
            get { return this._Output; }
            set { this._Output = value; }
        }
        private ConsolePanel _Output;

        /// <summary>
        /// Gets or sets the input textbox.
        /// </summary>
        public TextBox Input
        {
            get { return this._Input; }
            set
            {
                if (this._Input != null)
                {
                    // Remove the event.
                    this._Input.KeyDown -= In_KeyDown;
                }

                this._Input = value;

                // Set the event.
                value.KeyDown += In_KeyDown;
            }
        }
        private TextBox _Input;

        public bool Clear()
        {
            this.Output.Controls.Clear();
            return true;
        }

        public char ReadKey()
        {
            var result = InitReadOp(0);
            return result[0];
        }

        public string ReadLine()
        {
            var result = InitReadOp(1);
            return new string(result);
        }

        public void Write(string text)
        {
            Write(text, StyleOptions.OutputFont, StyleOptions.FontForeColor);
        }

        public void Write(string text, Color foreColor)
        {
            Write(text, StyleOptions.OutputFont, foreColor);
        }

        public void Write(string text, Font font, Color foreColor)
        {
            ConsoleLabel lastChild = GetLastChild();

            if (lastChild == null)
            {
                ConsoleLabel line = new ConsoleLabel(text, font, new Colours() { Background = Color.Transparent, Foreground = foreColor });
                this.Output.Controls.Add(line);
            }
            else
            {
                lastChild.Controls.Add(new ConsoleLabel(text, font, new Colours() { Background = Color.Transparent, Foreground = foreColor }));
            }
        }

        public void Write(string format, object[] args)
        {
            Write(string.Format(format, args), StyleOptions.OutputFont, StyleOptions.FontForeColor);
        }

        public void WriteLine(string text)
        {
            Color color = GetConsoleColor(ref text);
            if (color == Color.White)
                color = StyleOptions.FontForeColor;

            this.WriteLine(text, StyleOptions.OutputFont, color);
        }

        public void WriteLine(string text, Color foreColor)
        {
            this.WriteLine(text, StyleOptions.OutputFont, foreColor);
        }

        public void WriteLine(string text, Font font, Color foreColor)
        {
            ConsoleLabel line = new ConsoleLabel(text, font, new Colours() { Background = Color.Transparent, Foreground = foreColor });
            this.Output.Controls.Add(line);
        }

        public void WriteLine(string format, object[] args)
        {
            string result = string.Format(format, args);

            Color color = GetConsoleColor(ref result);
            this.WriteLine(result);
        }

        public void Dispose()
        {
            Output.Dispose();
            Input.Dispose();
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
                    this.Input.KeyDown += keyHandler;
                    break;
                case 1:
                    this.Input.KeyDown += lineHandler;
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
                    this.Input.KeyDown -= keyHandler;
                    break;
                case 1:
                    this.Input.KeyDown -= lineHandler;
                    break;
            }

            // No longer ignore input.
            this.IgnoreInput = false;

            // Reset input.
            this.Input.Text = "";

            return result.ToArray();
        }

        private void In_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = Input.Text;

                // Write to console.
                this.WriteLine(text);

                // Set last sent line.
                this.LastInput = this.Input.Text;

                // Reset input.
                this.Input.Text = "";

                if (!IgnoreInput)
                {
                    CommandResult result = this.CMDHandler.ProcessInput(text);
                    ConsoleFlags flag = ConsoleFlags.None;

                    switch (result.ResultType)
                    {
                        case CommandResultType.Error:
                        case CommandResultType.ErrorByException:
                            flag = ConsoleFlags.Error;
                            break;

                        case CommandResultType.Success:
                            flag = ConsoleFlags.Success;
                            break;

                        case CommandResultType.Warning:
                            flag = ConsoleFlags.Warning;
                            break;

                        default:
                            flag = ConsoleFlags.None;
                            break;
                    }

                    string errorFormat = "[{0}] {1}";

                    if (result.ExceptionThrown != null)
                        this.WriteLine(string.Format(errorFormat, result.ExceptionThrown.GetType().Name, result.ExceptionThrown.Message), flag);
                    else
                        this.WriteLine(result.Message);
                }

                // Scroll to element.
                Output.Invalidate();
                Output.ScrollControlIntoView(Output.Controls[Output.Controls.Count - 1]);
            }
        }

        /// <summary>
        /// Extract the color code from a string if there is one and then return the desired color.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>OLD TYPE</remarks>
        private static Color GetConsoleColor(ref string input)
        {
            // Make sure the result should not have a special color.
            Color color = Color.White;

            if (input.StartsWith("<"))
            {
                // Color coded string start with <{COLOR}>
                int colorCodeEndPos = input.IndexOf('>', 1, input.Length - 1);

                // Retrieve the value.
                string colorCode = input.Substring(1, colorCodeEndPos - 1);

                // Remove colorCode from string.
                input = input.Remove(0, colorCodeEndPos + 1);

                if (colorCode == "g")
                    color = Color.Green;
                else if (colorCode == "y")
                    color = Color.Yellow;
                else if (colorCode == "r")
                    color = Color.Red;
                else if (colorCode == "b")
                    color = Color.Blue;
                // Make sure the color exists.
                else if (Enum.TryParse<Color>(colorCode, true, out color))
                {
                    // Use the selected color.
                    return color = (Color)Enum.Parse(typeof(Color), colorCode, true);
                }
            }

            return color;
        }

        private ConsoleLabel GetLastChild()
        {
            if (this.Output.Controls.Count == 0)
                return null;

            ConsoleLabel lastLine = (ConsoleLabel)this.Output.Controls[this.Output.Controls.Count - 1];

            return lastLine;
        }
    }
}
