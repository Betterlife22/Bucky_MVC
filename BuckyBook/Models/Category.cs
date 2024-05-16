using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BuckyBook.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String? name { get; set; }  
        public int? displayOrder { get; set; } 
    }
}
