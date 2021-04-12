namespace Domain.Countries.Models
{
    using Domain.Common;

    public class Country : IAggregateRoot
    {
        public Country() { }

        public Country(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}
