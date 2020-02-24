using Cine.Interfaces.Horario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Cine
{
    public interface ICineRepository
    {
        Task Create(CineDto dto);

        Task Update(CineDto dto);

        Task Delete(long cineId);

        Task<CineDto> GetById(long cineId);

        Task<IEnumerable<CineDto>> GetAll();

        Task<IEnumerable<CineDto>> GetByFilter(string filtro);

    }
}
