using Microsoft.AspNetCore.Mvc;
using LibraryInventorySystem.Data;
using LibraryInventorySystem.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryInventorySystem.Controllers;

public class InventoryController : Controller
{
    private readonly AppDbContext _db;

    public InventoryController(AppDbContext db)
    {
        _db = db;
    }
        
}