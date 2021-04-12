namespace Test.Integration.Tests.Countries
{
    using Application.Countries.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Xunit;

    public class DetailsCountryTest : BaseIntegrationTest
    {
        [Fact]
        public async Task Fact_GetCountryByCode()
        {
            // EXAMPLE
            var countryCode = "GR";
            var countryName = "Germany";

            // CONTROLLER
            var result = await GetCountriesController().GetByCode(countryCode);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var countryModel = Assert.IsType<DetailsCountryOutputModel>(okResult.Value);
            Assert.Equal(countryName, countryModel.CountryName);
            Assert.Equal(countryCode, countryModel.CountryCode);
        }

        [Fact]
        public async void Fact_GetCountryByCode_Returns404()
        {
            // EXAMPLE
            var countryCode = "XX";
            
            // CONTROLLER
            var result = await GetCountriesController().GetByCode(countryCode);

            // ASSERT
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
