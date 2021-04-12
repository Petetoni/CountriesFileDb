namespace Infraestructure
{
    using Application.Common;
    using Domain.Common;
    using FileContextCore;
    using Infraestructure.Countries.Persistence;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var dbFilePath = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.CountryFilePath));
            services
                .AddDbContext<CountryDbContext>(
                   options => options.UseFileContextDatabase(
                       location: dbFilePath
                       ));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
