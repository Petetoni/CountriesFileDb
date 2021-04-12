namespace Application.Common
{
    public class ApplicationSettings
    {
        public ApplicationSettings() => this.CountryFilePath = default!;

        public string CountryFilePath { get; private set; }
    }
}
