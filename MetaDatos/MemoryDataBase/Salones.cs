using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDatos.MemoryDataBase
{
    public class Salones
    {
        public int NumeroSalon { get; set; }

        public int CapacidadMáx { get; set; }

        public ICollection<Peliculas> Peliculas { get; set; }
    }
}
