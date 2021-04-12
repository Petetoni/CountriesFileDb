namespace Test.Unit.Domain
{
    using FluentAssertions;
    using global::Domain;
    using global::Domain.Countries.Factories;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpec
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICountryFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
