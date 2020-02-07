using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Models
{
    public class CineViewModel
    {
       [ErroresPersonalizados(ErrorMessage = "La dirección no puede ser nula o vacía")]
        public string Dirección { get; set; }
 
        public string NombreCine { get; set; }

        public ICollection<SalonViewModel> Salones { get; set; }

    }
}
