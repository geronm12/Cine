using Cine.Dominio._4._1_Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData
{
    public class CronogramaMetaData : IEntityTypeConfiguration<Cronograma>
    {
        public void Configure(EntityTypeBuilder<Cronograma> builder)
        {
            builder.Property(x => x.HorarioId).IsRequired();

            builder.Property(x => x.EsTrasnoche).IsRequired();

            builder.Property(x => x.DiaId).IsRequired();
        }
    }
}
