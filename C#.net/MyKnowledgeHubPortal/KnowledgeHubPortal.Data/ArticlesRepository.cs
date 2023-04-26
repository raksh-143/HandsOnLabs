using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private KnowledgeHubDBContext context = new KnowledgeHubDBContext();
        public void ApproveArticles(List<int> articleIds)
        {
            foreach(var id in articleIds)
            {
                var article = context.Articles.Find(id);
                if (article != null)
                {
                    article.IsApproved = true;
                }
            }
            context.SaveChanges();
        }

        public void DeleteArticles(List<int> articleIds)
        {
            foreach (var id in articleIds)
            {
                var article = context.Articles.Find(id);
                context.Articles.Remove(article);
            }
            context.SaveChanges();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return context.Articles.Where(a=>a.IsApproved==true).ToList();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryId)
        {
            return context.Articles.Where(a => a.IsApproved == true && a.CategoryID==categoryId).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            return context.Articles.Where(a => a.IsApproved == false).ToList();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryId)
        {
            return context.Articles.Where(a => a.IsApproved == false && a.CategoryID == categoryId).ToList();
        }

        public void SubmitArticle(Article article)
        {
            context.Articles.Add(article);
            context.SaveChanges();
        }
    }
}
