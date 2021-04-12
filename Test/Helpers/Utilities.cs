namespace Test.Helpers
{
    using Domain.Countries.Models;
    using Infraestructure.Countries.Persistence;
    using System.Collections.Generic;

    public class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(CountryDbContext db)
        {
            db.Countries.AddRange(GetCountries());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(CountryDbContext db)
        {
            db.Countries.RemoveRange(db.Countries);
            InitializeDbForTests(db);
        }

        public static List<Country> GetCountries()
        {
            return new List<Country>()
            {
                new Country(){ Name = "Germany", Code = "GR" },
                new Country(){ Name = "Spain", Code = "SP" },
                new Country(){ Name = "India", Code = "IN" }
            };
        }
        #endregion
    }
}
