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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnVentasVendedor_Click(object sender, EventArgs e)
        {
            VentasXVendedor V = new VentasXVendedor();
            V.Show();
        }

        private void btnRankingProductos_Click(object sender, EventArgs e)
        {
            RankingProductos RP = new RankingProductos();
            RP.Show();
        }

        private void btnRankingClientes_Click(object sender, EventArgs e)
        {
            RankingClientes RC = new RankingClientes();
            RC.Show();
        }

        private void btnVentaDiaria_Click(object sender, EventArgs e)
        {
            VentasDiarias VD = new VentasDiarias();
            VD.Show();
        }
    }
}
