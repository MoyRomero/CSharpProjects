namespace LINQ_Form_1
{
    partial class Form4
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            nuevoProveedor = new ComboBox();
            nuevaCategoria = new ComboBox();
            nuevoProducto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            groupBox2 = new GroupBox();
            cmBoxProveedorA = new ComboBox();
            cmBoxCategoriaA = new ComboBox();
            label7 = new Label();
            textBox6 = new TextBox();
            cmBoxIDProductoA = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button2 = new Button();
            groupBox3 = new GroupBox();
            label8 = new Label();
            cmBoxIDProductoD = new ComboBox();
            button3 = new Button();
            tablaCRUD = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaCRUD).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nuevoProveedor);
            groupBox1.Controls.Add(nuevaCategoria);
            groupBox1.Controls.Add(nuevoProducto);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 136);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingresar Datos";
            // 
            // nuevoProveedor
            // 
            nuevoProveedor.FormattingEnabled = true;
            nuevoProveedor.Items.AddRange(new object[] { "Bimbo", "Barcel", "Tía Rosa", "Gamesa", "Sabritas", "Marinela" });
            nuevoProveedor.Location = new Point(83, 75);
            nuevoProveedor.Name = "nuevoProveedor";
            nuevoProveedor.Size = new Size(140, 23);
            nuevoProveedor.TabIndex = 7;
            nuevoProveedor.Text = "Selecciona Proveedor";
            // 
            // nuevaCategoria
            // 
            nuevaCategoria.FormattingEnabled = true;
            nuevaCategoria.Items.AddRange(new object[] { "Galletas", "Frituras", "Panes" });
            nuevaCategoria.Location = new Point(83, 45);
            nuevaCategoria.Name = "nuevaCategoria";
            nuevaCategoria.Size = new Size(140, 23);
            nuevaCategoria.TabIndex = 6;
            nuevaCategoria.Text = "Selecciona Categoría";
            // 
            // nuevoProducto
            // 
            nuevoProducto.Location = new Point(83, 16);
            nuevoProducto.Name = "nuevoProducto";
            nuevoProducto.PlaceholderText = "Nombre Producto";
            nuevoProducto.Size = new Size(140, 23);
            nuevoProducto.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 81);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 50);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Categoría";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 22);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Producto";
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(53, 108);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 0;
            button1.Text = "AGREGAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmBoxProveedorA);
            groupBox2.Controls.Add(cmBoxCategoriaA);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(cmBoxIDProductoA);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(button2);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(273, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 136);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actualizar Datos";
            // 
            // cmBoxProveedorA
            // 
            cmBoxProveedorA.FormattingEnabled = true;
            cmBoxProveedorA.Items.AddRange(new object[] { "Bimbo", "Barcel", "Tía Rosa", "Gamesa", "Sabritas", "Marinela" });
            cmBoxProveedorA.Location = new Point(82, 81);
            cmBoxProveedorA.Name = "cmBoxProveedorA";
            cmBoxProveedorA.Size = new Size(241, 23);
            cmBoxProveedorA.TabIndex = 13;
            cmBoxProveedorA.Text = "Selecciona Proveedor";
            // 
            // cmBoxCategoriaA
            // 
            cmBoxCategoriaA.FormattingEnabled = true;
            cmBoxCategoriaA.Items.AddRange(new object[] { "Galletas", "Frituras", "Panes" });
            cmBoxCategoriaA.Location = new Point(82, 51);
            cmBoxCategoriaA.Name = "cmBoxCategoriaA";
            cmBoxCategoriaA.Size = new Size(241, 23);
            cmBoxCategoriaA.TabIndex = 12;
            cmBoxCategoriaA.Text = "Selecciona Categoría";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 24);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 11;
            label7.Text = "ID Producto";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(209, 21);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Nombre Producto";
            textBox6.Size = new Size(114, 23);
            textBox6.TabIndex = 10;
            // 
            // cmBoxIDProductoA
            // 
            cmBoxIDProductoA.FormattingEnabled = true;
            cmBoxIDProductoA.Location = new Point(82, 21);
            cmBoxIDProductoA.Name = "cmBoxIDProductoA";
            cmBoxIDProductoA.Size = new Size(59, 23);
            cmBoxIDProductoA.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 84);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Proveedor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 54);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 5;
            label5.Text = "Categoría";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(147, 24);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 4;
            label6.Text = "Producto";
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(98, 109);
            button2.Name = "button2";
            button2.Size = new Size(158, 23);
            button2.TabIndex = 1;
            button2.Text = "ACTUALIZAR";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(cmBoxIDProductoD);
            groupBox3.Controls.Add(button3);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(631, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(180, 136);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Borrar Datos";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 46);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 13;
            label8.Text = "ID Producto";
            // 
            // cmBoxIDProductoD
            // 
            cmBoxIDProductoD.FormattingEnabled = true;
            cmBoxIDProductoD.Location = new Point(82, 43);
            cmBoxIDProductoD.Name = "cmBoxIDProductoD";
            cmBoxIDProductoD.Size = new Size(67, 23);
            cmBoxIDProductoD.TabIndex = 12;
            // 
            // button3
            // 
            button3.ForeColor = Color.Black;
            button3.Location = new Point(6, 109);
            button3.Name = "button3";
            button3.Size = new Size(168, 22);
            button3.TabIndex = 2;
            button3.Text = "BORRAR";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tablaCRUD
            // 
            tablaCRUD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaCRUD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaCRUD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tablaCRUD.BackgroundColor = SystemColors.ControlLightLight;
            tablaCRUD.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tablaCRUD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tablaCRUD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaCRUD.Location = new Point(12, 154);
            tablaCRUD.Name = "tablaCRUD";
            tablaCRUD.ReadOnly = true;
            tablaCRUD.RowTemplate.Height = 25;
            tablaCRUD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaCRUD.Size = new Size(800, 228);
            tablaCRUD.TabIndex = 12;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(823, 388);
            Controls.Add(tablaCRUD);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablaCRUD).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox nuevoProducto;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private GroupBox groupBox2;
        private Label label7;
        private TextBox textBox6;
        private ComboBox cmBoxIDProductoA;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button2;
        private GroupBox groupBox3;
        private Label label8;
        private ComboBox cmBoxIDProductoD;
        private Button button3;
        private DataGridView tablaCRUD;
        private ComboBox nuevoProveedor;
        private ComboBox nuevaCategoria;
        private ComboBox cmBoxProveedorA;
        private ComboBox cmBoxCategoriaA;
    }
}