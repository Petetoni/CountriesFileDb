namespace Domain.Countries.Factories
{
    using Domain.Common;
    using Domain.Countries.Models;

    public interface ICountryFactory : IFactory<Country>
    {
        ICountryFactory WithName(string name);

        ICountryFactory WithCode(string code);
    }
}
