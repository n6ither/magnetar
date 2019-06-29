using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class DataAccess
    {
        /// <summary>
        /// Constructor principal
        /// </summary>
        public DataAccess()
        {
            Open();
        }

        /// <summary>
        /// Obtiene o establece el string de conexion a la base de datos
        /// </summary>
        private string stConexion = ConfigurationManager.ConnectionStrings["Presentation.Properties.Settings.GymDatabaseConnectionString"].ConnectionString;

        /// <summary>
        /// Abre la coneccion
        /// </summary>
        public void Open()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-AR");
                mConnection = new SqlConnection(stConexion);
                mConnection.Open();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Cierra la conexion
        /// </summary>
        public void Close()
        {
            mConnection.Close();
        }

        /// <summary>
        /// Obtiene o establece la conexion a la base de datos
        /// </summary>
        private SqlConnection mConnection;
        public SqlConnection Connection
        {
            get { return mConnection; }
            set { mConnection = value; }
        }

        public int ExecuteCommando(SqlCommand sCommand)
        {
            try
            {
                if (mConnection.State == ConnectionState.Closed)
                {
                    Open();
                }

                int Id = (Int32)sCommand.ExecuteNonQuery();
                this.Close();
                return Id;
            }

            catch (Exception)
            {
                mConnection.Close();
                return -1;
            }
        }

        public int ExecuteCommando(string stSQL)
        {
            try
            {
                if (mConnection.State == ConnectionState.Closed)
                {
                    Open();
                }

                SqlCommand oCommand = new SqlCommand(stSQL, mConnection);

                int Id = (Int32)oCommand.ExecuteNonQuery();
                return Id;
            }

            catch (Exception ex)
            {
                mConnection.Close();
                throw ex;
            }
        }

        public DataTable ExecuteDataTable(string strSQL)
        {
            DataTable functionReturnValue = null;

            DataSet oData = new DataSet();
            try
            {
                SqlDataAdapter oAdap = new SqlDataAdapter(strSQL, mConnection);
                oAdap.Fill(oData, "Registros");
                mConnection.Close();
                functionReturnValue = oData.Tables[0];
            }

            catch (Exception ex)
            {
                mConnection.Close();
                throw ex;
            }

            return functionReturnValue;
        }

        public object ExecuteScalar(string strSQL)
        {
            if (mConnection.State == ConnectionState.Closed)
            {
                Open();
            }

            object functionReturnValue = null;
            try
            {
                SqlCommand oCommand = new SqlCommand(strSQL, mConnection);
                functionReturnValue = oCommand.ExecuteScalar();
                mConnection.Close();
            }

            catch (Exception ex)
            {
                mConnection.Close();
                throw ex;
            }

            return functionReturnValue;
        }
    }
}