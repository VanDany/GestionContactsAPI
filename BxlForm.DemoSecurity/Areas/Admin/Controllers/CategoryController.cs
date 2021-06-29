using BxlForm.DemoSecurity.Areas.Admin.Infrastructure.Attributes;
using BxlForm.DemoSecurity.Areas.Admin.Models.Forms.Category;
using Models.Client.Data;
using Models.Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BxlForm.DemoSecurity.Infrastructure;

namespace BxlForm.DemoSecurity.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [AdminRequired]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ISessionManager _sessionManager;
        public CategoryController(ICategoryRepository categoryRepository, IContactRepository contactRepository, ISessionManager sessionManager)
        {
            _categoryRepository = categoryRepository;
            _contactRepository = contactRepository;
            _sessionManager = sessionManager;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryRepository.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name, CanDelete = _contactRepository.GetByCategory(c.Id, _sessionManager.User.Id).Count() == 0}));
            //return View(_categoryRepository.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name, CanDelete = false}));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            _categoryRepository.Insert(new Category(form.Name));

            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            _categoryRepository.Update(id, new Category(form.Name));

            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_contactRepository.GetByCategory(id, _sessionManager.User.Id).Count() == 0)
            {
                _categoryRepository.Delete(id);
            }
            return RedirectToAction("Index");

        }
    }
}
