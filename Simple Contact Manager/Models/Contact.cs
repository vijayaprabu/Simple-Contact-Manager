using System;

namespace SimpleContactManager.Models
{
    [Serializable]
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;

        public Contact(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString()
        {
            return "Fullname: " + FullName + "\nPhone number: " + PhoneNumber + "\nAddress: " + Address;
        }
    }
}
