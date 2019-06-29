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
    public class SociosxTurnos
    {
        public class SocioxTurno
        {
            private int m_idSocioxTurno;
            public int idSocioxTurno
            {
                get { return m_idSocioxTurno; }
                set { m_idSocioxTurno = value; }
            }

            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
            }

            private int m_idTurno;
            public int idTurno
            {
                get { return m_idTurno; }
                set { m_idTurno = value; }
            }
        }

        public int Insert(SocioxTurno Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO SocioxTurno(idSocio, idTurno) VALUES(@idSocio, @idTurno)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("idSocio", Dato.idSocio);
            cmdInsert.Parameters.AddWithValue("idTurno", Dato.idTurno);

            int id = oDataAccess.ExecuteCommando(cmdInsert);
            return id;
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT  " + sColumnas + " FROM SocioxTurno" + sFiltro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
        }

        public int Delete(string stTabla, string stFiltro)
        {
            try
            {
                string s_SQL = "DELETE FROM " + stTabla + " WHERE " + stFiltro;

                DataAccess oDataAccess = new DataAccess();
                int id = oDataAccess.ExecuteCommando(s_SQL);
                return id;
            }
            catch (Exception) { return -1; }
        }
    }
}