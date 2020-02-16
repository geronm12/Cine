using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cine.Infraestructura.Encriptador
{
    public class Encripter: IEncryptar
    {
        public static string Llave => "jwey89e09ewgfo24";

        public string Encriptar(string dato, string llave)
        {
            byte[] keyArray;

            byte[] encriptar = Encoding.UTF8.GetBytes(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform ctransform = tdes.CreateEncryptor();

            byte[] resultado = ctransform.TransformFinalBlock(encriptar, 0, encriptar.Length);

            return Convert.ToBase64String(resultado, 0,  resultado.Length);
        }


        public string Desencriptar(string dato, string llave)
        {
            byte[] keyArray;

            byte[] desencriptar = Convert.FromBase64String(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform ctransform = tdes.CreateDecryptor();

            byte[] resultado = ctransform.TransformFinalBlock(desencriptar, 0, desencriptar.Length);
            tdes.Clear();

            return Encoding.UTF8.GetString(resultado);
        }

        public string GetKey()
        {
            return Llave;
        }

    }
}
