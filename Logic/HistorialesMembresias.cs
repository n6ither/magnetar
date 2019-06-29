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
    public class HistorialesMembresias
    {
        public class HistorialMembresias
        {
            private int m_idHistorialMembresias;
            public int idHistorialMembresias
            {
                get { return m_idHistorialMembresias; }
                set { m_idHistorialMembresias = value; }
            }

            private int m_idMembresia;
            public int idMembresia
            {
                get { return m_idMembresia; }
                set { m_idMembresia = value; }
            }

            private DateTime m_Fecha;
            public DateTime Fecha
            {
                get { return m_Fecha; }
                set { m_Fecha = value; }
            }

            private string m_Concepto;
            public string Concepto
            {
                get { return m_Concepto; }
                set { m_Concepto = value; }
            }

            private decimal m_Saldo;
            public decimal Saldo
            {
                get { return m_Saldo; }
                set { m_Saldo = value; }
            }
        }

        public int Insert(HistorialMembresias Dato)
        {
            DataAccess oDataAccess = new DataAccess();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO HistorialMembresias(idMembresia, Fecha, Concepto, Saldo) VALUES(@idMembresia, @Fecha, @Concepto, @Saldo)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("idMembresia", Dato.idMembresia);
            cmdInsert.Parameters.AddWithValue("Fecha", Dato.Fecha);
            cmdInsert.Parameters.AddWithValue("Concepto", Dato.Concepto);
            cmdInsert.Parameters.AddWithValue("Saldo", Dato.Saldo);

            int id = oDataAccess.ExecuteCommando(cmdInsert);
            return id;
        }

        public DataTable GetAllMix(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string s_SQL = "SELECT " + sColumnas + " FROM HistorialMembresias, Membresia, Actividad, Socio" + sFiltro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
            return DT;
        }
    }
}
