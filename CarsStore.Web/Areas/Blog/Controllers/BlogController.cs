﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace CarsStore.Web.Areas.Blog.Controllers
{
    using CarsStore.Models.BindingModels.Blog;

    using Models.ViewModels.Blog;
    using CarsStore.Service;
    using CarsStore.Service.Interfaces;

    [RouteArea("blog")]
    [Authorize(Roles = "User")]
    public class BlogController : Controller
    {
        private IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service=service;
        }
        [Route("articles")]
        public ActionResult Articles()
        {
            IEnumerable<ArticleVm> vms = this.service.GetAllArticles();

            return this.View(vms);
        }

        [HttpGet]
        [Authorize(Roles = "BlogAuthor")]
        [Route("articles/add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "BlogAuthor")]
        [Route("articles/add")]
        public ActionResult Add(AddArticleBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewArticle(bind, username);
                return this.RedirectToAction("Articles");
            }
            return this.View(); 
        }

    }
}