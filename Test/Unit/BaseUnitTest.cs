namespace Test.Unit
{
    using global::Domain.Countries.Models;
    using System.Collections.Generic;

    public class BaseUnitTest
    {
        protected IList<Country> CountriesTest = new List<Country>()
            {
                new Country("Test 1", "TST1"),
                new Country("Test 2", "TST2"),
                new Country("Test 3", "TST3")
            };
    }
}
