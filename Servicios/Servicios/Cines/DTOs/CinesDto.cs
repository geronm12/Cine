using Servicios.Servicios.Peliculas.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Servicios.Cines.DTOs
{
    public class CinesDto
    {
        public string Dirección { get; set; }

        public string País { get; set; }

        public long DueñoId { get; set; }

        public string NombreCine { get; set; }

        public ICollection<PeliculasDto> Cartelera { get; set; }

    }
}
