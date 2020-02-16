using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Cronograma
{
    public class CronogramaDto:EntidadBaseDto.EntidadBaseDto
    {
        public long DiaId { get; set; }

        public long HorarioId { get; set; }

        public bool EsTrasnoche { get; set; }


    }
}
