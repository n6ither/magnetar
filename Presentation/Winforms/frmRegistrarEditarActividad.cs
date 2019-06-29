using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Presentation.Winforms;

namespace Presentation.Winforms
{
    public partial class frmRegistrarEditarActividad : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarActividad.
        /// </summary>
        public static int idActividad = 0;
        #endregion

        public frmRegistrarEditarActividad()
        {
            InitializeComponent();
        }


        #region LOAD & DATAGRIDVIEW
        private void frmRegistrarEditarActividad_Load(object sender, EventArgs e)
        {
            try
            {
                Profesores oProfesores = new Profesores();
                DataTable dtProfesores = oProfesores.GetAllPL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, L.Nombre as 'Localidad'", "P.Estado=1 ORDER BY P.Apellido ASC");
                dgvProfesores.DataSource = dtProfesores;
                dgvProfesores.Columns["idProfesor"].Visible = false;

                if (!dgvProfesores.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                    chkColumn.Name = "Seleccionar";
                    chkColumn.HeaderText = "Seleccionar";
                    chkColumn.ReadOnly = false;
                    chkColumn.FalseValue = 0;
                    chkColumn.TrueValue = 1;
                    dgvProfesores.Columns.Insert(0, chkColumn);
                }

                if (idActividad == 0)
                {
                    f_ClearAll();
                }
                else
                {
                    Actividades oActividades = new Actividades();
                    Actividades.Actividad oActividad = oActividades.GetOne(idActividad);

                    txtNombre.Text = oActividad.Nombre.ToString().Trim();
                    if (oActividad.Cupo == 0) { chkSinCupo.Checked = true; numCupo.Enabled = false; } else { chkSinCupo.Checked = false; numCupo.Value = oActividad.Cupo; }
                    numPrecioClase.Value = Convert.ToDecimal(oActividad.PrecioClase);
                    numPrecioSemana.Value = Convert.ToDecimal(oActividad.PrecioSemana);
                    numPrecioMes.Value = Convert.ToDecimal(oActividad.PrecioMes);
                    numPrecioTrimestre.Value = Convert.ToDecimal(oActividad.PrecioTrimestre);
                    numPrecioOtro1.Value = Convert.ToDecimal(oActividad.PrecioOtro1);
                    numPrecioOtro2.Value = Convert.ToDecimal(oActividad.PrecioOtro2);

                    ProfesoresxActividades oProfesoresxActividades = new ProfesoresxActividades();
                    DataTable dtProfesoresxActividades = oProfesoresxActividades.GetAll("idProfesor", "idActividad=" + idActividad);

                    foreach (DataRow dtRow in dtProfesoresxActividades.Rows) //REVISAR
                    {
                        foreach (DataGridViewRow dgvRow in dgvProfesores.Rows)
                        {
                            if (Convert.ToInt32(dgvRow.Cells["idProfesor"].Value) == Convert.ToInt32(dtRow["idProfesor"].ToString().Trim()))
                            {
                                dgvRow.Cells["Seleccionar"].Value = true;
                            }
                        }
                    }

                    Turnos oTurnos = new Turnos();
                    DataTable dtTurnos = oTurnos.GetAll("*", "idActividad=" + idActividad);
                    foreach (DataRow row in dtTurnos.Rows)
                    {
                        if (row["Nombre"].ToString().Trim() == "Turno 1")
                        {
                            chkTurno1.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno1.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno1.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno1.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno1.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno1.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno1.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno1.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno1.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }

                        if (row["Nombre"].ToString().Trim() == "Turno 2")
                        {
                            chkTurno2.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno2.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno2.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno2.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno2.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno2.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno2.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno2.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno2.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }

                        if (row["Nombre"].ToString().Trim() == "Turno 3")
                        {
                            chkTurno3.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno3.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno3.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno3.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno3.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno3.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno3.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno3.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno3.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }

                        if (row["Nombre"].ToString().Trim() == "Turno 4")
                        {
                            chkTurno4.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno4.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno4.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno4.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno4.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno4.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno4.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno4.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno4.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }

                        if (row["Nombre"].ToString().Trim() == "Turno 5")
                        {
                            chkTurno5.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno5.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno5.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno5.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno5.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno5.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno5.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno5.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno5.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }

                        if (row["Nombre"].ToString().Trim() == "Turno 6")
                        {
                            chkTurno6.Checked = true;
                            if (Convert.ToString(row["Dias"]).Contains("lunes")) { clDiasTurno6.SetItemCheckState(0, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(0, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("martes")) { clDiasTurno6.SetItemCheckState(1, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(1, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("miércoles")) { clDiasTurno6.SetItemCheckState(2, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(2, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("jueves")) { clDiasTurno6.SetItemCheckState(3, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(3, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("viernes")) { clDiasTurno6.SetItemCheckState(4, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(4, CheckState.Unchecked); }
                            if (Convert.ToString(row["Dias"]).Contains("sábado")) { clDiasTurno6.SetItemCheckState(5, CheckState.Checked); } else { clDiasTurno6.SetItemCheckState(5, CheckState.Unchecked); }
                            dtpTurno6.Value = Convert.ToDateTime(row["Hora"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void dgvProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) { return; }
                if (dgvProfesores.CurrentCell.ColumnIndex == 0)
                {
                    dgvProfesores.EditMode = DataGridViewEditMode.EditOnF2;
                }
                else
                {
                    dgvProfesores.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnNuevaActividad_Click(object sender, EventArgs e)
        {
            f_ClearAll();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarActividad()) { return; }

                Actividades oActividades = new Actividades();
                Actividades.Actividad oActividad = new Actividades.Actividad();

                if (idActividad == 0)
                {
                    oActividad.Nombre = txtNombre.Text.ToString().Trim();
                    if (chkSinCupo.Checked) { oActividad.Cupo = 0; } else { oActividad.Cupo = numCupo.Value; }
                    oActividad.PrecioClase = numPrecioClase.Value;
                    oActividad.PrecioSemana = numPrecioSemana.Value;
                    oActividad.PrecioMes = numPrecioMes.Value;
                    oActividad.PrecioTrimestre = numPrecioTrimestre.Value;
                    oActividad.PrecioOtro1 = numPrecioOtro1.Value;
                    oActividad.PrecioOtro2 = numPrecioOtro2.Value;
                    oActividad.Estado = 1;

                    idActividad = oActividades.Insert(oActividad);

                    ProfesoresxActividades oProfesoresxActividades = new ProfesoresxActividades();
                    ProfesoresxActividades.ProfesorxActividad oProfesorxActividad = new ProfesoresxActividades.ProfesorxActividad();
                    oProfesorxActividad.idActividad = idActividad;
                    foreach (DataGridViewRow row in dgvProfesores.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            oProfesorxActividad.idProfesor = Convert.ToInt32(row.Cells["idProfesor"].Value);
                            oProfesoresxActividades.Insert(oProfesorxActividad);
                        }
                    }

                    Turnos oTurnos = new Turnos();
                    Turnos.Turno oTurno = new Turnos.Turno();
                    oTurno.idActividad = idActividad;

                    if (chkTurno1.Checked) { oTurno.Nombre = "Turno 1"; foreach (object item in clDiasTurno1.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno1.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno2.Checked) { oTurno.Nombre = "Turno 2"; foreach (object item in clDiasTurno2.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno2.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno3.Checked) { oTurno.Nombre = "Turno 3"; foreach (object item in clDiasTurno3.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno3.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno4.Checked) { oTurno.Nombre = "Turno 4"; foreach (object item in clDiasTurno4.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno4.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno5.Checked) { oTurno.Nombre = "Turno 5"; foreach (object item in clDiasTurno5.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno5.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno6.Checked) { oTurno.Nombre = "Turno 6"; foreach (object item in clDiasTurno6.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno6.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }

                    MessageBox.Show("La actividad se registro correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oActividad.idActividad = idActividad;
                    oActividad.Nombre = txtNombre.Text.ToString().Trim();
                    if (chkSinCupo.Checked) { oActividad.Cupo = 0; } else { oActividad.Cupo = numCupo.Value; }
                    oActividad.PrecioClase = numPrecioClase.Value;
                    oActividad.PrecioSemana = numPrecioSemana.Value;
                    oActividad.PrecioMes = numPrecioMes.Value;
                    oActividad.PrecioTrimestre = numPrecioTrimestre.Value;
                    oActividad.PrecioOtro1 = numPrecioOtro1.Value;
                    oActividad.PrecioOtro2 = numPrecioOtro2.Value;

                    oActividades.Update(oActividad);

                    ProfesoresxActividades oProfesoresxActividades = new ProfesoresxActividades();
                    oProfesoresxActividades.Delete("ProfesorxActividad", "idActividad=" + idActividad);
                    ProfesoresxActividades.ProfesorxActividad oProfesorxActividad = new ProfesoresxActividades.ProfesorxActividad();
                    oProfesorxActividad.idActividad = idActividad;
                    foreach (DataGridViewRow row in dgvProfesores.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            oProfesorxActividad.idProfesor = Convert.ToInt32(row.Cells["idProfesor"].Value);
                            oProfesoresxActividades.Insert(oProfesorxActividad);
                        }
                    }

                    f_UpdateTurnos();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Actividades oActividades = new Actividades();
                Actividades.Actividad oActividad = oActividades.GetOne(idActividad);

                DialogResult drEliminar;
                drEliminar = MessageBox.Show("Esta seguro que desea dar de baja " + oActividad.Nombre.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    oActividades.Disable(idActividad);
                    MessageBox.Show("La actividad ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception) { }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarActividad()) { return; }

                Actividades oActividades = new Actividades();
                Actividades.Actividad oActividad = new Actividades.Actividad();

                if (idActividad == 0)
                {
                    oActividad.Nombre = txtNombre.Text.ToString().Trim();
                    if (chkSinCupo.Checked) { oActividad.Cupo = 0; } else { oActividad.Cupo = numCupo.Value; }
                    oActividad.PrecioClase = numPrecioClase.Value;
                    oActividad.PrecioSemana = numPrecioSemana.Value;
                    oActividad.PrecioMes = numPrecioMes.Value;
                    oActividad.PrecioTrimestre = numPrecioTrimestre.Value;
                    oActividad.PrecioOtro1 = numPrecioOtro1.Value;
                    oActividad.PrecioOtro2 = numPrecioOtro2.Value;
                    oActividad.Estado = 1;

                    idActividad = oActividades.Insert(oActividad);

                    ProfesoresxActividades oProfesoresxActividades = new ProfesoresxActividades();
                    ProfesoresxActividades.ProfesorxActividad oProfesorxActividad = new ProfesoresxActividades.ProfesorxActividad();
                    oProfesorxActividad.idActividad = idActividad;
                    foreach (DataGridViewRow row in dgvProfesores.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            oProfesorxActividad.idProfesor = Convert.ToInt32(row.Cells["idProfesor"].Value);
                            oProfesoresxActividades.Insert(oProfesorxActividad);
                        }
                    }

                    Turnos oTurnos = new Turnos();
                    Turnos.Turno oTurno = new Turnos.Turno();
                    oTurno.idActividad = idActividad;

                    if (chkTurno1.Checked) { oTurno.Nombre = "Turno 1"; foreach (object item in clDiasTurno1.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno1.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno2.Checked) { oTurno.Nombre = "Turno 2"; foreach (object item in clDiasTurno2.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno2.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno3.Checked) { oTurno.Nombre = "Turno 3"; foreach (object item in clDiasTurno3.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno3.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno4.Checked) { oTurno.Nombre = "Turno 4"; foreach (object item in clDiasTurno4.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno4.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno5.Checked) { oTurno.Nombre = "Turno 5"; foreach (object item in clDiasTurno5.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno5.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }
                    if (chkTurno6.Checked) { oTurno.Nombre = "Turno 6"; foreach (object item in clDiasTurno6.CheckedItems) { oTurno.Dias += item.ToString(); } oTurno.Dias = oTurno.Dias.ToLower(); oTurno.Hora = dtpTurno6.Value.ToShortTimeString(); oTurnos.Insert(oTurno); }

                    MessageBox.Show("La actividad se registro correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oActividad.idActividad = idActividad;
                    oActividad.Nombre = txtNombre.Text.ToString().Trim();
                    if (chkSinCupo.Checked) { oActividad.Cupo = 0; } else { oActividad.Cupo = numCupo.Value; }
                    oActividad.PrecioClase = numPrecioClase.Value;
                    oActividad.PrecioSemana = numPrecioSemana.Value;
                    oActividad.PrecioMes = numPrecioMes.Value;
                    oActividad.PrecioTrimestre = numPrecioTrimestre.Value;
                    oActividad.PrecioOtro1 = numPrecioOtro1.Value;
                    oActividad.PrecioOtro2 = numPrecioOtro2.Value;

                    oActividades.Update(oActividad);

                    ProfesoresxActividades oProfesoresxActividades = new ProfesoresxActividades();
                    oProfesoresxActividades.Delete("ProfesorxActividad", "idActividad=" + idActividad);
                    ProfesoresxActividades.ProfesorxActividad oProfesorxActividad = new ProfesoresxActividades.ProfesorxActividad();
                    oProfesorxActividad.idActividad = idActividad;
                    foreach (DataGridViewRow row in dgvProfesores.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            oProfesorxActividad.idProfesor = Convert.ToInt32(row.Cells["idProfesor"].Value);
                            oProfesoresxActividades.Insert(oProfesorxActividad);
                        }
                    }

                    f_UpdateTurnos();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FUNCIONES
        public bool f_ValidarActividad()
        {
            try
            {
                if (txtNombre.Text == "") { MessageBox.Show("La actividad debe tener un nombre. Por favor, completa el campo", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                bool checkProf = false;
                foreach (DataGridViewRow row in dgvProfesores.Rows) { if (Convert.ToBoolean(row.Cells["Seleccionar"].Value)) { checkProf = true; break; } } if (!checkProf) { MessageBox.Show("La actividad debe tener al menos un profesor. Por favor, selecciona uno.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                if (!chkTurno1.Checked && !chkTurno2.Checked && !chkTurno3.Checked && !chkTurno4.Checked && !chkTurno5.Checked && !chkTurno6.Checked) { MessageBox.Show("La actividad debe tener al menos un turno. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                if (clDiasTurno1.CheckedItems.Count == 0 && clDiasTurno2.CheckedItems.Count == 0 && clDiasTurno3.CheckedItems.Count == 0 && clDiasTurno4.CheckedItems.Count == 0 && clDiasTurno5.CheckedItems.Count == 0 && clDiasTurno6.CheckedItems.Count == 0) { MessageBox.Show("Los turnos deben tener por lo menos un dia checkeado. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                if (numPrecioClase.Value == 0 && numPrecioSemana.Value == 0 && numPrecioMes.Value == 0 && numPrecioTrimestre.Value == 0 && numPrecioOtro1.Value == 0 && numPrecioOtro2.Value == 0) { MessageBox.Show("La actividad debe tener al menos un precio. Por favor, completa el campo", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                return true;
            }
            catch (Exception) { return false; }
        }

        public void f_ClearAll()
        {
            try
            {
                idActividad = 0;
                txtNombre.Clear();
                foreach (DataGridViewRow row in dgvProfesores.Rows) { row.Cells["Seleccionar"].Value = false; }
                dtpTurno2.Checked = false; dtpTurno3.Checked = false; dtpTurno4.Checked = false; dtpTurno5.Checked = false; dtpTurno6.Checked = false;
                numPrecioClase.Value = 0; numPrecioSemana.Value = 0; numPrecioMes.Value = 0; numPrecioTrimestre.Value = 0; numPrecioOtro1.Value = 0; numPrecioOtro2.Value = 0;
                foreach (int i in clDiasTurno1.CheckedIndices) { clDiasTurno1.SetItemCheckState(i, CheckState.Unchecked); }
                foreach (int i in clDiasTurno2.CheckedIndices) { clDiasTurno2.SetItemCheckState(i, CheckState.Unchecked); }
                foreach (int i in clDiasTurno3.CheckedIndices) { clDiasTurno3.SetItemCheckState(i, CheckState.Unchecked); }
                foreach (int i in clDiasTurno4.CheckedIndices) { clDiasTurno4.SetItemCheckState(i, CheckState.Unchecked); }
                foreach (int i in clDiasTurno5.CheckedIndices) { clDiasTurno5.SetItemCheckState(i, CheckState.Unchecked); }
                foreach (int i in clDiasTurno6.CheckedIndices) { clDiasTurno6.SetItemCheckState(i, CheckState.Unchecked); }
            }
            catch (Exception) { }
        }

        public void f_UpdateTurnos()
        {
            try
            {
                Turnos oTurnos = new Turnos();
                Turnos.Turno oTurno = new Turnos.Turno();

                //TURNO 1
                int idTurno = oTurnos.GetID("Turno 1", idActividad);
                if (chkTurno1.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 1";
                        foreach (object item in clDiasTurno1.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno1.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 1";
                        foreach (object item in clDiasTurno1.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno1.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }


                //TURNO 2
                idTurno = oTurnos.GetID("Turno 2", idActividad);
                if (chkTurno2.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 2";
                        foreach (object item in clDiasTurno2.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno2.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 2";
                        foreach (object item in clDiasTurno2.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno2.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }


                //TURNO 3
                idTurno = oTurnos.GetID("Turno 3", idActividad);
                if (chkTurno3.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 3";
                        foreach (object item in clDiasTurno3.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno3.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 3";
                        foreach (object item in clDiasTurno3.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno3.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }


                //TURNO 4
                idTurno = oTurnos.GetID("Turno 4", idActividad);
                if (chkTurno4.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 4";
                        foreach (object item in clDiasTurno4.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno4.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 4";
                        foreach (object item in clDiasTurno4.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno4.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }


                //TURNO 5
                idTurno = oTurnos.GetID("Turno 5", idActividad);
                if (chkTurno5.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 5";
                        foreach (object item in clDiasTurno5.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno5.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 5";
                        foreach (object item in clDiasTurno5.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno5.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }


                //TURNO 6
                idTurno = oTurnos.GetID("Turno 6", idActividad);
                if (chkTurno6.Checked)
                {
                    oTurno.Dias = "";
                    if (idTurno == 0)
                    {
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 6";
                        foreach (object item in clDiasTurno6.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno6.Value.ToShortTimeString();
                        oTurnos.Insert(oTurno);
                    }
                    else
                    {
                        oTurno.idTurno = idTurno;
                        oTurno.idActividad = idActividad;
                        oTurno.Nombre = "Turno 6";
                        foreach (object item in clDiasTurno6.CheckedItems) { oTurno.Dias += item.ToString().ToLower(); }
                        oTurno.Hora = dtpTurno6.Value.ToShortTimeString();
                        oTurnos.Update(oTurno);
                    }
                }
                else
                {
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "idTurno=" + idTurno);
                    oTurnos.Delete("Turno", "idTurno=" + idTurno);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region ETC
        private void chkSinCupo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSinCupo.Checked) { numCupo.Enabled = false; } else { numCupo.Enabled = true; }
            }
            catch (Exception) { }
        }

        private void chkTurno1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno1.Checked) { clDiasTurno1.Enabled = true; dtpTurno1.Enabled = true; } else { foreach (int i in clDiasTurno1.CheckedIndices) { clDiasTurno1.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno1.Enabled = false; dtpTurno1.Enabled = false; }
            }
            catch (Exception) { }

        }

        private void chkTurno2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno2.Checked) { clDiasTurno2.Enabled = true; dtpTurno2.Enabled = true; } else { foreach (int i in clDiasTurno2.CheckedIndices) { clDiasTurno2.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno2.Enabled = false; dtpTurno2.Enabled = false; }
            }
            catch (Exception) { }
        }

        private void chkTurno3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno3.Checked) { clDiasTurno3.Enabled = true; dtpTurno3.Enabled = true; } else { foreach (int i in clDiasTurno3.CheckedIndices) { clDiasTurno3.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno3.Enabled = false; dtpTurno3.Enabled = false; }
            }
            catch (Exception) { }
        }

        private void chkTurno4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno4.Checked) { clDiasTurno4.Enabled = true; dtpTurno4.Enabled = true; } else { foreach (int i in clDiasTurno4.CheckedIndices) { clDiasTurno4.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno4.Enabled = false; dtpTurno4.Enabled = false; }
            }
            catch (Exception) { }
        }

        private void chkTurno5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno5.Checked) { clDiasTurno5.Enabled = true; dtpTurno5.Enabled = true; } else { foreach (int i in clDiasTurno5.CheckedIndices) { clDiasTurno5.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno5.Enabled = false; dtpTurno5.Enabled = false; }
            }
            catch (Exception) { }
        }

        private void chkTurno6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTurno6.Checked) { clDiasTurno6.Enabled = true; dtpTurno6.Enabled = true; } else { foreach (int i in clDiasTurno6.CheckedIndices) { clDiasTurno6.SetItemCheckState(i, CheckState.Unchecked); } clDiasTurno6.Enabled = false; dtpTurno6.Enabled = false; }
            }
            catch (Exception) { }
        }
        #endregion
    }
}