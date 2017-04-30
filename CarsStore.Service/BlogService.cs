﻿namespace CarsStore.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using CarsStore.Models.BindingModels.Blog;

    using Models.EntityModels;
    using Models.ViewModels.Blog;

    public class BlogService:Service
    {
        public IEnumerable<ArticleVm> GetAllArticles()
        {
            IEnumerable<Article> models = this.Context.Articles;
            IEnumerable<ArticleVm> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(models);

            return vms;
        }
        public void AddNewArticle(AddArticleBm bind, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            Article model = Mapper.Map<AddArticleBm, Article>(bind);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today;
            this.Context.Articles.Add(model);
            this.Context.SaveChanges();
        }
    }
}