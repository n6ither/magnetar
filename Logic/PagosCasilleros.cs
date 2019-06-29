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
    public class PagosCasilleros
    {
        public class PagoCasillero
        {
            private int m_idPagoCasillero;
            public int idPagoCasillero
            {
                get { return m_idPagoCasillero; }
                set { m_idPagoCasillero = value; }
            }

            private int m_idCasillero;
            public int idCasillero
            {
                get { return m_idCasillero; }
                set { m_idCasillero = value; }
            }

            private DateTime m_Fecha;
            public DateTime Fecha
            {
                get { return m_Fecha; }
                set { m_Fecha = value; }
            }

            private decimal m_Monto;
            public decimal Monto
            {
                get { return m_Monto; }
                set { m_Monto = value; }
            }
        }

        public DataTable GetAllMix(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string stSQL = "SELECT  " + s_Columnas + " FROM PagoCasillero, Casillero, Socio " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Insert(PagoCasillero Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO PagoCasillero(idCasillero, Fecha, Monto) VALUES(@idCasillero, @Fecha, @Monto)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("idCasillero", Dato.idCasillero);
                cmdInsert.Parameters.AddWithValue("Fecha", Dato.Fecha);
                cmdInsert.Parameters.AddWithValue("Monto", Dato.Monto);

                int id = Convert.ToInt32(oDataAccess.ExecuteCommando(cmdInsert));
                return id;
            }
            catch (Exception) { return -1; }
        }

        public PagoCasillero GetOne(int idPagoCasillero)
        {
            string stSQL = "SELECT * FROM PagoCasillero WHERE idPagoCasillero=" + idPagoCasillero;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                PagoCasillero oPagoCasillero = new PagoCasillero();
                try
                {
                    oPagoCasillero.idCasillero = Convert.ToInt32(Fila["idCasillero"]);
                    oPagoCasillero.Fecha = Convert.ToDateTime(Fila["Fecha"]);
                    oPagoCasillero.Monto = Convert.ToDecimal(Fila["Monto"]);
                    return oPagoCasillero;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }
    }
}
