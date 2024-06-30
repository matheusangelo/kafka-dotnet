using App.Domain.Entities;
using App.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace App.Infra.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { 
        }
        public DbSet<Message> messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
        }
    }

    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {

        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\App.Producer")))
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseOracle(configuration.GetConnectionString("OracleConnection"));

            return new Context(optionsBuilder.Options);
        }
    }
}