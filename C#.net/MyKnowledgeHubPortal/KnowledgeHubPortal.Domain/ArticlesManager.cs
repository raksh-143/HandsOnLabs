using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain
{
    public class ArticlesManager : IArticlesManager
    {
        public IArticlesRepository repo;
        public ArticlesManager(IArticlesRepository repo)
        {
            this.repo = repo;
        }

        public void ApproveArticles(List<int> articleIds)
        {
            repo.ApproveArticles(articleIds);
        }

        public void DeleteArticles(List<int> articleIds)
        {
            repo.DeleteArticles(articleIds);
        }

        public List<Article> GetArticlesForBrowse()
        {
            return repo.GetArticlesForBrowse();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryId)
        {
            return repo.GetArticlesForBrowseByCategory(categoryId);
        }

        public List<Article> GetArticlesForReview()
        {
            return repo.GetArticlesForReview();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryId)
        {
            return GetArticlesForReviewByCategory(categoryId);
        }

        public void SubmitArticle(Article article)
        {
            repo.SubmitArticle(article);
        }
    }
}
