using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData.Horarios
{
    public class HorarioMetaData : IEntityTypeConfiguration<_1_Entidades.Horarios.Horarios>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Horarios.Horarios> builder)
        {
            builder.Property(x => x.HoraProyeccion).HasColumnType("Time").IsRequired();
        }
    }
}
