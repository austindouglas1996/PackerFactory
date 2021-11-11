using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Screens
{
    /// <summary>
    /// Manages a collection of <see cref="IScreen"/> to update and draw contents to the console.
    /// </summary>
    public class ScreenManager
    {
        private Stack<Screen> _screens;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenManager"/> class.
        /// </summary>
        /// <param name="screens"></param>
        public ScreenManager(params Screen[] screens)
        {
            this._screens = new Stack<Screen>();
            foreach (var screen in screens)
                this.Push(screen);
        }

        /// <summary>
        /// Gets the collection of screens.
        /// </summary>
        public Stack<Screen> Screens
        {
            get { return this._screens; }
        }

        /// <summary>
        /// Gets the current screen at the top of the stack currently on screen.
        /// </summary>
        public Screen ActiveScreen
        {
            get { return this.Screens.Peek(); }
        }

        /// <summary>
        /// Push a new screen to the top of the stack.
        /// </summary>
        /// <param name="screen"></param>
        public void Push(Screen screen)
        {
            screen.Initialize();

            // Push the new screen to the top.
            this.Screens.Push(screen);

            this.UpdateScreen();
        }

        /// <summary>
        /// Remove the screen at the top of the stack.
        /// </summary>
        /// <returns></returns>
        public Screen Pop()
        {
            Screen oldScreen = this.Screens.Pop();
            //oldScreen.Exit();

            this.UpdateScreen();

            return oldScreen;
        }

        /// <summary>
        /// Update the screen by clearing the text and redrawing the active screen.
        /// </summary>
        private void UpdateScreen()
        {
            // Get the active screen.
            Screen screen = this.ActiveScreen;

            // Clear the console.
            Console.Clear();

            // Initialize.
            screen.Initialize();

            // Execute the screen logic.
            screen.Run();
        }
    }
}
