using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogApi.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
