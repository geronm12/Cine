using Cine.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Usuario
{
    public class Usuario : EntityBase
    { 
        public string Nombre { get; set; }

        public string Password { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

    }
}
