﻿using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Show(int id)
        {
            Post post = RepositoryFactory.PostRepository.GetPostByID(id);

            return View(post);
        }

        public ActionResult Edit(int id)
        {
            Post post = RepositoryFactory.PostRepository.GetPostByID(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            post.Body = HttpUtility.HtmlDecode(post.Body);
            RepositoryFactory.PostRepository.UpdatePost(post);

            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Create()
        {
            List<SelectListItem> categories = RepositoryFactory.CategoryRepository.GetCategoriesForDropDown();
            ViewBag.CategoryList = categories;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post, int categoryList)
        {
            post.Body = HttpUtility.HtmlDecode(post.Body);
            post.CategoryID = categoryList;
            RepositoryFactory.PostRepository.CreatePost(post);

            return RedirectToAction("Index", "Home", null);
        }

        [HttpPost]
        public ActionResult Delete(Post post)
        {
            RepositoryFactory.PostRepository.DeletePostByID(post.ID);

            return RedirectToAction("Index", "Home", null);
        }
    }
}
