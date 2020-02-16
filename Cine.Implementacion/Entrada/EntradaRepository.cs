using AutoMapper;
using Cine.Interfaces.Entrada;
using Cine.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Entrada
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Entrada.Entrada> _entradaRepos;

        private readonly IMapper _mapper;
        public EntradaRepository(IRepository<Dominio._4._1_Entidades.Entrada.Entrada> entradaRepos)
        {
            _entradaRepos = entradaRepos;

            _mapper = CrearMapa();

        }
        public async Task Create(EntradaDto dto)
        {
            await _entradaRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Entrada.Entrada>(dto));
  
        }

        public async Task Delete(long entradaId)
        {
            var entrada = await _entradaRepos.GetById(entradaId);

            if(entrada != null)
            {
                await _entradaRepos.Delete(entrada);
            }
            
        }

        public async Task Update(EntradaDto dto)
        {
            var entrada = await _entradaRepos.GetById(dto.Id);

            if (entrada != null)
            {
                entrada = _mapper.Map<Dominio._4._1_Entidades.Entrada.Entrada>(dto);

                await _entradaRepos.Update(entrada);
            }

        
        }
    }
}
