using AutoMapper;
using Cine.Dominio._4._1_Entidades.Usuario;
using Cine.Dominio._4._4_Method;
using Cine.Infraestructura;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Usuario;
using HelpersServicios;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        private readonly IEncryptar _encryptar;
        public UsuarioRepositorio(IRepository<Dominio._4._1_Entidades.Usuario.Usuario> usuarioRepos, IEncryptar encriptar)
        {
            _usuarioRepos = usuarioRepos;

            _mapper = CrearMapa();

            _encryptar = encriptar;

        }

        public async Task Create(UsuarioDto dto)
        {

            var passwordEncriptado = _encryptar.Hash(dto.Password);

            dto.Password = passwordEncriptado;
            
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
            //Expression<Func<Dominio._4._1_Entidades.Usuario.Usuario, bool>> pred = x => true;
            //pred = pred.And(x => x.Nombre == nombre && _encryptar.Desencriptar(x.Password, _encryptar.GetKey()) == password);

        

            bool esValido = await Task.Run(() =>
            {
            var usuario = _usuarioRepos.GetByFilter(predicate: x => x.Nombre.Equals(nombre), null, null, false).Result;

            var _usuarioSelec = usuario.FirstOrDefault(x => x.Nombre == nombre);

            if (usuario.Count() > 0)
            {
                (bool check, bool needsUpgrade) = _encryptar.Check(_usuarioSelec.Password, password);


                if(check && !needsUpgrade)
                {

                   return true;
                    
                }
                
            }
 
                return false;
            });

            return esValido;
            
        }

        public async Task Update(UsuarioDto dto)
        {
            
            var usuario = await _usuarioRepos.GetById(dto.Id, null, false);

            if(usuario != null)
            {
                var password = _encryptar.Encriptar(dto.Password, _encryptar.GetKey());

                dto.Password = password;

                usuario = _mapper.Map<Dominio._4._1_Entidades.Usuario.Usuario>(dto);

                await _usuarioRepos.Update(usuario);
            }
        }
    }
}
