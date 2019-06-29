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
    public class Localidades
    {
        public class Localidad
        {
            private int m_idLocalidad;
            public int idLocalidad
            {
                get { return m_idLocalidad; }
                set { m_idLocalidad = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private int m_CodigoPostal;
            public int CodigoPostal
            {
                get { return m_CodigoPostal; }
                set { m_CodigoPostal = value; }
            }

            private string m_Provincia;
            public string Provincia
            {
                get { return m_Provincia; }
                set { m_Provincia = value; }
            }

            private string m_Pais;
            public string Pais
            {
                get { return m_Pais; }
                set { m_Pais = value; }
            }
        }

        public int Insert(Localidad Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand Insert = new SqlCommand("INSERT INTO Localidad(Nombre, CodigoPostal, Provincia, Pais) VALUES(@Nombre, @CodigoPostal, @Provincia, @Pais)", oDataAccess.Connection);
                Insert.Parameters.AddWithValue("Nombre", Dato.Nombre);
                Insert.Parameters.AddWithValue("CodigoPostal", Dato.CodigoPostal);
                Insert.Parameters.AddWithValue("Provincia", Dato.Provincia);
                Insert.Parameters.AddWithValue("Pais", Dato.Pais);

                int id = oDataAccess.ExecuteCommando(Insert);
                return id;
            }
            catch (Exception) { return -1; }
        }

        public void Update(Localidad Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Localidad SET Nombre=@Nombre, CodigoPostal=@CodigoPostal, Provincia=@Provincia, Pais=@Pais WHERE idLocalidad=@idLocalidad", oDataAccess.Connection);
                cmdUpdate.Parameters.AddWithValue("idLocalidad", Dato.idLocalidad);
                cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
                cmdUpdate.Parameters.AddWithValue("CodigoPostal", Dato.CodigoPostal);
                cmdUpdate.Parameters.AddWithValue("Provincia", Dato.Provincia);
                cmdUpdate.Parameters.AddWithValue("Pais", Dato.Pais);

                oDataAccess.ExecuteCommando(cmdUpdate);
            }
            catch (Exception) { }
        }

        public Localidad GetOne(int idLocalidad)
        {
            string stSQL = "SELECT * FROM Localidad WHERE idLocalidad=" + idLocalidad;
            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Localidad oLocalidad = new Localidad();
                try
                {
                    oLocalidad.idLocalidad = Convert.ToInt32(Fila["idLocalidad"]);
                    oLocalidad.Nombre = Fila["Nombre"].ToString().Trim();
                    oLocalidad.CodigoPostal = Convert.ToInt32(Fila["CodigoPostal"]);
                    oLocalidad.Provincia = Fila["Provincia"].ToString().Trim();
                    oLocalidad.Pais = Fila["Pais"].ToString().Trim();
                    return oLocalidad;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public DataTable GetAll(string sColumnas, string sFiltro)
        {
            try
            {
                if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
                string stSQL = "SELECT " + sColumnas + " FROM Localidad" + sFiltro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Delete(string s_Filtro)
        {
            try
            {
                string s_SQL = "DELETE FROM Localidad WHERE " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                int id = oDataAccess.ExecuteCommando(s_SQL);
                return id;
            }
            catch (Exception) { return -1; }
        }
    }
}