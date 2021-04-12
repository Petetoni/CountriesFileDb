﻿namespace Infraestructure.Countries.Persistence.Repositories
{
    using Domain.Countries.Models;
    using Domain.Countries.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CountryRepository : ICountryDomainRepository
    {
        public CountryRepository(CountryDbContext db) => this.Data = db;

        protected CountryDbContext Data { get; }

        protected IQueryable<Country> All() => this.Data.Set<Country>();

        public async Task Save(
            Country entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Countries.Add(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task<Country> FindByCode(
            string code, 
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(c => 
                    c.Code.Equals(code, System.StringComparison.InvariantCultureIgnoreCase), 
                    cancellationToken);

        public async Task<IEnumerable<Country>> FindAll(CancellationToken cancellationToken = default)
            => await this
                .All()
                .ToListAsync(cancellationToken);
    }
}
