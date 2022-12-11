using Microsoft.AspNetCore.Mvc;
using LibraryInventorySystem.Data;
using LibraryInventorySystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventorySystem.Controllers;

public class SearchController : Controller
{
    private readonly AppDbContext _context;

    public SearchController(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index(string filter, string searchString)
    {
        IQueryable<string> bookSearch = from m in _context.Inventories select m.BookTitle;

        ViewData["search"] = searchString;
        
        var books = from m in _context.Inventories select m;

        switch (filter)
        {
            case "Title":
                break;
        }
        
        if (!string.IsNullOrEmpty(searchString))
        {
            books = books.Where(s => s.BookTitle!.Contains(searchString));
        }
        
        var bookInventoryVm = new SearchViewModel
        {
            Inventories = await books.ToListAsync(),
            Titles = new SelectList(bookSearch.Distinct())
        };
            
        return View(bookInventoryVm);    
    }
}