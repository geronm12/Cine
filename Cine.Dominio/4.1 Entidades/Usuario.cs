﻿using Cine.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Usuario
{
    public class Usuario : EntityBase
    { 
        public string Nombre { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public DateTime UltimaConexión { get; set; }

        public bool UsuarioBloqueado { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

    }
}
