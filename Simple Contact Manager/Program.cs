using SimpleContactManager.Interactions;
using System;

namespace SimpleContactManager
{
    /// <summary>
    /// Handles the initialization of the program as well as any passed in command line parameters.
    /// </summary>
    public class Program
    {
        // Don't allow initialization of this class from the outside as it would serve no purpose.
        private Program() { }

        // Allow serialization of contacts to disk?
        public static bool UsePersistance { get; private set; } = true;

        /// <summary>
        /// Show a greeting, who the author is and set the console window title to the current logged in user in windows.
        /// </summary>
        private static void Initialize()
        {
            Console.Title = "Simple Contact Manager Launcher";
            Console.WriteLine("Hello {0}, and welcome to a simple contact manager by Jared Lung.", Environment.UserName);
            Console.Write("Press Q to exit and any other key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Q) { Environment.Exit(0); }
            else
            {
                Console.Title = string.Format("{0}'s Contacts", Environment.UserName);
                Console.Clear();
                Menu menu = new Menu();
                menu.RunMenu();
            }
        }

        /// <summary>
        /// The main entry point of the program that also gets the passed in command line arguments.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Cycle through the passed in command line arguments.
            foreach (string s in args)
            {
                // If a passed in argument matches nosave (ignore case) then set UsePersistance to false.
                if (s.Equals("nosave", StringComparison.OrdinalIgnoreCase)) { UsePersistance = false; }
            }
            Initialize();
        }
    }
}
