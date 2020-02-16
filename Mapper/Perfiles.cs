using AutoMapper;
using Cine.Dominio._4._1_Entidades.Usuario;
using Cine.Dominio._4._1_Entidades.Cine;
using Cine.Interfaces.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Cine.Interfaces.Cine;
using Cine.Dominio._4._1_Entidades;
using Cine.Interfaces.Cronograma;
using Cine.Interfaces.Dia;
using Cine.Dominio._4._1_Entidades.Entrada;
using Cine.Interfaces.Entrada;
using Cine.Dominio._4._1_Entidades.Horarios;
using Cine.Dominio._4._1_Entidades.Pelicula;
using Cine.Dominio._4._1_Entidades.Sala;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Horario;
using Cine.Interfaces.Pelicula;
using Cine.Interfaces.Sala;

namespace Mapper
{
    public class Perfiles : Profile
    {
        public Perfiles()
        {

            //Perfil Dto a Entidad y Viceversa

            CreateMap<Usuario, UsuarioDto>().ReverseMap().ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<Cine.Dominio._4._1_Entidades.Cine.Cine, CineDto>().ReverseMap();

            CreateMap<Cronograma, CronogramaDto>().ReverseMap();

            CreateMap<Dia, DiaDto>().ReverseMap();

            CreateMap<Entrada, EntradaDto>().ReverseMap();

            CreateMap<Funcion, FuncionDto>().ReverseMap();

            CreateMap<Horarios, HorarioDto>().ReverseMap();

            CreateMap<Pelicula, PeliculaDto>().ReverseMap();

            CreateMap<Sala, SalaDto>().ReverseMap();

            //Perfil Dto a ViewModel
                 
        }


    }
}
