namespace Domain.Countries.Repositories
{
    using Domain.Common;
    using Domain.Countries.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICountryDomainRepository : IDomainRepository<Country>
    {
        Task<Country> FindByCode(
            Specification<Country> specification, 
            CancellationToken cancellationToken = default);

        Task<IEnumerable<Country>> FindAll(CancellationToken cancellationToken = default);
    }
}
