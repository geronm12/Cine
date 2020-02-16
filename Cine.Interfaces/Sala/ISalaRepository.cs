using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Sala
{
    public interface ISalaRepository
    {

        Task Create(SalaDto dto);

        Task Update(SalaDto dto);

        Task Delete(long salaId);

    }
}
