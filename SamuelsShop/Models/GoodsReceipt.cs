using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamuelsShop.Models
{
    class GoodsReceipt
    {
        [Key]
        public int GoodsReceiptID { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime BestBefore { get; set; }
        
        [Required]
        public DateTime AcceptanceDay { get; set; }

        [Required]
        public int ChargeID { get; set; }

        [Required]
        public bool GoodsIncomplete { get; set; }

        [Required]
        public bool GoodsDamaged { get; set; }


        public double? MeasuredTemperature { get; set; }
        
        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
