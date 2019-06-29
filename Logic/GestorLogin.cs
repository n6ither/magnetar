using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using Data;

namespace Logic
{
    public class GestorLogin
    {
        /// <summary>
        /// Verifica que el usuario y la contraseña ingresados se encuentren almacenados en la base de datos.
        /// </summary>
        /// <param name="Username">ID del usuario.</param>
        /// <param name="Password">Contraseña del usuario.</param>
        /// <returns></returns>
        public static bool Autentificar(string Username, string Password)
        {
            DataAccess oDataAccess = new DataAccess();
            string hash = EncriptarPWD(string.Concat(Username, Password)); //Genera el hash de la contraseña.
            string stSQL = @"SELECT COUNT(*) FROM Usuario WHERE Username=@Username AND Password=@Password";

            SqlCommand Command = new SqlCommand(stSQL, oDataAccess.Connection);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", hash);

            int Count = Convert.ToInt32(Command.ExecuteScalar());

            if (Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        /// <summary>
        /// Crea la contraseña a partir de la contraseña elegida por el usuario.
        /// </summary>
        /// <param name="originalPWD">ID concatenado con la contraseña.</param>
        /// <returns></returns>
        public static string EncriptarPWD(string originalPWD)
        {
            string stClave = "7f9facc418f74439c5e9709832;0ab8a5:OCOdN5Wl,q8SLIQz8i|8agmu¬s13Q7ZXyno/";  //Clave que se utilizara para crear el hash.
            SHA512 Sha512 = new SHA512CryptoServiceProvider();  //Algoritmo encriptador.
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPWD + stClave);  //Se une el ID, la contraseña y la clave y se mete en un vector.
            byte[] hash = Sha512.ComputeHash(inputBytes);  //Se calcula la matriz de bytes del vector y se encripta.
            return Convert.ToBase64String(hash);  //Convierte el vector de bytes a string.
        }
    }
}