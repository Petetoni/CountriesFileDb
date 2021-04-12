namespace Test.Unit.Infrastructure.Factories
{
    using global::Domain.Countries.Exceptions;
    using global::Domain.Countries.Factories;
    using System;
    using Xunit;

    public class CountryFactorySpecs
    {
        [Fact]
        public void Fact_BuildThrowExceptionIfNameIsNotSet()
        {
            // Arrange
            var countryFactory = new CountryFactory();

            // Act
            Action act = () => countryFactory
                .WithName("")
                .WithCode("C1")
                .Build();

            // Assert
            Assert.Throws<InvalidCountryException>(act);
        }

        [Fact]
        public void Fact_BuildThrowExceptionIfCodeIsNotSet()
        {
            // Arrange
            var countryFactory = new CountryFactory();

            // Act
            Action act = () => countryFactory
                .WithName("Country 1")
                .WithCode("")
                .Build();

            // Assert
            Assert.Throws<InvalidCountryException>(act);
        }

        [Fact]
        public void Fact_BuildShouldCreateCountryAdIfEveryPropertyIsSet()
        {
            // Arrange
            var countryFactory = new CountryFactory();

            // Act
            var country = countryFactory
                .WithName("Country 1")
                .WithCode("C1")
                .Build();

            // Assert
            Assert.NotNull(country);
        }
    }
}
