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

namespace Capa_de_Presentacion
{
    public partial class MenuPrincipal : Form
    {
        int EnviarFecha = 0;
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
        {
            lblUsuario.Text = Program.NombreEmpleadoLogueado;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();

            if (Program.CargoEmpleadoLogueado == "Vendedor")
            {
                //btnUsuarios.Hide();
                btnReportes.Hide();
            }

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ListadoProductos P = new ListadoProductos();
            P.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ListadoClientes C = new ListadoClientes();
            C.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            RegistroVentas V = new RegistroVentas();
            V.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            RegistrarUsuarios U = new RegistrarUsuarios();
            U.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(EnviarFecha){
                case 0: CapturarFechaSistema(); break;
            }
        }

        private void CapturarFechaSistema() {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ListadoEmpleados E = new ListadoEmpleados();
            E.Show();
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Cerrar Sesion.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Login L = new Login();
                L.Show();
                this.Hide();
            }
            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes R = new Reportes();

            R.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
