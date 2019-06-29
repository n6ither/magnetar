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
    public class Ajustes
    {
        public class Ajuste
        {
            private int m_idAjuste;
            public int idAjuste
            {
                get { return m_idAjuste; }
                set { m_idAjuste = value; }
            }

            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
            }

            private DateTime m_Fecha;
            public DateTime Fecha
            {
                get { return m_Fecha; }
                set { m_Fecha = value; }
            }

            private string m_Descripcion;
            public string Descripcion
            {
                get { return m_Descripcion; }
                set { m_Descripcion = value; }
            }

            private decimal m_Monto;
            public decimal Monto
            {
                get { return m_Monto; }
                set { m_Monto = value; }
            }
        }

        public int Insert(Ajuste Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Ajuste(idSocio, Fecha, Descripcion, Monto) VALUES(@idSocio, @Fecha, @Descripcion, @Monto)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("idSocio", Dato.idSocio);
                cmdInsert.Parameters.AddWithValue("Fecha", Dato.Fecha);
                cmdInsert.Parameters.AddWithValue("Descripcion", Dato.Descripcion);
                cmdInsert.Parameters.AddWithValue("Monto", Dato.Monto);

                int id = oDataAccess.ExecuteCommando(cmdInsert);
                return id;
            }
            catch (Exception) { return -1; }
        }

        public DataTable GetAll(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string stSQL = "SELECT " + s_Columnas + " FROM Ajuste" + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public DataTable GetTop100(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string stSQL = "SELECT TOP 100 " + s_Columnas + " FROM Ajuste" + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }
    }
}
