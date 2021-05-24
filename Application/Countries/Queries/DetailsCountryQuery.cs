namespace Application.Countries.Queries
{
    using Application.Common;
    using Application.Countries.Exceptions;
    using Application.Countries.Models;
    using Domain.Common;
    using Domain.Countries.Models;
    using Domain.Countries.Repositories;
    using Domain.Countries.Specifications;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DetailsCountryQuery : EntityCommand<string>, IRequest<DetailsCountryOutputModel>
    {
        public class DetailsCountryQueryHandler : IRequestHandler<
            DetailsCountryQuery, 
            DetailsCountryOutputModel>
        {
            private readonly ICountryDomainRepository countryRepository;
            
            public DetailsCountryQueryHandler(ICountryDomainRepository countryRepository)
            {
                this.countryRepository = countryRepository;
            }

            public async Task<DetailsCountryOutputModel> Handle(
                DetailsCountryQuery request,
                CancellationToken cancellationToken)
            {
                Specification<Country> specification = new CountryByCodeSpecification(request.CountryCode);
                var country = await this.countryRepository.FindByCode(
                    specification,
                    cancellationToken);
                if (country == null)
                {
                    throw new CountryNotFoundException(request.CountryCode);
                }

                return new DetailsCountryOutputModel(country.Name, country.Code);
            }
        }
    }
}
