using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamuelsShop.Models
{
    class GoodsReceiptDraft
    {
        [Key]
        public int DraftID { get; set; }

        [Required]
        public string DraftName { get; set; }

        public int? Quantity { get; set; }
        
        
        public DateTime? BestBefore { get; set; }
        

        public DateTime AcceptanceDay { get; set; }

        
        public int? ChargeID { get; set; }

        
        public bool? GoodsIncomplete { get; set; }

        
        public bool? GoodsDamaged { get; set; }


        public double? MeasuredTemperature { get; set; }
        
        [ForeignKey("Product")]
        public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
