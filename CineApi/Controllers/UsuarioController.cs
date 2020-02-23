using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Infraestructura;
using Cine.Interfaces.Usuario;
using CineApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioService;

        private  readonly IEncryptar _encriptar;

        private readonly string key;
        public UsuarioController(IUsuarioRepository usuarioService, IEncryptar encryptar)
        {
            _usuarioService = usuarioService;

            _encriptar = encryptar;

            key = _encriptar.GetKey();
            

        }


        [HttpPost()]
        [EnableCors("_myPolicy")]
        [Route("login")]
        public async Task<IActionResult>Login(ULoginViewModel model)
        {
             var permitirAcceso = await _usuarioService.Login(model.nombreUsuario, model.password);

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