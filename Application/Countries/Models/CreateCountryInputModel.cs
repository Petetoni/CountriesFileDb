namespace Application.Countries.Models
{
    public class CreateCountryInputModel
    {
        public CreateCountryInputModel(string countryName, string countryCode)
        {
            this.CountryName = countryName;
            this.CountryCode = countryCode;
        }

        public string CountryName { get; }

        public string CountryCode { get; }
    }
}
