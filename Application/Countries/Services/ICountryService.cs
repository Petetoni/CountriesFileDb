namespace Application.Countries.Services
{
    using Application.Countries.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountryService
    {
        Task<CreateCountryOutputModel> CreateCountry(string name, string code);

        Task<DetailsCountryOutputModel> GetCountry(string code);

        Task<IEnumerable<DetailsCountryOutputModel>> GetCountries();
    }
}
