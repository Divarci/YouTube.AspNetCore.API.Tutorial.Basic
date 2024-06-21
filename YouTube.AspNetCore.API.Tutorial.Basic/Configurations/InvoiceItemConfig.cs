using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Configurations
{
    public class InvoiceItemConfig : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Price).IsRequired().HasPrecision(10,2);
            builder.Property(x=>x.Quantity).IsRequired();
            builder.Property(x => x.Vat).HasPrecision(10, 2);
            builder.Property(x => x.Total).HasPrecision(10, 2);
            builder.Property(x => x.GrandTotal).HasPrecision(10, 2);
        }
    }
}
