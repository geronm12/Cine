using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades
{
    public class Funcion : EntityBase
    {
        public long PeliculaId { get; set; }

        public long SalaId { get; set; }

        public long EntradaId { get; set; }

        public long EntradasDisponibles { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaDeEstreno { get; set; }

        public DateTime FechaDeBaja { get; set; }


        //Propiedades de Navegación

        public virtual Pelicula.Pelicula Pelicula { get; set; }

        public virtual Sala.Sala Sala { get; set; }

        public virtual Entrada.Entrada Entrada{get; set;}

    }
}
