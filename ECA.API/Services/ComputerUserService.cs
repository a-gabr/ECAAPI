
namespace ECA.API.Services
{
    public class ComputerUserService : IComputerUserService
    {
        private readonly ApplicationDbContext _context;

        public ComputerUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ComputerUser> Add(ComputerUser model)
        {
            await _context.ComputerUsers.AddAsync(model);    
            _context.SaveChanges();
            return model;
        }

        public ComputerUser Delete(ComputerUser computerUser)
        {
            _context.Remove(computerUser);
            _context.SaveChanges();
            return computerUser;
        }

        public async Task<ComputerUser> GetById(decimal userId)
        {
            var user = await _context.ComputerUsers.SingleOrDefaultAsync(q=>q.UserId==userId);
            return user;
        }

        public async Task<IEnumerable<ComputerUser>> GetUsers(string username = "", decimal userId = 0)
        {
            var users = await _context.ComputerUsers
                .Where(m => (m.name == username || username == "") && (m.UserId ==  userId || userId == 0))
                .Take(5)
                .ToListAsync();
            return users;
            //throw new NotImplementedException();
        }

        public  ComputerUser Update(ComputerUser computerUser)
        {
             _context.Update(computerUser);
            _context.SaveChanges();
            return computerUser;
        }
        public async Task<bool> IsExist(decimal id)
        {
            var exist = await _context.ComputerUsers.AnyAsync(q=>q.UserId== id);
            return exist;
        }
        public async Task<bool> IsExist(string username)
        {
            var exist = await _context.ComputerUsers.AnyAsync(q => q.name == username);
            return exist;
        }
    }
}
