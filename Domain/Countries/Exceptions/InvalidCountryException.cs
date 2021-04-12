namespace Domain.Countries.Exceptions
{
    using Domain.Common;

    public class InvalidCountryException : BaseDomainException
    {
        public InvalidCountryException()
        {
        }

        public InvalidCountryException(string error) => this.Error = error;
    }
}
