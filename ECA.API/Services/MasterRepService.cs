
namespace ECA.API.Services
{
    public class MasterRepService : IMasterRepService
    {
        private readonly HrDbContext _context;

        public MasterRepService(HrDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<MasterRep>> Get(string xCode = "")
        {
            var employees = await _context.MasterReps
                .Where(m => (m.NO == xCode || xCode == ""))
                .ToListAsync();
            return employees;
        }

    }
}
