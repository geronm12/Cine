using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Usuario
{
    public interface IUsuarioRepository
    {
        Task Create(UsuarioDto dto);

        Task Update(UsuarioDto dto);

        Task Delete(long usuarioId);

        Task<bool> Login(string nombre, string password);

    }
}
