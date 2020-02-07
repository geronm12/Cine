using Cine.Models.Enumeradores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._2_MetaData.Usuario
{
    public class UsuarioMetaData : IEntityTypeConfiguration<_1_Entidades.Usuario.Usuario>
    {
        public void Configure(EntityTypeBuilder<_1_Entidades.Usuario.Usuario> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(20).IsRequired();

            builder.Property(x => x.Password).HasMaxLength(20).IsRequired();

            builder.Property(x => x.TipoUsuario).HasConversion(x => x.ToString(), e => (TipoUsuario)Enum.Parse(typeof(TipoUsuario), e)).IsRequired();
                 

        }
    }
}
