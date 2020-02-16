using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public static class AutoMapper
    {
        public static IMapper CrearMapa()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Perfiles>());

            var mapper = config.CreateMapper();
           
            return mapper;

        }

    }
}
