using AutoMapper;
using Cine.Interfaces.Cine;
using Cine.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Cine
{
    public class CineRepository : ICineRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Cine.Cine> _cineRepos;


        private readonly IMapper _mapper;


        public CineRepository(IRepository<Dominio._4._1_Entidades.Cine.Cine> cineRepos)
        {
            _cineRepos = cineRepos;

            _mapper = CrearMapa();

        }
        public async Task Create(CineDto dto)
        {
            await _cineRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Cine.Cine>(dto));
        }

        public async Task Delete(long cineId)
        {
            var cine = await _cineRepos.GetById(cineId);
           
            if(cine != null)
            {
                await _cineRepos.Delete(cine);
            }

        }

        public async Task Update(CineDto dto)
        {
            var cine = await _cineRepos.GetById(dto.Id);

            if(cine != null)
            {
                cine = _mapper.Map<Dominio._4._1_Entidades.Cine.Cine>(dto);

                await _cineRepos.Update(cine);
            }
        }
    }
}
