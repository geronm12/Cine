using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData.Sala
{
    public class SalaMetaData : IEntityTypeConfiguration<_1_Entidades.Sala.Sala>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Sala.Sala> builder)
        {
            builder.Property(x => x.NumeroSalon).IsRequired();

            builder.Property(x => x.CapacidadMáx).IsRequired();
        }
    }
}
