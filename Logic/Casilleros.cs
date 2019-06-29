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
    public class Casilleros
    {
        public class Casillero
        {
            private int m_idCasillero;
            public int idCasillero
            {
                get { return m_idCasillero; }
                set { m_idCasillero = value; }
            }

            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
            }

            private int m_Numero;
            public int Numero
            {
                get { return m_Numero; }
                set { m_Numero = value; }
            }
            
            private decimal m_Precio;
            public decimal Precio
            {
                get { return m_Precio; }
                set { m_Precio = value; }
            }

            private DateTime m_FechaInicio;
            public DateTime FechaInicio
            {
                get { return m_FechaInicio; }
                set { m_FechaInicio = value; }
            }

            private DateTime m_FechaVencimiento;
            public DateTime FechaVencimiento
            {
                get { return m_FechaVencimiento; }
                set { m_FechaVencimiento = value; }
            }

            private int m_Estado;
            public int Estado
            {
                get { return m_Estado; }
                set { m_Estado = value; }
            }
        }

        public DataTable GetAll(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string s_SQL = "SELECT  " + s_Columnas + " FROM Casillero " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Insert(Casillero Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Casillero(idSocio, Numero, Precio, FechaInicio, FechaVencimiento, Estado) VALUES(@idSocio, @Numero, @Precio, @FechaInicio, @FechaVencimiento, @Estado)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("idSocio", Dato.idSocio);
                cmdInsert.Parameters.AddWithValue("Numero", Dato.Numero);
                cmdInsert.Parameters.AddWithValue("Precio", Dato.Precio);
                cmdInsert.Parameters.AddWithValue("FechaInicio", Dato.FechaInicio);
                cmdInsert.Parameters.AddWithValue("FechaVencimiento", Dato.FechaVencimiento);
                cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

                oDataAccess.ExecuteCommando(cmdInsert);
                string stTop = "SELECT TOP 1 idCasillero FROM Casillero ORDER BY idCasillero DESC";
                int id = Convert.ToInt32(oDataAccess.ExecuteScalar(stTop));
                return id;
            }
            catch (Exception) { return -1; }
        }

        public void Disable(int idCasillero)
        {
            try
            {
                string s_SQL = "UPDATE Casillero SET Estado=0 WHERE idCasillero=" + idCasillero;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(s_SQL);
            }
            catch (Exception) { }
        }

        public string GetCasillero(int idSocio)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                string s_SQL = "SELECT * FROM Casillero WHERE Casillero.Estado=1 AND Casillero.idSocio=" + idSocio;
                DataTable dtCasillero = oDataAccess.ExecuteDataTable(s_SQL);

                if (dtCasillero.Rows.Count == 0) { return "Ninguno"; }
                return "#" + dtCasillero.Rows[0]["Numero"].ToString();
            }
            catch (Exception) { return ""; }
        }

        public void LiberarVencidos()
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                string s_SQL = "SELECT * FROM Casillero WHERE Estado=1";
                DataTable dtCasilleros = oDataAccess.ExecuteDataTable(s_SQL);
                Casilleros oCasilleros = new Casilleros();

                foreach (DataRow row in dtCasilleros.Rows)
                {
                    if (Convert.ToDateTime(row["FechaVencimiento"]) < DateTime.Now.Date)
                    {
                        oCasilleros.Disable(Convert.ToInt32(row["idCasillero"]));
                    }
                }
            }
            catch (Exception) { }
        }

        public int CountActivos()
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                string s_SQL = "SELECT COUNT(*) FROM Casillero WHERE Casillero.Estado=1";
                int cant = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
                return cant;
            }
            catch (Exception) { return -1; }
        }

        /// <summary>
        /// Devuelve un string con el monto abonado por un casillero.
        /// </summary>
        /// <param name="idCasillero"></param>
        /// <returns></returns>
        public string CuantoPago(int idCasillero)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_Casillero = "SELECT * FROM Casillero WHERE Casillero.idCasillero=" + idCasillero;
            DataTable dtCasillero = oDataAccess.ExecuteDataTable(s_Casillero);
            string s_PagoCasillero = "SELECT PagoCasillero.idPagoCasillero, PagoCasillero.idCasillero, PagoCasillero.Fecha, PagoCasillero.Monto FROM PagoCasillero, Casillero WHERE Casillero.idCasillero=" + idCasillero + " AND Casillero.idCasillero=PagoCasillero.idCasillero";
            DataTable dtPagoCasillero = oDataAccess.ExecuteDataTable(s_PagoCasillero);

            if (dtPagoCasillero.Rows.Count == 0)
            {
                return "0,00";
            }
            else
            {
                decimal d_MontoCobros = 0;
                foreach (DataRow row in dtPagoCasillero.Rows)
                {
                    d_MontoCobros += Convert.ToDecimal(row["Monto"]);
                }
                return d_MontoCobros.ToString();
            }
        }

        /// <summary>
        /// Devuelve un color segun el pago. Verde: completo, Amarillo: parcial y Rojo: nulo.
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public string ColorCasillero(int idCasillero)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_Casillero = "SELECT * FROM Casillero WHERE Casillero.idCasillero=" + idCasillero;
            DataTable dtCasillero = oDataAccess.ExecuteDataTable(s_Casillero);
            string s_PagoCasillero = "SELECT PagoCasillero.idPagoCasillero, PagoCasillero.idCasillero, PagoCasillero.Fecha, PagoCasillero.Monto FROM PagoCasillero, Casillero WHERE Casillero.idCasillero=" + idCasillero + " AND Casillero.idCasillero=PagoCasillero.idCasillero";
            DataTable dtPagoCasillero = oDataAccess.ExecuteDataTable(s_PagoCasillero);

            if (dtPagoCasillero.Rows.Count == 0)
            {
                return "Rojo";
            }
            else
            {
                decimal d_MontoCobros = 0;
                foreach (DataRow row in dtPagoCasillero.Rows)
                {
                    d_MontoCobros += Convert.ToDecimal(row["Monto"]);
                }
                if (d_MontoCobros < Convert.ToDecimal(dtCasillero.Rows[0]["Precio"])) { return "Amarillo"; }
            }

            return "Verde";
        }
    }
}
