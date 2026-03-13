using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using System.Linq;


namespace Infrastructure.Persistence.Configuration.Customers
{
    public class CustomerConfiguration
    {

        public class RolesAplicacionesConfiguration : IEntityTypeConfiguration<Customer>
        {

            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.ToTable("Customers");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Nombre)
                    .HasMaxLength(20)
                    .IsRequired();

                builder.Property(x => x.Email)
                    .HasMaxLength(50)
                    .IsRequired();

                builder.Property(x => x.Activo).IsRequired();

                builder.Property(x => x.CreatedAt).IsRequired();


            }
        }
    }
}

