using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Logic
{
    public class Usuarios
    {
        public class Usuario
        {
            /// <summary>
            /// ID de la cuenta de usuario.
            /// </summary>
            private string m_Username;
            public string Username
            {
                get { return m_Username; }
                set { m_Username = value; }
            }

            /// <summary>
            /// Contraseña.
            /// </summary>
            private string m_Password;
            public string Password
            {
                get { return m_Password; }
                set { m_Password = value; }
            }

            private string m_Email;
            public string Email
            {
                get { return m_Email; }
                set { m_Email = value; }
            }
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT " + sColumnas + " FROM Usuario" + sFiltro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
        }

        public int Insert(Usuario Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand Insert = new SqlCommand("INSERT INTO Usuario(Username, Password, Email) VALUES(@Username, @Password, @Email)", oDataAccess.Connection);
            Insert.Parameters.AddWithValue("Username", Dato.Username);
            Insert.Parameters.AddWithValue("Password", Dato.Password);
            Insert.Parameters.AddWithValue("Email", Dato.Email);

            int id = oDataAccess.ExecuteCommando(Insert);
            return id;
        }

        public int Update(Usuario Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Usuario SET Username=@Username, Password=@Password, Email=@Email WHERE idUsuario=@idUsuario", oDataAccess.Connection);
            cmdUpdate.Parameters.AddWithValue("Username", Dato.Username);
            cmdUpdate.Parameters.AddWithValue("Password", Dato.Password);
            cmdUpdate.Parameters.AddWithValue("Email", Dato.Email);

            int id = oDataAccess.ExecuteCommando(cmdUpdate);
            return id;
        }

        public void ChangePassword(string Username, string Password)
        {
            string stSQL = "UPDATE Usuario SET Password='" + Password + "' WHERE Username='" + Username + "'";
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteScalar(stSQL);
        }

        public bool ComprobarUsuario(string Username)
        {
            DataAccess oDataAccess = new DataAccess();

            string stSQL = "SELECT * FROM Usuario WHERE Username='" + Username + "'";
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            if (DT.Rows.Count < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Delete(string stTabla, string stFiltro)
        {
            string stSQL = "DELETE FROM " + stTabla + " WHERE " + stFiltro;

            DataAccess oDataAccess = new DataAccess();
            int id = oDataAccess.ExecuteCommando(stSQL);
            return id;
        }
    }
}