using Cine.Implementacion.Encriptador;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cine.Infraestructura.Encriptador
{
    public sealed class Encripter: IEncryptar
    {
        public static string Llave => "jwey89e09ewgfo24";

        public const int saltsize = 16;
        public const int keysize = 32;

         
        public Encripter(IOptions<HashingOptions> options)
        {
            Options = options.Value;

        }
        private HashingOptions Options { get; }
        public string Encriptar(string dato, string llave)
        {
            byte[] keyArray;

            byte[] encriptar = Encoding.UTF8.GetBytes(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform ctransform = tdes.CreateEncryptor();

            byte[] resultado = ctransform.TransformFinalBlock(encriptar, 0, encriptar.Length);

            return Convert.ToBase64String(resultado, 0,  resultado.Length);
        }


        public string Desencriptar(string dato, string llave)
        {
            byte[] keyArray;

            byte[] desencriptar = Convert.FromBase64String(dato);

            keyArray = Encoding.UTF8.GetBytes(llave);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform ctransform = tdes.CreateDecryptor();

            byte[] resultado = ctransform.TransformFinalBlock(desencriptar, 0, desencriptar.Length);
            tdes.Clear();

            return Encoding.UTF8.GetString(resultado);
        }

        public string GetKey()
        {
            return Llave;
        }

        public string Hash(string password)
        {
            using var algoritm = new Rfc2898DeriveBytes(password, saltsize, Options.Iterations, HashAlgorithmName.SHA512);
            var key = Convert.ToBase64String(algoritm.GetBytes(keysize));

            var salt = Convert.ToBase64String(algoritm.Salt);

            return $"{Options.Iterations}.{salt}.{key}";
        }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if(parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format..." +
                    "Should be formatted as  `{iterations}.{salt}.{hash}`");

            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != Options.Iterations;

            
            using var algoritm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);

            var ketToCheck = algoritm.GetBytes(keysize);

            var verified = ketToCheck.SequenceEqual(key);

            return (verified, needsUpgrade);
        }
    }
}
