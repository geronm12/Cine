using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Dia
{
    public interface IDiaRepository
    {
        Task Create(DiaDto dto);

        Task Update(DiaDto dto);

        Task Delete(long diaId);



    }
}
