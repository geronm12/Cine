using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Sala
{
    public class SalaDto: EntidadBaseDto.EntidadBaseDto
    {
        public int NumeroSalon { get; set; }

        public int CapacidadMáx { get; set; }

        public long CineId { get; set; }

    }
}
