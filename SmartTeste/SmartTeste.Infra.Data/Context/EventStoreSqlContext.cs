using Microsoft.EntityFrameworkCore;
using SmartTeste.Infra.Data.Mappings;
using SmartTeste.Domain.Core.Events;

namespace SmartTeste.Infra.Data.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
        //***********  DESCOMENTAR NO PRIMEIRO MIGRATION  ***********

        //public EventStoreSqlContext() : base() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-A7RT5PC\\SQLEXPRESS;Database=Smart.People;User Id=sa;Password=admin123;Encrypt=no;");
        //}

    }
}
