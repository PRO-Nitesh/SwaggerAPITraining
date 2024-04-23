using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    //public class Jwt
    //{
    //    public string key { get; set; }
    //    public string Issuer { get; set; }
    //    public string Audience { get; set; }
    //    public string Subject { get; set; }

    //}
}
