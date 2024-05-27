using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC.Models
{

    [Table("products")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double? Price { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }

        
    }
}
