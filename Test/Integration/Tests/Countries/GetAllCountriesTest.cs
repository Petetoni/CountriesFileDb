namespace Test.Integration.Tests.Countries
{
    using Application.Countries.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAllCountriesTest : BaseIntegrationTest
    {
        [Fact]
        public async Task Fact_GetAllCountries()
        {
            // CONTROLLER
            var result = await GetCountriesController().GetAll();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            //var product = Assert.IsType<IEnumerable<DetailsCountryOutputModel>>(okResult.Value);
            var countriesModel = Assert
                .IsAssignableFrom<IEnumerable<DetailsCountryOutputModel>>(okResult.Value);
            Assert.Contains(countriesModel, c => c.CountryCode == "GR" && c.CountryName == "Germany");
            Assert.Contains(countriesModel, c => c.CountryCode == "SP" && c.CountryName == "Spain");
            Assert.Contains(countriesModel, c => c.CountryCode == "IN" && c.CountryName == "India");
        }
    }
}
