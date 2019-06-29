using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Presentation.Winforms
{
    public partial class frmCalcIMC : Form
    {
        #region VARIABLES
        /// <summary>
        /// Valor que se da segun la actividad fisica semanal de la persona.
        /// </summary>
        decimal d_ParaCal = 15.5m;
        #endregion

        public frmCalcIMC()
        {
            InitializeComponent();
        }

        private void frmCalcIMC_Load(object sender, EventArgs e)
        {
            try
            {
                numPeso.Value = 50; numAltura.Value = 150; txtIMC.Clear(); txtCalorias.Clear(); rbtnModeradamenteActivo.Checked = true;
            }
            catch (Exception) { }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal imc = (numPeso.Value / (numAltura.Value * numAltura.Value)) * 10000;
                txtIMC.Text = imc.ToString().Trim();

                txtIMC.BackColor = Color.White;
                if (imc <= 16) { txtIMC.ForeColor = Color.Red; }
                if (imc >= 16 && imc <= 17) { txtIMC.ForeColor = Color.Orange; }
                if (imc >= 17 && imc <= 18.49m) { txtIMC.ForeColor = Color.GreenYellow; }
                if (imc >= 18.5m && imc <= 24.99m) { txtIMC.ForeColor = Color.Green; }
                if (imc >= 25 && imc <= 29.99m) { txtIMC.ForeColor = Color.GreenYellow; }
                if (imc >= 30 && imc <= 34.99m) { txtIMC.ForeColor = Color.Orange; }
                if (imc >= 35 && imc <= 39.99m) { txtIMC.ForeColor = Color.OrangeRed; }
                if (imc >= 40) { txtIMC.ForeColor = Color.Red; }

                txtCalorias.Text = Convert.ToString((numPeso.Value * 2.2m) * d_ParaCal);
            }
            catch (Exception) { }
        }

        private void lbMasInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://es.wikipedia.org/wiki/%C3%8Dndice_de_masa_corporal");
                Process.Start("http://www.who.int/mediacentre/factsheets/fs311/es/");
                Process.Start("http://evidasana.com/blog/%C2%BFcuantas-calorias-necesito/");
            }
            catch (Exception) { }
        }

        private void rbtnSedentario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                d_ParaCal = 12;
            }
            catch (Exception) { }
        }

        private void rbtnAlgoActivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                d_ParaCal = 13.5m;
            }
            catch (Exception) { }
        }

        private void rbtnModeradamenteActivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                d_ParaCal = 15.5m;
            }
            catch (Exception) { }
        }

        private void rbtnMuyActivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                d_ParaCal = 17;
            }
            catch (Exception) { }
        }

        private void rbtnAltamenteActivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                d_ParaCal = 19;
            }
            catch (Exception) { }
        }
    }
}