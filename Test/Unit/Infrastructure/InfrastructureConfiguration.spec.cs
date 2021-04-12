using Domain.Common;
using Domain.Countries.Repositories;
using FluentAssertions;
using Infraestructure;
using Infraestructure.Countries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit.Infrastructure
{
    public class InfrastructureConfiguration
    {
        [Fact]
        public void Fact_AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<CountryDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Act
            var services = serviceCollection
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICountryDomainRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
