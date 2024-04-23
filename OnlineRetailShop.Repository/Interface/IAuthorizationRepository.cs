using OnlineRetailShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Interface
{
    public interface IAuthorizationRepository
    {
        Task<User> GetRole(Guid UserId);
    }
}
