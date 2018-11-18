using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using CapaLogicaNegocio;

namespace Capa_de_Presentacion
{
    public partial class ListadoEmpleados : Form
    {
        Empleado E = new Empleado();
        int Listado = 0;
        public ListadoEmpleados()
        {
            InitializeComponent();
        }

        private void FrmListadoEmpleados_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            MostrarListadoEmpleados();
            //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
        }

        private void MostrarListadoEmpleados() {
            DataTable dt = new DataTable();
            dt = E.ListadoEmpleados();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                dataGridView1.Rows[i].Cells[7].Value = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
            }
            dataGridView1.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            RegistrarEmpleados E = new RegistrarEmpleados();
            E.txtIdE.Text = "0";
            Program.IdCargo = 0;
            Program.Evento = 0;
            E.Show();
            dataGridView1.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) {
                if (dataGridView1.SelectedRows.Count > 0) {
                    RegistrarEmpleados E = new RegistrarEmpleados();
                    E.txtIdE.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Program.IdCargo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    E.txtRut.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    E.txtDv.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    E.txtApellidos.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    E.txtNombres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "M")
                        E.rbnMasculino.Checked = true;
                    else
                        E.rbnFemenino.Checked = true;
                    E.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    E.txtDireccion.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    Program.Evento = 1;
                    E.Show();
                }
                else
                {
                    MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dataGridView1.ClearSelection(); 
                timer1.Start();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(Listado){
                case 0: MostrarListadoEmpleados(); break;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                timer1.Stop();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Desea Crear Una Cuenta de Usuario Para este Empleado.?","Sistema de Ventas.", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                RegistrarUsuarios U = new RegistrarUsuarios();
                Program.IdEmpleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                U.txtEmpleado.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString() + ", " +
                                     dataGridView1.CurrentRow.Cells[4].Value.ToString();
                U.txtRut.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                U.txtDV.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                U.txtCargo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                U.Show();
            }
        }

        private void txtDatos_TextChanged(object sender, EventArgs e)
        {
            if (txtDatos.TextLength>0)
            {

                DataTable dt = new DataTable();
                E.Nombres = txtDatos.Text;
                dt = E.BuscarEmpleado(E.Nombres);
                try
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0]);
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                        dataGridView1.Rows[i].Cells[7].Value = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                        dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                        dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
                    }
                    dataGridView1.ClearSelection();
                    timer1.Stop();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                }
            }
            else
            {
                MostrarListadoEmpleados();
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    MessageBoxEx.Show(E.EliminarEmpleado(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); 
                }
                else
                {
                    MessageBoxEx.Show("Debe Seleccionar la Fila a Eliminar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            
        }
    }
}
