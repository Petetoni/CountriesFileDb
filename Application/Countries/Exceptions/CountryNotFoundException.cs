namespace Application.Countries.Exceptions
{
    using System;

    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(string code)
            : base($"Country '{code}' was not found.")
        {
        }
    }
}
