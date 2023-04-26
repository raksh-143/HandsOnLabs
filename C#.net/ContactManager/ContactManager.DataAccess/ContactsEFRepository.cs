using ContactManager.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.DataAccess;
using System.Data.Entity;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ContactManager.DataAccess
{
    public class ContactsEFRepository : IContactsRepository
    {
        //Do not let user create an object of this
        private ContactsDbContext db = new ContactsDbContext();
        public bool Delete(int id)
        {
            db.Contacts.Remove(db.Contacts.Find(id));
            db.SaveChanges();
            return true;
        }

        public bool Edit(int id, Contact contactToEdit)
        {
            //var c = db.Contacts.Find(id);
            //c.Name = contactToEdit.Name;
            //c.Email = contactToEdit.Email;
            //c.Location= contactToEdit.Location;
            //c.Phone= contactToEdit.Phone;
            var c = new EFDataAccess.Contact
            {
                ContactID = contactToEdit.ContactID,
                Name = contactToEdit.Name,
                Location = contactToEdit.Location,
                Phone = contactToEdit.Phone
            };
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public List<Contact> GetAll()
        {
            var contacts = from c in db.Contacts
                           select new Contact
                           {
                               ContactID = c.ContactID,
                               Name = c.Name.Trim(),
                               Location = c.Location.Trim(),
                               Phone = c.Phone.Trim(),
                           };
            //automapper framework can be used
            //Has methods called convert to and convert from
            return contacts.ToList();
        }

        public Contact GetContact(int id)
        {
            var c = db.Contacts.Find(id);
            return new Contact 
            { 
                ContactID=id,
                Name = c.Name.Trim(),
                Location = c.Location.Trim(),
                Phone = c.Phone.Trim()
            };
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            var contacts = from c in db.Contacts
                           where c.Location == location
                           select new Contact
                           {
                               ContactID = c.ContactID,
                               Name = c.Name.Trim(),
                               Location = c.Location.Trim(),
                               Phone = c.Phone.Trim(),
                           };
            return contacts.ToList();
        }

        public void Save(Contact contactToSave)
        {
            db.Contacts.Add( new EFDataAccess.Contact
            {
                ContactID=contactToSave.ContactID,
                Name = contactToSave.Name,
                Location = contactToSave.Location,
                Phone = contactToSave.Phone
            });
            db.SaveChanges();
        }
    }
}
