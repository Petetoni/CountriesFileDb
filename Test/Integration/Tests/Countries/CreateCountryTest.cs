namespace Test.Integration.Tests.Countries
{
    using Application.Countries.Models;
    using Application.Countries.Services;
    using Domain.Countries.Exceptions;
    using Domain.Countries.Factories;
    using Domain.Countries.Models;
    using Domain.Countries.Repositories;
    using Infraestructure.Countries.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateCountryTest : BaseIntegrationTest
    {
        #region THEORY
        #endregion
        #region FACT
        //[Fact]
        //public void Fact_CreateCountry_NoModelNoRepository()
        //{
        //    // EXAMPLE
        //    var country = new Country("DISNEY LAND", "DL");

        //    // REPOSITORY
        //    ctx.Country.Add(country);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal("DL", country.Code);
        //}

        //[Fact]
        //public void Fact_CreateCountry_NoRepository()
        //{
        //    // EXAMPLE
        //    var country = new Country("DISNEY LAND", "DL");

        //    // REPOSITORY
        //    ctx.Country.Add(country);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal("DL", country.Code);
        //}

        [Fact]
        public async Task Fact_CreateCountryByRepository()
        {
            // EXAMPLE
            var country = new Country("DISNEY LAND", "DL");
            var nCountries = DBContext.Countries.Count();

            // REPOSITORY
            await new CountryRepository(DBContext).Save(country);
            
            // ASSERT
            Assert.Equal("DL", country.Code);
            Assert.Equal(nCountries + 1, DBContext.Countries.Count());
        }

        [Fact]
        public async Task Fact_CreateCountryByService()
        {
            // EXAMPLE
            var country = new Country("DISNEY LAND", "DL");
            var nCountries = DBContext.Countries.Count();

            // SERVICE
            ICountryFactory factory = new CountryFactory();
            ICountryDomainRepository repository = new CountryRepository(DBContext);
            ICountryService service = new CountryService(repository, factory);
            var countryModel = await service.CreateCountry(country.Name, country.Code);

            // ASSERT
            Assert.Equal(countryModel.CountryName, country.Name);
            Assert.Equal(countryModel.CountryCode, country.Code);
            Assert.Equal(nCountries + 1, DBContext.Countries.Count());
        }

        [Fact]
        public async Task Fact_CreateCountryByController()
        {
            // EXAMPLE
            var country = new CountryFactory()
                .WithName("Country 1")
                .WithCode("Code 1")
                .Build();
            var nCountries = DBContext.Countries.Count();

            // CONTROLLER
            var result = await GetCountriesController().Post(
                new CreateCountryInputModel(country.Name, country.Code));

            // ASSERT
            var okResult = Assert.IsType<CreatedResult>(result.Result);
            var countryModel = Assert.IsType<CreateCountryOutputModel>(okResult.Value);
            Assert.Equal(country.Name, countryModel.CountryName);
            Assert.Equal(country.Code, countryModel.CountryCode);
            Assert.Equal(nCountries + 1, DBContext.Countries.Count());
        }

        [Fact]
        public async Task Fact_CreateCountryWithoutName()
        {
            // EXAMPLE
            var countryName = string.Empty;
            var countryCode = "XX";

            // ACT
            Task act() => GetCountriesController().Post(
                new CreateCountryInputModel(countryName, countryCode));

            // ASSERT
            InvalidCountryException exception = await Assert.ThrowsAsync<InvalidCountryException>(act);
        }

        [Fact]
        public async Task Fact_CreateCountryWithoutCode()
        {
            // EXAMPLE
            var countryName = "XX";
            var countryCode = string.Empty;

            // ACT
            Func<Task> act = () => GetCountriesController().Post(
                new CreateCountryInputModel(countryName, countryCode));

            // ASSERT
            InvalidCountryException exception = await Assert.ThrowsAsync<InvalidCountryException>(act);
        }
        #endregion
    }
}

