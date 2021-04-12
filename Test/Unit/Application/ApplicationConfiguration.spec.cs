using Application;
using Application.Countries.Services;
using Domain;
using Infraestructure;
using Infraestructure.Countries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit.Application
{
    public class ApplicationConfigurationSpec
    {
        [Fact]
        public void Fact_AddApplicationShouldRegisterServices()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<CountryDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())); 
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json"); //or what ever file you have the settings
            IConfiguration configuration = builder.Build();

            // Act
            var services = serviceCollection
                .AddDomain()
                .AddRepositories()
                .AddApplication(configuration)
                .BuildServiceProvider();

            // Assert
            var service = services.GetService<ICountryService>();
            Assert.NotNull(service);
        }
    }
}
