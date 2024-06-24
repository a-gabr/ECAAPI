
namespace ECA.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee model)
        {
            await _context.Employees.AddAsync(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<IEnumerable<Employee>> Get(int xCode = 0)
        {
            var employees = await _context.Employees
                .Where(m => (m.xcode == xCode || xCode == 0))
                .ToListAsync();
            return employees;
        }

    }
}
