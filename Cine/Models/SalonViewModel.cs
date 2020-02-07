using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Models
{
    public class SalonViewModel
    {
        public int NumeroSalon { get; set; }

        public int CapacidadMáx { get; set; }

        public ICollection<PeliculaViewModel> Peliculas { get; set; }

    }
}
