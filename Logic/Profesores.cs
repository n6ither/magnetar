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
    public class Profesores
    {
        public class Profesor
        {
            private int m_idProfesor;
            public int idProfesor
            {
                get { return m_idProfesor; }
                set { m_idProfesor = value; }
            }

            private int m_NroDoc;
            public int NroDoc
            {
                get { return m_NroDoc; }
                set { m_NroDoc = value; }
            }

            private string m_Nombre;
            public string Nombre
            {
                get { return m_Nombre; }
                set { m_Nombre = value; }
            }

            private string m_Apellido;
            public string Apellido
            {
                get { return m_Apellido; }
                set { m_Apellido = value; }
            }

            private DateTime m_FechaNacimiento;
            public DateTime FechaNacimiento
            {
                get { return m_FechaNacimiento; }
                set { m_FechaNacimiento = value; }
            }

            private int m_Edad;
            public int Edad
            {
                get { return m_Edad; }
                set { m_Edad = value; }
            }

            private string m_Sexo;
            public string Sexo
            {
                get { return m_Sexo; }
                set { m_Sexo = value; }
            }

            private string m_Direccion;
            public string Direccion
            {
                get { return m_Direccion; }
                set { m_Direccion = value; }
            }

            private int m_idLocalidad;
            public int idLocalidad
            {
                get { return m_idLocalidad; }
                set { m_idLocalidad = value; }
            }

            private string m_TelefonoFijo;
            public string TelefonoFijo
            {
                get { return m_TelefonoFijo; }
                set { m_TelefonoFijo = value; }
            }

            private string m_TelefonoCelular;
            public string TelefonoCelular
            {
                get { return m_TelefonoCelular; }
                set { m_TelefonoCelular = value; }
            }

            private string m_Email;
            public string Email
            {
                get { return m_Email; }
                set { m_Email = value; }
            }

            private string m_Ocupacion;
            public string Ocupacion
            {
                get { return m_Ocupacion; }
                set { m_Ocupacion = value; }
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

            private DateTime m_FechaRegistracion;
            public DateTime FechaRegistracion
            {
                get { return m_FechaRegistracion; }
                set { m_FechaRegistracion = value; }
            }

            private int m_Estado;
            public int Estado
            {
                get { return m_Estado; }
                set { m_Estado = value; }
            }
        }

        /// <summary>
        /// Devuelve un DataTable con los primeros 100 profesores y sus localidades haciendo un FULL OUTER JOIN.
        /// </summary>
        /// <param name="s_Columnas">Datos a mostrar en la clausula SELECT.</param>
        /// <param name="s_Filtro">Condicion en la clausula WHERE.</param>
        /// <returns></returns>
        public DataTable GetTop100PL(string s_Columnas, string s_Filtro)
        {
            if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
            string stSQL = "SELECT TOP 100  " + s_Columnas + " FROM Profesor P FULL OUTER JOIN Localidad L ON P.idLocalidad=L.idLocalidad " + s_Filtro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
        }

        /// <summary>
        /// Devuelve un DataTable con todos los profesores y sus localidades haciendo un FULL OUTER JOIN.
        /// </summary>
        /// <param name="s_Columnas">Datos a mostrar en la clausula SELECT.</param>
        /// <param name="s_Filtro">Condicion en la clausula WHERE.</param>
        /// <returns></returns>
        public DataTable GetAllPL(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string s_SQL = "SELECT " + s_Columnas + " FROM Profesor P FULL OUTER JOIN Localidad L ON P.idLocalidad=L.idLocalidad " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int Insert(Profesor Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Profesor(NroDoc, Nombre, Apellido, FechaNacimiento, Edad, Sexo, Direccion, idLocalidad, TelefonoFijo, TelefonoCelular, Email, Ocupacion, Imagen, SizeMode, FechaRegistracion, Estado) VALUES(@NroDoc, @Nombre, @Apellido, @FechaNacimiento, @Edad, @Sexo, @Direccion, @idLocalidad, @TelefonoFijo, @TelefonoCelular, @Email, @Ocupacion, @Imagen, @SizeMode, @FechaRegistracion, @Estado)", oDataAccess.Connection);
                cmdInsert.Parameters.AddWithValue("NroDoc", Dato.NroDoc);
                cmdInsert.Parameters.AddWithValue("Nombre", Dato.Nombre);
                cmdInsert.Parameters.AddWithValue("Apellido", Dato.Apellido);
                cmdInsert.Parameters.AddWithValue("FechaNacimiento", Dato.FechaNacimiento);
                cmdInsert.Parameters.AddWithValue("Edad", Dato.Edad);
                cmdInsert.Parameters.AddWithValue("Sexo", Dato.Sexo);
                cmdInsert.Parameters.AddWithValue("Direccion", Dato.Direccion);
                cmdInsert.Parameters.AddWithValue("idLocalidad", Dato.idLocalidad);
                cmdInsert.Parameters.AddWithValue("TelefonoFijo", Dato.TelefonoFijo);
                cmdInsert.Parameters.AddWithValue("TelefonoCelular", Dato.TelefonoCelular);
                cmdInsert.Parameters.AddWithValue("Email", Dato.Email);
                cmdInsert.Parameters.AddWithValue("Ocupacion", Dato.Ocupacion);
                cmdInsert.Parameters.AddWithValue("Imagen", Dato.Imagen);
                cmdInsert.Parameters.AddWithValue("SizeMode", Dato.SizeMode);
                cmdInsert.Parameters.AddWithValue("FechaRegistracion", Dato.FechaRegistracion);
                cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

                oDataAccess.ExecuteCommando(cmdInsert);
                string stTop = "SELECT TOP 1 idProfesor FROM Profesor ORDER BY idProfesor DESC";
                Int32 id = Convert.ToInt32(oDataAccess.ExecuteScalar(stTop));
                return id;
            }
            catch (Exception) { return -1; }
        }

        public Profesor GetOne(int idProfesor)
        {
            string stSQL = "SELECT * FROM Profesor WHERE idProfesor=" + idProfesor;
            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Profesor oProfesor = new Profesor();
                try
                {
                    oProfesor.idProfesor = Convert.ToInt32(Fila["idProfesor"]);
                    oProfesor.NroDoc = Convert.ToInt32(Fila["NroDoc"]);
                    oProfesor.Nombre = Fila["Nombre"].ToString();
                    oProfesor.Apellido = Fila["Apellido"].ToString();
                    oProfesor.FechaNacimiento = Convert.ToDateTime(Fila["FechaNacimiento"]);
                    oProfesor.Edad = Convert.ToInt32(Fila["Edad"]);
                    oProfesor.Sexo = Fila["Sexo"].ToString();
                    oProfesor.Direccion = Fila["Direccion"].ToString();
                    oProfesor.idLocalidad = Convert.ToInt32(Fila["idLocalidad"]);
                    oProfesor.TelefonoFijo = Fila["TelefonoFijo"].ToString();
                    oProfesor.TelefonoCelular = Fila["TelefonoCelular"].ToString();
                    oProfesor.Email = Fila["Email"].ToString();
                    oProfesor.Ocupacion = Fila["Ocupacion"].ToString();
                    oProfesor.Imagen = Fila["Imagen"].ToString();
                    oProfesor.SizeMode = Fila["SizeMode"].ToString();
                    oProfesor.FechaRegistracion = Convert.ToDateTime(Fila["FechaRegistracion"]);
                    oProfesor.Estado = Convert.ToInt32(Fila["Estado"]);
                    return oProfesor;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public void Update(Profesor Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdUpdate = new SqlCommand("UPDATE Profesor SET NroDoc=@NroDoc, Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, Edad=@Edad, Sexo=@Sexo, Direccion=@Direccion, idLocalidad=@idLocalidad, TelefonoFijo=@TelefonoFijo, TelefonoCelular=@TelefonoCelular, Email=@Email, Ocupacion=@Ocupacion, Imagen=@Imagen, SizeMode=@SizeMode, Estado=@Estado WHERE idProfesor=@idProfesor", oDataAccess.Connection);
                cmdUpdate.Parameters.AddWithValue("idProfesor", Dato.idProfesor);
                cmdUpdate.Parameters.AddWithValue("NroDoc", Dato.NroDoc);
                cmdUpdate.Parameters.AddWithValue("Nombre", Dato.Nombre);
                cmdUpdate.Parameters.AddWithValue("Apellido", Dato.Apellido);
                cmdUpdate.Parameters.AddWithValue("FechaNacimiento", Dato.FechaNacimiento);
                cmdUpdate.Parameters.AddWithValue("Edad", Dato.Edad);
                cmdUpdate.Parameters.AddWithValue("Sexo", Dato.Sexo);
                cmdUpdate.Parameters.AddWithValue("Direccion", Dato.Direccion);
                cmdUpdate.Parameters.AddWithValue("idLocalidad", Dato.idLocalidad);
                cmdUpdate.Parameters.AddWithValue("TelefonoFijo", Dato.TelefonoFijo);
                cmdUpdate.Parameters.AddWithValue("TelefonoCelular", Dato.TelefonoCelular);
                cmdUpdate.Parameters.AddWithValue("Email", Dato.Email);
                cmdUpdate.Parameters.AddWithValue("Ocupacion", Dato.Ocupacion);
                cmdUpdate.Parameters.AddWithValue("Imagen", Dato.Imagen);
                cmdUpdate.Parameters.AddWithValue("SizeMode", Dato.SizeMode);
                cmdUpdate.Parameters.AddWithValue("Estado", Dato.Estado);

                Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
            }
            catch (Exception) { }
        }

        public string ValidarDocumento(string NroDoc)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_SQL = "SELECT Estado FROM Profesor WHERE Profesor.NroDoc='" + NroDoc + "'";
            DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
            if (DT.Rows.Count == 1)
            {
                if (Convert.ToInt32(DT.Rows[0]["Estado"]) == 0) { return "Ya existe un profesor con ese numero de documento. Se encuentra en la lista de profesores inactivos. Por favor, verifica."; }
                if (Convert.ToInt32(DT.Rows[0]["Estado"]) == 1) { return "Ya existe un profesor con ese numero de documento. Por favor, verifica."; }
            }
            return "";
        }

        public void Disable(int idProfesor)
        {
            try
            {
                string stSQL = "UPDATE Profesor SET Estado=0 WHERE idProfesor=" + idProfesor;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(stSQL);
            }
            catch (Exception) { }
        }

        public void Enable(int idProfesor)
        {
            try
            {
                string stSQL = "UPDATE Profesor SET Estado=1 WHERE idProfesor=" + idProfesor;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(stSQL);
            }
            catch (Exception) { }
        }

        public bool Delete(int idProfesor)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();
                string s_Delete = "DELETE FROM ProfesorxActividad WHERE ProfesorxActividad.idProfesor=" + idProfesor + ";DELETE FROM Profesor WHERE Profesor.idProfesor=" + idProfesor;
                oDataAccess.ExecuteCommando(s_Delete);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}