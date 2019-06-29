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
    public class Servicios
    {
        public class Servicio
        {
            private int m_idServicio;
            public int idServicio
            {
                get { return m_idServicio; }
                set { m_idServicio = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private decimal m_Precio1;
            public decimal Precio1
            {
                get { return m_Precio1; }
                set { m_Precio1 = value; }
            }

            private decimal m_Precio2;
            public decimal Precio2
            {
                get { return m_Precio2; }
                set { m_Precio2 = value; }
            }

            private string m_Descripcion;
            public string Descripcion
            {
                get { return m_Descripcion; }
                set { m_Descripcion = value; }
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
            if (sFiltro.Length != 0) sFiltro = " WHERE " + sFiltro;
            string stSQL = "SELECT  " + sColumnas + " FROM Servicio " + sFiltro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
        }

        public int Insert(Servicio Dato)
        {
            DataAccess oDataAccess = new DataAccess();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Servicio(Nombre, Precio1, Precio2, Descripcion, Estado) VALUES(@Nombre, @Precio1, @Precio2, @Descripcion, @Estado)", oDataAccess.Connection);
            cmdInsert.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdInsert.Parameters.AddWithValue("Precio1", Dato.Precio1);
            cmdInsert.Parameters.AddWithValue("Precio2", Dato.Precio2);
            cmdInsert.Parameters.AddWithValue("Descripcion", Dato.Descripcion);
            cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

            int id = Convert.ToInt32(oDataAccess.ExecuteCommando(cmdInsert));
            return id;
        }

        public Servicio GetOne(int idServicio)
        {
            string stSQL = "SELECT * FROM Servicio WHERE idServicio=" + idServicio;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Servicio oServicio = new Servicio();
                try
                {
                    oServicio.idServicio = Convert.ToInt32(Fila["idServicio"]);
                    oServicio.Nombre = Fila["Nombre"].ToString();
                    oServicio.Precio1 = Convert.ToDecimal(Fila["Precio1"]);
                    oServicio.Precio2 = Convert.ToDecimal(Fila["Precio2"]);
                    oServicio.Descripcion = Fila["Descripcion"].ToString();
                    oServicio.Estado = Convert.ToInt32(Fila["Estado"]);
                    return oServicio;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public void Update(Servicio Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Servicio SET Nombre=@Nombre, Precio1=@Precio1, Precio2=@Precio2, Descripcion=@Descripcion WHERE idServicio=@idServicio", oDataAccess.Connection);
            cmdUpdate.Parameters.AddWithValue("idServicio", Dato.idServicio);
            cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
            cmdUpdate.Parameters.AddWithValue("Precio1", Dato.Precio1);
            cmdUpdate.Parameters.AddWithValue("Precio2", Dato.Precio2);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Dato.Descripcion);

            Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
        }

        public void Disable(int idServicio)
        {
            string stSQL = "UPDATE Servicio SET Estado=0 WHERE idServicio=" + idServicio;
            DataAccess oDataAccess = new DataAccess();
            oDataAccess.ExecuteScalar(stSQL);
        }
    }
}