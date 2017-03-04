using Simple_Contact_Manager;
using Simple_Contact_Manager_model;
using Simple_Contact_Manager_util;
using System;
using System.Linq;
using System.Threading;

namespace Simple_Contact_Manager_view
{
    public class Tasks
    {
        private Manager manager;
        private Persist persist;

        public Tasks(Manager manager, Persist persist)
        {
            this.manager = manager;
            this.persist = persist;
        }

        // Walk the user through the process of creating a new contact.
        public void AddContactProcess()
        {
            string firstName, lastName;
            string phoneNumber;
            string address;

            Console.Clear();
            Console.Write("Enter the contact's first name: ");
            firstName = Console.ReadLine();
            Console.Write("\nEnter the contact's last name: ");
            lastName = Console.ReadLine();
            Console.Write("\nEnter the contact's phone number: ");
            phoneNumber = Console.ReadLine();
            Console.Write("\nEnter the contact's address: ");
            address = Console.ReadLine();
            if (manager.AddContact(new Contact(firstName, lastName, phoneNumber, address)))
            {
                if (Launcher.GetUsePersistance())
                {
                    persist.WriteContacts(manager.GetContacts());
                }
            }
        }
        // List all of the user's current contacts to the console.
        public void ListAllContacts()
        {
            if (manager.GetContacts().Count() != 0)
            {
                Console.Clear();
                int tempNum;
                for (int i = 0; i < manager.GetContacts().Count(); i++)
                {
                    tempNum = i + 1;
                    Console.WriteLine("{0}) {1}", tempNum, manager.GetContacts()[i].GetFullName());
                }
                Console.Write("\nPress any key to continue: ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no contacts.");
                Thread.Sleep(2500);
                Console.ResetColor();
                Console.Clear();
            }
        }
        // Walk the user through the process of removing a contact.
        public void RemoveContactProcess()
        {
            string input;
            int selection;

            if (manager.GetContacts().Count != 0)
            {
                Console.Clear();
                int tempNum;
                for (int i = 0; i < manager.GetContacts().Count; i++)
                {
                    tempNum = i + 1;
                    Console.WriteLine("{0}) {1}", tempNum, manager.GetContacts()[i].GetFullName());
                }

                while (true)
                {
                    tempNum = 1;
                    tempNum = tempNum + manager.GetContacts().Count;
                    Console.Write("\nEnter the number of the contact you wish to remove: ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out selection))
                    {
                        if (selection < 1 || selection >= tempNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThe selection {0} is out of range, please try again.\n", selection);
                            Console.ResetColor();
                            continue;
                        }
                        else
                        {
                            manager.RemoveContact(selection = selection - 1);
                            if (Launcher.GetUsePersistance())
                            {
                                persist.WriteContacts(manager.GetContacts());
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n{0} is not a valid whole number, please use numbers only.\n", input);
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no contacts that you can remove.");
                Thread.Sleep(2500);
                Console.ResetColor();
                Console.Clear();
            }
        }

        public void RemoveAllContactsProcess()
        {
            if (manager.GetContacts().Count != 0)
            {
                manager.RemoveAllContacts();
                persist.DeleteSaveFile();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no contacts that you can remove.");
                Thread.Sleep(2500);
                Console.ResetColor();
                Console.Clear();
            }
        }

        // Walk the user through the process of selecting a contact to have there info shown.
        public void ShowContactDetails()
        {
            string input;
            int selection;

            if (manager.GetContacts().Count != 0)
            {
                Console.Clear();
                int tempNum;
                for (int i = 0; i < manager.GetContacts().Count; i++)
                {
                    tempNum = i + 1;
                    Console.WriteLine("{0}) {1}", tempNum, manager.GetContacts()[i].GetFullName());
                }

                while (true)
                {
                    tempNum = 1;
                    tempNum = tempNum + manager.GetContacts().Count;
                    Console.Write("\nEnter the number of the contact you wish to see the details of: ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out selection))
                    {
                        if (selection < 1 || selection >= tempNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThe selection {0} is out of range, please try again.\n", selection);
                            Console.ResetColor();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\n{0}", manager.GetContact(selection = selection - 1).ToString());
                            Console.Write("\nPress any key to continue: ");
                            Console.ReadKey();
                            Console.Clear();
                            break;       
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n{0} is not a valid whole number, please use numbers only.\n", input);
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no contacts that you can view the details of.");
                Thread.Sleep(2500);
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
