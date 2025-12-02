using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSportStore.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string[] data)
        {
            //"Kayak;A boat for one person;Watersports;275" 
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = Convert.ToDecimal(data[3]);
        }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
