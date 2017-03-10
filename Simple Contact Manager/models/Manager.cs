using Simple_Contact_Manager_util;
using System;
using System.Collections.Generic;

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
                    Utilities.ConsoleShowErrorMsg(string.Format("Failed to add {0}, the contact {1} already exists.", contact.GetFullName(), contact.GetFullName()));
                    return false; // failure
                }
            }
            contacts.Add(contact);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully added to your contacts.", contact.GetFullName()));
            return true; // success
        }

        public void RemoveContact(int index)
        {
            Contact removedContact = contacts[index];
            contacts.RemoveAt(index);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully removed from your contacts.", removedContact.GetFullName()));
        }

        public void RemoveAllContacts()
        {
            int numberRemoved = contacts.Count;
            contacts.RemoveRange(0, contacts.Count);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} contact(s) have been removed.", numberRemoved));
        }
    }
}
