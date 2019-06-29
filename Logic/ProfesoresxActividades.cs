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
    public class ProfesoresxActividades
    {
        public class ProfesorxActividad
        {
            private int m_idProfesorxActividad;
            public int idProfesorxActividad
            {
                get { return m_idProfesorxActividad; }
                set { m_idProfesorxActividad = value; }
            }

            private int m_idProfesor;
            public int idProfesor
            {
                get { return m_idProfesor; }
                set { m_idProfesor = value; }
            }

            private int m_idActividad;
            public int idActividad
            {
                get { return m_idActividad; }
                set { m_idActividad = value; }
            }
        }

        public int Insert(ProfesorxActividad Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO ProfesorxActividad(idProfesor, idActividad) VALUES(@idProfesor, @idActividad)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("idProfesor", Dato.idProfesor);
            cmdInsert.Parameters.AddWithValue("idActividad", Dato.idActividad);

            int id = oDataAccess.ExecuteCommando(cmdInsert);
            return id;
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT  " + sColumnas + " FROM ProfesorxActividad" + sFiltro;

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
    }
}