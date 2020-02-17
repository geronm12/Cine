using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Entrada
{
    public class Entrada : EntityBase
    {
        public string Descripcion { get; set; }

        public long Numero { get; set; }

        public int Cantidad { get; set; }


        //Propiedades de Navegacion

        public virtual Funcion Funcion { get; set; }


    }
}
