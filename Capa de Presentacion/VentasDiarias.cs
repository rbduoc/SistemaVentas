using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class VentasDiarias : Form
    {
        Ventas V = new Ventas();

        public VentasDiarias()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }


        private void MostrarListado()
        {
            DataTable dt = new DataTable();
            dt = V.VentasDiarias(Convert.ToDateTime(dtPickerFecha.Value));
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = Convert.ToDateTime(dt.Rows[i][4]).Date.ToString();
                dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
            }
            dataGridView1.ClearSelection();
        }
    }
}
