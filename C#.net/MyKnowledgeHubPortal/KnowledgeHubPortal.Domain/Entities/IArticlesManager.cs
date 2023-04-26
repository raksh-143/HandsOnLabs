using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public interface IArticlesManager
    {
        void SubmitArticle(Article article);
        void ApproveArticles(List<int> articleIds);
        void DeleteArticles(List<int> articleIds);
        List<Article> GetArticlesForReviewByCategory(int categoryId);
        List<Article> GetArticlesForBrowseByCategory(int categoryId);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();
    }
}
