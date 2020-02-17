using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.ConsultasDto.Interfaces
{
    public interface ICineSalaServicio
    {
        Task<CineSalaDto>GetSalasByCineId(long cineId);

        Task<IEnumerable<CineSalaDto>> GetCines();

    }
}
