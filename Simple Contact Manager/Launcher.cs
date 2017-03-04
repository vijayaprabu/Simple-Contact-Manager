using Simple_Contact_Manager_view;
using System;

namespace Simple_Contact_Manager
{
    public class Launcher
    {

        private Launcher() { } // Don't allow initialization of this class as it would serve no purpose.

        public static readonly string VERSION = "1.2";
        public static readonly string AUTHOR = "Jared Lung";
        private static bool usePersistance = true;

        public static bool GetUsePersistance ()
        {
            return usePersistance;
        }

        public static void Main(string[] args)
        {
            // Cycle through the passed in command line arguments.
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("nosave", StringComparison.OrdinalIgnoreCase))
                {
                    usePersistance = false;
                }
            }
            Initialize();
        }

        // Show basic info such as author and program version.
        private static void Initialize()
        {
            Console.Title = "Simple Contact Manager Launcher";
            Console.WriteLine("Hello {0}, and welcome to version {1:f1} of a simple contact manager by {2}.", Environment.UserName, VERSION, AUTHOR);
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
                menu.runMenu();
            }
        }
    }
}
