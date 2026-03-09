using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration.Customer
{
    internal class CustomerConfiguration
    {

        //public class RolesAplicacionesConfiguration : IEntityTypeConfiguration<RolesAplicacionesEntity>
        //{
        //    public void Configure(EntityTypeBuilder<RolesAplicacionesEntity> builder)
        //    {
        //        builder.ToTable("CORE_Roles_Aplicaciones", "dbo");
        //        builder.HasKey(x => x.Id);

        //        builder.Property(x => x.Nombre)
        //            .HasMaxLength(150)
        //            .IsRequired();

        //        builder.Property(x => x.Descripcion)
        //            .IsRequired(false);

        //        // Columna legacy varchar(50), en dominio Guid?
        //        builder.Property(x => x.Tipo)
        //            .HasColumnName("Tipo")
        //            .HasConversion(
        //                v => v.HasValue ? v.Value.ToString() : null,
        //                v => string.IsNullOrWhiteSpace(v) ? (Guid?)null : Guid.Parse(v)
        //            )
        //            .HasMaxLength(50)
        //            .IsUnicode(false)
        //            .IsRequired(false);

        //        builder.Property(x => x.IdTipoAutenticacion)
        //            .IsRequired(false);

        //        builder.Property(x => x.IdTipoAutorizacion)
        //            .IsRequired(false);

        //        builder.Property(x => x.Activo)
        //            .IsRequired();
        //    }
        //}

    }
}
