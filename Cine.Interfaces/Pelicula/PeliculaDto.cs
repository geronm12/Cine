using Cine.Dominio._4._6_Enumeradores;
using Cine.Interfaces.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Pelicula
{
    public class PeliculaDto
    {
        public string Nombre { get; set; }

        public string País { get; set; }

        public int Duración { get; set; }

        public TipoPelicula TipoDePelicula { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string URL { get; set; }

        public string TrailerURL { get; set; }

        public string Descripción { get; set; }

        public ICollection<FuncionDto> Funciones { get; set; }
    }
}
