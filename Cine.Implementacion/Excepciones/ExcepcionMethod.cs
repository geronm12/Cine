using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Implementacion.Excepciones
{
    public class ExcepcionMethod : IExceptionMethod
    {
        public Task<object> ReturnNulleable()
        {
            return null;
        }
    }
}
