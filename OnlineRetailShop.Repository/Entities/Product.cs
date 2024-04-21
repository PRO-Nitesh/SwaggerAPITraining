using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
