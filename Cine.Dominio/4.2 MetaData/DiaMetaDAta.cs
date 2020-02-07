using Cine.Dominio._4._1_Entidades;
using Cine.Dominio._4._6_Enumeradores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData
{
    public class DiaMetaData : IEntityTypeConfiguration<_1_Entidades.Dia>
    {
        public void Configure(EntityTypeBuilder<Dia> builder)
        {
            builder.Property(x => x.TipoDia).HasConversion(x => x.ToString(), e => (TipoDia)Enum.Parse(typeof(TipoDia), e)).IsRequired();

            

        }
    }
}
