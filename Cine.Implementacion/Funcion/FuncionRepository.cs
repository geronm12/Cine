using AutoMapper;
using Cine.Dominio._4._1_Entidades;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Sala;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;

namespace Cine.Implementacion.Funcion
{
    public class FuncionRepository : IFuncionRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Funcion> _funcionRepos;

        private readonly IMapper _mapper;

 
        

        public FuncionRepository(IRepository<Dominio._4._1_Entidades.Funcion> funcionRepos)
        {
            _funcionRepos = funcionRepos;

            _mapper = CrearMapa();
 

        }

        public async Task Create(FuncionDto dto)
        {
            await _funcionRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Funcion>(dto));
        }

        public async Task Delete(long funcionId)
        {
            var funcion = await _funcionRepos.GetById(funcionId);

            if (funcion != null)
            {
                await _funcionRepos.Delete(funcion);
            }
        }
 
        public async Task<IEnumerable<FuncionDto>> GetAllBySalaId(long salaId)
        {
            var listaFunciones = await _funcionRepos.GetByFilter(predicate: x => x.SalaId == salaId, null, include:
                x => x.Include(x => x.Sala).Include(x => x.Pelicula).Include(x => x.Entrada), true);

            if(listaFunciones != null)
            {
                return _mapper.Map<IEnumerable<Dominio._4._1_Entidades.Funcion>, IEnumerable<FuncionDto>>(listaFunciones);
            }
            else
            {
                return null;
            }
        }

        public async Task<FuncionDto> GetById(long funcionId)
        {
            var funcion = await _funcionRepos.GetById(funcionId, x => x.Include(x => x.Sala).Include(x => x.Entrada).Include(x => x.Pelicula), true);

            if(funcion != null)
            {
                return _mapper.Map<FuncionDto>(funcion);
            }
            else
            {
                return null;
            }

        }

        public async Task Update(FuncionDto dto)
        {
            var funcion = await _funcionRepos.GetById(dto.Id);

            if (funcion != null)
            {
                funcion = _mapper.Map<Dominio._4._1_Entidades.Funcion>(dto);

                await _funcionRepos.Update(funcion);
            }

        }
    }
}
