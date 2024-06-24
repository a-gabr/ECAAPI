using Microsoft.AspNetCore.Identity;

namespace ECA.API.Services
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByMobileAsync(this UserManager<ApplicationUser> userManager, string mobile)
        {
            return await userManager?.Users?.SingleOrDefaultAsync(x => x.PhoneNumber == mobile);    
        }

        //public static async Task<ApplicationUser> FindByCardIDAsync(this UserManager<ApplicationUser> um, string cardId)
        //{
        //    return await um?.Users?.SingleOrDefaultAsync(x => x.CardID == cardId);
        //}

        //public static async Task<ApplicationUser> FindByAddressAsync(this UserManager<ApplicationUser> um, string address)
        //{
        //    return await um?.Users?.SingleOrDefaultAsync(x => x.Address == address);
        //}
    }
}
