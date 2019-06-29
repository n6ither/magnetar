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
    public class Socios
    {
        public class Socio
        {
            private int m_idSocio;
            public int idSocio
            {
                get { return m_idSocio; }
                set { m_idSocio = value; }
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

            private string m_Organizacion;
            public string Organizacion
            {
                get { return m_Organizacion; }
                set { m_Organizacion = value; }
            }

            private int m_Peso;
            public int Peso
            {
                get { return m_Peso; }
                set { m_Peso = value; }
            }

            private int m_Altura;
            public int Altura
            {
                get { return m_Altura; }
                set { m_Altura = value; }
            }

            private string m_Medicamentos;
            public string Medicamentos
            {
                get { return m_Medicamentos; }
                set { m_Medicamentos = value; }
            }

            private int m_idRutina;
            public int idRutina
            {
                get { return m_idRutina; }
                set { m_idRutina = value; }
            }

            private string m_NombreEmergencia;
            public string NombreEmergencia
            {
                get { return m_NombreEmergencia; }
                set { m_NombreEmergencia = value; }
            }

            private string m_ApellidoEmergencia;
            public string ApellidoEmergencia
            {
                get { return m_ApellidoEmergencia; }
                set { m_ApellidoEmergencia = value; }
            }

            private string m_NumeroEmergencia;
            public string NumeroEmergencia
            {
                get { return m_NumeroEmergencia; }
                set { m_NumeroEmergencia = value; }
            }

            private int m_ExperienciaPesas;
            public int ExperienciaPesas
            {
                get { return m_ExperienciaPesas; }
                set { m_ExperienciaPesas = value; }
            }

            private int m_Fuma;
            public int Fuma
            {
                get { return m_Fuma; }
                set { m_Fuma = value; }
            }

            private int m_Alcohol;
            public int Alcohol
            {
                get { return m_Alcohol; }
                set { m_Alcohol = value; }
            }

            private string m_Notas;
            public string Notas
            {
                get { return m_Notas; }
                set { m_Notas = value; }
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

            private decimal m_Saldo;
            public decimal Saldo
            {
                get { return m_Saldo; }
                set { m_Saldo = value; }
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
        /// Devuelve un DataTable con los primeros 100 socios y sus localidades haciendo un FULL OUTER JOIN.
        /// </summary>
        /// <param name="s_Columnas">Datos a mostrar en la clausula SELECT.</param>
        /// <param name="s_Filtro">Condicion en la clausula WHERE.</param>
        /// <returns></returns>
        public DataTable GetTop100SL(string s_Columnas, string s_Filtro)
        {
            if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
            string stSQL = "SELECT TOP 100  " + s_Columnas + " FROM Socio S FULL OUTER JOIN Localidad L ON S.idLocalidad=L.idLocalidad " + s_Filtro;

            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);
            return DT;
        }

        /// <summary>
        /// Devuelve un DataTable con todos los socios y sus localidades haciendo un FULL OUTER JOIN.
        /// </summary>
        /// <param name="s_Columnas">Datos a mostrar en la clausula SELECT.</param>
        /// <param name="s_Filtro">Condicion en la clausula WHERE.</param>
        /// <returns></returns>
        public DataTable GetAllSL(string s_Columnas, string s_Filtro)
        {
            try
            {
                if (s_Filtro.Length != 0) s_Filtro = " WHERE " + s_Filtro;
                string s_SQL = "SELECT " + s_Columnas + " FROM Socio S FULL OUTER JOIN Localidad L ON S.idLocalidad=L.idLocalidad " + s_Filtro;

                DataAccess oDataAccess = new DataAccess();
                DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
                return DT;
            }
            catch (Exception) { return null; }
        }

        public int CountSociosActivos()
        {
            string s_SQL = "SELECT COUNT(DISTINCT Membresia.idSocio) FROM Socio, Membresia WHERE Membresia.Estado=1 AND Socio.Estado=1";

            DataAccess oDataAccess = new DataAccess();
            int cant = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
            return cant;
        }

        public int CountSocios()
        {
            string s_SQL = "SELECT COUNT(idSocio) FROM Socio";
            DataAccess oDataAccess = new DataAccess();
            int cant = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
            return cant;
        }

        public int Insert(Socio Dato)
        {
            DataAccess oDataAccess = new DataAccess();

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Socio(NroDoc, Nombre, Apellido, FechaNacimiento, Edad, Sexo, Direccion, idLocalidad, TelefonoFijo, TelefonoCelular, Email, Ocupacion, Organizacion, Peso, Altura, Medicamentos, idRutina, NombreEmergencia, ApellidoEmergencia, NumeroEmergencia, ExperienciaPesas, Fuma, Alcohol, Notas, Imagen, SizeMode, Saldo, FechaRegistracion, Estado) VALUES(@NroDoc, @Nombre, @Apellido, @FechaNacimiento, @Edad, @Sexo, @Direccion, @idLocalidad, @TelefonoFijo, @TelefonoCelular, @Email, @Ocupacion, @Organizacion, @Peso, @Altura, @Medicamentos, @idRutina, @NombreEmergencia, @ApellidoEmergencia, @NumeroEmergencia, @ExperienciaPesas, @Fuma, @Alcohol, @Notas, @Imagen, @SizeMode, @Saldo, @FechaRegistracion, @Estado)", oDataAccess.Connection);
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
            cmdInsert.Parameters.AddWithValue("Organizacion", Dato.Organizacion);
            cmdInsert.Parameters.AddWithValue("Peso", Dato.Peso);
            cmdInsert.Parameters.AddWithValue("Altura", Dato.Altura);
            cmdInsert.Parameters.AddWithValue("Medicamentos", Dato.Medicamentos);
            cmdInsert.Parameters.AddWithValue("idRutina", Dato.idRutina);
            cmdInsert.Parameters.AddWithValue("NombreEmergencia", Dato.NombreEmergencia);
            cmdInsert.Parameters.AddWithValue("ApellidoEmergencia", Dato.ApellidoEmergencia);
            cmdInsert.Parameters.AddWithValue("NumeroEmergencia", Dato.NumeroEmergencia);
            cmdInsert.Parameters.AddWithValue("ExperienciaPesas", Dato.ExperienciaPesas);
            cmdInsert.Parameters.AddWithValue("Fuma", Dato.Fuma);
            cmdInsert.Parameters.AddWithValue("Alcohol", Dato.Alcohol);
            cmdInsert.Parameters.AddWithValue("Notas", Dato.Notas);
            cmdInsert.Parameters.AddWithValue("Imagen", Dato.Imagen);
            cmdInsert.Parameters.AddWithValue("SizeMode", Dato.SizeMode);
            cmdInsert.Parameters.AddWithValue("Saldo", Dato.Saldo);
            cmdInsert.Parameters.AddWithValue("FechaRegistracion", Dato.FechaRegistracion);
            cmdInsert.Parameters.AddWithValue("Estado", Dato.Estado);

            oDataAccess.ExecuteCommando(cmdInsert);
            string stTop = "SELECT TOP 1 idSocio FROM Socio ORDER BY idSocio DESC";
            Int32 id = Convert.ToInt32(oDataAccess.ExecuteScalar(stTop));
            return id;
        }

        public Socio GetOne(int idSocio)
        {
            string stSQL = "SELECT * FROM Socio WHERE idSocio=" + idSocio;
            DataAccess oDataAccess = new DataAccess();
            DataTable DT = oDataAccess.ExecuteDataTable(stSQL);

            foreach (DataRow Fila in DT.Rows)
            {
                Socio oSocio = new Socio();
                try
                {
                    oSocio.idSocio = Convert.ToInt32(Fila["idSocio"]);
                    oSocio.NroDoc = Convert.ToInt32(Fila["NroDoc"]);
                    oSocio.Nombre = Fila["Nombre"].ToString();
                    oSocio.Apellido = Fila["Apellido"].ToString();
                    oSocio.FechaNacimiento = Convert.ToDateTime(Fila["FechaNacimiento"]);
                    oSocio.Edad = Convert.ToInt32(Fila["Edad"]);
                    oSocio.Sexo = Fila["Sexo"].ToString();
                    oSocio.Direccion = Fila["Direccion"].ToString();
                    oSocio.idLocalidad = Convert.ToInt32(Fila["idLocalidad"]);
                    oSocio.TelefonoFijo = Fila["TelefonoFijo"].ToString();
                    oSocio.TelefonoCelular = Fila["TelefonoCelular"].ToString();
                    oSocio.Email = Fila["Email"].ToString();
                    oSocio.Ocupacion = Fila["Ocupacion"].ToString();
                    oSocio.Organizacion = Fila["Organizacion"].ToString();
                    oSocio.Peso = Convert.ToInt32(Fila["Peso"]);
                    oSocio.Altura = Convert.ToInt32(Fila["Altura"]);
                    oSocio.Medicamentos = Fila["Medicamentos"].ToString();
                    oSocio.idRutina = Convert.ToInt32(Fila["idRutina"]);
                    oSocio.NombreEmergencia = Fila["NombreEmergencia"].ToString();
                    oSocio.ApellidoEmergencia = Fila["ApellidoEmergencia"].ToString();
                    oSocio.NumeroEmergencia = Fila["NumeroEmergencia"].ToString();
                    oSocio.ExperienciaPesas = Convert.ToInt32(Fila["ExperienciaPesas"]);
                    oSocio.Fuma = Convert.ToInt32(Fila["Fuma"]);
                    oSocio.Alcohol = Convert.ToInt32(Fila["Alcohol"]);
                    oSocio.Notas = Fila["Notas"].ToString();
                    oSocio.Imagen = Fila["Imagen"].ToString();
                    oSocio.SizeMode = Fila["SizeMode"].ToString();
                    oSocio.Saldo = Convert.ToDecimal(Fila["Saldo"]);
                    oSocio.FechaRegistracion = Convert.ToDateTime(Fila["FechaRegistracion"]);
                    oSocio.Estado = Convert.ToInt32(Fila["Estado"]);
                    return oSocio;
                }

                catch (Exception ex) { throw ex; }
            }
            return null;
        }

        public void Update(Socio Dato)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                SqlCommand cmdUpdate = new SqlCommand("UPDATE Socio SET NroDoc=@NroDoc, Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, Edad=@Edad, Sexo=@Sexo, Direccion=@Direccion, idLocalidad=@idLocalidad, TelefonoFijo=@TelefonoFijo, TelefonoCelular=@TelefonoCelular, Email=@Email, Ocupacion=@Ocupacion, Organizacion=@Organizacion, Peso=@Peso, Altura=@Altura, Medicamentos=@Medicamentos, idRutina=@idRutina, NombreEmergencia=@NombreEmergencia, ApellidoEmergencia=@ApellidoEmergencia, NumeroEmergencia=@NumeroEmergencia, ExperienciaPesas=@ExperienciaPesas, Fuma=@Fuma, Alcohol=@Alcohol, Notas=@Notas, Imagen=@Imagen, SizeMode=@SizeMode, Saldo=@Saldo WHERE idSocio=@idSocio", oDataAccess.Connection);
                cmdUpdate.Parameters.AddWithValue("idSocio", Dato.idSocio);
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
                cmdUpdate.Parameters.AddWithValue("Organizacion", Dato.Organizacion);
                cmdUpdate.Parameters.AddWithValue("Peso", Dato.Peso);
                cmdUpdate.Parameters.AddWithValue("Altura", Dato.Altura);
                cmdUpdate.Parameters.AddWithValue("Medicamentos", Dato.Medicamentos);
                cmdUpdate.Parameters.AddWithValue("idRutina", Dato.idRutina);
                cmdUpdate.Parameters.AddWithValue("NombreEmergencia", Dato.NombreEmergencia);
                cmdUpdate.Parameters.AddWithValue("ApellidoEmergencia", Dato.ApellidoEmergencia);
                cmdUpdate.Parameters.AddWithValue("NumeroEmergencia", Dato.NumeroEmergencia);
                cmdUpdate.Parameters.AddWithValue("ExperienciaPesas", Dato.ExperienciaPesas);
                cmdUpdate.Parameters.AddWithValue("Fuma", Dato.Fuma);
                cmdUpdate.Parameters.AddWithValue("Alcohol", Dato.Alcohol);
                cmdUpdate.Parameters.AddWithValue("Notas", Dato.Notas);
                cmdUpdate.Parameters.AddWithValue("Imagen", Dato.Imagen);
                cmdUpdate.Parameters.AddWithValue("SizeMode", Dato.SizeMode);
                cmdUpdate.Parameters.AddWithValue("Saldo", Dato.Saldo);

                Int32 id = oDataAccess.ExecuteCommando(cmdUpdate);
            }
            catch (Exception) { }
        }

        public void Disable(int idSocio)
        {
            try
            {
                string stSQL = "UPDATE Socio SET Estado=0 WHERE idSocio=" + idSocio;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(stSQL);
            }
            catch (Exception) { }
        }

        public void Enable(int idSocio)
        {
            try
            {
                string stSQL = "UPDATE Socio SET Estado=1 WHERE idSocio=" + idSocio;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(stSQL);
            }
            catch (Exception) { }
        }

        public void UpdateSaldo(int idSocio, string Saldo)
        {
            try
            {
                string s_SQL = "UPDATE Socio SET Saldo=Saldo+" + Saldo.Replace(",", ".") + " WHERE idSocio=" + idSocio;
                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteScalar(s_SQL);
            }
            catch (Exception) { }
        }

        public decimal GetSaldo(int idSocio)
        {
            try
            {
                string s_SQL = "SELECT Saldo FROM Socio WHERE idSocio=" + idSocio;
                DataAccess oDataAccess = new DataAccess();
                decimal saldo = Convert.ToDecimal(oDataAccess.ExecuteScalar(s_SQL));
                return saldo;
            }
            catch (Exception) { return -1; }
        }

        public string ValidarDocumento(string NroDoc)
        {
            DataAccess oDataAccess = new DataAccess();
            string s_SQL = "SELECT Estado FROM Socio WHERE Socio.NroDoc='" + NroDoc + "'";
            DataTable DT = oDataAccess.ExecuteDataTable(s_SQL);
            if (DT.Rows.Count == 1)
            {
                if (Convert.ToInt32(DT.Rows[0]["Estado"]) == 0) { return "Ya existe un socio con ese numero de documento. Se encuentra en la lista de socios inactivos. Por favor, verifica."; }
                if (Convert.ToInt32(DT.Rows[0]["Estado"]) == 1) { return "Ya existe un socio con ese numero de documento. Por favor, verifica."; }
            }
            return "";
        }

        public bool Delete(int idSocio)
        {
            try
            {
                DataAccess oDataAccess = new DataAccess();

                string s_Membresias = "SELECT * FROM Membresia WHERE Membresia.idSocio=" + idSocio;
                DataTable dtMembresias = oDataAccess.ExecuteDataTable(s_Membresias);
                foreach (DataRow row in dtMembresias.Rows)
                {
                    string s_HistorialMembresias = "DELETE FROM HistorialMembresias WHERE HistorialMembresias.idMembresia=" + row["idMembresia"].ToString();
                    oDataAccess.ExecuteCommando(s_HistorialMembresias);  //BORRA EL HISTORIAL DE LAS MEMBRESIAS.

                    string s_Cobros = "DELETE FROM PagoMembresia WHERE PagoMembresia.idMembresia=" + row["idMembresia"].ToString();
                    oDataAccess.ExecuteCommando(s_Cobros);  //BORRA LOS COBROS DE LAS MEMBRESIAS.
                }

                string s_Casilleros = "SELECT * FROM Casillero WHERE Casillero.idSocio=" + idSocio;
                DataTable dtCasilleros = oDataAccess.ExecuteDataTable(s_Casilleros);
                foreach (DataRow row in dtCasilleros.Rows)
                {
                    string s_PagoCasilleros = "DELETE FROM PagoCasillero WHERE PagoCasillero.idCasillero=" + row["idCasillero"].ToString();
                    oDataAccess.ExecuteCommando(s_PagoCasilleros);
                }

                string s_ATLMCAS = "DELETE FROM Asistencia WHERE Asistencia.idSocio=" + idSocio + "; DELETE FROM SocioxTurno WHERE SocioxTurno.idSocio=" + idSocio + "; DELETE FROM Membresia WHERE Membresia.idSocio=" + idSocio + "; DELETE FROM Lesion WHERE Lesion.idSocio=" + idSocio + "; DELETE FROM Casillero WHERE Casillero.idSocio=" + idSocio + "; DELETE FROM Ajuste WHERE Ajuste.idSocio=" + idSocio + "; DELETE FROM Socio WHERE Socio.idSocio=" + idSocio;
                oDataAccess.ExecuteCommando(s_ATLMCAS);  //BORRA ASISTENCIAS, TURNOS, LESIONES, MEMBRESIAS, CASILLEROS, AJUSTES Y EL SOCIO.

                return true;
            }
            catch (Exception) { return false; }
        }

        //public int getNext(int idActual)
        //{
        //    string s_SQL = "SELECT TOP(1) idSocio FROM Socio WHERE idSocio>" + idActual + "AND Estado=1";
        //    DataAccess oDataAccess = new DataAccess();
        //    int id = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
        //    return id;
        //}

        //public int getPrevious(int idActual)
        //{
        //    string s_SQL = "SELECT TOP(1) idSocio FROM Socio WHERE idSocio<" + idActual + "AND Estado=1";
        //    DataAccess oDataAccess = new DataAccess();
        //    int id = Convert.ToInt32(oDataAccess.ExecuteScalar(s_SQL));
        //    return id;
        //}
    }
}