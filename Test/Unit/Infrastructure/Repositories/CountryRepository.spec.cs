using Domain.Countries.Models;
using Domain.Countries.Specifications;
using Infraestructure.Countries.Persistence;
using Infraestructure.Countries.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit.Infrastructure.Repositories
{
    public class CountryRepositorySpec : BaseUnitTest
    {
        [Fact]
        public async Task Fact_FindByCode_ReturnsNullIfDoesNotExists()
        {
            // Arrange
            var mock = CountriesTest.AsQueryable().BuildMockDbSet();
            var dbContextMock = new Mock<CountryDbContext>(new DbContextOptions<CountryDbContext>());
            dbContextMock.Setup(c => c.Countries).Returns(mock.Object);
            dbContextMock.Setup(c => c.Set<Country>()).Returns(mock.Object);

            // Act
            var countryRepository = new CountryRepository(dbContextMock.Object);
            var countryCodeSpecification = new CountryByCodeSpecification("TST12");
            var country = await countryRepository.FindByCode(countryCodeSpecification);

            // Assert
            Assert.Null(country);
        }

        [Fact]
        public async Task Fact_FindByCode_ReturnsCountry()
        {
            // Arrange
            var mock = CountriesTest.AsQueryable().BuildMockDbSet();
            var dbContextMock = new Mock<CountryDbContext>(new DbContextOptions<CountryDbContext>());
            dbContextMock.Setup(c => c.Countries).Returns(mock.Object);
            dbContextMock.Setup(c => c.Set<Country>()).Returns(mock.Object); 

            // Act
            var countryRepository = new CountryRepository(dbContextMock.Object);
            var countryCodeSpecification = new CountryByCodeSpecification("TST1");
            var country = await countryRepository.FindByCode(countryCodeSpecification);

            // Assert
            Assert.NotNull(country);
            Assert.Equal("Test 1", country.Name);
        }
    }
}
