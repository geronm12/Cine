using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDatos.MemoryDataBase
{
    public class Peliculas
    {
        public string Nombre { get; set; }

        public string País { get; set; }

        public int Duración { get; set; }

        public PeliculaTipo TipoDePelicula { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string URL { get; set; }
        
        public string TrailerURL { get; set; }

        public long DirectorId { get; set; }
 
        public Entradas Entradas { get; set; }
    }
}
