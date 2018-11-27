namespace Capa_de_Presentacion
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVentasVendedor = new System.Windows.Forms.Button();
            this.btnRankingProductos = new System.Windows.Forms.Button();
            this.btnRankingClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVentasVendedor
            // 
            this.btnVentasVendedor.Location = new System.Drawing.Point(65, 51);
            this.btnVentasVendedor.Name = "btnVentasVendedor";
            this.btnVentasVendedor.Size = new System.Drawing.Size(176, 52);
            this.btnVentasVendedor.TabIndex = 0;
            this.btnVentasVendedor.Text = "Ventas por Vendedor";
            this.btnVentasVendedor.UseVisualStyleBackColor = true;
            this.btnVentasVendedor.Click += new System.EventHandler(this.btnVentasVendedor_Click);
            // 
            // btnRankingProductos
            // 
            this.btnRankingProductos.Location = new System.Drawing.Point(65, 139);
            this.btnRankingProductos.Name = "btnRankingProductos";
            this.btnRankingProductos.Size = new System.Drawing.Size(176, 54);
            this.btnRankingProductos.TabIndex = 1;
            this.btnRankingProductos.Text = "Ranking Productos";
            this.btnRankingProductos.UseVisualStyleBackColor = true;
            this.btnRankingProductos.Click += new System.EventHandler(this.btnRankingProductos_Click);
            // 
            // btnRankingClientes
            // 
            this.btnRankingClientes.Location = new System.Drawing.Point(65, 233);
            this.btnRankingClientes.Name = "btnRankingClientes";
            this.btnRankingClientes.Size = new System.Drawing.Size(176, 52);
            this.btnRankingClientes.TabIndex = 2;
            this.btnRankingClientes.Text = "Clientes que mas Compran";
            this.btnRankingClientes.UseVisualStyleBackColor = true;
            this.btnRankingClientes.Click += new System.EventHandler(this.btnRankingClientes_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 359);
            this.Controls.Add(this.btnRankingClientes);
            this.Controls.Add(this.btnRankingProductos);
            this.Controls.Add(this.btnVentasVendedor);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVentasVendedor;
        private System.Windows.Forms.Button btnRankingProductos;
        private System.Windows.Forms.Button btnRankingClientes;
    }
}