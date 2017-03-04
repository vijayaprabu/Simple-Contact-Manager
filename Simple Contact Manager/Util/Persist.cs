using Simple_Contact_Manager_model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simple_Contact_Manager_util
{
    public class Persist
    {

        private readonly string filePath = Environment.CurrentDirectory + "\\Saved Contacts.dat"; // The file path for the file to be read and created at for serilization.

        public void WriteContacts(List<Contact> contacts)
        {
            using (FileStream fileWriter = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // Overwrite the current serilization file with a new updated file.
            {
                try
                {
                    BinaryFormatter writer = new BinaryFormatter();
                    writer.Serialize(fileWriter, contacts);
                }

                catch (Exception ex)
                {
                    Console.Write("{0} \nPress any key to continue: ", ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public List<Contact> ReadContacts()
        {
            if (!File.Exists(filePath)) // Create an empty file for serilization if one is not found upon program launch. (assuming persistance is enabled)
            {
                using (FileStream fileWriter = File.Create(filePath)) { }
            }

            if (Utilities.IsFileEmpty(filePath)) // Only try to read the file if it's not empty.
            {
                using (FileStream fileReader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        BinaryFormatter reader = new BinaryFormatter();
                        List<Contact> contacts = (List<Contact>)reader.Deserialize(fileReader);
                        return contacts;
                    }

                    catch (Exception ex)
                    {
                        Console.Write("{0} \nPress any key to continue: ", ex.Message);
                        Console.ReadKey();
                        Console.Clear();
                        return null;
                    }
                }
            }

            else
            {
                List<Contact> contacts = new List<Contact>();
                return contacts;
            }
        }

        public void DeleteSaveFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
