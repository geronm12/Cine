using AutoMapper;
using Cine.Interfaces.Cronograma;
using Cine.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Cronograma
{
    public class CronogramaRepository : ICronogramaRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Cronograma> _cronogramaRepos;

        private readonly IMapper _mapper;
        public CronogramaRepository(IRepository<Dominio._4._1_Entidades.Cronograma> cronogramaRepos)
        {
            _cronogramaRepos = cronogramaRepos;

            _mapper = CrearMapa();

        }
        public async Task Create(CronogramaDto dto)
        {
            await _cronogramaRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Cronograma>(dto));

        }

        public async Task Delete(long cronogramaId)
        {
            var cronograma = await _cronogramaRepos.GetById(cronogramaId);

            if (cronograma != null)
            {
                await _cronogramaRepos.Delete(cronograma);
            }
        }

        public async Task Update(CronogramaDto dto)
        {
            var cronograma = await _cronogramaRepos.GetById(dto.Id);

            if (cronograma != null)
            {
                cronograma = _mapper.Map<Dominio._4._1_Entidades.Cronograma>(dto);

                await _cronogramaRepos.Update(cronograma);
            }

        }
    }
}
