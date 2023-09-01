using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.DataMapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.PhoneNumber).HasColumnType("VARCHAR");
        }
    }
}