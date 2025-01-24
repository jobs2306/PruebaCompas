namespace FrontEndWinForm
{
    partial class ProductoForm
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
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            panel19 = new Panel();
            buttActProd = new Button();
            panel22 = new Panel();
            buttonCreateProd = new Button();
            panel21 = new Panel();
            panel20 = new Panel();
            panel6 = new Panel();
            panel18 = new Panel();
            panel17 = new Panel();
            panel15 = new Panel();
            panel14 = new Panel();
            panel12 = new Panel();
            panel11 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            panel3 = new Panel();
            panel16 = new Panel();
            label5 = new Label();
            panel13 = new Panel();
            label4 = new Label();
            panel10 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            label2 = new Label();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel19.SuspendLayout();
            panel6.SuspendLayout();
            panel17.SuspendLayout();
            panel14.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            panel16.SuspendLayout();
            panel13.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Bottom;
            txtNombre.Location = new Point(0, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(467, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Location = new Point(0, 4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(467, 27);
            txtDescripcion.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Dock = DockStyle.Bottom;
            txtPrecio.Location = new Point(0, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(467, 27);
            txtPrecio.TabIndex = 2;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // txtStock
            // 
            txtStock.Dock = DockStyle.Top;
            txtStock.Location = new Point(0, 0);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(467, 27);
            txtStock.TabIndex = 3;
            txtStock.KeyPress += txtStock_KeyPress;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(53, 653);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(53, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1129, 59);
            panel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(397, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 41);
            label1.TabIndex = 10;
            label1.Text = "Productos";
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(397, 59);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel19);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel3);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(53, 59);
            panel5.Name = "panel5";
            panel5.Size = new Size(1117, 594);
            panel5.TabIndex = 9;
            // 
            // panel19
            // 
            panel19.Controls.Add(buttActProd);
            panel19.Controls.Add(panel22);
            panel19.Controls.Add(buttonCreateProd);
            panel19.Controls.Add(panel21);
            panel19.Controls.Add(panel20);
            panel19.Dock = DockStyle.Left;
            panel19.Location = new Point(664, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(397, 594);
            panel19.TabIndex = 9;
            // 
            // buttActProd
            // 
            buttActProd.Dock = DockStyle.Top;
            buttActProd.Font = new Font("Segoe UI", 13.8F);
            buttActProd.Location = new Point(61, 84);
            buttActProd.Name = "buttActProd";
            buttActProd.Size = new Size(336, 40);
            buttActProd.TabIndex = 20;
            buttActProd.Text = "Actualizar Producto";
            buttActProd.UseVisualStyleBackColor = true;
            buttActProd.Click += buttActProd_Click;
            // 
            // panel22
            // 
            panel22.Dock = DockStyle.Top;
            panel22.Location = new Point(61, 73);
            panel22.Name = "panel22";
            panel22.Size = new Size(336, 11);
            panel22.TabIndex = 19;
            // 
            // buttonCreateProd
            // 
            buttonCreateProd.Dock = DockStyle.Top;
            buttonCreateProd.Font = new Font("Segoe UI", 13.8F);
            buttonCreateProd.Location = new Point(61, 30);
            buttonCreateProd.Name = "buttonCreateProd";
            buttonCreateProd.Size = new Size(336, 43);
            buttonCreateProd.TabIndex = 18;
            buttonCreateProd.Text = "Crear Producto";
            buttonCreateProd.UseVisualStyleBackColor = true;
            buttonCreateProd.Click += buttonCreateProd_Click;
            // 
            // panel21
            // 
            panel21.Dock = DockStyle.Top;
            panel21.Location = new Point(61, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(336, 30);
            panel21.TabIndex = 17;
            // 
            // panel20
            // 
            panel20.Dock = DockStyle.Left;
            panel20.Location = new Point(0, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(61, 594);
            panel20.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel18);
            panel6.Controls.Add(panel17);
            panel6.Controls.Add(panel15);
            panel6.Controls.Add(panel14);
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(panel11);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(197, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(467, 594);
            panel6.TabIndex = 8;
            // 
            // panel18
            // 
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(0, 157);
            panel18.Name = "panel18";
            panel18.Size = new Size(467, 11);
            panel18.TabIndex = 16;
            // 
            // panel17
            // 
            panel17.Controls.Add(txtStock);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(0, 126);
            panel17.Name = "panel17";
            panel17.Size = new Size(467, 31);
            panel17.TabIndex = 15;
            // 
            // panel15
            // 
            panel15.Dock = DockStyle.Top;
            panel15.Location = new Point(0, 115);
            panel15.Name = "panel15";
            panel15.Size = new Size(467, 11);
            panel15.TabIndex = 14;
            // 
            // panel14
            // 
            panel14.Controls.Add(txtPrecio);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(0, 84);
            panel14.Name = "panel14";
            panel14.Size = new Size(467, 31);
            panel14.TabIndex = 13;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 73);
            panel12.Name = "panel12";
            panel12.Size = new Size(467, 11);
            panel12.TabIndex = 12;
            // 
            // panel11
            // 
            panel11.Controls.Add(txtDescripcion);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 42);
            panel11.Name = "panel11";
            panel11.Size = new Size(467, 31);
            panel11.TabIndex = 11;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 31);
            panel9.Name = "panel9";
            panel9.Size = new Size(467, 11);
            panel9.TabIndex = 10;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtNombre);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(467, 31);
            panel8.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel16);
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel7);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(197, 594);
            panel3.TabIndex = 7;
            // 
            // panel16
            // 
            panel16.Controls.Add(label5);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 126);
            panel16.Name = "panel16";
            panel16.Size = new Size(197, 42);
            panel16.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 31);
            label5.TabIndex = 11;
            label5.Text = "Stock:";
            // 
            // panel13
            // 
            panel13.Controls.Add(label4);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 84);
            panel13.Name = "panel13";
            panel13.Size = new Size(197, 42);
            panel13.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 31);
            label4.TabIndex = 11;
            label4.Text = "Precio:";
            // 
            // panel10
            // 
            panel10.Controls.Add(label3);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 42);
            panel10.Name = "panel10";
            panel10.Size = new Size(197, 42);
            panel10.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(139, 31);
            label3.TabIndex = 11;
            label3.Text = "Descripción:";
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(197, 42);
            panel7.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(103, 31);
            label2.TabIndex = 11;
            label2.Text = "Nombre:";
            // 
            // ProductoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 59, 93);
            ClientSize = new Size(1182, 653);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductoForm";
            Text = "ProductoForm";
            Load += ProductoForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel3.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Label label1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel8;
        private Panel panel3;
        private Panel panel7;
        private Label label2;
        private Panel panel19;
        private Button buttActProd;
        private Panel panel22;
        private Button buttonCreateProd;
        private Panel panel21;
        private Panel panel20;
        private Panel panel18;
        private Panel panel17;
        private Panel panel15;
        private Panel panel14;
        private Panel panel12;
        private Panel panel11;
        private Panel panel9;
        private Panel panel16;
        private Label label5;
        private Panel panel13;
        private Label label4;
        private Panel panel10;
        private Label label3;
    }
}