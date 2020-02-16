using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Funcion
{
    public interface IFuncionRepository
    {
        Task Create(FuncionDto dto);

        Task Update(FuncionDto dto);

        Task Delete(long funcionId);

        Task<FuncionDto> GetById(long funcionId);

        Task<IEnumerable<FuncionDto>>GetAllBySalaId(long salaId);

       
    }
}
