using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Infraestructura
{
    public interface IEncryptar
    {
        string Encriptar(string dato, string llave);

        string Desencriptar(string dato, string llave);


        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);

        string GetKey();

    }
}
