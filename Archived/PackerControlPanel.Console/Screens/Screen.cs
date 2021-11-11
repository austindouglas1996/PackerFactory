using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    public abstract class Screen
    {
        /// <summary>
        /// Gets a value indicating whether <see cref="Initialize"/> has been called.
        /// </summary>
        private bool initializeCalled = false;

        /// <summary>
        /// An array of options to be displayed on screen for the user.
        /// </summary>
        private List<ScreenItem> options = new List<ScreenItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Screen"/> class.
        /// </summary>
        public Screen(ScreenManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// Gets the name of the screen.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Gets or sets the options to display on screen on <see cref="Run"/>
        /// </summary>
        public List<ScreenItem> Options
        {
            get { return this.options; }
            protected set { this.options = value; }
        }

        /// <summary>
        /// Gets or sets the manager
        /// </summary>
        public ScreenManager Manager
        {
            get;
        }

        /// <summary>
        /// Initialize screen elements.
        /// </summary>
        public void Initialize()
        {
            if (!this.initializeCalled)
                this.OnInitialize();

            this.initializeCalled = true;
        }

        /// <summary>
        /// Dispose of elements.
        /// </summary>
        public virtual void Exit()
        {
            Manager.Pop();
        }

        /// <summary>
        /// Start screen logic.
        /// </summary>
        public virtual void Run()
        {
            var items = this.options.ToList();

            ScreenItem exit = new ScreenItem();
            exit.Text = "Exit";
            exit.Execute += (o, e) => { this.Exit(); };
            items.Add(exit);

            Console.WriteLine("\n");
            Utility.Write(this.Title, ConsoleColor.Yellow, 5);

            for (int i = 0; i < items.Count(); i++)
            {
                Utility.Write(string.Format("{0}. {1}", i, items[i].Text), ConsoleColor.White, 5);
            }


            while (true)
            {
                string input = Console.ReadLine();

                string[] arguments = new string[0];
                if (input.Contains(' '))
                {
                    arguments = new string[] { input.Remove(0, input.IndexOf(' ') + 1) };
                    input = input.Substring(0, input.IndexOf(' '));
                }

                Int32 choice;
                bool isNum = int.TryParse(input, out choice);

                if (!isNum || choice > items.Count() - 1 || choice < 0)
                {
                    Utility.Write("Invalid Value. Please select a different choice.", ConsoleColor.Red, 5);
                    continue;
                }

                ScreenItem selectedItem = items[choice];
                selectedItem.OnExecute(this, arguments);

                Utility.Write("You chose " + selectedItem.Text);
            }
        }

        /// <summary>
        /// Add a new option to the menu.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="onExecute"></param>
        protected void AddOption(string text, ScreenItemEventHandler onExecute)
        {
            ScreenItem item = new ScreenItem();
            item.Text = text;
            item.Execute += onExecute;

            this.options.Add(item);
        }

        /// <summary>
        /// Initialize screen contents, only called once per screen instance.
        /// </summary>
        protected abstract void OnInitialize();
    }
}
