using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryInventorySystem.Models
{
    public class Employee
    {
        [Key] public int Id { get; set; }

        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        public string? Suffix { get; set; }

        [Required] public int PhoneNumber { get; set; }

        [Required] public int StreetNumber { get; set; }

        [Required] public string? StreetName { get; set; }

        [Required] public string? Town { get; set; }

        [Required] public string? State { get; set; }

        [Required] public int ZipCode { get; set; }
    }
}