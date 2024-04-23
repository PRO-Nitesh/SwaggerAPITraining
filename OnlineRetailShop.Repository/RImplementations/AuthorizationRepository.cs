using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.RImplementations
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetRole(Guid UserId)
        {
            User user = null;
            user = _context.Users.Find(UserId);
            return user;
        }
    }
}
