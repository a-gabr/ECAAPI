namespace ECA.API.Services
{
    public interface ISecurityUserService
    {
        Task<SecurityUsers> Add(SecurityUsers model);
        Task<IEnumerable<SecurityUsers>> Get(string? userName = "");
        Task<bool> IsExist(string username);        
    }
}
