using System;
using System.Collections.Generic;
using System.IO;
using ContactManager.DataAccess;
using ContactManager.DataAccess.Exceptions;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Welcome to your contact manager!");
                Console.WriteLine("Select one of the following operations to perform: ");
                Console.WriteLine("1. Add a new contact");
                Console.WriteLine("2. Edit contact");
                Console.WriteLine("3. Get contact");
                Console.WriteLine("4. Get all contacts");
                Console.WriteLine("5. Get contacts by location");
                Console.WriteLine("6. Delete a contact");
                Console.WriteLine("7. Exit");
                int choice = 7;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter only numbers ranging from 1 to 7");
                }
                Console.WriteLine();
                switch (choice)
                {
                    case 1: Save();
                        break;
                    case 2: Edit();
                        break;
                    case 3: GetContact();
                        break;
                    case 4: GetAll();
                        break;
                    case 5: GetContactsByLocation();
                        break;
                    case 6: Delete();
                        break;
                    case 7: Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Invalid Choice!"); ;
                        break;
                }
            }
        }
        public static void Save()
        {
            try
            {
                Console.WriteLine("Enter Contact details: ");
                //Console.Write("Enter Contact ID: ");
                //int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Contact Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Contact Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Contact Phone: ");
                string phone = Console.ReadLine();
                Console.Write("Enter Contact Location: ");
                string location = Console.ReadLine();
                Contact contact = new Contact { Name = name, Email = email, Phone = phone, Location = location };
                ContactsEFRepository cfr = new ContactsEFRepository();
                cfr.Save(contact);
                Console.WriteLine("Contact Saved Successfully!");
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while writing into contacts");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void Edit()
        {
            try
            {
                Console.WriteLine("Enter Contact details: ");
                Console.Write("Enter Contact ID to be edited: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter new Contact Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new Contact Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter new Contact Phone: ");
                string phone = Console.ReadLine();
                Console.Write("Enter new Contact Location: ");
                string location = Console.ReadLine();
                Contact contact = new Contact {  ContactID = id,Name = name, Email = email, Phone = phone, Location = location };
                ContactsEFRepository cfr = new ContactsEFRepository();
                bool res = cfr.Edit(id, contact);
                if (res)
                {
                    Console.WriteLine("Contact Edited successfully!");
                }
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while reading/writing contacts");
            }
            catch (NoSuchContactFoundException)
            {
                Console.WriteLine("There is no contact with this contact ID");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetContact()
        {
            try
            {
                Console.Write("Enter Contact ID to be found: ");
                int id = int.Parse(Console.ReadLine());
                ContactsEFRepository cfr = new ContactsEFRepository();
                Contact contact = cfr.GetContact(id);
                if (contact != null)
                {
                    Console.WriteLine("Contact ID\tName\tEmail\tPhone\tLocation");
                    Console.WriteLine($"{contact.ContactID}\t{contact.Name}\t{contact.Email}\t{contact.Phone}\t{contact.Location}");
                }
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while reading contacts");
            }
            catch (NoSuchContactFoundException)
            {
                Console.WriteLine("There is no contact with this contact ID");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetAll()
        {
            try
            {
                ContactsEFRepository cfr = new ContactsEFRepository();
                List<Contact> contacts = cfr.GetAll();
                if(contacts.Count != 0)
                {
                    Console.WriteLine("Contact ID\tName\tEmail\tPhone\tLocation");
                    foreach (Contact contact in contacts)
                    {
                        Console.WriteLine($"{contact.ContactID}\t{contact.Name}\t{contact.Email}\t{contact.Phone}\t{contact.Location}");
                    }
                }
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while reading contacts");
            }
            catch (NoSuchContactFoundException)
            {
                Console.WriteLine("No contacts found");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetContactsByLocation()
        {
            try
            {
                Console.Write("Enter Contact's Location: ");
                string location = Console.ReadLine();
                ContactsEFRepository cfr = new ContactsEFRepository();
                List<Contact> contacts = cfr.GetContactsByLocation(location);
                if (contacts.Count != 0)
                {
                    Console.WriteLine("Contact ID\tName\tEmail\tPhone\tLocation");
                    foreach (Contact contact in contacts)
                    {
                        Console.WriteLine($"{contact.ContactID}\t{contact.Name}\t{contact.Email}\t{contact.Phone}\t{contact.Location}");
                    }
                }
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while reading contacts");
            }
            catch (NoSuchContactFoundException)
            {
                Console.WriteLine("No contacts in this location");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Delete()
        {
            try
            {
                Console.Write("Enter Contact ID to be deleted: ");
                int id = int.Parse(Console.ReadLine());
                ContactsEFRepository cfr = new ContactsEFRepository();
                bool res = cfr.Delete(id);
                if (res)
                {
                    Console.WriteLine("Contact Deleted successfully!");
                }
                Console.WriteLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error occured while reading/writing contacts");
            }
            catch (NoSuchContactFoundException)
            {
                Console.WriteLine("There is no contact with this contact ID");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number for contact ID and valid values for the other required details!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Memory full!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
