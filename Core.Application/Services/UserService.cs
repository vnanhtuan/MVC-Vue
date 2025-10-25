using Core.Application.Common;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IAppDbContext _context;

        public UserService(IAppDbContext context) 
        {
            _context = context;
        }

        public async Task SaveUser(string username, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utility.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordKey = passwordSalt,
                Email = username,
                FirstName = "Admin",
                LastName = "Vo",
                Phone = password
            };   
            
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
