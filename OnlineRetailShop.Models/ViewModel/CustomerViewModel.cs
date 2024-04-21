using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Models.ViewModel
{
    internal class CustomerViewModel
    {
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Mobile { get; set; }
        public string? EmailId { get; set; }
    }
}
