using SimpleContactManager.Interactions;
using System;

namespace SimpleContactManager
{
    /// <summary>
    /// Handles the initialization of the program as well as any passed in command line parameters.
    /// </summary>
    public class Program
    {
        private Program() { } // Don't allow initialization of this class from outside as it would serve no purpose.

        public static bool UsePersistance { get; private set; } = true; // Allow serialization of contacts to file?

        /// <summary>
        /// Show basic program info such as the version and who the author is.
        /// </summary>
        private void Initialize()
        {
            Console.Title = "Simple Contact Manager Launcher";
            Console.WriteLine("Hello {0}, and welcome to version 1.4 of a simple contact manager by Jared Lung.", Environment.UserName);
            Console.Write("Press Q to exit and any other key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
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
                if (s.Equals("nosave", StringComparison.OrdinalIgnoreCase)) // If a passed in argument matches nosave (ignore case) then set usePersistance to false
                {
                    UsePersistance = false;
                }
            }
            Program launcher = new Program();
            launcher.Initialize();
        }
    }
}
