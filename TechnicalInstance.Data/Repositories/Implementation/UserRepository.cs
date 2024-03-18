using Microsoft.EntityFrameworkCore;
using TechnicalInstance.Data.Context;
using TechnicalInstance.Data.Entities;
using TechnicalInstance.Data.Repositories.Contract;

namespace TechnicalInstance.Data.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == userEmail);
        }
    
    }
}
