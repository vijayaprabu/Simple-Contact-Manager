using System;

namespace Simple_Contact_Manager_model
{
    [Serializable]
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }
           
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public override string ToString()
        {
            return GetFullName() + " " + PhoneNumber + " " + Address;
        }
    }
}
