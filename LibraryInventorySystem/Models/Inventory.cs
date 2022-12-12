using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventorySystem.Models;

public class Inventory
{
    [Key] public int Id { get; set; }

   
    [BindProperty(SupportsGet = true)]

    [DisplayName("Book Title")]



    [Required] public string? BookTitle { get; set; }
    
    [DisplayName("Author Name")] public string? AuthorName { get; set; }

    [DisplayName("ISBN")] public int Isbn { get; set; }


    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}