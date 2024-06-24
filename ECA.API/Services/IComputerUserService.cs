namespace ECA.API.Services
{
    public interface IComputerUserService
    {
        Task<ComputerUser> GetById(decimal userId);
        Task<IEnumerable<ComputerUser>> GetUsers(string username="", decimal userId = 0);
        Task<ComputerUser> Add(ComputerUser model);
        ComputerUser Update(ComputerUser model);
        ComputerUser Delete(ComputerUser model);
        Task<bool> IsExist(decimal id);
        Task<bool> IsExist(string username);
    }
}
