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
    public class Publicidades
    {
        public class Publicidad
        {
            private int m_idPublicidad;
            public int idPublicidad
            {
                get { return m_idPublicidad; }
                set { m_idPublicidad = value; }
            }

            private string m_Texto;
            public string Texto
            {
                get { return m_Texto; }
                set { m_Texto = value; }
            }

            private string m_Imagen;
            public string Imagen
            {
                get { return m_Imagen; }
                set { m_Imagen = value; }
            }

            private string m_SizeMode;
            public string SizeMode
            {
                get { return m_SizeMode; }
                set { m_SizeMode = value; }
            }
        }

        public int Insert(Publicidad Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand Insert = new SqlCommand("INSERT INTO Publicidad(Texto, Imagen, SizeMode) VALUES(@Texto, @Imagen, @SizeMode)", oDataAccess.Connection);
            Insert.Parameters.AddWithValue("Texto", Dato.Texto);
            Insert.Parameters.AddWithValue("Imagen", Dato.Imagen);
            Insert.Parameters.AddWithValue("SizeMode", Dato.SizeMode);

            int id = oDataAccess.ExecuteCommando(Insert);
            return id;
        }

        public Publicidad GetTheOne()
        {
            string stSQL = "SELECT TOP(1) * FROM Publicidad";

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Publicidad oPublicidad = new Publicidad();
                try
                {
                    oPublicidad.Texto = Fila["Texto"].ToString().Trim();
                    oPublicidad.Imagen = Fila["Imagen"].ToString().Trim();
                    oPublicidad.SizeMode = Fila["SizeMode"].ToString().Trim();
                    return oPublicidad;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public int TruncateTable()
        {
            string stSQL = "TRUNCATE TABLE Publicidad";
            DataAccess oDataAccess = new DataAccess();
            int id = oDataAccess.ExecuteCommando(stSQL);
            return id;
        }
    }
}