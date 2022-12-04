using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using LibraryInventorySystem.Data;
using LibraryInventorySystem.Models;
using LibraryInventorySystem.Views.Search;
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

    
    public async Task<IActionResult> Index(string filter, string search)
    {
        ViewData["CurrentFilter"] = filter;
                
        IQueryable<string> bookSearch = from m in _context.Inventories 
                                        select m.BookTitle;
        
        ViewData["search"] = search;
        
        var books = from m in _context.Inventories select m;
        
        if (!string.IsNullOrEmpty(search))
        {
            books = books.Where(s => s.BookTitle!.Contains(search));
        }
    
        if (!string.IsNullOrEmpty(search))
        {
            books = books.Where(x => x.AuthorName == search);
        }
        
        if (!string.IsNullOrEmpty(search) && search.Length is 8 or 13)
        {
            if (int.TryParse(search, out var isbn))
            {
                books = books.Where(y => y.Isbn == isbn);
            }
        }
        
        var bookInventoryVm = new SearchViewModel
        {
            Inventories = await books.ToListAsync(),
            Titles = new SelectList(await bookSearch.Distinct().ToListAsync()),
            Authors = new SelectList(await bookSearch.Distinct().ToListAsync()),
            Isbn = new SelectList(await bookSearch.Distinct().ToListAsync()),
            SearchInput = search
        };
            
        return View(bookInventoryVm);    
    }
}