using BookCatalogWeb.Data;
using BookCatalogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogWeb.Controllers;

public class BookController : Controller
{

    private readonly ApplicationDbContext _database;

    public BookController(ApplicationDbContext databse)
    {
        _database = databse; 
    }

    public IActionResult Index()
    {
        IEnumerable<Book> bookList = _database.Categories;
        return View(bookList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var bookFromDb = _database.Categories.Find(id);

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

        var bookFromDb = _database.Categories.Find(id);

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
        _database.Categories.Remove(book);
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

        _database.Categories.Update(book);
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
    public IActionResult Create(Book book)
    {
        if (book.DisplayOrder < 0)
        {
            ModelState.AddModelError("displayorder", "The Display Order cannot be less than zero");
        }

        if (!ModelState.IsValid)
        {
            return View(book);
        }

        _database.Categories.Add(book);
        _database.SaveChanges();

        MarkInTempData("created");

        return RedirectToAction("Index");
    }



}
