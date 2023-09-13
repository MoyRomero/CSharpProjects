namespace BDEmpleados
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
            this.dvgEmpleados = new System.Windows.Forms.DataGridView();
            this.buscarLbl = new System.Windows.Forms.Label();
            this.txtBxFiltro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.dvgEmpleados.Location = new System.Drawing.Point(12, 64);
            this.dvgEmpleados.Name = "dvgEmpleados";
            this.dvgEmpleados.ReadOnly = true;
            this.dvgEmpleados.Size = new System.Drawing.Size(455, 234);
            this.dvgEmpleados.TabIndex = 1;
            // 
            // buscarLbl
            // 
            this.buscarLbl.AutoSize = true;
            this.buscarLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buscarLbl.Location = new System.Drawing.Point(25, 26);
            this.buscarLbl.Name = "buscarLbl";
            this.buscarLbl.Size = new System.Drawing.Size(91, 13);
            this.buscarLbl.TabIndex = 3;
            this.buscarLbl.Text = "Escribe para filtrar";
            // 
            // txtBxFiltro
            // 
            this.txtBxFiltro.Location = new System.Drawing.Point(135, 23);
            this.txtBxFiltro.Name = "txtBxFiltro";
            this.txtBxFiltro.Size = new System.Drawing.Size(211, 20);
            this.txtBxFiltro.TabIndex = 4;
            this.txtBxFiltro.TextChanged += new System.EventHandler(this.txtBxFiltradoVacio);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "FILTRAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(479, 310);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBxFiltro);
            this.Controls.Add(this.buscarLbl);
            this.Controls.Add(this.dvgEmpleados);
            this.Name = "Form3";
            this.Text = "FILTRADO POR BOTÓN";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpleados;
        private System.Windows.Forms.Label buscarLbl;
        private System.Windows.Forms.TextBox txtBxFiltro;
        private System.Windows.Forms.Button button1;
    }
}