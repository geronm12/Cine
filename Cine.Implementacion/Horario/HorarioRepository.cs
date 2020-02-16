using AutoMapper;
using Cine.Dominio._4._1_Entidades.Horarios;
using Cine.Interfaces.Horario;
using Cine.Interfaces.Repositorio;
using System;   
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;


namespace Cine.Implementacion.Horario
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly IRepository<Horarios> _horarioRepos;

        private readonly IMapper _mapper;

        public HorarioRepository(IRepository<Horarios> horarioRepos)
        {
            _horarioRepos = horarioRepos;

            _mapper = CrearMapa(); 

        }



        public async Task Create(HorarioDto dto)
        {
            await _horarioRepos.Create(_mapper.Map<Horarios>(dto));
        }

        public async Task Delete(long horarioId)
        {
            var horario = await _horarioRepos.GetById(horarioId, null, false);

            if(horario != null)
            {
                await _horarioRepos.Delete(horario);
            }

        }

        public async Task Update(HorarioDto dto)
        {
            var horario = await _horarioRepos.GetById(dto.Id, null, false);

            if(horario != null)
            {
                horario = _mapper.Map<Horarios>(dto);

                await _horarioRepos.Update(horario);
            }



        }
    }
}
