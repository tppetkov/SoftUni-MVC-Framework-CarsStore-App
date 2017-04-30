namespace CarsStore.Models.ViewModels.Blog
{
    using System;

    using CarsStore.Models.EntityModels;

    public class ArticleVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}