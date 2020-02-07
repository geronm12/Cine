using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades.Horarios
{
    public class Horarios : EntityBase
    {
        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }
 
        //Propiedades de Navegacion
        
        public virtual ICollection<Cronograma> Cronogramas { get; set; }

    }
}
