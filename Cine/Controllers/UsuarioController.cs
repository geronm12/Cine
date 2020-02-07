using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class UsuarioController : Controller
    {
       



        public UsuarioController()
        {


        }


        [HttpPost]
        public IActionResult Login(   )
        {

            return View();

        }
 
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        
    }
}