using Cine.Dominio._4._6_Enumeradores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData.Pelicula
{
    public class PeliculaMetaData : IEntityTypeConfiguration<_1_Entidades.Pelicula.Pelicula>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Pelicula.Pelicula> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            builder.Property(x => x.País).HasMaxLength(30).IsRequired();

            builder.Property(x => x.URL).HasMaxLength(300).IsRequired();

            builder.Property(x => x.TrailerURL).HasMaxLength(300).IsRequired();

            builder.Property(x => x.FechaDeCreacion).HasColumnType("Date").IsRequired();

            builder.Property(x => x.Duración).IsRequired();

            builder.Property(x => x.Descripción).HasMaxLength(700).IsRequired();

            builder.Property(x => x.TipoDePelicula).HasConversion(x => x.ToString(), e => (TipoPelicula)Enum.Parse(typeof(TipoPelicula), e)).IsRequired();

        }
    }
}
