namespace Application.Countries.Queries
{
    using Application.Countries.Models;
    using Domain.Countries.Repositories;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DetailsAllCountriesQuery : IRequest<IEnumerable<DetailsCountryOutputModel>>
    {
        public class DetailsAllCountriesQueryHandler : IRequestHandler<
            DetailsAllCountriesQuery,
            IEnumerable<DetailsCountryOutputModel>>
        {
            private readonly ICountryDomainRepository countryRepository;

            public DetailsAllCountriesQueryHandler(ICountryDomainRepository countryRepository)
            {
                this.countryRepository = countryRepository;
            }

            public async Task<IEnumerable<DetailsCountryOutputModel>> Handle(
                DetailsAllCountriesQuery request,
                CancellationToken cancellationToken)
            {
                var countries = await this.countryRepository.FindAll(cancellationToken);

                return countries
                    .Select(c =>
                        new DetailsCountryOutputModel(
                            c.Name,
                            c.Code));
            }
        }
    }
}
