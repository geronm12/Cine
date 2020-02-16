using AutoMapper;
using Cine.Interfaces.Pelicula;
using Cine.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Pelicula
{
    public class PeliculaRepository: IPeliculaRepository
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Dominio._4._1_Entidades.Pelicula.Pelicula> _peliculaRepos;
        public PeliculaRepository(IRepository<Dominio._4._1_Entidades.Pelicula.Pelicula> peliculaRepos)
        {
            _peliculaRepos = peliculaRepos;

            _mapper = CrearMapa();

        }

        public async Task Create(PeliculaDto dto)
        {
           await _peliculaRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Pelicula.Pelicula>(dto));
        }

        public async Task Delete(long peliculaId)
        {
            var pelicula = await _peliculaRepos.GetById(peliculaId, null, false);

            if(pelicula != null)
            {
                await _peliculaRepos.Delete(pelicula);
            }
        }

        public async Task<IEnumerable<PeliculaDto>> Obtener(string cadenaBuscar)
        {
            var pelicula = await _peliculaRepos.GetByFilter(predicate: x => x.Nombre.Contains(cadenaBuscar) || x.País.Contains(cadenaBuscar)
            || x.TipoDePelicula.ToString().Contains(cadenaBuscar),
            orderBy: x => x.OrderBy(t => t.TipoDePelicula), 
            include: x => x.Include(x => x.Funciones), true);

            if(pelicula != null)
            {
                var listaPeliculasDto = _mapper.Map<IEnumerable<Dominio._4._1_Entidades.Pelicula.Pelicula>, IEnumerable<PeliculaDto>>(pelicula);

                return listaPeliculasDto;

            }
            else
            {
                return null;
            }
        }

        public async Task<PeliculaDto> ObtenerPorId(long peliculaId)
        {
            var pelicula = await _peliculaRepos.GetById(peliculaId);

            if (pelicula != null)
            {
                return _mapper.Map<PeliculaDto>(pelicula);
            }
            else
            {
                return null;
            }
           
        
        }

        public async Task<IEnumerable<PeliculaDto>> ObtenerTodas()
        {
            var _listaPeliculas = await _peliculaRepos.GetAll();

            if(_listaPeliculas != null)
            {
                return _mapper.Map<IEnumerable <Dominio._4._1_Entidades.Pelicula.Pelicula>, IEnumerable<PeliculaDto>>(_listaPeliculas);
            }
            else
            {
                return null;
            }

        }

        public async Task Update(PeliculaDto dto)
        {

            var pelicula = await _peliculaRepos.GetById(dto.Id, null, false);

            if(pelicula != null)
            {
                pelicula = _mapper.Map<Dominio._4._1_Entidades.Pelicula.Pelicula>(dto);
                await _peliculaRepos.Update(pelicula);
            }
            
           
        
        }
    }
}
