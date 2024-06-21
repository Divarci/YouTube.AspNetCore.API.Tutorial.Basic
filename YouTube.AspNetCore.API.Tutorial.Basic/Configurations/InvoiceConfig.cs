using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x=>x.InvoiceDate).IsRequired();
            builder.Property(x=>x.PONumber).HasMaxLength(10);
            builder.Property(x => x.Vat).HasPrecision(10, 2);
            builder.Property(x => x.Total).HasPrecision(10, 2);
            builder.Property(x => x.GrandTotal).HasPrecision(10, 2);
        }
    }
}
