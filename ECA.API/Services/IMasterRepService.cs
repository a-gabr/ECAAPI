namespace ECA.API.Services
{
    public interface IMasterRepService
    {
        Task<IEnumerable<MasterRep>> Get(string xCode = "");
        
    }
}
