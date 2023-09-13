namespace BDEmpleados
{
    partial class Form6
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
            this.dvgEmpleados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmBoxOpciones = new System.Windows.Forms.ComboBox();
            this.txtbValor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReestablecer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgEmpleados
            // 
            this.dvgEmpleados.AllowUserToAddRows = false;
            this.dvgEmpleados.AllowUserToDeleteRows = false;
            this.dvgEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEmpleados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgEmpleados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEmpleados.Location = new System.Drawing.Point(12, 112);
            this.dvgEmpleados.Name = "dvgEmpleados";
            this.dvgEmpleados.ReadOnly = true;
            this.dvgEmpleados.Size = new System.Drawing.Size(419, 201);
            this.dvgEmpleados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "OPCIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "VALOR";
            // 
            // cmBoxOpciones
            // 
            this.cmBoxOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxOpciones.FormattingEnabled = true;
            this.cmBoxOpciones.Items.AddRange(new object[] {
            "Código",
            "Nombre",
            "Apellido Paterno",
            "Apellido Materno"});
            this.cmBoxOpciones.Location = new System.Drawing.Point(87, 12);
            this.cmBoxOpciones.Name = "cmBoxOpciones";
            this.cmBoxOpciones.Size = new System.Drawing.Size(211, 21);
            this.cmBoxOpciones.TabIndex = 6;
            // 
            // txtbValor
            // 
            this.txtbValor.Location = new System.Drawing.Point(87, 49);
            this.txtbValor.Name = "txtbValor";
            this.txtbValor.Size = new System.Drawing.Size(211, 20);
            this.txtbValor.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(315, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnReestablecer
            // 
            this.btnReestablecer.Location = new System.Drawing.Point(141, 83);
            this.btnReestablecer.Name = "btnReestablecer";
            this.btnReestablecer.Size = new System.Drawing.Size(137, 23);
            this.btnReestablecer.TabIndex = 9;
            this.btnReestablecer.Text = "REESTABLECER TABLA";
            this.btnReestablecer.UseVisualStyleBackColor = true;
            this.btnReestablecer.Click += new System.EventHandler(this.btnReestablecer_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(443, 325);
            this.Controls.Add(this.btnReestablecer);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtbValor);
            this.Controls.Add(this.cmBoxOpciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvgEmpleados);
            this.Name = "Form6";
            this.Text = "FILTRO POR CAMPO";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBoxOpciones;
        private System.Windows.Forms.TextBox txtbValor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnReestablecer;
    }
}