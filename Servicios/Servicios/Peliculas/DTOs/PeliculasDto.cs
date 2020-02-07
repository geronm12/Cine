using Servicios.Enumeradores;
 
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Servicios.Peliculas.DTOs
{
    public class PeliculasDto
    {
        public string Nombre { get; set; }

        public string País { get; set; }

        public int Duración { get; set; }

        public TipoPelicula TipoDePelicula { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string URL { get; set; }

        public long DirectorId { get; set; }
         
    }
}
