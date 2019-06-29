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
    public class PagosMembresias
    {
        public class PagoMembresia
        {
            private int m_idPagoMembresia;
            public int idPagoMembresia
            {
                get { return m_idPagoMembresia; }
                set { m_idPagoMembresia = value; }
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

            private decimal m_Monto;
            public decimal Monto
            {
                get { return m_Monto; }
                set { m_Monto = value; }
            }
        }

        public DataTable GetAllMix(string sColumnas, string sFiltro)
        {
            try
            {
                if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
                string stSQL = "SELECT  " + sColumnas + " FROM PagoMembresia, Membresia, Socio, Actividad " + sFiltro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Insert(PagoMembresia Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO PagoMembresia(idMembresia, Fecha, Monto) VALUES(@idMembresia, @Fecha, @Monto)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("idMembresia", Dato.idMembresia);
                cmdInsert.Parameters.AddWithValue("Fecha", Dato.Fecha);
                cmdInsert.Parameters.AddWithValue("Monto", Dato.Monto);

                int id = Convert.ToInt32(oDataAccess.ExecuteCommando(cmdInsert));
                return id;
            }
            catch (Exception) { return -1; }
        }

        public PagoMembresia GetOne(int idPagoMembresia)
        {
            string stSQL = "SELECT * FROM PagoMembresia WHERE idPagoMembresia=" + idPagoMembresia;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                PagoMembresia oPagoMembresia = new PagoMembresia();
                try
                {
                    oPagoMembresia.idMembresia = Convert.ToInt32(Fila["idMembresia"]);
                    oPagoMembresia.Fecha = Convert.ToDateTime(Fila["Fecha"]);
                    oPagoMembresia.Monto = Convert.ToDecimal(Fila["Monto"]);
                    return oPagoMembresia;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }
    }
}