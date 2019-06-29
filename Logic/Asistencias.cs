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
    public class Asistencias
    {
        public class Asistencia
        {
            private int m_idAsistencia;
            public int idAsistencia
            {
                get { return m_idAsistencia; }
                set { m_idAsistencia = value; }
            }

            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
            }

            private int m_idActividad;
            public int idActividad
            {
                get { return m_idActividad; }
                set { m_idActividad = value; }
            }

            private DateTime m_Fecha;
            public DateTime Fecha
            {
                get { return m_Fecha; }
                set { m_Fecha = value; }
            }

            public string m_Hora;
            public string Hora
            {
                get { return m_Hora; }
                set { m_Hora = value; }
            }
        }

        public int Insert(Asistencia Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Asistencia(idSocio, idActividad, Fecha, Hora) VALUES(@idSocio, @idActividad, @Fecha, @Hora)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("idSocio", Dato.idSocio);
            cmdInsert.Parameters.AddWithValue("idActividad", Dato.idActividad);
            cmdInsert.Parameters.AddWithValue("Fecha", Dato.Fecha);
            cmdInsert.Parameters.AddWithValue("Hora", Dato.Hora);

            int id = oDataAccess.ExecuteCommando(cmdInsert);
            return id;
        }

        public DataTable GetTop100Mix(string sColumnas, string sFiltro)
        {
            try
            {
                if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
                string s_SQL = "SELECT TOP 100  " + sColumnas + " FROM Asistencia, Socio, Actividad" + sFiltro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public DataTable GetAllMix(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT " + sColumnas + " FROM Asistencia, Socio, Actividad" + sFiltro;

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

        public int CountAsistenciasHoy()
        {
            try
            {
                string s_SQL = "SELECT COUNT(DISTINCT idSocio) FROM Asistencia WHERE Asistencia.Fecha='" + DateTime.Now.Date.ToShortDateString() + "'";

                DataAccess oDataAccess = new DataAccess();
                int cant = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
                return cant;
            }
            catch (Exception) { return -1; }
        }

        public int CountAsistenciasSocio(int idSocio)
        {
            try
            {
                string s_SQL = "SELECT COUNT(idSocio) FROM Asistencia WHERE Asistencia.idSocio=" + idSocio;

                DataAccess oDataAccess = new DataAccess();
                int cant = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
                return cant;
            }
            catch (Exception) { return -1; }
        }

        public string UltimaAsistenciaSocio(int idSocio)
        {
            try
            {
                string s_SQL = "SELECT MAX(Fecha) as 'Fecha', MAX(Hora) as 'Hora' FROM Asistencia WHERE idSocio=" + idSocio;
                DataAccess oDataAccess = new DataAccess();

                DataTable dtAsistencia = oDataAccess.ExecuteDataTable(s_SQL);
                if (dtAsistencia.Rows.Count > 0) { string s_Asistencia = Convert.ToDateTime(dtAsistencia.Rows[0]["Fecha"]).ToShortDateString() + " " + dtAsistencia.Rows[0]["Hora"].ToString(); return s_Asistencia; }
                return "";
            }
            catch (Exception) { return ""; }
        }
    }
}
