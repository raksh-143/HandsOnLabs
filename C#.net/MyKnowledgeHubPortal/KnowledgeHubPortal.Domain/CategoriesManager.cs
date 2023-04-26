using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain
{
    public class CategoriesManager : ICategoriesManager
    {
        private ICategoriesRepository repo = null;
        public CategoriesManager(ICategoriesRepository repo)
        {
            this.repo = repo;
        }
        public void CreateCategory(Category categoryToSave)
        {
            //Apply any business rules here
            //Call data layer for saving
            repo.Save(categoryToSave);
        }

        public void DeleteCategory(int categoryId)
        {
            repo.Delete(categoryId);
        }

        public void EditCategory(Category categoryToEdit)
        {
            repo.Edit(categoryToEdit);
        }

        public Category GetCategoryById(int categoryid)
        {
            return repo.GetCategoryById(categoryid);
        }

        public List<Category> ListCategories()
        {
            return repo.GetAll();
        }
    }
}
