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
    public partial class RegistrarEmpleados : Form
    {
        Cargo C = new Cargo();
        Empleado E = new Empleado();
        int Listado = 0;
        public RegistrarEmpleados()
        {
            InitializeComponent();
        }

        private void FrmRegistrarEmpleados_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            CargarComboBox();
        }

        private void CargarComboBox(){
            comboBox1.DataSource = C.Listar();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "IdCargo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarCargo C = new RegistrarCargo();
            C.Show();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Program.Evento == 0)
            {
                E.IdEmpleado = Convert.ToInt32(txtIdE.Text);
                E.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                E.Rut = Convert.ToInt32(txtRut.Text);
                E.Dv = txtRut.Text;
                E.Apellidos = txtApellidos.Text;
                E.Nombres = txtNombres.Text;
                E.Sexo = rbnMasculino.Checked == true ? 'M' : 'F';
                E.FechaNac = Convert.ToDateTime(dateTimePicker1.Value);
                E.Direccion = txtDireccion.Text;
                MessageBoxEx.Show(E.RegistrarEmpleado(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Limpiar();

            } else {

                E.IdEmpleado = Convert.ToInt32(txtIdE.Text);
                E.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                E.Rut = Convert.ToInt32(txtRut.Text);
                E.Dv = txtRut.Text;
                E.Apellidos = txtApellidos.Text;
                E.Nombres = txtNombres.Text;
                E.Sexo = rbnMasculino.Checked == true ? 'M' : 'F';
                E.FechaNac = Convert.ToDateTime(dateTimePicker1.Value);
                E.Direccion = txtDireccion.Text;
                MessageBoxEx.Show(E.ActualizarEmpleado(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Limpiar();

            }

        }

        private void Limpiar() {
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtRut.Clear();
            txtDv.Clear();
            txtNombres.Clear();
            rbnMasculino.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            txtIdE.Clear();
            Program.IdCargo = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Listado) {
                case 0: CargarComboBox(); break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void FrmRegistrarEmpleados_Activated(object sender, EventArgs e)
        {
            if (Program.IdCargo != 0)
                comboBox1.SelectedValue = Program.IdCargo;
            //else
               // cbxEstadoCivil.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
