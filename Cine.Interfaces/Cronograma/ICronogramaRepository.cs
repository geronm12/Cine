using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Cronograma
{
    public interface ICronogramaRepository
    {

        Task Create(CronogramaDto dto);

        Task Update(CronogramaDto dto);

        Task Delete(long cronogramaId);


    }
}
