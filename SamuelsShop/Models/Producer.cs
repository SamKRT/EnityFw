using System.ComponentModel.DataAnnotations;

namespace SamuelsShop.Models
{
    class Producer
    {
        [Key]
        public int ProducerID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)] 
        public string Street { get; set; }

        [Required, MaxLength(50)] 
        public int HouseNumber { get; set; }

        [Required] 
        public int PostalCode { get; set; }

        [Required, MaxLength(50)] 
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}
