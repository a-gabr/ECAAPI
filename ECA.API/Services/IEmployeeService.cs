namespace ECA.API.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Add(Employee model);
        Task<IEnumerable<Employee>> Get(int xCode = 0);
        
    }
}
