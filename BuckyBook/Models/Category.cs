using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BuckyBook.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100)]
        public String name { get; set; }
        [DisplayName ("Display Order")]
        [Range (1,100)]  
        
        public int displayOrder { get; set; } 
    }
}
