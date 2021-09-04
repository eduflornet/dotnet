using Microsoft.EntityFrameworkCore;
using NET5.DAL.Configurations;
using NET5.DAL.Entities;

namespace NET5.DAL
{
    class EfCoreContext: DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options): base(options)
        {
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<PriceOffer> PriceOffers { get; set; }
            public DbSet<Order> Orders { get; set; }
        }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfig());
        modelBuilder.ApplyConfiguration(new BookAuthorConfig());
        modelBuilder.ApplyConfiguration(new PriceOfferConfig());
        modelBuilder.ApplyConfiguration(new LineItemConfig());
    }
 
}
