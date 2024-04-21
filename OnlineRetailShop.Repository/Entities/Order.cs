using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int IsCancle { get; set; }
    }
}
