using Microsoft.AspNetCore.Mvc;

namespace BookCatalogWeb.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
