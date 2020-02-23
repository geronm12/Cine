using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Interfaces.Usuario;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioService;


        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService;

        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("login")]
        public async Task<IActionResult>Login(string nombreUsuario, string password)
        {
             var permitirAcceso = await _usuarioService.Login(nombreUsuario, password);

            if (permitirAcceso)
            {

                return Ok(permitirAcceso);

            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("crear")]
        public async Task<IActionResult> Crear(UsuarioDto dto)
        {
            await _usuarioService.Create(dto);

            return Ok(dto);

        }
    }
}