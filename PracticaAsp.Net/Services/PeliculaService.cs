using PracticaAsp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaAsp.Net.Services
{
    public class PeliculaService
    {
        public PeliculasViewModel Obtener(int Id)
        {
            return new PeliculasViewModel
            {
                Titulo = "Escape Plan",
                Duracion = 115,
                Pais = "USA",
                Publicacion = new DateTime(2013, 12, 5)
            };
        }

        public List<PeliculasViewModel>ObtenerTodas()
        {
            return new List<PeliculasViewModel>
            {
                new PeliculasViewModel{Titulo = "Dragon ball Super Broly", Publicacion = new DateTime(2018,12,08), Duracion = 120, Pais = "Japon"  },
                new PeliculasViewModel{Titulo = "Naruto: The Last", Publicacion = new DateTime(2014,07,14), Duracion = 120, Pais = "Japon"}
            };
        }



    }
}
