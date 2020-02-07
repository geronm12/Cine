using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class CineController : Controller
    {
         [HttpGet]
        public IActionResult Salas()
        {
             
            return View( );

        }
 
        

        [HttpGet]
        public IActionResult Entradas(   )
        {
            
             
            return View( );
        }


         

    }
}