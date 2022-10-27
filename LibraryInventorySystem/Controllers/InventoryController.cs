using Microsoft.AspNetCore.Mvc;
using LibraryInventorySystem.Data;
using LibraryInventorySystem.Models;


namespace LibraryInventorySystem.Controllers;

public class InventoryController : Controller
{
    private readonly AppDbContext _db;

    public InventoryController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Inventory> objInventoryList = _db.Inventories;
        return View(objInventoryList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Inventory obj)
    {
        if (obj.AuthorName == obj.Isbn.ToString())
        {
            ModelState.AddModelError("CustomError", "The ISBN cannot exactly match the Author Name.");
        }

        if (ModelState.IsValid)
        {
            _db.Inventories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Inventory item created successfully!";
            return RedirectToAction("Index");
        }

        return View();
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var inventoryFromDb = _db.Inventories.Find(id);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Inventory obj)
    {
        if (obj.AuthorName == obj.Isbn.ToString())
        {
            ModelState.AddModelError("CustomError", "The ISBN cannot exactly match the Author Name.");
        }

        if (ModelState.IsValid)
        {
            _db.Inventories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully!";

            return RedirectToAction("Index");
        }

        return View();
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var inventoryFromDb = _db.Inventories.Find(id);

        if (inventoryFromDb == null)
        {
            return NotFound();
        }

        return View(inventoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Inventories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Inventories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully!";

        return RedirectToAction("Index");
    }
}

