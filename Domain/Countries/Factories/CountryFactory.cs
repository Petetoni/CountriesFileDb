namespace Domain.Countries.Factories
{
    using Domain.Countries.Exceptions;
    using Domain.Countries.Models;

    public class CountryFactory : ICountryFactory
    {
        private string name = default!;
        private string code = default!;
        
        public ICountryFactory WithCode(string code)
        {
            this.code = code;
            return this;
        }

        public ICountryFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public Country Build()
        {
            if (string.IsNullOrEmpty(this.code) || string.IsNullOrEmpty(this.name))
            {
                throw new InvalidCountryException("Country must have a name and a code.");
            }

            return new Country(this.name, this.code);
        }
    }
}
