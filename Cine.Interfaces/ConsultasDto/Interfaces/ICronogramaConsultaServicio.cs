using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.ConsultasDto.Interfaces
{
    public interface ICronogramaConsultaServicio
    {
        Task<IEnumerable<CronogramaConsultaDto>> Obtenertodos();

        Task<CronogramaConsultaDto> ObtenerPorFuncionId(long fucionId);

        Task<IEnumerable<CronogramaConsultaDto>> ObtenerPorFiltro(string cadenaBuscar);
    }
}
