﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cine.Dominio._4._1_Entidades
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }

        public bool EstaBorrado { get; set; }

    }
}
