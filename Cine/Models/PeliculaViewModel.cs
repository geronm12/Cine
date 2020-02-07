using Cine.Dominio._4._6_Enumeradores;
using Cine.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Models
{
    public class PeliculaViewModel
    {

        public string Nombre { get; set; }

        public string País { get; set; }

        public int Duración { get; set; }

        public TipoPelicula TipoDePelicula { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string URL { get; set; }

       
 
 

    }
}
