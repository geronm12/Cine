using AutoMapper;
using Cine.Interfaces.Cine;
using Cine.Interfaces.ConsultasDto;
using Cine.Interfaces.ConsultasDto.Interfaces;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Sala;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.ConsultasServicio
{
    public class CineSalaConsultaServicio : ICineSalaServicio
    {
        private readonly IRepository<Dominio._4._1_Entidades.Cine.Cine> _cineRepos;
      
        private readonly IMapper _mapper;
        public CineSalaConsultaServicio(IRepository<Dominio._4._1_Entidades.Cine.Cine> cineRepos)
        {

            _cineRepos = cineRepos;

            _mapper = CrearMapa();
        }
        public async Task<IEnumerable<CineSalaDto>> GetCines()
        {
            var listaCines = await _cineRepos.GetAll();

            var listaCineSalaDto = new List<CineSalaDto>();

            foreach (var item in listaCines)
            {
                var cineSala = new CineSalaDto
                {
                    Cine = _mapper.Map<CineDto>(item),
                    Salas = _mapper.Map<ICollection<Dominio._4._1_Entidades.Sala.Sala>, List<SalaDto>>(item.Salas)
                };

                listaCineSalaDto.Add(cineSala);

            }

            return listaCineSalaDto;
            
        }

        public async Task<CineSalaDto> GetSalasByCineId(long cineId)
        {
            var cine = await _cineRepos.GetById(cineId, x => x.Include(x => x.Salas), true);

            var cineSalaDto = new CineSalaDto
            {
                Cine = _mapper.Map<CineDto>(cine),

                Salas = _mapper.Map<ICollection<Dominio._4._1_Entidades.Sala.Sala>, List<SalaDto>>(cine.Salas)
            };

            return cineSalaDto;
            
        }
    }
}
