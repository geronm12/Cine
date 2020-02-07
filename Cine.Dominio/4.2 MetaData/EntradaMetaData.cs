using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Cine.Dominio._4._2_MetaData.Entrada
{
    public class EntradaMetaData : IEntityTypeConfiguration<_1_Entidades.Entrada.Entrada>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Entrada.Entrada> builder)
        {
            builder.Property(x => x.Numero).IsRequired();

            builder.Property(x => x.Precio).HasColumnName("numeric(18,2)").IsRequired();

            builder.Property(x => x.Descripcion).HasMaxLength(100).IsRequired();

            builder.Property(x => x.CantidadDisponible).IsRequired();

        }
    }
}
