using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET5.DAL.Entities;

namespace NET5.DAL.Configurations
{
    class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
