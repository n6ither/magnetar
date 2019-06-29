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
    public class Gimnasios
    {
        public class Gimnasio
        {
            private int m_idGimnasio;
            public int idGimnasio
            {
                get { return m_idGimnasio; }
                set { m_idGimnasio = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private string m_Direccion;
            public string Direccion
            {
                get { return m_Direccion; }
                set { m_Direccion = value; }
            }

            private int m_idLocalidad;
            public int idLocalidad
            {
                get { return m_idLocalidad; }
                set { m_idLocalidad = value; }
            }

            private string m_TelefonoFijo;
            public string TelefonoFijo
            {
                get { return m_TelefonoFijo; }
                set { m_TelefonoFijo = value; }
            }

            private string m_TelefonoCelular;
            public string TelefonoCelular
            {
                get { return m_TelefonoCelular; }
                set { m_TelefonoCelular = value; }
            }

            private string m_Email;
            public string Email
            {
                get { return m_Email; }
                set { m_Email = value; }
            }

            private string m_Logo;
            public string Logo
            {
                get { return m_Logo; }
                set { m_Logo = value; }
            }

            private string m_SizeMode;
            public string SizeMode
            {
                get { return m_SizeMode; }
                set { m_SizeMode = value; }
            }
        }

        public int Insert(Gimnasio Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand Insert = new SqlCommand("INSERT INTO Gimnasio(Nombre, Direccion, idLocalidad, TelefonoFijo, TelefonoCelular, Email, Logo, SizeMode) VALUES(@Nombre, @Direccion, @idLocalidad, @TelefonoFijo, @TelefonoCelular, @Email, @Logo, @SizeMode)", oDataAccess.Connection);
                Insert.Parameters.AddWithValue("Nombre", Dato.Nombre);
                Insert.Parameters.AddWithValue("Direccion", Dato.Direccion);
                Insert.Parameters.AddWithValue("idLocalidad", Dato.idLocalidad);
                Insert.Parameters.AddWithValue("TelefonoFijo", Dato.TelefonoFijo);
                Insert.Parameters.AddWithValue("TelefonoCelular", Dato.TelefonoCelular);
                Insert.Parameters.AddWithValue("Email", Dato.Email);
                Insert.Parameters.AddWithValue("Logo", Dato.Logo);
                Insert.Parameters.AddWithValue("SizeMode", Dato.SizeMode);

                int id = oDataAccess.ExecuteCommando(Insert);
                return id;
            }
            catch (Exception) { return -1; }
        }

        public Gimnasio GetTheOne()
        {
            string stSQL = "SELECT TOP(1) * FROM Gimnasio";

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Gimnasio oGimnasio = new Gimnasio();
                try
                {
                    oGimnasio.Nombre = Fila["Nombre"].ToString().Trim();
                    oGimnasio.Direccion = Fila["Direccion"].ToString().Trim();
                    oGimnasio.idLocalidad = Convert.ToInt32(Fila["idLocalidad"]);
                    oGimnasio.TelefonoFijo = Fila["TelefonoFijo"].ToString().Trim();
                    oGimnasio.TelefonoCelular = Fila["TelefonoCelular"].ToString().Trim();
                    oGimnasio.Email = Fila["Email"].ToString().Trim();
                    oGimnasio.Logo = Fila["Logo"].ToString().Trim();
                    oGimnasio.SizeMode = Fila["SizeMode"].ToString().Trim();
                    return oGimnasio;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public int TruncateTable()
        {
            try
            {
                string s_SQL = "TRUNCATE TABLE Gimnasio";
                DataAccess oDataAccess = new DataAccess();
                int id = oDataAccess.ExecuteCommando(s_SQL);
                return id;
            }
            catch (Exception) { return -1; }
        }
    }
}