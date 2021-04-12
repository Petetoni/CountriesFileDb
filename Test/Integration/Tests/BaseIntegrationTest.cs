namespace Test.Integration.Tests
{
    using Application.Countries.Services;
    using Domain.Countries.Factories;
    using Domain.Countries.Repositories;
    using global::Test.Helpers;
    using Infraestructure.Countries.Persistence;
    using Infraestructure.Countries.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Web.Features;

    public class BaseIntegrationTest
    {
        protected CountryDbContext DBContext { get; private set; }

        public BaseIntegrationTest(
            CountryDbContext ctx = null)
        {
            this.DBContext = ctx ?? GetInMemoryDBContext();
        }

        protected CountryDbContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<CountryDbContext>();
            var options = builder
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            CountryDbContext dbContext = new CountryDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            Utilities.InitializeDbForTests(dbContext);

            return dbContext;
        }

        protected CountriesController GetCountriesController()
        {
            ICountryFactory factory = new CountryFactory();
            ICountryDomainRepository repository = new CountryRepository(DBContext);
            ICountryService service = new CountryService(repository, factory);

            return new CountriesController(service);
        }
    }
}
