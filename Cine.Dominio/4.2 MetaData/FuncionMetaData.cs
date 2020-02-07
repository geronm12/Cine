using Cine.Dominio._4._1_Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData
{
    public class FuncionMetaData : IEntityTypeConfiguration<_1_Entidades.Funcion>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Funcion> builder)
        {
            builder.Property(x => x.PeliculaId).IsRequired();

            builder.Property(x => x.SalaId).IsRequired();

            builder.Property(x => x.EntradaId).IsRequired();

            builder.Property(x => x.EntradasDisponibles).IsRequired();

            builder.Property(x => x.Precio).HasColumnType("numeric(18,2)").IsRequired();

            builder.Property(x => x.FechaDeEstreno).HasColumnType("Date").IsRequired();

            builder.Property(x => x.FechaDeBaja).HasColumnType("Date").IsRequired();

            
        }
    }
}
