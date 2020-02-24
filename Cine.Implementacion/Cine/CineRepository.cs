using AutoMapper;
using Cine.Implementacion.Excepciones;
using Cine.Interfaces.Cine;
using Cine.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CineDto>> GetAll()
        {
            var _listaCines = await _cineRepos.GetAll();
            
            if(_listaCines != null)
            {
                return _mapper.Map<IEnumerable<Dominio._4._1_Entidades.Cine.Cine>, IEnumerable<CineDto>>(_listaCines);
            }
            else
            {
                return null;
            }
        
        }

        public async Task<IEnumerable<CineDto>> GetByFilter(string filtro)
        {
            try
            {
                var cinePorFiltr = await _cineRepos.GetByFilter(predicate: x => x.Nombre.Contains(filtro),
                orderBy: x => x.OrderBy(l => l.Nombre), include: x => x.Include
                (x => x.Salas), true);

                if(cinePorFiltr.Count() > 0)
                {
                    return _mapper.Map<IEnumerable<CineDto>>(cinePorFiltr);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                filtro = string.Empty;
            }
 
        }

        public async Task<CineDto> GetById(long cineId)
        {
            try
            {
                var cineObtenido = await _cineRepos.GetById(cineId, x => x.Include(x => x.Salas), true);

                if (cineObtenido != null)
                {
                    return _mapper.Map<CineDto>(cineObtenido);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw new Exception(mensaje);
            }
            finally
            {
                cineId = 0;
            }
           
        }

        public async Task Update(CineDto dto)
        {
            try
            {
                var cine = await _cineRepos.GetById(dto.Id);

                if (cine != null)
                {
                    cine = _mapper.Map<Dominio._4._1_Entidades.Cine.Cine>(dto);

                    await _cineRepos.Update(cine);
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dto = null;
            }
            
        }
    }
}
