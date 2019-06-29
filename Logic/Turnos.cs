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
    public class Turnos
    {
        public class Turno
        {
            private int m_idTurno;
            public int idTurno
            {
                get { return m_idTurno; }
                set { m_idTurno = value; }
            }

            private int m_idActividad;
            public int idActividad
            {
                get { return m_idActividad; }
                set { m_idActividad = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private string m_Dias;
            public string Dias
            {
                get { return m_Dias; }
                set { m_Dias = value; }
            }

            private string m_Hora;
            public string Hora
            {
                get { return m_Hora; }
                set { m_Hora = value; }
            }

            private int m_Inscriptos;
            public int Inscriptos
            {
                get { return m_Inscriptos; }
                set { m_Inscriptos = value; }
            }

        }

        public int Insert(Turno Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Turno(idActividad, Nombre, Dias, Hora, Inscriptos) VALUES(@idActividad, @Nombre, @Dias, @Hora, @Inscriptos)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("idActividad", Dato.idActividad);
            cmdInsert.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdInsert.Parameters.AddWithValue("Dias", Dato.Dias);
            cmdInsert.Parameters.AddWithValue("Hora", Dato.Hora);
            cmdInsert.Parameters.AddWithValue("Inscriptos", Dato.Inscriptos);

            oDataAccess.ExecuteCommando(cmdInsert);
            string stTop = "SELECT TOP 1 idTurno FROM Turno ORDER BY idTurno DESC";
            Int32 id = Convert.ToInt32(oDataAccess.ExecuteScalar(stTop));
            return id;
        }

        public void Update(Turno Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Turno SET idActividad=@idActividad, Nombre=@Nombre, Dias=@Dias, Hora=@Hora WHERE idTurno=@idTurno", oDataAccess.Connection);
            cmdUpdate.Parameters.AddWithValue("idTurno", Dato.idTurno);
            cmdUpdate.Parameters.AddWithValue("idActividad", Dato.idActividad);
            cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdUpdate.Parameters.AddWithValue("Dias", Dato.Dias);
            cmdUpdate.Parameters.AddWithValue("Hora", Dato.Hora);

            Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT  " + sColumnas + " FROM Turno " + sFiltro;

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

        public int GetInscriptos(int idTurno)
        {
            string stSQL = "SELECT Inscriptos FROM Turno WHERE idTurno=" + idTurno;
            DataAccess oDataAccess = new DataAccess();
            int inscriptos = Convert.ToInt32(oDataAccess.ExecuteScalar(stSQL));
            return inscriptos;
        }

        public int GetInscriptos(string NombreTurno, int idActividad)
        {
            string stSQL = "SELECT Inscriptos FROM Turno WHERE Nombre='" + NombreTurno + "' AND idActividad=" + idActividad;
            DataAccess oDataAccess = new DataAccess();
            int inscriptos = Convert.ToInt32(oDataAccess.ExecuteScalar(stSQL));
            return inscriptos;
        }

        public void AddInscripto(int idTurno, int Valor)
        {
            string stSQL = "UPDATE Turno SET Inscriptos=Inscriptos+" + Valor + " WHERE idTurno=" + idTurno;
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteScalar(stSQL);
        }

        public int GetID(string NombreTurno, int idActividad)
        {
            string stSQL = "SELECT idTurno FROM Turno WHERE Nombre='" + NombreTurno + "' AND idActividad=" + idActividad;
            DataAccess oDataAccess = new DataAccess();
            int id = Convert.ToInt32(oDataAccess.ExecuteScalar(stSQL));
            return id;
        }

        /// <summary>
        /// Devuelve un string con los dias en que se da ese turno. Es igual a la de Magnetar Control Access pero devuelve el string un poco diferente.
        /// </summary>
        /// <param name="idTurno">Clave primaria de la tabla Turno.</param>
        /// <returns></returns>
        public string GetDias(int idTurno)
        {
            try
            {
                string s_SQL = "SELECT Dias FROM Turno WHERE idTurno=" + idTurno;
                DataAccess oDataAccess = new DataAccess();
                DataTable dtDias = oDataAccess.ExecuteDataTable(s_SQL);

                string dias = "";
                if (dtDias.Rows[0]["Dias"].ToString().Contains("lunes")) { if (dias == "") { dias = "Lunes"; } else { dias += "-Lunes"; } }
                if (dtDias.Rows[0]["Dias"].ToString().Contains("martes")) { if (dias == "") { dias = "Martes"; } else { dias += "-Martes"; } }
                if (dtDias.Rows[0]["Dias"].ToString().Contains("miércoles")) { if (dias == "") { dias = "Miércoles"; } else { dias += "-Miércoles"; } }
                if (dtDias.Rows[0]["Dias"].ToString().Contains("jueves")) { if (dias == "") { dias = "Jueves"; } else { dias += "-Jueves"; } }
                if (dtDias.Rows[0]["Dias"].ToString().Contains("viernes")) { if (dias == "") { dias = "Viernes"; } else { dias += "-Viernes"; } }
                if (dtDias.Rows[0]["Dias"].ToString().Contains("sábado")) { if (dias == "") { dias = "Sábado"; } else { dias += "-Sábado"; } }

                return dias;
            }
            catch (Exception) { return ""; }
        }
    }
}
