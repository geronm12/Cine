using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cine.Interfaces.Cine;
using CineApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static CineApi.Mapper.MapperInstance;
namespace CineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_myPolicy")]
    public class CineController : Controller
    {
        private readonly ICineRepository _cineRepos;

        private readonly IMapper _mapper; 
        public CineController(ICineRepository cineRepos)
        {
            _cineRepos = cineRepos;

            _mapper = CrearMapa();
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("crear")]
        public async Task<IActionResult> Crear(CinePostViewModel model)
        {

            var cineDto = _mapper.Map<CineDto>(model);

            await _cineRepos.Create(cineDto);

            return Ok(model);

        }
        
        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerTodos()
        {

            try
            {
                var _listaCines = await _cineRepos.GetAll();

                if(_listaCines.Count() > 0)
                {
                    return Ok(_listaCines);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                throw new Exception(@"Excepción no controlada");
            }
             
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtenerfiltrado")]
        public async Task<IActionResult> ObtenerPorFiltro(long cindeId)
        {
            try
            {
                var cine = await _cineRepos.GetById(cindeId);

                if (cine != null)
                {
                    return Ok(cine);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                throw new Exception(@"No se encontró ningún cine");
            }
        }

    }
}