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
    public class Rutinas
    {
        public class Rutina
        {
            private int m_idRutina;
            public int idRutina
            {
                get { return m_idRutina; }
                set { m_idRutina = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private int m_Duracion;
            public int Duracion
            {
                get { return m_Duracion; }
                set { m_Duracion = value; }
            }

            private string m_Contenido;
            public string Contenido
            {
                get { return m_Contenido; }
                set { m_Contenido = value; }
            }
        }

        public int Insert(Rutina Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Rutina(Nombre, Duracion, Contenido) VALUES(@Nombre, @Duracion, @Contenido)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdInsert.Parameters.AddWithValue("Duracion", Dato.Duracion);
            cmdInsert.Parameters.AddWithValue("Contenido", Dato.Contenido);

            int id = oDataAccess.ExecuteCommando(cmdInsert);
            return id;
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT " + sColumnas + " FROM Rutina " + sFiltro;

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

        public Rutina GetOne(int idRutina)
        {
            string stSQL = "SELECT * FROM Rutina WHERE idRutina=" + idRutina;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Rutina oPlan = new Rutina();
                try
                {
                    oPlan.idRutina = Convert.ToInt32(Fila["idRutina"]);
                    oPlan.Nombre = Fila["Nombre"].ToString().Trim();
                    oPlan.Duracion = Convert.ToInt32(Fila["Duracion"]);
                    oPlan.Contenido = Fila["Contenido"].ToString().Trim();
                    return oPlan;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public void Update(Rutina Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Rutina SET Nombre=@Nombre, Duracion=@Duracion, Contenido=@Contenido WHERE idRutina=@idRutina", oDataAccess.Connection);
            cmdUpdate.Parameters.AddWithValue("idRutina", Dato.idRutina);
            cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdUpdate.Parameters.AddWithValue("Duracion", Dato.Duracion);
            cmdUpdate.Parameters.AddWithValue("Contenido", Dato.Contenido);

            Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
        }
    }
}
