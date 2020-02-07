using Cine.Dominio._4._6_Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Pelicula
{
    public class Pelicula : EntityBase
    {
        public string Nombre { get; set; }

        public string País { get; set; }

        public int Duración { get; set; }

        public TipoPelicula TipoDePelicula { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string URL { get; set; }

        public string TrailerURL { get; set; }

        

    }
}
