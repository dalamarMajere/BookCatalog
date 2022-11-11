using BookCatalogWeb.Data;
using BookCatalogWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookCatalogWeb.Controllers;

public class BookController : Controller
{

    private readonly ApplicationDbContext _database;

    public BookController(ApplicationDbContext databse)
    {
        _database = databse; 
    }

    public List<Book> GetSortedList()
    {
        return _database.Books.OrderBy(book => book.DisplayOrder).ToList();
    }

    public IActionResult Index()
    {
        IEnumerable<Book> bookList = GetSortedList();
        return View(bookList);
    }

    //GET
    public IActionResult Create()
    {
        IEnumerable<Category> categories = _database.Categories;
        var item = new BookWithCategories() { Book = new(), Categories = categories.Select(category => category.Name) };
        return View(item);
    }

    public IActionResult Random()
    {
        return View();
    }
    
    public IActionResult Filter()
    {
        return View(_database.Categories);
    }

    [HttpPost]
    public IActionResult Filter(IEnumerable<Category> categories)
    {
        return NoContent();
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var bookFromDb = _database.Books.Find(id);

        if (bookFromDb == null)
        {
            return NotFound();
        }

        return View(bookFromDb);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var bookFromDb = _database.Books.Find(id);

        if (bookFromDb == null)
        {
            return NotFound();
        }

        return View(bookFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Book book)
    {
        _database.Books.Remove(book);
        _database.SaveChanges();

        MarkInTempData("deleted");

        return RedirectToAction("Index");
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Book book)
    {
        if (book.DisplayOrder < 0)
        {
            ModelState.AddModelError("displayorder", "The Display Order cannot be less than zero");
        }

        if (!ModelState.IsValid)
        {
            return View(book);
        }

        _database.Books.Update(book);
        _database.SaveChanges();

        MarkInTempData("updated");

        return RedirectToAction("Index");
    }

    private void MarkInTempData(string action)
    { 
        TempData[Constants.OperationPerformedTempData] = "Book " + action + " successfully";
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookWithCategories bookWithCategory)
    {
        if (bookWithCategory.Book.DisplayOrder < 0)
        {
            ModelState.AddModelError("displayorder", "The Display Order cannot be less than zero");
        }

        if (!ModelState.IsValid)
        {
            return View(bookWithCategory);
        }

        _database.Books.Add(bookWithCategory.Book);
        _database.SaveChanges();

        MarkInTempData("created");

        return RedirectToAction("Index");
    }



}
