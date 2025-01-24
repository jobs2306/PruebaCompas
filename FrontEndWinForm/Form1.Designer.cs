namespace FrontEndWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            lvProductos = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            buttActProd = new Button();
            panel10 = new Panel();
            buttDeleteProd = new Button();
            panel9 = new Panel();
            buttChangeProd = new Button();
            panel8 = new Panel();
            buttAddProd = new Button();
            panel7 = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 63);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(520, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 41);
            label1.TabIndex = 2;
            label1.Text = "Productos";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 63);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(43, 590);
            panel3.TabIndex = 6;
            // 
            // lvProductos
            // 
            lvProductos.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            lvProductos.Dock = DockStyle.Left;
            lvProductos.Location = new Point(0, 0);
            lvProductos.Name = "lvProductos";
            lvProductos.Size = new Size(680, 590);
            lvProductos.TabIndex = 7;
            lvProductos.UseCompatibleStateImageBehavior = false;
            lvProductos.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "ID";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Nombre";
            columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Descripción";
            columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Precio";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Stock";
            columnHeader10.Width = 80;
            // 
            // panel4
            // 
            panel4.Controls.Add(lvProductos);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(43, 63);
            panel4.Name = "panel4";
            panel4.Size = new Size(686, 590);
            panel4.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(729, 63);
            panel5.Name = "panel5";
            panel5.Size = new Size(74, 590);
            panel5.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttActProd);
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(buttDeleteProd);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(buttChangeProd);
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(buttAddProd);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(803, 63);
            panel6.Name = "panel6";
            panel6.Size = new Size(287, 590);
            panel6.TabIndex = 10;
            // 
            // buttActProd
            // 
            buttActProd.Dock = DockStyle.Top;
            buttActProd.Font = new Font("Segoe UI", 12F);
            buttActProd.Location = new Point(0, 356);
            buttActProd.Name = "buttActProd";
            buttActProd.Size = new Size(287, 40);
            buttActProd.TabIndex = 11;
            buttActProd.Text = "Actualizar Lista";
            buttActProd.UseVisualStyleBackColor = true;
            buttActProd.Click += buttActProd_Click;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 331);
            panel10.Name = "panel10";
            panel10.Size = new Size(287, 25);
            panel10.TabIndex = 10;
            // 
            // buttDeleteProd
            // 
            buttDeleteProd.Dock = DockStyle.Top;
            buttDeleteProd.Font = new Font("Segoe UI", 12F);
            buttDeleteProd.Location = new Point(0, 291);
            buttDeleteProd.Name = "buttDeleteProd";
            buttDeleteProd.Size = new Size(287, 40);
            buttDeleteProd.TabIndex = 9;
            buttDeleteProd.Text = "Eliminar Producto";
            buttDeleteProd.UseVisualStyleBackColor = true;
            buttDeleteProd.Click += buttDeleteProd_Click;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 266);
            panel9.Name = "panel9";
            panel9.Size = new Size(287, 25);
            panel9.TabIndex = 8;
            // 
            // buttChangeProd
            // 
            buttChangeProd.Dock = DockStyle.Top;
            buttChangeProd.Font = new Font("Segoe UI", 12F);
            buttChangeProd.Location = new Point(0, 226);
            buttChangeProd.Name = "buttChangeProd";
            buttChangeProd.Size = new Size(287, 40);
            buttChangeProd.TabIndex = 7;
            buttChangeProd.Text = "Modificar Producto";
            buttChangeProd.UseVisualStyleBackColor = true;
            buttChangeProd.Click += buttChangeProd_Click;
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 201);
            panel8.Name = "panel8";
            panel8.Size = new Size(287, 25);
            panel8.TabIndex = 6;
            // 
            // buttAddProd
            // 
            buttAddProd.Dock = DockStyle.Top;
            buttAddProd.Font = new Font("Segoe UI", 12F);
            buttAddProd.Location = new Point(0, 161);
            buttAddProd.Name = "buttAddProd";
            buttAddProd.Size = new Size(287, 40);
            buttAddProd.TabIndex = 5;
            buttAddProd.Text = "Agregar Producto";
            buttAddProd.UseVisualStyleBackColor = true;
            buttAddProd.Click += buttAddProd_Click;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(287, 161);
            panel7.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 59, 93);
            ClientSize = new Size(1182, 653);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private ListView lvProductos;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button buttAddProd;
        private Panel panel7;
        private Panel panel9;
        private Button buttChangeProd;
        private Panel panel8;
        private Button buttActProd;
        private Panel panel10;
        private Button buttDeleteProd;
    }
}
