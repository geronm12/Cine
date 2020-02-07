using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Cine
{
    public class Cine: EntityBase
    {
        public string Nombre { get; set; }

        public string Dirección { get; set; }

        public string Teléfono { get; set; }

        //Propiedades de Navegacion

        public virtual ICollection<Sala.Sala> Salas { get; set; }
    }
}
