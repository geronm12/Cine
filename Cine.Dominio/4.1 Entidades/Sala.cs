using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Sala
{
    public class Sala : EntityBase
    {
        public int NumeroSalon { get; set; }

        public int CapacidadMáx { get; set; }

        public long CineId { get; set; }


        //Propiedades de Navegacion

        public virtual Cine.Cine Cine { get; set; }

        public virtual ICollection<Funcion> Funciones { get; set; }

      }
}
