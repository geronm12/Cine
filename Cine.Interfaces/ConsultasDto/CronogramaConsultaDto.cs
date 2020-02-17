using Cine.Interfaces.Dia;
using Cine.Interfaces.Horario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.ConsultasDto
{
    public class CronogramaConsultaDto : ConsultasDto
    {
        public HorarioDto Horario { get; set; }

        public DiaDto Dia { get; set; }

        public FuncionConsultaDto Funcion { get; set; }
    
    }
}
