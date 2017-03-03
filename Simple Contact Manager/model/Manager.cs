using System;
using System.Collections.Generic;
using System.Threading;

namespace Simple_Contact_Manager_model
{
    public class Manager
    {
        private List<Contact> contacts;

        public Manager(List<Contact> contacts)
        {
            this.contacts = contacts;
        }
        
        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact GetContact(int index)
        {
            return contacts[index];
        }

        public bool AddContact(Contact contact)
        {
            foreach (Contact c in contacts)
            {
                if (contact.GetFullName().Equals(c.GetFullName(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to add {0}, the contact {1} already exists.", contact.GetFullName(), contact.GetFullName());
                    Thread.Sleep(2500);
                    Console.ResetColor();
                    Console.Clear();
                    return false; // failure
                }
            }
            contacts.Add(contact);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} has been successfully added to your contacts.", contact.GetFullName());
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
            return true; // success
        }

        public void RemoveContact(int index)
        {
            Contact removedContact = contacts[index];
            contacts.RemoveAt(index);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} has been successfully removed from your contacts.", removedContact.GetFullName());
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }

        public void RemoveAllContacts()
        {
            int numberRemoved = contacts.Count;
            contacts.RemoveRange(0, contacts.Count);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} contact(s) have been removed.", numberRemoved);
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
