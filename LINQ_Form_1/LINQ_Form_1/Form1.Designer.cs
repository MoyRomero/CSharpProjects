namespace LINQ_Form_1
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
            components = new System.ComponentModel.Container();
            Grid_Categoria = new DataGridView();
            txtbidCategoria = new TextBox();
            txtbCategoria = new TextBox();
            idCategoria = new Label();
            categoria = new Label();
            agregarBtn = new Button();
            errorFormulario = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)Grid_Categoria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorFormulario).BeginInit();
            SuspendLayout();
            // 
            // Grid_Categoria
            // 
            Grid_Categoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Categoria.Location = new Point(12, 150);
            Grid_Categoria.Name = "Grid_Categoria";
            Grid_Categoria.RowTemplate.Height = 25;
            Grid_Categoria.Size = new Size(293, 163);
            Grid_Categoria.TabIndex = 0;
            // 
            // txtbidCategoria
            // 
            txtbidCategoria.Location = new Point(109, 22);
            txtbidCategoria.Name = "txtbidCategoria";
            txtbidCategoria.PlaceholderText = "Ingresar ID Categoría";
            txtbidCategoria.Size = new Size(161, 23);
            txtbidCategoria.TabIndex = 2;
            // 
            // txtbCategoria
            // 
            txtbCategoria.Location = new Point(109, 63);
            txtbCategoria.Name = "txtbCategoria";
            txtbCategoria.PlaceholderText = "Ingresar Categoría";
            txtbCategoria.Size = new Size(161, 23);
            txtbCategoria.TabIndex = 3;
            // 
            // idCategoria
            // 
            idCategoria.AutoSize = true;
            idCategoria.Location = new Point(24, 25);
            idCategoria.Name = "idCategoria";
            idCategoria.Size = new Size(75, 15);
            idCategoria.TabIndex = 4;
            idCategoria.Text = "ID Categoría:";
            // 
            // categoria
            // 
            categoria.AutoSize = true;
            categoria.Location = new Point(24, 66);
            categoria.Name = "categoria";
            categoria.Size = new Size(61, 15);
            categoria.TabIndex = 5;
            categoria.Text = "Categoría:";
            // 
            // agregarBtn
            // 
            agregarBtn.Location = new Point(109, 112);
            agregarBtn.Name = "agregarBtn";
            agregarBtn.Size = new Size(75, 23);
            agregarBtn.TabIndex = 6;
            agregarBtn.Text = "AGREGAR";
            agregarBtn.UseVisualStyleBackColor = true;
            agregarBtn.Click += agregarBtn_Click;
            // 
            // errorFormulario
            // 
            errorFormulario.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 325);
            Controls.Add(agregarBtn);
            Controls.Add(categoria);
            Controls.Add(idCategoria);
            Controls.Add(txtbCategoria);
            Controls.Add(txtbidCategoria);
            Controls.Add(Grid_Categoria);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LINQ Formulario 1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Grid_Categoria).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorFormulario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Grid_Categoria;
        private TextBox txtbidCategoria;
        private TextBox txtbCategoria;
        private Label idCategoria;
        private Label categoria;
        private Button agregarBtn;
        private ErrorProvider errorFormulario;
    }
}