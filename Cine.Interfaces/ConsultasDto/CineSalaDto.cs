using Cine.Interfaces.Cine;
using Cine.Interfaces.Sala;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.ConsultasDto
{
    public class CineSalaDto: ConsultasDto
    {
        public CineSalaDto()
        {
            if(Salas == null)
            {
                Salas = new List<SalaDto>();
            }
        }

        public CineDto Cine { get; set; }

        public List<SalaDto> Salas { get; set; }

    }
}
