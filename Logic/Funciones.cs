using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Data;

namespace Logic
{
    public class Funciones
    {
        /// <summary>
        /// Carga un Combo Box con los registros de una tabla.
        /// </summary>
        /// <param name="cboCombo">Nombre del control a llenar.</param>
        /// <param name="s_ValueMember">Valor real del item.</param>
        /// <param name="s_DisplayMember">Valor visible del item.</param>
        /// <param name="s_As">Si el stDisplayMember esta compuesto por mas de un campo, se debe especificar un campo en este parametro que servira como DisplayMember.</param>
        /// <param name="s_Tabla">Tabla de la base de datos.</param>
        /// <param name="s_Filtro">Clausula WHERE.</param>
        /// <param name="s_Orden">Clausula ORDER BY.</param>
        public static void f_FillComboBox(ComboBox cboCombo, string s_ValueMember, string s_DisplayMember, string s_As, string s_Tabla, string s_Filtro, string s_Orden)
        {
            try
            {
                string stSQL = "SELECT " + s_ValueMember + ", " + s_DisplayMember + " FROM " + s_Tabla;

                if (s_Filtro.Length != 0) stSQL += " WHERE " + s_Filtro;
                if (s_Orden.Length != 0) stSQL += " ORDER BY " + s_Orden;

                DataAccess oDataAccess = new DataAccess();
                DataTable oDT = oDataAccess.ExecuteDataTable(stSQL);

                if (s_DisplayMember.Contains(" as ")) s_DisplayMember = s_As;
                if (s_ValueMember.Contains('.')) { s_ValueMember = s_ValueMember.Remove(0, s_ValueMember.IndexOf('.') + 1); }
                if (s_DisplayMember.Contains('.')) { s_DisplayMember = s_DisplayMember.Remove(0, s_DisplayMember.IndexOf('.') + 1); }

                cboCombo.ValueMember = s_ValueMember;
                cboCombo.DisplayMember = s_DisplayMember;
                cboCombo.DataSource = oDT;
                cboCombo.Refresh();
            }
            catch (Exception) { }
        }
    }
}
