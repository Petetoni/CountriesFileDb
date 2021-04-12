namespace Application.Countries.Models
{
    public class CreateCountryOutputModel
    {
        public CreateCountryOutputModel(string countryName, string countryCode)
        {
            this.CountryName = countryName;
            this.CountryCode = countryCode;
        }

        public string CountryName { get; }

        public string CountryCode { get; }
    }
}
