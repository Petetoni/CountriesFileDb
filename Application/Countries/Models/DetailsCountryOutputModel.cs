namespace Application.Countries.Models
{
    public class DetailsCountryOutputModel
    {
        public DetailsCountryOutputModel(string countryName, string countryCode)
        {
            this.CountryName = countryName;
            this.CountryCode = countryCode;
        }

        public string CountryName { get; }

        public string CountryCode { get; }
    }
}
