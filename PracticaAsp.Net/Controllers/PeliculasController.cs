using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaAsp.Net.Services;

namespace PracticaAsp.Net.Controllers
{
    public class PeliculasController : Controller
    {
         

        public IActionResult Peliculas()
        {
            var peliculasServices = new PeliculaService();

            var model = peliculasServices.ObtenerTodas();

            return View(model);
        }



    }
}