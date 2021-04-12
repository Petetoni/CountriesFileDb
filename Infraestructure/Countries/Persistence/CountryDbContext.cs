namespace Infraestructure.Countries.Persistence
{
    using Domain.Countries.Models;
    using Microsoft.EntityFrameworkCore;

    public class CountryDbContext : DbContext
    {
        private readonly string tableName;

        public CountryDbContext(DbContextOptions<CountryDbContext> options) : base(options) { }

        public CountryDbContext(
            DbContextOptions<CountryDbContext> options, 
            string tableName) 
            : this(options)
        {
            this.tableName = tableName;
        }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Country>()
                .ToTable(tableName ?? "countries")
                .HasKey(c => c.Code);
        }
    }
}
