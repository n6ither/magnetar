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
    public class Membresias
    {
        public class Membresia
        {
            private int m_idMembresia;
            public int idMembresia
            {
                get { return m_idMembresia; }
                set { m_idMembresia = value; }
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

            private int m_idTurno;
            public int idTurno
            {
                get { return m_idTurno; }
                set { m_idTurno = value; }
            }

            private string m_Duracion;
            public string Duracion
            {
                get { return m_Duracion; }
                set { m_Duracion = value; }
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

            private decimal m_Precio;
            public decimal Precio
            {
                get { return m_Precio; }
                set { m_Precio = value; }
            }

            private decimal m_Descuento;
            public decimal Descuento
            {
                get { return m_Descuento; }
                set { m_Descuento = value; }
            }

            private decimal m_Total;
            public decimal Total
            {
                get { return m_Total; }
                set { m_Total = value; }
            }

            private int m_Estado;
            public int Estado
            {
                get { return m_Estado; }
                set { m_Estado = value; }
            }
        }

        public int Insert(Membresia Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Membresia(idSocio, idActividad, idTurno, Duracion, FechaInicio, FechaVencimiento, Precio, Descuento, Total, Estado) VALUES(@idSocio, @idActividad, @idTurno, @Duracion, @FechaInicio, @FechaVencimiento, @Precio, @Descuento, @Total, @Estado)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("idSocio", Dato.idSocio);
                cmdInsert.Parameters.AddWithValue("idActividad", Dato.idActividad);
                cmdInsert.Parameters.AddWithValue("idTurno", Dato.idTurno);
                cmdInsert.Parameters.AddWithValue("Duracion", Dato.Duracion);
                cmdInsert.Parameters.AddWithValue("FechaInicio", Dato.FechaInicio);
                cmdInsert.Parameters.AddWithValue("FechaVencimiento", Dato.FechaVencimiento);
                cmdInsert.Parameters.AddWithValue("Precio", Dato.Precio);
                cmdInsert.Parameters.AddWithValue("Descuento", Dato.Descuento);
                cmdInsert.Parameters.AddWithValue("Total", Dato.Total);
                cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

                oDataAccess.ExecuteCommando(cmdInsert);
                string s_Top = "SELECT TOP 1 idMembresia FROM Membresia ORDER BY idMembresia DESC";
                Int32 id = Convert.ToInt32(oDataAccess.ExecuteScalar(s_Top));
                return id;
            }
            catch (Exception) { return -1; }
        }

        public void Update(Membresia Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Membresia SET idSocio=@idSocio, idActividad=@idActividad, idTurno=@idTurno, Duracion=@Duracion, FechaInicio=@FechaInicio, FechaVencimiento=@FechaVencimiento, Precio=@Precio, Descuento=@Descuento, Total=@Total, Estado=@Estado WHERE idMembresia=@idMembresia", oDataAccess.Connection);
                cmdUpdate.Parameters.AddWithValue("idMembresia", Dato.idMembresia);
                cmdUpdate.Parameters.AddWithValue("idSocio", Dato.idSocio);
                cmdUpdate.Parameters.AddWithValue("idActividad", Dato.idActividad);
                cmdUpdate.Parameters.AddWithValue("idTurno", Dato.idTurno);
                cmdUpdate.Parameters.AddWithValue("Duracion", Dato.Duracion);
                cmdUpdate.Parameters.AddWithValue("FechaInicio", Dato.FechaInicio);
                cmdUpdate.Parameters.AddWithValue("FechaVencimiento", Dato.FechaVencimiento);
                cmdUpdate.Parameters.AddWithValue("Precio", Dato.Precio);
                cmdUpdate.Parameters.AddWithValue("Descuento", Dato.Descuento);
                cmdUpdate.Parameters.AddWithValue("Total", Dato.Total);
                cmdUpdate.Parameters.AddWithValue("Estado", Dato.Estado);
                oDataAccess.ExecuteCommando(cmdUpdate);
            }
            catch (Exception) { }
        }

        public Membresia GetOne(int idMembresia)
        {
            string s_SQL = "SELECT * FROM Membresia WHERE idMembresia=" + idMembresia;
            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Membresia oMembresia = new Membresia();
                try
                {
                    oMembresia.idMembresia = Convert.ToInt32(Fila["idMembresia"]);
                    oMembresia.idSocio = Convert.ToInt32(Fila["idSocio"]);
                    oMembresia.idActividad = Convert.ToInt32(Fila["idActividad"]);
                    oMembresia.idTurno = Convert.ToInt32(Fila["idTurno"]);
                    oMembresia.Duracion = Fila["Duracion"].ToString().Trim();
                    oMembresia.FechaInicio = Convert.ToDateTime(Fila["FechaInicio"]);
                    oMembresia.FechaVencimiento = Convert.ToDateTime(Fila["FechaVencimiento"]);
                    oMembresia.Precio = Convert.ToDecimal(Fila["Precio"]);
                    oMembresia.Descuento = Convert.ToDecimal(Fila["Descuento"]);
                    oMembresia.Total = Convert.ToDecimal(Fila["Total"]);
                    oMembresia.Estado = Convert.ToInt32(Fila["Estado"]);
                    return oMembresia;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public DataTable GetAll(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string stSQL = "SELECT  " + s_Columnas + " FROM Membresia " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public DataTable GetAllMix(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string s_SQL = "SELECT  " + s_Columnas + " FROM Membresia, Socio, Actividad, Turno " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public void Disable(int idMembresia)
        {
            string s_SQL = "UPDATE Membresia SET Estado=0 WHERE idMembresia=" + idMembresia;
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteScalar(s_SQL);
        }

        public void Delete(int idMembresia)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                string s_HistorialMembresias = "DELETE FROM HistorialMembresias WHERE HistorialMembresias.idMembresia=" + idMembresia;
                oDataAccess.ExecuteCommando(s_HistorialMembresias);  //BORRA EL HISTORIAL DE LA MEMBRESIA.

                string s_Cobros = "DELETE FROM PagoMembresia WHERE PagoMembresia.idMembresia=" + idMembresia;
                oDataAccess.ExecuteCommando(s_Cobros);  //BORRA LOS COBROS DE LA MEMBRESIA.

                string s_Membresia = "DELETE FROM Membresia WHERE Membresia.idMembresia=" + idMembresia;
                oDataAccess.ExecuteCommando(s_Membresia);  //BORRA LA MEMBRESIA.
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Devuelve un color segun el pago. Verde: completo, Amarillo: parcial y Rojo: nulo.
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public string ColorMembresia(int idMembresia)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_Membresia = "SELECT * FROM Membresia WHERE Membresia.idMembresia=" + idMembresia;
            DataTable dtMembresia = oDataAccess.ExecuteDataTable(s_Membresia);
            string s_PagoMembresia = "SELECT PagoMembresia.idPagoMembresia, PagoMembresia.idMembresia, PagoMembresia.Fecha, PagoMembresia.Monto FROM PagoMembresia, Membresia WHERE Membresia.idMembresia=" + idMembresia + " AND Membresia.idMembresia=PagoMembresia.idMembresia";
            DataTable dtPagoMembresia = oDataAccess.ExecuteDataTable(s_PagoMembresia);

            if (dtPagoMembresia.Rows.Count == 0)
            {
                return "Rojo";
            }
            else
            {
                decimal d_MontoCobros = 0;
                foreach (DataRow row in dtPagoMembresia.Rows)
                {
                    d_MontoCobros += Convert.ToDecimal(row["Monto"]);
                }
                if (d_MontoCobros < Convert.ToDecimal(dtMembresia.Rows[0]["Total"])) { return "Amarillo"; }
            }

            return "Verde";
        }

        /// <summary>
        /// Metodo encargado de controlar los vencimientos de las membresias y dar de bajas las vencidas. Tambien devuelve mensajes para informarle al socio sobre el estado de una membresia.
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idTurno"></param>
        /// <param name="Saldo"></param>
        /// <returns></returns>
        public string EstadoDelPago(int idMembresia, int idTurno, decimal Saldo)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                DateTime FechaVencimiento; //Membresia.FechaVencimiento
                TimeSpan Dias; //Diferencia de dias entre dos fechas
                Membresias oMembresias = new Membresias();
                HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                HistorialesMembresias.HistorialMembresias oHistorialMembresias = new HistorialesMembresias.HistorialMembresias();

                string s_Membresia = "SELECT * FROM Membresia WHERE Membresia.idMembresia=" + idMembresia + " AND Membresia.Estado=1";
                DataTable dtMembresia = oDataAccess.ExecuteDataTable(s_Membresia);
                string s_Cobro = "SELECT TOP 1 PagoMembresia.idMembresia, PagoMembresia.Fecha, PagoMembresia.Monto FROM PagoMembresia, Membresia WHERE Membresia.idMembresia=" + idMembresia + " AND Membresia.Estado=1 AND Membresia.idMembresia=PagoMembresia.idMembresia";
                DataTable dtCobro = oDataAccess.ExecuteDataTable(s_Cobro);

                if (Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]) == DateTime.Now.Date) //Membresia.FechaVencimiento es hoy, independientemente de si hay pago o no.
                {
                    return "Recuerda que hoy vence esta membresia. Comunicate con tu profesor para renovarla.";
                }

                if (dtCobro.Rows.Count == 0 && Convert.ToDateTime(dtMembresia.Rows[0]["FechaInicio"]).AddDays(30) < DateTime.Now.Date) //No hay pago y Membresia.FechaInicio+30 es menor a la fecha actual, se da de baja la membresia. Si pasan los 30 dias del inicio y no pago, se da de baja.
                {
                    oMembresias.Disable(idMembresia);
                    oHistorialMembresias.idMembresia = idMembresia;
                    oHistorialMembresias.Fecha = DateTime.Now.Date;
                    oHistorialMembresias.Concepto = "Baja";
                    oHistorialMembresias.Saldo = Saldo;
                    oHistorialesMembresias.Insert(oHistorialMembresias);

                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno + " AND idSocio=" + dtMembresia.Rows[0]["idSocio"].ToString());
                    Turnos oTurnos = new Turnos();
                    oTurnos.AddInscripto(idTurno, -1);
                    return "Baja";
                }

                if (Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]) < DateTime.Now.Date) //Membresia.FechaVencimiento es menor a la fecha actual, se da de baja. Independientemente de si hay pago o no.
                {
                    oMembresias.Disable(idMembresia);
                    oHistorialMembresias.idMembresia = idMembresia;
                    oHistorialMembresias.Fecha = DateTime.Now.Date;
                    oHistorialMembresias.Concepto = "Baja";
                    oHistorialMembresias.Saldo = Saldo;
                    oHistorialesMembresias.Insert(oHistorialMembresias);

                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno + " AND idSocio=" + dtMembresia.Rows[0]["idSocio"].ToString());
                    Turnos oTurnos = new Turnos();
                    oTurnos.AddInscripto(idTurno, -1);
                    return "Baja";
                }

                if (dtCobro.Rows.Count == 0 && Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]) > DateTime.Now.Date) //No hay pago y Membresia.FechaVencimiento es mayor a la fecha actual.
                {
                    FechaVencimiento = Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]);
                    Dias = DateTime.Now.Date.Subtract(FechaVencimiento);
                    if ((Dias.Days * -1) > 10) { return "Recuerda que aun no has abonado por esta membresia. Por favor, comunicate con tu profesor para regularizar tu situacion."; }
                    if ((Dias.Days * -1) <= 10 && (Dias.Days * -1) >= 1) { return "Recuerda que aun no has abonado por esta membresia. Faltan " + Convert.ToString(Dias.Days * -1) + " dia(s) para su vencimiento."; }
                }

                if (dtCobro.Rows.Count == 1 && Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]) > DateTime.Now.Date) //Si hay pago y Membresia.FechaVencimiento es mayor que la fecha actual.
                {
                    FechaVencimiento = Convert.ToDateTime(dtMembresia.Rows[0]["FechaVencimiento"]);
                    Dias = DateTime.Now.Date.Subtract(FechaVencimiento);
                    if ((Dias.Days * -1) <= 10 && (Dias.Days * -1) > 4) { return "Recuerda que faltan " + (Dias.Days * -1).ToString() + " dia(s) para el vencimiento de esta membresia."; }
                    if ((Dias.Days * -1) <= 3) { return "Recuerda que faltan " + (Dias.Days * -1).ToString() + " dia(s) para el vencimiento de esta membresia. Comunicate con tu profesor para renovarla."; }
                }

                return "";
            }
            catch (Exception) { return ""; }
        }

        /// <summary>
        /// Devuelve un string con el monto abonado por una membresia.
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public string CuantoPago(int idMembresia)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_Membresia = "SELECT * FROM Membresia WHERE Membresia.idMembresia=" + idMembresia;
            DataTable dtMembresia = oDataAccess.ExecuteDataTable(s_Membresia);
            string s_PagoMembresia = "SELECT PagoMembresia.idPagoMembresia, PagoMembresia.idMembresia, PagoMembresia.Fecha, PagoMembresia.Monto FROM PagoMembresia, Membresia WHERE Membresia.idMembresia=" + idMembresia + " AND Membresia.idMembresia=PagoMembresia.idMembresia";
            DataTable dtPagoMembresia = oDataAccess.ExecuteDataTable(s_PagoMembresia);

            if (dtPagoMembresia.Rows.Count == 0)
            {
                return "0,00";
            }
            else
            {
                decimal d_MontoPagos = 0;
                foreach (DataRow row in dtPagoMembresia.Rows)
                {
                    d_MontoPagos += Convert.ToDecimal(row["Monto"]);
                }
                return d_MontoPagos.ToString();
            }
        }

        public int GetidMembresia(int idSocio, int idTurno)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_SQL = "SELECT Membresia.idMembresia, Membresia.idSocio, Membresia.idActividad, Membresia.idTurno, Membresia.FechaInicio, Membresia.FechaVencimiento, Membresia.Duracion, Membresia.Precio, Membresia.Descuento FROM Membresia, Socio, Turno WHERE Socio.idSocio=" + idSocio + " AND Turno.idTurno=" + idTurno + " AND Membresia.idSocio=Socio.idSocio AND Membresia.idTurno=Turno.idTurno AND Membresia.Estado=1";
            DataTable dtMembresia = oDataAccess.ExecuteDataTable(s_SQL);
            int i_idMembresia = Convert.ToInt32(dtMembresia.Rows[0]["idMembresia"]);
            return i_idMembresia;
        }
    }
}