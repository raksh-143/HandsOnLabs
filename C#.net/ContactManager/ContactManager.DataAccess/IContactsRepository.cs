using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public interface IContactsRepository
    {
        void Save(Contact contactToSave);
        bool Delete(int id);
        bool Edit(int id, Contact contactToEdit);
        Contact GetContact(int id);
        List<Contact> GetAll();
        List<Contact> GetContactsByLocation(string location);
    }
}
