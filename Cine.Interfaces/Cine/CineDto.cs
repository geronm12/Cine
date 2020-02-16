using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.Cine
{
    public class CineDto:EntidadBaseDto.EntidadBaseDto
    {
        public string Nombre { get; set; }

        public string Dirección { get; set; }

        public string Teléfono { get; set; }
    }
}
