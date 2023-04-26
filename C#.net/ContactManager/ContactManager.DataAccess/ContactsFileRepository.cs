using ContactManager.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public class ContactsFileRepository : IContactsRepository
    {
        /// <summary>
        /// Deletes the contact whose Contact ID is specified
        /// </summary>
        /// <param name="id">ContactID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StreamReader sr = new StreamReader("contact.txt");
            try
            {
                List<string> contacts = new List<string>();
                bool flag = false;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    int ID = int.Parse(data[0]);
                    if (ID != id)
                    {
                        contacts.Add(line);
                    }
                    else
                    {
                        flag = true;
                    }
                }
                sr.Close();
                if (!flag)
                {
                    NoSuchContactFoundException exc = new NoSuchContactFoundException("No such customer found!");
                    throw exc;
                }
                StreamWriter sw = new StreamWriter("contact.txt");
                try
                {
                    foreach (string line in contacts)
                    {
                        sw.WriteLine(line);
                    }
                }
                finally
                {
                    sw.Close();
                }
                return flag;
            }
            finally
            {
                sr.Close();
            }
        }

        public bool Edit(int id, Contact contactToEdit)
        {
            StreamReader sr = new StreamReader("contact.txt");
            try
            {
                bool flag = false;
                List<string> contacts = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    int ID = int.Parse(data[0]);
                    if (ID == id)
                    {
                        line = $"{id},{contactToEdit.Name},{contactToEdit.Email},{contactToEdit.Phone},{contactToEdit.Location}";
                        flag = true;
                    }
                    contacts.Add(line);
                }
                sr.Close();
                if (!flag)
                {
                    NoSuchContactFoundException exc = new NoSuchContactFoundException("No such customer found!");
                    throw exc;
                }
                StreamWriter sw = new StreamWriter("contact.txt");
                try
                {
                    foreach (string line in contacts)
                    {
                        sw.WriteLine(line);
                    }
                }
                finally
                {
                    sw.Close();
                }
                return flag;
            }
            finally
            {
                sr.Close();
            }
        }

        public List<Contact> GetAll()
        {
            List<Contact> allContacts = new List<Contact>();
            StreamReader sr = new StreamReader("contact.txt");
            try
            {
                while (!sr.EndOfStream)
                {
                    Contact contact = new Contact();
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    contact.ContactID = int.Parse(data[0]);
                    contact.Name = data[1];
                    contact.Email = data[2];
                    contact.Phone = data[3];
                    contact.Location = data[4];
                    allContacts.Add(contact);
                }
                if(allContacts.Count == 0)
                {
                    NoSuchContactFoundException ex = new NoSuchContactFoundException("No contacts found!");
                    throw ex;
                }
                return allContacts;
            }
            finally
            {
                sr.Close();
            }
        }

        public Contact GetContact(int id)
        {
            StreamReader sr = new StreamReader("contact.txt");
            Contact contact = null;
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    int ID = int.Parse(data[0]);
                    if (ID == id)
                    {
                        contact = new Contact { ContactID = ID, Name = data[1], Email = data[2], Phone = data[3], Location = data[4] };
                    }
                }
                if(contact == null)
                {
                    NoSuchContactFoundException ex = new NoSuchContactFoundException("No such contact found!");
                    throw ex;
                }
                return contact;
            }
            finally
            {
                sr.Close();
            }
        }

        public List<Contact> GetContactsByLocation(string Location)
        {
            StreamReader sr = new StreamReader("contact.txt");
            List<Contact> contacts = new List<Contact>();
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    string loc = data[4];
                    if (loc == Location)
                    {
                        Contact contact = new Contact();
                        contact.ContactID = int.Parse(data[0]);
                        contact.Name = data[1];
                        contact.Email = data[2];
                        contact.Phone = data[3];
                        contact.Location = data[4];
                        contacts.Add(contact);
                    }
                }
                if(contacts.Count == 0)
                {
                    NoSuchContactFoundException ex = new NoSuchContactFoundException("No contacts at this location!");
                    throw ex;
                }
                return contacts;
            }
            finally
            {
                sr.Close();
            }
        }

        public void Save(Contact contactToSave)
        {
            string contact = $"{contactToSave.ContactID},{contactToSave.Name},{contactToSave.Email},{contactToSave.Phone},{contactToSave.Location}";
            StreamWriter sw = new StreamWriter("contact.txt", true);
            try
            {
                sw.WriteLine(contact);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
