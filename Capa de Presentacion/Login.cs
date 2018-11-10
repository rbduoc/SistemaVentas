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
    public partial class Login : Form
    {
        Usuarios U = new Usuarios();

        public Login()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                Application.Exit();
            }
               
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "")
            {
                if (txtPassword.Text.Trim() != "")
                {
                    String Mensaje = "";
                    U.User = txtUser.Text;
                    U.Password = txtPassword.Text;
                    Mensaje = U.IniciarSesion();
                    if (Mensaje == "Su Contraseña es Incorrecta.")
                    {
                        MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                    else
                        if (Mensaje == "El Nombre de Usuario no Existe.")
                        {
                            MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtUser.Clear();
                            txtPassword.Clear();
                            txtUser.Focus();
                        }
                        else
                        {
                            MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            MenuPrincipal MP = new MenuPrincipal();
                            RecuperarDatosSesion();
                            MP.Show();
                            this.Hide();
                        }
                }else {
                    MessageBoxEx.Show("Por Favor Ingrese su Contraseña.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
            }else{
                MessageBoxEx.Show("Por Favor Ingrese Nombre de Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                }
        }

        private void RecuperarDatosSesion() {
            DataRow row;
            DataTable dt = new DataTable();
            dt = U.DevolverDatosSesion(txtUser.Text,txtPassword.Text);
            if (dt.Rows.Count == 1) {
                row = dt.Rows[0];
                Program.IdEmpleadoLogueado = Convert.ToInt32(row[0].ToString());
                Program.NombreEmpleadoLogueado = row[1].ToString();
            }
        }
    }
}
