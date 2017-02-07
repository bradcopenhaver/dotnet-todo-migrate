using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;



namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: /<controller>/
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // Create
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Read
        public IActionResult Details(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        // Update
        public IActionResult Edit(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete

        public IActionResult Delete(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            db.Categories.Remove(thisCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
