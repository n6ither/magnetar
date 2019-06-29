using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Winforms
{
    public partial class frmImprimirRecibo : Form
    {
        #region VARIABLES
        public static string s_Formula = "";
        #endregion

        public frmImprimirRecibo()
        {
            InitializeComponent();
        }

        private void frmImprimirRecibo_Load(object sender, EventArgs e)
        {
            try
            {
                rptRecibo rptRecibo = new rptRecibo();
                rptRecibo.Load(Properties.Resources.rptRecibo.ToString());
                rptRecibo.SetDatabaseLogon("admin", "123456", "(local)", "GymDatabase");
                if (s_Formula != "") { crvImprimir.SelectionFormula = s_Formula; }
                crvImprimir.ReportSource = rptRecibo;
                crvImprimir.Refresh();
            }
            catch (Exception) { }
        }
    }
}
