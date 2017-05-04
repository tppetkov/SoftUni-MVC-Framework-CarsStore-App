namespace CarsStore.Service.Interfaces
{
    using System.Collections.Generic;

    using CarsStore.Models.BindingModels.Blog;
    using CarsStore.Models.ViewModels.Blog;

    public interface IBlogService
    {
        IEnumerable<ArticleVm> GetAllArticles();

        void AddNewArticle(AddArticleBm bind, string username);
    }
}