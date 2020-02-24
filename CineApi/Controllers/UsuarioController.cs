using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cine.Infraestructura;
using Cine.Interfaces.Usuario;
using Cine.Mailer;
using CineApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static CineApi.Mapper.MapperInstance;
namespace CineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioService;

        private readonly IMapper _mapper;

        private readonly IEmailSender _sender;

        public UsuarioController(IUsuarioRepository usuarioService, IEmailSender sender)
        {
            _usuarioService = usuarioService;

            _mapper = CrearMapa();

            _sender = sender;
        }


        [HttpPost()]
        [EnableCors("_myPolicy")]
        [Route("login")]
        public async Task<IActionResult>Login(ULoginViewModel model)
        {
             var permitirAcceso = await _usuarioService.Login(model.NombreUsuario, model.Password);

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
        public async Task<IActionResult> Crear(UPostViewModel model)
        {
            var usuarioDto = _mapper.Map<UsuarioDto>(model);

            await _usuarioService.Create(usuarioDto);

            return Ok(model);

        }



        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("modificar")]
        public async Task<IActionResult> Update(UsuarioDto dto)
        {
            await _usuarioService.Update(dto);

            return Ok(dto);

        }


        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("mail")]
        public async Task<IActionResult> Mailer(SendEmailDetails details)
        {
            var response = await _sender.SendEmailAsync(details);
                
            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}