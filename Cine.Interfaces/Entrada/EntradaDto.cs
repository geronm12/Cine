using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Entrada
{
    public class EntradaDto: EntidadBaseDto.EntidadBaseDto
    {
        public string Descripcion { get; set; }

        public long Numero { get; set; }
    }
}
