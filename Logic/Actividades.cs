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
    public class Actividades
    {
        public class Actividad
        {
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

            private decimal m_Cupo;
            public decimal Cupo
            {
                get { return m_Cupo; }
                set { m_Cupo = value; }
            }

            private decimal m_PrecioClase;
            public decimal PrecioClase
            {
                get { return m_PrecioClase; }
                set { m_PrecioClase = value; }
            }
            private decimal m_PrecioSemana;
            public decimal PrecioSemana
            {
                get { return m_PrecioSemana; }
                set { m_PrecioSemana = value; }
            }

            private decimal m_PrecioMes;
            public decimal PrecioMes
            {
                get { return m_PrecioMes; }
                set { m_PrecioMes = value; }
            }

            private decimal m_PrecioTrimestre;
            public decimal PrecioTrimestre
            {
                get { return m_PrecioTrimestre; }
                set { m_PrecioTrimestre = value; }
            }

            private decimal m_PrecioOtro1;
            public decimal PrecioOtro1
            {
                get { return m_PrecioOtro1; }
                set { m_PrecioOtro1 = value; }
            }

            private decimal m_PrecioOtro2;
            public decimal PrecioOtro2
            {
                get { return m_PrecioOtro2; }
                set { m_PrecioOtro2 = value; }
            }

            private int m_Estado;
            public int Estado
            {
                get { return m_Estado; }
                set { m_Estado = value; }
            }
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            try
            {
                if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
                string stSQL = "SELECT  " + sColumnas + " FROM Actividad " + sFiltro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Devuelve un datatable con las actividades relacionadas a un profesor en particular.
        /// </summary>
        /// <param name="sColumnas"></param>
        /// <param name="sFiltro"></param>
        /// <returns></returns>
        public DataTable GetAllProfesor(int idProfesor)
        {
            try
            {
                string s_SQL = "SELECT Actividad.Nombre as 'Actividades' FROM Actividad, Profesor, ProfesorxActividad WHERE Actividad.idActividad=ProfesorxActividad.idActividad AND Profesor.idProfesor=ProfesorxActividad.idProfesor AND Profesor.idProfesor=" + idProfesor;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Insert(Actividad Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Actividad(Nombre, Cupo, PrecioClase, PrecioSemana, PrecioMes, PrecioTrimestre, PrecioOtro1, PrecioOtro2, Estado) VALUES(@Nombre, @Cupo, @PrecioClase, @PrecioSemana, @PrecioMes, @PrecioTrimestre, @PrecioOtro1, @PrecioOtro2, @Estado)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdInsert.Parameters.AddWithValue("Cupo", Dato.Cupo);
            cmdInsert.Parameters.AddWithValue("PrecioClase", Dato.PrecioClase);
            cmdInsert.Parameters.AddWithValue("PrecioSemana", Dato.PrecioSemana);
            cmdInsert.Parameters.AddWithValue("PrecioMes", Dato.PrecioMes);
            cmdInsert.Parameters.AddWithValue("PrecioTrimestre", Dato.PrecioTrimestre);
            cmdInsert.Parameters.AddWithValue("PrecioOtro1", Dato.PrecioOtro1);
            cmdInsert.Parameters.AddWithValue("PrecioOtro2", Dato.PrecioOtro2);
            cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

            oDataAccess.ExecuteCommando(cmdInsert);
            string stTop = "SELECT TOP 1 idActividad FROM Actividad ORDER BY idActividad DESC";
            int id = Convert.ToInt32(oDataAccess.ExecuteScalar(stTop));
            return id;
        }

        public Actividad GetOne(int idActividad)
        {
            string stSQL = "SELECT * FROM Actividad WHERE idActividad=" + idActividad;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Actividad oActividad = new Actividad();
                try
                {
                    oActividad.idActividad = Convert.ToInt32(Fila["idActividad"]);
                    oActividad.Nombre = Fila["Nombre"].ToString();
                    oActividad.Cupo = Convert.ToDecimal(Fila["Cupo"]);
                    oActividad.PrecioClase = Convert.ToDecimal(Fila["PrecioClase"]);
                    oActividad.PrecioSemana = Convert.ToDecimal(Fila["PrecioSemana"]);
                    oActividad.PrecioMes = Convert.ToDecimal(Fila["PrecioMes"]);
                    oActividad.PrecioTrimestre = Convert.ToDecimal(Fila["PrecioTrimestre"]);
                    oActividad.PrecioOtro1 = Convert.ToDecimal(Fila["PrecioOtro1"]);
                    oActividad.PrecioOtro2 = Convert.ToDecimal(Fila["PrecioOtro2"]);
                    oActividad.Estado = Convert.ToInt32(Fila["Estado"]);
                    return oActividad;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public void Update(Actividad Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Actividad SET Nombre=@Nombre, Cupo=@Cupo, PrecioClase=@PrecioClase, PrecioSemana=@PrecioSemana, PrecioMes=@PrecioMes, PrecioTrimestre=@PrecioTrimestre, PrecioOtro1=@PrecioOtro1, PrecioOtro2=@PrecioOtro2 WHERE idActividad=@idActividad", oDataAccess.Connection);
            cmdUpdate.Parameters.AddWithValue("idActividad", Dato.idActividad);
            cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdUpdate.Parameters.AddWithValue("Cupo", Dato.Cupo);
            cmdUpdate.Parameters.AddWithValue("PrecioClase", Dato.PrecioClase);
            cmdUpdate.Parameters.AddWithValue("PrecioSemana", Dato.PrecioSemana);
            cmdUpdate.Parameters.AddWithValue("PrecioMes", Dato.PrecioMes);
            cmdUpdate.Parameters.AddWithValue("PrecioTrimestre", Dato.PrecioTrimestre);
            cmdUpdate.Parameters.AddWithValue("PrecioOtro1", Dato.PrecioOtro1);
            cmdUpdate.Parameters.AddWithValue("PrecioOtro2", Dato.PrecioOtro2);

            Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
        }

        public void Disable(int idActividad)
        {
            string stSQL = "UPDATE Actividad SET Estado=0 WHERE idActividad=" + idActividad;
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteScalar(stSQL);
        }

        public int GetPrecio(int idActividad, string Precio)
        {
            string stSQL = "SELECT " + Precio + " FROM Actividad WHERE idActividad=" + idActividad + " AND Actividad.Estado=1";

            DataAccess oDataAccess = new DataAccess();
            int p = Convert.ToInt32(oDataAccess.ExecuteScalar(stSQL));
            return p;
        }

        public int GetCupo(int idActividad)
        {
            string stSQL = "SELECT Cupo FROM Actividad WHERE idActividad=" + idActividad + " AND Actividad.Estado=1";
            DataAccess oDataAccess = new DataAccess();
            int c = Convert.ToInt32(oDataAccess.ExecuteScalar(stSQL));
            return c;
        }
    }
}
