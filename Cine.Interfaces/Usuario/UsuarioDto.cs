using Cine.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Usuario
{
    public  class UsuarioDto: EntidadBaseDto.EntidadBaseDto
    {
        public string Nombre { get; set; }

        public string Password { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
    }
}
