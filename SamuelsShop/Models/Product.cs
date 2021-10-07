using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamuelsShop.Models
{
    class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public double? TargetTemperature { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Stock { get; set; }
        
        [Required]
        public int DailyConsumption { get; set; }
        
        [Required, ForeignKey("Producer")]
        public int ProducerID { get; set; }

        public Producer Producer { get; set; }
    }
}
