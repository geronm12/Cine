using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Entrada
{
    public class Entrada : EntityBase
    {
        public string Descripcion { get; set; }

        public long Numero { get; set; }

        public long CantidadDisponible { get; set; }

        public decimal Precio { get; set; }


    }
}
