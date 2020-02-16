using AutoMapper;
using Cine.Dominio._4._1_Entidades.Usuario;
using Cine.Infraestructura;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Usuario;
using HelpersServicios;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly IRepository<Dominio._4._1_Entidades.Usuario.Usuario> _usuarioRepos;
 
        private  readonly IMapper _mapper;
      
        public UsuarioRepositorio(IRepository<Dominio._4._1_Entidades.Usuario.Usuario> usuarioRepos)
        {
            _usuarioRepos = usuarioRepos;

            _mapper = CrearMapa(); 

        }

        public async Task Create(UsuarioDto dto)
        {

          await _usuarioRepos.Create(_mapper.Map<Dominio._4._1_Entidades.Usuario.Usuario>(dto));
            
        }

        public async Task Delete(long usuarioId)
        {
            var usuario = await _usuarioRepos.GetById(usuarioId, null, false);

            if(usuario != null)
            {
                await _usuarioRepos.Delete(usuario);
            }
            
            
        }

        public async Task<bool> Login(string nombre, string password)
        {
            bool esValido = await Task.Run(() =>
            {
                return _usuarioRepos.GetByFilter(predicate: x => x.Nombre == nombre && x.Password == password, null, null, false) != null ? true : false;
            });

            return esValido;
            
        }

        public async Task Update(UsuarioDto dto)
        {
            
            var usuario = await _usuarioRepos.GetById(dto.Id, null, false);

            if(usuario != null)
            {
                usuario = _mapper.Map<Dominio._4._1_Entidades.Usuario.Usuario>(dto);

                await _usuarioRepos.Update(usuario);
            }
        }
    }
}
