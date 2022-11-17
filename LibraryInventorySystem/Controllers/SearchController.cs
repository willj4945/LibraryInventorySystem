using System.Text.RegularExpressions;
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
    
    
    
    public async Task<IActionResult> Index(string title, string authorName, string isbn)
    {
        IQueryable<string> bookSearch = from m in _context.Inventories 
                                        orderby m.BookTitle
                                        select m.BookTitle;
        
        var books = from m in _context.Inventories select m;
        
        if (!string.IsNullOrEmpty(title))
        {
            books = books.Where(s => s.BookTitle!.Contains(title));
        }

        if (!string.IsNullOrEmpty(authorName))
        {
            books = books.Where(x => x.AuthorName == authorName);
        }
        
        if (!string.IsNullOrEmpty(isbn) && isbn.Length is 8 or 13)
        {
            books = books.Where(y => y.Isbn == int.Parse(isbn));
        }

        var bookInventoryVm = new SearchViewModel
        {
            Inventories = await books.ToListAsync(),
            Titles = new SelectList(await bookSearch.Distinct().ToListAsync()),
            Authors = new SelectList(await bookSearch.Distinct().ToListAsync()),
            ISBN = new SelectList(await bookSearch.Distinct().ToListAsync())
        };
            
        return View(bookInventoryVm);
    }
}