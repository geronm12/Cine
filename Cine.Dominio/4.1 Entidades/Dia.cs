﻿using Cine.Dominio._4._6_Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Dominio._4._1_Entidades
{
    public class Dia : EntityBase
    {
        public TipoDia TipoDia {get; set;}

        public List<DateTime> HorasDeProyeccion { get; set; }

    }
}
