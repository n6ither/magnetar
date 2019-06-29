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
    public class CopiasSeguridad
    {
        public class CopiaSeguridad
        {
            private int m_idCopiaSeguridad;
            public int idCopiaSeguridad
            {
                get { return m_idCopiaSeguridad; }
                set { m_idCopiaSeguridad = value; }
            }

            private DateTime m_FechaHora;
            public DateTime FechaHora
            {
                get { return m_FechaHora; }
                set { m_FechaHora = value; }
            }

            private string m_Ruta;
            public string Ruta
            {
                get { return m_Ruta; }
                set { m_Ruta = value; }
            }
        }

        public CopiaSeguridad GetUltimaCopia()
        {
            string s_SQL = "SELECT TOP 1 * FROM CopiaSeguridad ORDER BY idCopiaSeguridad DESC";
            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);

            foreach (DataRow Fila in DT.Rows)
            {
                CopiaSeguridad oCopiaSeguridad= new CopiaSeguridad();
                try
                {
                    oCopiaSeguridad.FechaHora = Convert.ToDateTime(Fila["FechaHora"]);
                    oCopiaSeguridad.Ruta = Fila["Ruta"].ToString();
                    return oCopiaSeguridad;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public int Insert(CopiaSeguridad Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO CopiaSeguridad(FechaHora, Ruta) VALUES(@FechaHora, @Ruta)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("FechaHora", Dato.FechaHora);
                cmdInsert.Parameters.AddWithValue("Ruta", Dato.Ruta);

                int id = oDataAccess.ExecuteCommando(cmdInsert);
                return id;
            }
            catch (Exception) { return -1; }
        }

        public DateTime UltimaFecha()
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                string sUltimaCopia = "SELECT TOP 1 CopiaSeguridad.FechaHora FROM CopiaSeguridad ORDER BY idCopiaSeguridad DESC";
                DateTime dtUltimaFecha = Convert.ToDateTime(oDataAccess.ExecuteScalar(sUltimaCopia));
                return dtUltimaFecha;
            }
            catch (Exception) { return new DateTime(1900, 1, 1); }
        }

        public bool Pasaron15Dias()
        {
            try
            {
                TimeSpan tsDiferencia = UltimaFecha() - DateTime.Now;
                int iDias = tsDiferencia.Days * -1;

                if (iDias <= 15) { return false; }
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
