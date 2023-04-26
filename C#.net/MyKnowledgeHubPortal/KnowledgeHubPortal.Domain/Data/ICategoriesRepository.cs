using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Data
{
    public interface ICategoriesRepository
    {
        void Save(Category categoryToSave);
        List<Category> GetAll();
        void Delete(int id);
        void Edit(Category categoryToEdit);
        Category GetCategoryById(int id);
    }
}
