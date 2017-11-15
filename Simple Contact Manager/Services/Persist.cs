using SimpleContactManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleContactManager.Services
{
    /// <summary>
    /// Represents a collection of static methods responsible for the serialization of the user's contacts.
    /// </summary>
    public static class Persist
    {
        // The paths on disk the application uses to save the user's contacts to.
        private static readonly string AppSaveFile = "Contacts.dat";
        private static readonly string AppSaveFolder = Path.Combine(Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData), @"Simple Contact Manager\Saved Contacts");

        /// <summary>
        /// Serializes a list of contacts to disk.
        /// </summary>
        /// <param name="contacts"></param>
        public static void WriteContacts(List<Contact> contacts)
        {
            ValidatePath();
            using (FileStream fileWriter = new FileStream(Path.Combine(AppSaveFolder, AppSaveFile), FileMode.Create, FileAccess.Write))
            {
                try
                {
                    BinaryFormatter writer = new BinaryFormatter();
                    writer.Serialize(fileWriter, contacts);
                }
                catch (Exception ex)
                {
                    // TODO: Catch specific exceptions
                    Console.Write("{0} \nPress any key to continue: ", ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Deserializes a list of contacts from a file.
        /// </summary>
        /// <returns></returns>
        public static List<Contact> ReadContacts()
        {
            ValidatePath();
            if (Utilities.IsFileEmpty(Path.Combine(AppSaveFolder, AppSaveFile)))
            {
                using (FileStream fileReader = new FileStream(Path.Combine(AppSaveFolder, AppSaveFile), FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        BinaryFormatter reader = new BinaryFormatter();
                        List<Contact> contacts = (List<Contact>)reader.Deserialize(fileReader);
                        return contacts;
                    }
                    catch (Exception ex)
                    {
                        // TODO: Catch specific exceptions
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

        /// <summary>
        /// Deletes the file that stores the user's saved contacts from the disk.
        /// </summary>
        public static void DeleteSaveData()
        {
            if (Directory.Exists(AppSaveFolder)) { Directory.Delete(AppSaveFolder, true); }
        }

        /// <summary>
        /// Validates whether or not the directories and the file the application uses for serialization purposes exist.
        /// </summary>
        private static void ValidatePath()
        {
            // Creates an empty file and directory for serialization if one is not found upon program launch. (assuming persistence is enabled)
            if (!Directory.Exists(AppSaveFolder))
            {
                Directory.CreateDirectory(AppSaveFolder);
                using (FileStream fileWriter = File.Create(Path.Combine(AppSaveFolder, AppSaveFile))) { }
            }
        }
    }
}
