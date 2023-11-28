using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_C_
{
    public class Funciones
    {
        // FUNCION QUE RECIBE UNA CADENA DE TEXTO Y RETORNA LA CADENA ENCRIPTADA
        public static string Encriptar(string Input)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi");
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");


            byte[] buffer = Encoding.UTF8.GetBytes(Input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;

            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        // FUNCION QUE RECIBE UNA CADENA ENCRIPTADA Y LA DESENCRIPTA
        public static string Desencriptar(string Input)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi");
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");

            // Asegúrate de que la longitud de la cadena sea un múltiplo de 4 agregando padding '=' si es necesario

            int mod4 = Input.Length % 4;
            if (mod4 > 0)
            {
                Input += new string('=', 4 - mod4);
            }



            byte[] buffer = Convert.FromBase64String(Input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;

            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
}
