using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECA.API.Models
{
    public class IdentityDataContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }
    }
}
