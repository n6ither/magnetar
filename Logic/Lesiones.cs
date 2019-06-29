using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Data;

namespace Logic
{
    public class Lesiones
    {
        public class Lesion
        {
            private int m_idLesion;
            public int idLesion
            {
                get { return m_idLesion; }
                set { m_idLesion = value; }
            }

            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private string m_Tipo;
            public string Tipo
            {
                get { return m_Tipo; }
                set { m_Tipo = value; }
            }
        }

        public int Insert(Lesion Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand Insert = new SqlCommand("INSERT INTO Lesion(idSocio, Nombre, Tipo) VALUES(@idSocio, @Nombre, @Tipo)", oDataAccess.Connection);
            Insert.Parameters.AddWithValue("idSocio", Dato.idSocio);
            Insert.Parameters.AddWithValue("Nombre", Dato.Nombre);
            Insert.Parameters.AddWithValue("Tipo", Dato.Tipo);

            int id = oDataAccess.ExecuteCommando(Insert);
            return id;
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT " + sColumnas + " FROM Lesion" + sFiltro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
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
