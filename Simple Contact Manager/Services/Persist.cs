using SimpleContactManager.Models;
using SimpleContactManager.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleContactManager.Services
{
    public static class Persist
    {
        private static readonly string AppSaveFile = "Contacts.dat";
        private static readonly string AppSaveFolder = Path.Combine(Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData), @"Simple Contact Manager\Saved Contacts");

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

        public static void DeleteSaveData()
        {
            if (Directory.Exists(AppSaveFolder)) { Directory.Delete(AppSaveFolder, true); }
        }

        private static void ValidatePath()
        {
            if (!Directory.Exists(AppSaveFolder))
            {
                Directory.CreateDirectory(AppSaveFolder);
                using (FileStream fileWriter = File.Create(Path.Combine(AppSaveFolder, AppSaveFile))) { }
            }
        }
    }
}
