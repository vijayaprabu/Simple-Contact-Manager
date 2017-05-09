﻿using SimpleContactManager.Models;
using SimpleContactManager.Services;
using System;
using System.Linq;

namespace SimpleContactManager.Interactions
{
    /*
     * Contains a series of actions that occur based off what the user choose to do in the menu.
     */
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
            while (true)
            {
                firstName = Utilities.GetAndValidateName("\nEnter the contact's first name: ");
                lastName = Utilities.GetAndValidateName("\nEnter the contact's last name: ");

                if (firstName.Equals(lastName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe first and last name cannot be identical.");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            phoneNumber = Utilities.GetAndValidatePhoneNumber("\nEnter the contact's phone number: ");
            Console.Write("\nEnter the contact's address: ");
            address = Console.ReadLine();

            if (manager.AddContact(new Contact(firstName, lastName, phoneNumber, address)))
            {
                if (Program.GetUsePersistance())
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
            else // If the user has no contacts display a message stating such.
            {
                Utilities.ConsoleShowErrorMsg("You have no contacts.");
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
                            if (Program.GetUsePersistance()) // If persistence is enabled save the user's current contacts to file.
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
            else // If the user has no contacts display a message stating such.
            {
                Utilities.ConsoleShowErrorMsg("You have no contacts that you can remove.");
            }
        }

        // Remove all the user's contacts
        public void RemoveAllContactsProcess()
        {
            if (manager.GetContacts().Count != 0) // If the user has a contact or contacts
            {
                manager.RemoveAllContacts();
                persist.DeleteSaveFile();
            }
            else // If the user has not contacts display a message stating such.
            {
                Utilities.ConsoleShowErrorMsg("You have no contacts that you can remove.");
            }
        }

        // Walk the user through the process of selecting a contact to have there info shown.
        public void ShowContactDetails()
        {
            string input;

            if (manager.GetContacts().Count != 0) // If the user has a contact or contacts
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

                    if (int.TryParse(input, out int selection))
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
                Utilities.ConsoleShowErrorMsg("You have no contacts that you can view the details of.");
            }
        }
    }
}