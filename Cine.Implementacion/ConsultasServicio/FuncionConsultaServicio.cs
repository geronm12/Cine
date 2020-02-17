using AutoMapper;
using Cine.Infraestructura.Repositorio;
using Cine.Interfaces.ConsultasDto;
using Cine.Interfaces.ConsultasDto.Interfaces;
using Cine.Interfaces.Entrada;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Pelicula;
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
    public class FuncionConsultaServicio : IFuncionConsultaServicio
    {
        
        private readonly IRepository<Dominio._4._1_Entidades.Funcion> _funcionRepos;
        private readonly IRepository<Dominio._4._1_Entidades.Entrada.Entrada> _entradaRepos;
        private readonly IMapper _mapper;
        public FuncionConsultaServicio(IRepository<Dominio._4._1_Entidades.Funcion> funcionRepos, IRepository<Dominio._4._1_Entidades.Entrada.Entrada> entradaRepos)
        {
            _entradaRepos = entradaRepos;

            _funcionRepos = funcionRepos;

            _mapper = CrearMapa();
        }
        public async Task <IEnumerable<FuncionConsultaDto>> ObtenerPorPelicula(long peliculaId)
        {
            var funciones = await _funcionRepos.GetByFilter(predicate: x => x.PeliculaId == peliculaId,
                null, include: x => x.Include(x => x.Pelicula).Include(x => x.Sala).Include(x => x.Entrada), true);

            var listaFunciones = new List<FuncionConsultaDto>();

            foreach (var item in funciones)
            {
                var funcion = new FuncionConsultaDto
                {
                    Entrada = _mapper.Map<EntradaDto>(item.Entrada),
                    Funcion = _mapper.Map<FuncionDto>(item),
                    Pelicula = _mapper.Map<PeliculaDto>(item.Pelicula),
                    Sala = _mapper.Map<SalaDto>(item.Sala)
                };


                listaFunciones.Add(funcion);

            }

            return listaFunciones;
        
        
        
        }

        public async Task<IEnumerable<FuncionConsultaDto>> ObtenerPorSala(long salaId)
        {
            var funciones = await _funcionRepos.GetByFilter(predicate: x => x.SalaId == salaId,null
                ,include: x => x.Include(x => x.Sala).Include(x => x.Pelicula)
            .Include(x => x.Entrada), true);


            var listaFuncionesDto = new List<FuncionConsultaDto>();

            foreach (var item in funciones)
            {

                var funcionConsulta = new FuncionConsultaDto
                {
                    Entrada = _mapper.Map<EntradaDto>(item.Entrada),
                    Funcion = _mapper.Map<FuncionDto>(item),
                    Pelicula = _mapper.Map<PeliculaDto>(item.Pelicula),
                    Sala = _mapper.Map<SalaDto>(item.Sala)
                };

                listaFuncionesDto.Add(funcionConsulta);
            }


            return listaFuncionesDto;

        }

        public async Task<IEnumerable<FuncionConsultaDto>> ObtenerTodas()
        {
            var funciones = await _funcionRepos.GetAll(null, include: x => x.Include(x => x.Pelicula).Include(x => x.Sala)
            .Include(x => x.Entrada), true);

            var listaFunciones = new List<FuncionConsultaDto>();

            foreach (var item in funciones)
            {
                var funcion = new FuncionConsultaDto
                {
                    Entrada = _mapper.Map<EntradaDto>(item.Entrada),
                    Pelicula = _mapper.Map<PeliculaDto>(item.Pelicula),
                    Sala = _mapper.Map<SalaDto>(item.Sala),
                    Funcion = _mapper.Map<FuncionDto>(item)
                };

                listaFunciones.Add(funcion);
            }

            return listaFunciones;
        }

        public async Task RestarEntradas(int cantidadEntradas, long funcionId)
        {
            var entrada = await _entradaRepos.GetByFilter(predicate: x => x.Funcion.Id == funcionId,null,include: x => x.Include(x => x.Funcion), true);

            var entradaDto = new EntradaDto();
 
            var entradaEncontrada = entrada.First(x => x.Funcion.Id == funcionId);
            entradaEncontrada.Cantidad -= cantidadEntradas;
            await _entradaRepos.Update(entradaEncontrada);
            
        }
    }
}
