using System;
using System.Collections.Generic;
using System.Text;
using Cine.Dominio._4._1_Entidades.Cine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Dominio._4._2_MetaData.Cine
{
    public class CineMetaData : IEntityTypeConfiguration<_1_Entidades.Cine.Cine>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Cine.Cine> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Teléfono).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Dirección).IsRequired().HasMaxLength(150);

            
        }
    }
}
