using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogicaNegocio;
using DevComponents.DotNetBar;

namespace Capa_de_Presentacion
{
    public partial class RegistrarUsuarios : Form
    {
        Usuarios U = new Usuarios();

        public RegistrarUsuarios()
        {
            InitializeComponent();
        }

        private void FrmRegistrarUsuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "")
            {
                if (txtPassword.Text.Trim() != "")
                {
                    if (Program.IdEmpleado != 0)
                    {
                        U.IdEmpleado = Program.IdEmpleado;
                        U.User = txtUser.Text;
                        U.Password = txtPassword.Text;
                        MessageBoxEx.Show(U.RegistrarUsuarios(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Limpiar();
                    }
                    else {
                        MessageBoxEx.Show("Lo Sentimos, Pero Usted debe Eligir un \n Empleado para Crear una Cuenta de Usuario.\n \n G R A C I A S.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Por Favor Ingrese su Contraseña.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
            }
            else {
                MessageBoxEx.Show("Por Favor Ingrese su Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
        }

        private void Limpiar() {
            txtPassword.Clear();
            txtUser.Clear();
            Program.IdEmpleado = 0;
            txtUser.Focus();
            txtCargo.Text = "";
            txtRut.Text = "";
            txtEmpleado.Text = "";
        }
    }
}
