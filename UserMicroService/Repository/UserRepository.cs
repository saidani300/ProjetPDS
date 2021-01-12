using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.DbContexts;
using UserMicroService.Models;

namespace UserMicroService.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByID(string Id)
        {
            return await _context.Users.FirstOrDefaultAsync((e) => e.Id == Id);
        }

    }
}
