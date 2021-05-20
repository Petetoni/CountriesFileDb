namespace Application.Countries.Commands
{
    using Application.Common;
    using Application.Countries.Models;
    using Domain.Countries.Factories;
    using Domain.Countries.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCountryCommand : EntityCommand<string>, IRequest<CreateCountryOutputModel>
    {
        public string CountryName { get; set;}

        public class CreateCountryCommandHandler : IRequestHandler<
            CreateCountryCommand,
            CreateCountryOutputModel>
        {
            private readonly ICountryDomainRepository countryRepository;
            private readonly ICountryFactory countryFactory;

            public CreateCountryCommandHandler(
                ICountryDomainRepository countryRepository,
                ICountryFactory countryFactory)
            {
                this.countryRepository = countryRepository;
                this.countryFactory = countryFactory;
            }

            public async Task<CreateCountryOutputModel> Handle(
                CreateCountryCommand request, 
                CancellationToken cancellationToken)
            {
                var country = countryFactory
                .WithCode(request.CountryCode)
                .WithName(request.CountryName)
                .Build();

                await countryRepository.Save(country);

                return new CreateCountryOutputModel(country.Name, country.Code);
            }
        }
    }
}
