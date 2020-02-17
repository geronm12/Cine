using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades
{
    public class Cronograma : EntityBase
    {
        public long DiaId { get; set; }

        public long HorarioId { get; set; }

        public bool EsTrasnoche { get; set; }

        public long FuncionId { get; set; }

        public virtual Dia Dia { get; set; }

        public virtual Horarios.Horarios Horarios {get; set;}

    
        public virtual Funcion Funcion { get; set; }
        
    }
}
