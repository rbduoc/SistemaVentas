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
    public partial class RegistroVentas : Form
    {
        Ventas Ventas = new Ventas();
        DetalleVenta Detalle = new DetalleVenta();

        private List<Venta> lst = new List<Venta>();

        public RegistroVentas()
        {
            InitializeComponent();
        }

  

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
           // GenerarNumeroComprobante();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            //GenerarNumeroComprobante();
            GenerarIdVenta();
            //GenerarSeriedeDocumento();
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void GenerarIdVenta() {
            txtIdVenta.Text = Ventas.GenerarIdVenta();
        }

        //private void GenerarSeriedeDocumento() {
        //    lblSerie.Text = Ventas.GenerarSerieDocumento();
        //}

        //private void GenerarNumeroComprobante()
        //{
        //        lblNroCorrelativo.Text = Ventas.NumeroComprobante();

        //}

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            ListadoClientes C = new ListadoClientes();
            C.Show();
        }

        private void FrmVentas_Activated(object sender, EventArgs e)
        {
            //txtIdProducto.Text = Program.IdCliente+"";
            txtDocIdentidad.Text = Program.DocumentoIdentidad;
            txtDatos.Text = Program.ApellidosCliente + ", " + Program.NombreCliente;
            txtIdProducto.Text = Program.IdProducto+"";
            txtDescripcion.Text = Program.Descripcion;
            txtMarca.Text = Program.Marca;
            txtStock.Text = Program.Stock+"";
            txtPVenta.Text = Program.PrecioVenta+"";
        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            ListadoProductos P = new ListadoProductos();
            P.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Venta V = new Venta();
            //Int32 SubTotal;
            if(this.txtDocIdentidad.Text.Trim()!=""){
                if (txtDescripcion.Text.Trim() != ""){
                    if (txtCantidad.Text.Trim() != ""){
                        if (Convert.ToInt32(txtCantidad.Text) >= 0){
                            if (Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock.Text)){
                                    V.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                                    V.IdVenta = Convert.ToInt32(txtIdVenta.Text);
                                    V.Descripcion = txtDescripcion.Text + " - " + txtMarca.Text;
                                    V.Cantidad = Convert.ToInt32(txtCantidad.Text);
                                    V.PrecioVenta = Convert.ToInt32(txtPVenta.Text);
                                    //V.Iva = 1.19; //(Convert.ToDecimal(txtIgv.Text) / 100) + 1;
                                    V.SubTotal = Convert.ToInt32((V.PrecioVenta * V.Cantidad));
                                    // = 19;//Math.Round(Convert.ToDecimal(SubTotal) * (Convert.ToDecimal(txtIgv.Text) / (100)), 2);
                                    //V.SubTotal = Math.Round(SubTotal, 2);
                                    lst.Add(V);
                                    LlenarGrilla();
                                    Limpiar();
                            }else{
                                MessageBoxEx.Show("Stock Insuficiente para Realizar la Venta.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                        }else{
                            MessageBoxEx.Show("Cantidad Ingresada no Válida.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtCantidad.Clear();
                            txtCantidad.Focus();
                        }
                    }
                    else {
                        MessageBoxEx.Show("Por Favor Ingrese Cantidad a Vender.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtCantidad.Focus();
                    }
                }
                else {
                    MessageBoxEx.Show("Por Favor Busque el Producto a Vender.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }else{
                MessageBoxEx.Show("Por Favor Busque el Cliente a Vender.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LlenarGrilla() {
            Int32 SumaSubTotal = 0; double iva = 1.19; Int32 SumaTotal =0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = lst[i].IdVenta;
                dataGridView1.Rows[i].Cells[1].Value = lst[i].Cantidad;
                dataGridView1.Rows[i].Cells[2].Value = lst[i].Descripcion;
                dataGridView1.Rows[i].Cells[3].Value = lst[i].PrecioVenta;
                dataGridView1.Rows[i].Cells[4].Value = lst[i].SubTotal;
                dataGridView1.Rows[i].Cells[5].Value = lst[i].IdProducto;
                dataGridView1.Rows[i].Cells[6].Value = lst[i].Iva;
                SumaSubTotal += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                //SumaIva += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }

            dataGridView1.Rows.Add();


            if (radioFactura.Checked == true)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[lst.Count + 1].Cells[3].Value = "SUB-TOTAL  S/.";
                dataGridView1.Rows[lst.Count + 1].Cells[4].Value = SumaSubTotal;

                dataGridView1.Rows.Add();
                dataGridView1.Rows[lst.Count + 2].Cells[3].Value = "      IVA.        %";
                dataGridView1.Rows[lst.Count + 2].Cells[4].Value = "19";

                dataGridView1.Rows.Add();
                dataGridView1.Rows[lst.Count + 3].Cells[3].Value = "     TOTAL     S/.";
                SumaTotal += Convert.ToInt32(SumaSubTotal * iva);
                dataGridView1.Rows[lst.Count + 3].Cells[4].Value = SumaTotal;
            } else {

                dataGridView1.Rows.Add();
                dataGridView1.Rows[lst.Count + 1].Cells[3].Value = "     TOTAL     S/.";
                SumaTotal += Convert.ToInt32(SumaSubTotal);
                dataGridView1.Rows[lst.Count + 1].Cells[4].Value = SumaTotal;
            }

            dataGridView1.ClearSelection();
        }

        private void Limpiar() {
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtStock.Clear();
            txtPVenta.Clear();
            txtCantidad.Clear();
            txtCantidad.Focus();
            Program.Descripcion = "";
            Program.Stock = 0;
            Program.Marca = "";
            Program.PrecioVenta = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0){
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected == true){
                    if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != ""){
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    lst.RemoveAt(dataGridView1.CurrentRow.Index);
                        LlenarGrilla();
                        MessageBoxEx.Show("Producto Eliminado de la Lista Ok.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }else{
                      MessageBoxEx.Show("No Existe Ningun Elemento en la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      dataGridView1.ClearSelection();
                    }
                }else{
                 MessageBoxEx.Show("Por Favor Seleccione Item a Eliminar de la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                MessageBoxEx.Show("No Existe Ningun Elemento en la Lista","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0){
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != ""){
                    GuardarVenta();
                    try{
                        for (int i = 0; i < dataGridView1.Rows.Count; i++){
                               Decimal SumaSubTotal = 0;
                            if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) != ""){
                                SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                GuardarDetalleVenta(
                                Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value),
                                Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                                Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value),
                                Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value), SumaSubTotal
                                );
                                //DevComponents.DotNetBar.MessageBoxEx.Show("Contiene Datos.");
                            }else{
                                //DevComponents.DotNetBar.MessageBoxEx.Show("Fila Vacia.");
                            }
                        }
                        dataGridView1.Rows.Clear();
                        lst.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show(ex.Message);
                    }
                }else{
                    MessageBoxEx.Show("No Existe Ningún Elemento en la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBoxEx.Show("No Existe Ningún Elemento en la Lista.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void GuardarVenta()
        {
            Int32 Total=0;
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "") {
                for (int i = 0; i < dataGridView1.Rows.Count; i++){
			        Total=Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
			    }
            string TipoDocumento = "";
            TipoDocumento = radioBoleta.Checked == true ? "Boleta" : "Factura";

            Ventas.IdEmpleado=Program.IdEmpleadoLogueado;
            Ventas.IdCliente=Program.IdCliente;
            Ventas.TipoDocumento = TipoDocumento;
            Ventas.FechaVenta = DateTime.Today; //Convert.ToDateTime(dateTimePicker1.Value);
            Ventas.Total=Total;
            MessageBoxEx.Show(Ventas.RegistrarVenta(),"Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void GuardarDetalleVenta(Int32 objIdProducto, Int32 objIdVenta, Int32 objCantidad, Decimal objPUnitario, Decimal objSubTotal){
                    Detalle.IdProducto = objIdProducto;
                    Detalle.IdVenta = objIdVenta;
                    Detalle.Cantidad = objCantidad;
                    Detalle.PUnitario = objPUnitario;
                    Detalle.SubTotal = objSubTotal;
                    Detalle.RegistrarDetalleVenta();
                    Limpiar1();
                    GenerarIdVenta();
                    //GenerarNumeroComprobante();
        }

        private void Limpiar1() {
            txtDocIdentidad.Clear();
            txtDatos.Clear();
            dataGridView1.Rows.Clear();
            Program.IdEmpleadoLogueado = 0;
            Program.IdCliente = 0;
            txtIdProducto.Clear();
            Program.DocumentoIdentidad = "";
            Program.ApellidosCliente = "";
            Program.NombreCliente = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbnFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFactura.Checked == true)
                lblDocumento.Text = "FACTURA";
            else
                lblDocumento.Text = "BOLETA";
        }
        //private void btnQuitar_Click(object sender, EventArgs e)
        //{
        //    DialogResult Resultado = new DialogResult();
        //    Resultado = DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro Que Desea Quitar Este Producto.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //       if(Resultado==DialogResult.OK){
        //            try{	        
        //                foreach (DataGridViewRow row in dataGridView1.Rows)
        //                {
        //                    Boolean Activo=Convert.ToBoolean(row.Cells["Eliminar"].Value);
        //                    if(Activo){
        //                        for (int i = 0; i < dataGridView1.RowCount; i++)
        //                        {
        //                            dataGridView1.Rows.RemoveAt(i);
        //                        }
        //                    }
        //                }
        //            }catch (Exception ex){
        //                 DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
        //            }
        //       }
        //}

    }
}
