using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Entrada
{
    public interface IEntradaRepository
    {
        Task Create(EntradaDto dto);

        Task Update(EntradaDto dto);

        Task Delete(EntradaDto dto);


    }
}
