using AutoMapper;
using Cine.Dominio._4._1_Entidades.Sala;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Sala;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;


namespace Cine.Implementacion.Sala
{
    public class SalaRepository:ISalaRepository
    {
        public readonly IMapper _mapper;

        public readonly IRepository<Dominio._4._1_Entidades.Sala.Sala> _salaRepos;

        public SalaRepository(IRepository<Dominio._4._1_Entidades.Sala.Sala> salaRepos)
        {
            _salaRepos = salaRepos;

            _mapper = CrearMapa();
        }

        public async Task Create(SalaDto dto)
        {
            await _salaRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Sala.Sala>(dto));
        }

        public async Task Delete(long salaId)
        {
            var sala = await _salaRepos.GetById(salaId, null, false);
            
            if(sala != null)
            {
               await _salaRepos.Delete(sala);
            }
        }

        public async Task Update(SalaDto dto)
        {
            var sala = await _salaRepos.GetById(dto.Id, null, false);
            
            if(sala != null)
            {
                sala = _mapper.Map<Dominio._4._1_Entidades.Sala.Sala>(dto);

                await _salaRepos.Update(sala);
            }


        }
    }
}
