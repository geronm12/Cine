using AutoMapper;
using Cine.Interfaces.ConsultasDto;
using Cine.Interfaces.ConsultasDto.Interfaces;
using Cine.Interfaces.Dia;
using Cine.Interfaces.Entrada;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Horario;
using Cine.Interfaces.Pelicula;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Sala;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mapper.AutoMapper;
namespace Cine.Implementacion.ConsultasServicio
{
    public class CronogramaConsultaServicio : ICronogramaConsultaServicio
    {
        private readonly IRepository<Dominio._4._1_Entidades.Cronograma> _cronogramaRepos;

        private readonly IMapper _mapper; 
        public CronogramaConsultaServicio(IRepository<Dominio._4._1_Entidades.Cronograma> cronogramaRepos)
        {
            _cronogramaRepos = cronogramaRepos;

            _mapper = CrearMapa();

        }
        public async Task<IEnumerable<CronogramaConsultaDto>> ObtenerPorFiltro(string cadenaBuscar)
        {
            var cronogramaFuncion = await _cronogramaRepos.GetByFilter(predicate: x => x.Funcion.Pelicula.Descripción.Contains(cadenaBuscar) ||
            x.Dia.TipoDia.ToString().Contains(cadenaBuscar) || x.Funcion.Sala.NumeroSalon.ToString().Contains(cadenaBuscar)
            || x.Funcion.Sala.Cine.Nombre.Contains(cadenaBuscar), null, include: x => x.Include(x => x.Funcion).Include(x => x.Funcion.Sala)
            .Include(x => x.Funcion.Pelicula).Include(x => x.Funcion.Sala.Cine).Include(x => x.Funcion.Entrada), true);

            var listaCronogramas = new List<CronogramaConsultaDto>();

            foreach (var item in cronogramaFuncion)
            {
                var cronograma = new CronogramaConsultaDto
                {
                    Dia = _mapper.Map<DiaDto>(item.Dia),
                    Horario = _mapper.Map<HorarioDto>(item.Horarios),
                    Funcion = new FuncionConsultaDto
                    {
                        Entrada = _mapper.Map<EntradaDto>(item.Funcion.Entrada),
                        Pelicula = _mapper.Map<PeliculaDto>(item.Funcion.Pelicula),
                        Sala = _mapper.Map<SalaDto>(item.Funcion.Sala),
                        Funcion = _mapper.Map<FuncionDto>(item)
                    },
                };

                listaCronogramas.Add(cronograma);
                

            }

            return listaCronogramas;

        }

        public async Task<CronogramaConsultaDto> ObtenerPorFuncionId(long fucionId)
        {
            var cronograma = await _cronogramaRepos.GetByFilter(predicate: x => x.FuncionId == fucionId, null, include: x => x.Include(x => x.Funcion)
            .Include(x => x.Funcion.Sala).Include(x => x.Funcion.Pelicula).Include(x => x.Funcion.Entrada), true);

            var cronogramaSeleccionado = cronograma.First(x => x.FuncionId == fucionId);

            return new CronogramaConsultaDto
            {
                Dia = _mapper.Map<DiaDto>(cronogramaSeleccionado.Dia),
                Horario = _mapper.Map<HorarioDto>(cronogramaSeleccionado.Horarios),
                Funcion = new FuncionConsultaDto
                {
                    Entrada = _mapper.Map<EntradaDto>(cronogramaSeleccionado.Funcion.Entrada),
                    Pelicula = _mapper.Map<PeliculaDto>(cronogramaSeleccionado.Funcion.Pelicula),
                    Sala = _mapper.Map<SalaDto>(cronogramaSeleccionado.Funcion.Sala),
                    Funcion = _mapper.Map<FuncionDto>(cronogramaSeleccionado.Funcion)
                }
            };

        }

        public async Task<IEnumerable<CronogramaConsultaDto>> Obtenertodos()
        {
            var cronogramaFuncion = await _cronogramaRepos.GetAll(null, include: x => x.Include(x => x.Funcion).Include(x => x.Funcion.Sala)
          .Include(x => x.Funcion.Pelicula).Include(x => x.Funcion.Sala.Cine).Include(x => x.Funcion.Entrada), true);

            var listaCronogramas = new List<CronogramaConsultaDto>();

            foreach (var item in cronogramaFuncion)
            {
                var cronograma = new CronogramaConsultaDto
                {
                    Dia = _mapper.Map<DiaDto>(item.Dia),
                    Horario = _mapper.Map<HorarioDto>(item.Horarios),
                    Funcion = new FuncionConsultaDto
                    {
                        Entrada = _mapper.Map<EntradaDto>(item.Funcion.Entrada),
                        Pelicula = _mapper.Map<PeliculaDto>(item.Funcion.Pelicula),
                        Sala = _mapper.Map<SalaDto>(item.Funcion.Sala),
                        Funcion = _mapper.Map<FuncionDto>(item)
                    },
                };

                listaCronogramas.Add(cronograma);


            }

            return listaCronogramas;
        }
    }
}
