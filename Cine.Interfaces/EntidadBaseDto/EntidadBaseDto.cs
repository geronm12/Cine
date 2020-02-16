using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Interfaces.EntidadBaseDto
{
    public abstract class EntidadBaseDto
    {
        public long Id { get; set; }

        public bool EstaBorrado { get; set; }

    }
}
