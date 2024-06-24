namespace ECA.API.Services
{
    public interface ICustomsDealerService
    {
        Task<IEnumerable<CustomsDealer>> Get(decimal? cdlrNumber = 0);
        CustomsDealer Update(CustomsDealer model);
    }
}
