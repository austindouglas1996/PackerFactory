using PackerControlPanel.Win32Console.Win.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Win32Console
{
    /// <summary>
    /// The default console, uses a <see cref="StackPanel"/> to organize it's children and uses a textbox to handle input.
    /// </summary>
    internal class PackerConsole : IConsole
    {
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
            this.Settings.FontChange += (o, e) =>
            {
                foreach (Control child in this.Out.Controls)
                    child.Font = this.Settings.DefaultFont;

                this.Out.Invalidate();
            };

            this.In.KeyDown += In_KeyDown;
        }

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
