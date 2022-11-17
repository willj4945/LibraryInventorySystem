using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryInventorySystem.Models;

public class SearchViewModel
{
    public List<Inventory>? Inventories { get; set; }
    public SelectList? Titles { get; set; }
    public SelectList? Authors { get; set; }
    public SelectList? ISBN { get; set; }
    
    public string? SearchString { get; set; }
    public string? searchInput { get; set; }
}