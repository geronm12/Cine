
using Cine.Implementacion.Cine;
using Cine.Implementacion.ConsultasServicio;
using Cine.Implementacion.Cronograma;
using Cine.Implementacion.Dia;
using Cine.Implementacion.Entrada;
using Cine.Implementacion.Funcion;
using Cine.Implementacion.Horario;
using Cine.Implementacion.Pelicula;
using Cine.Implementacion.Sala;
using Cine.Implementacion.Usuario;
using Cine.Infraestructura;
using Cine.Infraestructura.Encriptador;
using Cine.Infraestructura.Repositorio;
using Cine.Interfaces.Cine;
using Cine.Interfaces.ConsultasDto.Interfaces;
using Cine.Interfaces.Cronograma;
using Cine.Interfaces.Dia;
using Cine.Interfaces.Entrada;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Horario;
using Cine.Interfaces.Pelicula;
using Cine.Interfaces.Repositorio;
using Cine.Interfaces.Sala;
using Cine.Interfaces.Usuario;
using Cine.Mailer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public static class Inyeccion
    {
        public static void ConfigurationServices(IServiceCollection services)
        {
            services.AddDbContext<Datacontext>();

            services.AddTransient<ICineRepository, CineRepository>();

            services.AddTransient<ICronogramaRepository, CronogramaRepository>();

            services.AddTransient<IPeliculaRepository, PeliculaRepository>();

            services.AddTransient<IHorarioRepository, HorarioRepository>();

            services.AddTransient<ISalaRepository, SalaRepository>();

            services.AddTransient<IEntradaRepository, EntradaRepository>();

            services.AddTransient<IDiaRepository, DiaRepository>();

            services.AddTransient<IFuncionRepository, FuncionRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();

            services.AddTransient<IEncryptar, Encripter>();

            services.AddTransient<IFuncionConsultaServicio, FuncionConsultaServicio>();

            services.AddTransient<ICronogramaConsultaServicio, CronogramaConsultaServicio>();

            services.AddTransient<ICineSalaServicio, CineSalaConsultaServicio>();

            //Repositorio

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //EmailSender

            services.AddTransient<IEmailSender, SendGridEmailSender>();

        }
    }

 

}