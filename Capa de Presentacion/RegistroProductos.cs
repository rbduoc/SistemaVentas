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
    public partial class RegistroProductos : Form
    {
        private Categoria C = new Categoria();
        private Producto P = new Producto();
        private ListadoProductos listadoView;

        public RegistroProductos()
        {
            InitializeComponent();
        }

        public RegistroProductos(ListadoProductos list)
        {
            InitializeComponent();

            listadoView = list;
        }

        private void FrmRegistroProductos_Load(object sender, EventArgs e)
        {
            ListarElementos();
        }

        public void ListarElementos() {
            if (IdC.Text.Trim() != "")
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
                cbxCategoria.SelectedValue = IdC.Text;
            }
            else
            {
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DataSource = C.Listar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            if (txtProducto.Text.Trim() != "")
            {
                if (txtMarca.Text.Trim() != "")
                {
                        if (txtPVenta.Text.Trim() != "")
                        {
                            if (txtStock.Text.Trim() != "")
                            {
                                if (Program.Evento == 0)
                                {
                                    P.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                                    P.ProductoNombre = txtProducto.Text;
                                    P.Marca = txtMarca.Text;
                                    P.Precio = Convert.ToInt32(txtPVenta.Text);
                                    P.Stock = Convert.ToInt32(txtStock.Text);
                                    Mensaje = P.RegistrarProductos();
                                    if (Mensaje == "Este Producto ya ha sido Registrado."){
                                        MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }else{
                                        MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Limpiar();
                                    }
                                }
                                else
                                {
                                    P.IdP = Convert.ToInt32(txtIdP.Text);
                                    P.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                                    P.ProductoNombre = txtProducto.Text;
                                    P.Marca = txtMarca.Text;
                                    P.Precio = Convert.ToInt32(txtPVenta.Text);
                                    P.Stock = Convert.ToInt32(txtStock.Text);
                                    MessageBoxEx.Show(P.ActualizarProductos(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar(); 
                                    this.Close();

                                }
                            }
                            else
                            {
                                MessageBoxEx.Show("Por Favor Ingrese Stock del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtStock.Focus();
                            }
                    }
                }
                else
                {
                    MessageBoxEx.Show("Por Favor Ingrese Marca del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarca.Focus();
                }
            }
            else {
                MessageBoxEx.Show("Por Favor Ingrese Nombre del Producto.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
            }
            ListadoProductos LP = new ListadoProductos();
            LP.timer1.Start();
            listadoView.CargarListado();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            RegistrarCategoria C = new RegistrarCategoria(this);
            C.Show();
        }

        private void Limpiar() {
            txtProducto.Text = "";
            txtMarca.Clear();
            txtPVenta.Clear();
            IdC.Clear();
            txtIdP.Clear();
            txtStock.Clear();
            txtProducto.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                this.Close();
            }

        }

        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.txtPCompra.Text.Contains('.'))
            //{
            //    if (!char.IsDigit(e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }

            //    if (e.KeyChar == '\b')
            //    {
            //        e.Handled = false;
            //    }
            //}
            //else
            //{
            //    if (!char.IsDigit(e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }

            //    if (e.KeyChar == '.' || e.KeyChar == '\b')
            //    {
            //        e.Handled = false;
            //    }
            //}
        }

        private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtPVenta.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                } 
        }

    

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }
    }
}
