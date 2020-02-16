using AutoMapper;
using Cine.Dominio._4._1_Entidades;
using Cine.Interfaces.Dia;
using Cine.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Dia
{
    public class DiaRepository : IDiaRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Dia> _diaRepos;

        private readonly IMapper _mapper;

        public DiaRepository(IRepository<Dominio._4._1_Entidades.Dia> diaRepos)
        {
            _diaRepos = diaRepos;

            _mapper = CrearMapa();

        }
        public async Task Create(DiaDto dto)
        {
            await _diaRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Dia>(dto));
        }

        public async Task Delete(long diaId)
        {
            var dia = await _diaRepos.GetById(diaId);

            if(dia != null)
            {
                await _diaRepos.Delete(dia);
            }
        }

        public async Task Update(DiaDto dto)
        {
            var dia = await _diaRepos.GetById(dto.Id);

            if(dia != null)
            {
                dia = _mapper.Map<Dominio._4._1_Entidades.Dia>(dto);

                await _diaRepos.Update(dia);
            }
        }
    }
}
