using System;
using System.Collections.Generic;
using System.Text;

namespace HelpersServicios
{
    public class Instanciador
    {
        public object Instanciar(Type tipo)
        {

            var instancia = Activator.CreateInstance(tipo);

            return instancia;

        }


    }
}
