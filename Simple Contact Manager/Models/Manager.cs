using SimpleContactManager.Util;
using System;
using System.Collections.Generic;

namespace SimpleContactManager.Models
{
    public class Manager
    {
        //TODO move console messages into Tasks.cs with the rest of the application logic 
        private readonly List<Contact> contacts;

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
                if (contact.FullName.Equals(c.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    Utilities.ConsoleShowErrorMsg(string.Format("Failed to add {0}, the contact {1} already exists.", contact.FullName, contact.FullName));
                    return false;
                }
            }
            contacts.Add(contact);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully added to your contacts.", contact.FullName));
            return true;
        }

        public void RemoveContact(int index)
        {
            string removedContact = contacts[index].FullName;
            contacts.RemoveAt(index);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully removed from your contacts.", removedContact));
        }

        public void RemoveAllContacts()
        {
            int numberRemoved = contacts.Count;
            contacts.RemoveRange(0, contacts.Count);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} contact(s) have been removed.", numberRemoved));
        }
    }
}
