namespace Application.Countries.Services
{
    using Application.Countries.Exceptions;
    using Application.Countries.Models;
    using Domain.Common;
    using Domain.Countries.Factories;
    using Domain.Countries.Models;
    using Domain.Countries.Repositories;
    using Domain.Countries.Specifications;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CountryService : ICountryService
    {
        private readonly ICountryDomainRepository countryRepository;
        private readonly ICountryFactory countryFactory;

        public CountryService(
            ICountryDomainRepository countryRepository,
            ICountryFactory countryFactory)
        {
            this.countryRepository = countryRepository;
            this.countryFactory = countryFactory;
        }

        public async Task<CreateCountryOutputModel> CreateCountry(string name, string code)
        {
            var country = countryFactory
                .WithName(name)
                .WithCode(code)
                .Build();

            await countryRepository.Save(country);

            return new CreateCountryOutputModel(name, code);
        }

        public async Task<IEnumerable<DetailsCountryOutputModel>> GetCountries()
        {
            var countries = await countryRepository.FindAll();

            return countries
                .Select(c => 
                    new DetailsCountryOutputModel(
                        c.Name, 
                        c.Code));
        }

        public async Task<DetailsCountryOutputModel> GetCountry(string code)
        {
            Specification<Country> specification = new CountryByCodeSpecification(code);
            var country = await countryRepository.FindByCode(specification);
            if (country == null)
            {
                throw new CountryNotFoundException(code);
            }

            return new DetailsCountryOutputModel(country.Name, country.Code);
        }
    }
}
