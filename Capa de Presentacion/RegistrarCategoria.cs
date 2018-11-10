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
    public partial class RegistrarCategoria : Form
    {
        private Categoria C = new Categoria();

        public RegistrarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria C = new Categoria();
            String Mensaje = "";
            try{
                if (txtCategoria.Text.Trim() != "")
                {
                    if (Program.Evento == 0){
                        C.Descripcion = txtCategoria.Text;
                        Mensaje = C.RegistrarCategoria();
                        if (Mensaje == "Categoria ya se encuentra Registrada."){
                            MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }else {
                            MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }

                    }else{
                        C.IdC = Convert.ToInt32(IdC.Text);
                        C.Descripcion = txtCategoria.Text;
                        MessageBoxEx.Show(C.ActualizarCategoria(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                }else {
                    MessageBoxEx.Show("Por Favor Digíte Datos.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtCategoria.Focus();
                }
            }catch (Exception ex){
                MessageBoxEx.Show(ex.Message);
            }
        }


        private void Limpiar() {
            txtCategoria.Clear();
            txtCategoria.Focus();
        }
    }
}
