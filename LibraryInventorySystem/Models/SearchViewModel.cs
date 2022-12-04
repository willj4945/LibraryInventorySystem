using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryInventorySystem.Models;

public enum Options
{
    Title = 0,
    Author = 1,
    Isbn = 2
}

public class SearchViewModel
{
    
    public List<Inventory>? Inventories { get; set; }
    
    public SelectList? Titles { get; set; }
    public SelectList? Authors { get; set; }
    public SelectList? Isbn { get; set; }
    public Options Filter { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string? SearchInput { get; set; }
}
