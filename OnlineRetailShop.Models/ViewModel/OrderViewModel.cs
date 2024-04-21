using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Models.ViewModel
{
    internal class OrderViewModel
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
