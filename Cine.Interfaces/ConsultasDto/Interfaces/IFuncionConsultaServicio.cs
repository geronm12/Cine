using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.ConsultasDto.Interfaces
{
    public interface IFuncionConsultaServicio
    {

        Task<IEnumerable<FuncionConsultaDto>> ObtenerPorSala(long salaId);

        Task <IEnumerable<FuncionConsultaDto>> ObtenerTodas();
         
        Task <IEnumerable<FuncionConsultaDto>> ObtenerPorPelicula(long peliculaId);

        Task RestarEntradas(int cantidadEntradas, long funcionId);

    }
}
