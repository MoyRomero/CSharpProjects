namespace LINQ_Form_1
{
    partial class Form3
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ProductosTabla = new DataGridView();
            filtrarBtn = new Button();
            lblFiltrar = new Label();
            cmBoxCategoria = new ComboBox();
            ErrorComboBox = new ErrorProvider(components);
            txtBCategoria = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ProductosTabla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorComboBox).BeginInit();
            SuspendLayout();
            // 
            // ProductosTabla
            // 
            ProductosTabla.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProductosTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductosTabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ProductosTabla.BackgroundColor = SystemColors.ControlLightLight;
            ProductosTabla.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ProductosTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ProductosTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductosTabla.Location = new Point(12, 108);
            ProductosTabla.Name = "ProductosTabla";
            ProductosTabla.ReadOnly = true;
            ProductosTabla.RowTemplate.Height = 25;
            ProductosTabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductosTabla.Size = new Size(405, 288);
            ProductosTabla.TabIndex = 0;
            // 
            // filtrarBtn
            // 
            filtrarBtn.Location = new Point(177, 73);
            filtrarBtn.Name = "filtrarBtn";
            filtrarBtn.Size = new Size(75, 23);
            filtrarBtn.TabIndex = 1;
            filtrarBtn.Text = "FILTRAR";
            filtrarBtn.UseVisualStyleBackColor = true;
            filtrarBtn.Click += filtrarBtn_Click;
            // 
            // lblFiltrar
            // 
            lblFiltrar.AutoSize = true;
            lblFiltrar.ForeColor = SystemColors.Control;
            lblFiltrar.Location = new Point(161, 14);
            lblFiltrar.Margin = new Padding(0);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(108, 15);
            lblFiltrar.TabIndex = 3;
            lblFiltrar.Text = "Filtra por Categoría";
            lblFiltrar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmBoxCategoria
            // 
            cmBoxCategoria.ForeColor = SystemColors.MenuText;
            cmBoxCategoria.FormattingEnabled = true;
            cmBoxCategoria.Items.AddRange(new object[] { "Todas", "Galletas", "Frituras", "Panes" });
            cmBoxCategoria.Location = new Point(63, 39);
            cmBoxCategoria.Name = "cmBoxCategoria";
            cmBoxCategoria.Size = new Size(134, 23);
            cmBoxCategoria.TabIndex = 4;
            cmBoxCategoria.Tag = "";
            cmBoxCategoria.Text = "Selecciona Categoría";
            // 
            // ErrorComboBox
            // 
            ErrorComboBox.ContainerControl = this;
            // 
            // txtBCategoria
            // 
            txtBCategoria.Location = new Point(235, 39);
            txtBCategoria.Name = "txtBCategoria";
            txtBCategoria.PlaceholderText = "O escribe Categoría";
            txtBCategoria.Size = new Size(139, 23);
            txtBCategoria.TabIndex = 5;
            txtBCategoria.TextChanged += txtBFiltro;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(44, 44, 44);
            ClientSize = new Size(429, 408);
            Controls.Add(txtBCategoria);
            Controls.Add(cmBoxCategoria);
            Controls.Add(lblFiltrar);
            Controls.Add(filtrarBtn);
            Controls.Add(ProductosTabla);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)ProductosTabla).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorComboBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ProductosTabla;
        private Button filtrarBtn;
        private Label lblFiltrar;
        private ComboBox cmBoxCategoria;
        private ErrorProvider ErrorComboBox;
        private TextBox txtBCategoria;
    }
}