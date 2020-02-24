using AutoMapper;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineApi.Mapper
{
    public static class MapperInstance
    {
        public static IMapper CrearMapa()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Perfil>());

            var mapper = config.CreateMapper();

            return mapper;

        }
    }
}
