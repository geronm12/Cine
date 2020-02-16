using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Pelicula
{
    public interface IPeliculaRepository
    {
        Task Create(PeliculaDto dto);

        Task Update(PeliculaDto dto);

        Task Delete(long peliculaId);

        Task<IEnumerable<PeliculaDto>> ObtenerTodas();

        Task<IEnumerable<PeliculaDto>> Obtener(string cadenaBuscar);

        Task<PeliculaDto> ObtenerPorId(long peliculaId);


    }
}
