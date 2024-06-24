using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace ECA.API.Services
{
    public class SecurityUserService :ISecurityUserService
    {
        private readonly ApplicationDbContext _context;

        public SecurityUserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SecurityUsers> Add(SecurityUsers model)
        {
            await _context.securityUsers.AddAsync(model);
            _context.SaveChanges();
            return model;
        }
        public async Task<IEnumerable<SecurityUsers>> Get(string? userName = "")
        {
            var users = await _context.securityUsers
                .Where(m => (m.name == userName || userName == ""))
                .ToListAsync();
            return users;
        }
        public async Task<bool> IsExist(string username)
        {
            var exist = await _context.securityUsers.AnyAsync(q => q.name == username);
            return exist;
        }
    }
}
