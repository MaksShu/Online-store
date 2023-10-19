﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Services;
using Shop.Web.ViewModels;

namespace Shop.Web.Controllers
{
    public class CategoryController : Controller
    {
        //CategoriesService categoriesService = new CategoriesService();
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModels model = new NewCategoryViewModels();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModels model)
        {
            if (ModelState.IsValid)
            {
                //categoriesService.SaveCategory(category);
                var newCategory = new Category();
                newCategory.Name = model.Name;
                newCategory.Description = model.Description;
                newCategory.ImageURL = model.ImageURL;
                newCategory.isFeatured = model.isFeatured;
                //return RedirectToAction("Index");
                CategoriesService.Instance.SaveCategory(newCategory);
                return RedirectToAction("CategoryTable");
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var category = CategoriesService.Instance.GetCategory(ID);
            model.ID=category.ID;
            model.Name=category.Name;
            model.Description=category.Description;
            model.ImageURL=category.ImageURL;
            model.isFeatured = category.isFeatured;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = CategoriesService.Instance.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.Description = model.Description;
            existingCategory.ImageURL = model.ImageURL;
            existingCategory.isFeatured = model.isFeatured;
            CategoriesService.Instance.UpdateCategory(existingCategory);
            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoriesService.Instance.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }

        public ActionResult CategoryTable(string search, int? pageNo)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1:1;
            var totalRecocrds = CategoriesService.Instance.GetCategoriesCount(search);
            model.Categories = CategoriesService.Instance.GetCategories(search,pageNo.Value);
            if (model.Categories!=null)
            {
                model.Pager = new Pager(totalRecocrds, pageNo, 3);
                return PartialView("CategoryTable", model);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}