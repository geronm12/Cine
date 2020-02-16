using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Horario
{
    public class HorarioDto: EntidadBaseDto.EntidadBaseDto
    {
        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }



    }
}
