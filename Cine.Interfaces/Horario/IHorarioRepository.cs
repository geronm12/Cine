using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Horario
{
    public interface IHorarioRepository
    {
        Task Create(HorarioDto dto);

        Task Update(HorarioDto dto);

        Task Delete(long horarioId);

    }
}
