using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET5.DAL.Entities;

namespace NET5.WebApi.DAL.Configurations
{
    internal class PriceOfferConfig : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> entity)
        {
            //automated
            entity.Property(p => p.NewPrice)
                .HasColumnType("decimal(9,2)");
        }
    }
}
