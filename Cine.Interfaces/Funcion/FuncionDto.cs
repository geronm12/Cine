using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Funcion
{
    public class FuncionDto: EntidadBaseDto.EntidadBaseDto
    {
        public long PeliculaId { get; set; }

        public long SalaId { get; set; }

        public long EntradaId { get; set; }

        public long EntradasDisponibles { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaDeEstreno { get; set; }

        public DateTime FechaDeBaja { get; set; }
    }
}
