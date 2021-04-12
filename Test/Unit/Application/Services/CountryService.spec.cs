using Application.Countries.Services;
using Domain.Countries.Factories;
using Domain.Countries.Models;
using Domain.Countries.Repositories;
using Infraestructure.Countries.Persistence.Repositories;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit.Application.Services
{
    public class CountryServiceSpec : BaseUnitTest
    {
        [Fact]
        public async Task Fact_GetUsers_ReturnsAllUsers()
        {
            // Arrange 
            var mockRepo = new Mock<ICountryDomainRepository>();
            mockRepo
                .Setup(repo => repo.FindAll(new System.Threading.CancellationToken()))
                .ReturnsAsync(CountriesTest);
            var mockFactory = new Mock<ICountryFactory>();
            mockFactory
                .Setup(fac => fac.Build())
                .Returns(new Country());
            var service = new CountryService(mockRepo.Object, mockFactory.Object);
            
            // Act
            var result = await service.GetCountries();

            // Assert
            Assert.Equal(CountriesTest.Count, result.Count());
        }
    }
}
