using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookCatalogWeb.Data;
using BookCatalogWeb.Models;

namespace BookCatalogWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoryController(ApplicationDbContext context)
        {
            _database = context;
        }

        // GET: Categories
        public IActionResult Index()
        {
              return View(_database.Categories);
        }

        // GET 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _database.Add(category);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
