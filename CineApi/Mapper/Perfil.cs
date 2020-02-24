using AutoMapper;
using Cine.Interfaces.Cine;
using Cine.Interfaces.Usuario;
using CineApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineApi.Mapper
{
    public class Perfil: Profile
    {
        public Perfil()
        {
            CreateMap<UPostViewModel,UsuarioDto >().ForMember(src => src.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CinePostViewModel, CineDto>().ForMember(src => src.Id, opt => opt.Ignore()).ReverseMap();

        }
    }
}
