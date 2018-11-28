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
    public partial class RegistroCliente : Form
    {
        private Cliente C = new Cliente();
        private ListadoClientes listaClientes;

        public RegistroCliente()
        {
            InitializeComponent();
        }

        public RegistroCliente(ListadoClientes list)
        {
            InitializeComponent();

            listaClientes = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRut.Text.Trim() != "")
            {
                if (txtApellidos.Text.Trim() != "")
                {
                    if (txtNombres.Text.Trim() != "")
                    {
                        if (txtDireccion.Text.Trim() != "")
                        {
                            if (txtTelefono.Text.Trim() != "")
                            {

                                if (Program.Evento == 0)
                                {
                                    C.Rut = Convert.ToInt32(txtRut.Text);
                                    C.Dv = txtDV.Text;
                                    C.Nombres = txtNombres.Text;
                                    C.Apellidos = txtApellidos.Text;
                                    C.Direccion = txtDireccion.Text;
                                    C.Telefono = txtTelefono.Text;
                                    MessageBoxEx.Show(C.RegistrarCliente(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                                else
                                {
                                    C.Rut = Convert.ToInt32(txtRut.Text);
                                    C.Dv = txtDV.Text;
                                    C.Apellidos = txtApellidos.Text;
                                    C.Nombres = txtNombres.Text;
                                    C.Direccion = txtDireccion.Text;
                                    C.Telefono = txtTelefono.Text;
                                    MessageBoxEx.Show(C.ActualizarCliente(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                            }
                            else
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de Teléfono o Celular.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtTelefono.Focus();
                            }
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Dirección del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtDireccion.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre(s) del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombres.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Apellidos del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtApellidos.Focus();
                }
            }
            else {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de D.N.I del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRut.Focus();
            }

            listaClientes.ListarClientes();
       }

        private void Limpiar() {
            txtRut.Text = "";
            txtDV.Text = "";
            txtApellidos.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtRut.Focus();
        }

        private void FrmRegistroCliente_Load(object sender, EventArgs e)
        {
            txtRut.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmRegistroCliente_Activated(object sender, EventArgs e)
        {
            txtRut.Focus();
        }
    }
}
