using App.Domain.Entities;
using App.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Message> messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
        }
    }
}