namespace Domain.Countries.Specifications
{
    using Domain.Common;
    using Domain.Countries.Models;
    using System;
    using System.Linq.Expressions;

    public class CountryByCodeSpecification : Specification<Country>
    {
        private readonly string code;

        public CountryByCodeSpecification(string code)
            => this.code = code;

        protected override bool Include => this.code != null;

        public override Expression<Func<Country, bool>> ToExpression()
            => country => country.Code.ToLower().Equals(this.code!.ToLower());
    }
}
