namespace Application
{
    using Application.Common;
    using Application.Countries.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddServices()
                .Configure<ApplicationSettings>(
                    configuration.GetSection(nameof(ApplicationSettings)),
                    options => options.BindNonPublicProperties = true);

        private static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddScoped<ICountryService, CountryService>();
    }
}
