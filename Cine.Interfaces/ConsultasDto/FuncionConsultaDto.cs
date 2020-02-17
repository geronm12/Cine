using Cine.Interfaces.Entrada;
using Cine.Interfaces.Funcion;
using Cine.Interfaces.Pelicula;
using Cine.Interfaces.Sala;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.ConsultasDto
{
    public class FuncionConsultaDto:ConsultasDto
    {
        public FuncionDto Funcion { get; set; }

        public PeliculaDto Pelicula { get; set; }
        
        public EntradaDto Entrada { get; set; }

        public SalaDto Sala { get; set; } 
    }
}
