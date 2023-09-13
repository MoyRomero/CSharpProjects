namespace BDNorthwind
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            this.dgvEjercicio_5 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCbProveedor = new System.Windows.Forms.ComboBox();
            this.txtCbCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNumPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtNumStock = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorVacio = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicio_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorVacio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEjercicio_5
            // 
            this.dgvEjercicio_5.AllowUserToAddRows = false;
            this.dgvEjercicio_5.AllowUserToDeleteRows = false;
            this.dgvEjercicio_5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEjercicio_5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEjercicio_5.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEjercicio_5.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvEjercicio_5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjercicio_5.Location = new System.Drawing.Point(382, 32);
            this.dgvEjercicio_5.Name = "dgvEjercicio_5";
            this.dgvEjercicio_5.Size = new System.Drawing.Size(441, 336);
            this.dgvEjercicio_5.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(505, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "TABLA DE PRODUCTOS";
            // 
            // txtCbProveedor
            // 
            this.txtCbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCbProveedor.FormattingEnabled = true;
            this.txtCbProveedor.Location = new System.Drawing.Point(139, 120);
            this.txtCbProveedor.Name = "txtCbProveedor";
            this.txtCbProveedor.Size = new System.Drawing.Size(211, 21);
            this.txtCbProveedor.TabIndex = 5;
            // 
            // txtCbCategoria
            // 
            this.txtCbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCbCategoria.FormattingEnabled = true;
            this.txtCbCategoria.Location = new System.Drawing.Point(139, 79);
            this.txtCbCategoria.Name = "txtCbCategoria";
            this.txtCbCategoria.Size = new System.Drawing.Size(211, 21);
            this.txtCbCategoria.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(139, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(211, 20);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.TextChanged += new System.EventHandler(this.senNombre);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(139, 164);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(211, 83);
            this.txtDescripcion.TabIndex = 8;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.senDescrip);
            // 
            // txtNumPrecio
            // 
            this.txtNumPrecio.Location = new System.Drawing.Point(139, 264);
            this.txtNumPrecio.Name = "txtNumPrecio";
            this.txtNumPrecio.Size = new System.Drawing.Size(126, 20);
            this.txtNumPrecio.TabIndex = 9;
            // 
            // txtNumStock
            // 
            this.txtNumStock.Location = new System.Drawing.Point(139, 301);
            this.txtNumStock.Name = "txtNumStock";
            this.txtNumStock.Size = new System.Drawing.Size(126, 20);
            this.txtNumStock.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(23, 340);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(327, 28);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "AGREGAR PRODUCTO";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "NOMBRE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "CATEGORÍA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "PROVEEDOR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(20, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "DESCRIPCIÓN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(29, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "PRECIO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(29, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "STOCK:";
            // 
            // errorVacio
            // 
            this.errorVacio.ContainerControl = this;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(835, 391);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNumStock);
            this.Controls.Add(this.txtNumPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCbCategoria);
            this.Controls.Add(this.txtCbProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEjercicio_5);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSERCIÓN DE PRODUCTOS";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicio_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorVacio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEjercicio_5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtCbProveedor;
        private System.Windows.Forms.ComboBox txtCbCategoria;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown txtNumPrecio;
        private System.Windows.Forms.NumericUpDown txtNumStock;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorVacio;
    }
}