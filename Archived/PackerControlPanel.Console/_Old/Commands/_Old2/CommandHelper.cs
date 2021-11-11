using CommandHandlerLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Helper;
    using PackerControlPanel.PanelConsole;
    using PackerControlPanel.Persistence;

    internal class CommandHelper
    {
        /* General Error string */
        internal const string ERROR_COMMAND_CANCELLED = "[ERROR] Command cancelled. no changes have been made.";
        internal const string ERROR_INDEX_OUT_OF_RANGE = "[ERROR]Index cannot be smaller or larger than the collection.";

        /* Part error strings */
        internal const string ERROR_PART_NOT_FOUND = "[ERROR]Unable to find a part with the name '{0}' within the collection.";
        internal const string ERROR_PART_ID_NOT_FOUND = "[ERROR]Unable to locate a part with the ID of '{0}' within the collection.";
        internal const string ERROR_DUPLICATE_ENTRY = "[ERROR]The part '{0}' already exists within the collection.";

        /* Receiver error strings */
        internal const string ERROR_RECEIVER_NOT_FOUND = "[ERROR] Unable to find a receiver by the name '{0}'.";
        internal const string ERROR_RECEIVER_ID_NOT_FOUND = "[ERROR] Unable to find a receiver with the ID of '{0}' within the collection.";
        internal const string ERROR_DOCUMENT_ALREADY_EXISTS = "[ERROR] There is already a document by the name '{0}'.";
        internal const string ERROR_RECEIVER_NOT_LOADED = "[ERROR] There is no active document, unable to execute command.";
        internal const string ERROR_RECEIVER__ORDER_NOT_FOUND = "[ERROR]Unable to find the order #'{0}' within the receiver.";

        /* Job error strings */
        internal const string ERROR_ORDER_NOT_FOUND = "[ERROR]The job {0} is unable to be located.";
        internal const string ERROR_ORDER_ID_NOT_FOUND = "[ERROR]Unable to locate a job with the ID of '{0}' within the collection..";

        /// <summary>
        /// Gets or sets the alkon inventory source.
        /// </summary>
        internal static UnitOfWork AlkonInventory
        {
            get; set;
        }

        /// <summary>
        /// Asks a yes or no question to the user.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        internal static bool AskQuestion(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                throw new ArgumentNullException("No question provided.");

            if (!question.EndsWith("(Y/N)"))
                question = question + " (Y/N)";

            Program.WriteToConsole(question);

            int attempts = 0;
            while (true)
            {
                if (attempts > 0)
                    Program.WriteToConsole("Invalid responce, please use 'Y' for yes, 'N' for no.", ConsoleColor.Red);
                attempts += 1;

                string responce = Console.ReadLine().ToLower();

                switch (responce)
                {
                    case "y":
                    // Break through
                    case "yes":
                        return true;
                    case "n":
                    // Break through
                    case "no":
                        return false;
                    default:
                        continue;
                }
            }
        }
    }
}
