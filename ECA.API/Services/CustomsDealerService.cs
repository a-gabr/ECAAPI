namespace ECA.API.Services
{
    public class CustomsDealerService : ICustomsDealerService
    {
        private readonly ApplicationDbContext _context;

        public CustomsDealerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomsDealer>> Get(decimal? cdlrNumber = 0)
        {
            var customsDealers = await _context.CustomsDealers
                .Where(m => (m.CDLRNumber == cdlrNumber || cdlrNumber == 0))
                .ToListAsync();
            return customsDealers;
        }
        public CustomsDealer Update(CustomsDealer model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
