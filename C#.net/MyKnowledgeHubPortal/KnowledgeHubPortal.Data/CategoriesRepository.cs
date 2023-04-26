using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        //We create an object here because throughout the life of this app we will use the same class
        private readonly KnowledgeHubDBContext db = new KnowledgeHubDBContext();
        public void Delete(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }

        public void Edit(Category categoryToEdit)
        {
            db.Entry(categoryToEdit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Find(id);
        }

        public void Save(Category categoryToSave)
        {
            db.Categories.Add(categoryToSave);
            db.SaveChanges();
        }
    }
}
