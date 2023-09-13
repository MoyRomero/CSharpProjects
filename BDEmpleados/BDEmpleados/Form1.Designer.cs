namespace BDEmpleados
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvgEmpleados = new System.Windows.Forms.DataGridView();
            this.buscarLbl = new System.Windows.Forms.Label();
            this.buscarTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgEmpleados
            // 
            this.dvgEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEmpleados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgEmpleados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEmpleados.Location = new System.Drawing.Point(12, 57);
            this.dvgEmpleados.Name = "dvgEmpleados";
            this.dvgEmpleados.ReadOnly = true;
            this.dvgEmpleados.Size = new System.Drawing.Size(336, 281);
            this.dvgEmpleados.TabIndex = 0;
            // 
            // buscarLbl
            // 
            this.buscarLbl.AutoSize = true;
            this.buscarLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buscarLbl.Location = new System.Drawing.Point(21, 15);
            this.buscarLbl.Name = "buscarLbl";
            this.buscarLbl.Size = new System.Drawing.Size(51, 13);
            this.buscarLbl.TabIndex = 1;
            this.buscarLbl.Text = "BUSCAR";
            // 
            // buscarTxtBox
            // 
            this.buscarTxtBox.Location = new System.Drawing.Point(78, 12);
            this.buscarTxtBox.Name = "buscarTxtBox";
            this.buscarTxtBox.Size = new System.Drawing.Size(270, 20);
            this.buscarTxtBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(360, 350);
            this.Controls.Add(this.buscarTxtBox);
            this.Controls.Add(this.buscarLbl);
            this.Controls.Add(this.dvgEmpleados);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLEADOS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpleados;
        private System.Windows.Forms.Label buscarLbl;
        private System.Windows.Forms.TextBox buscarTxtBox;
    }
}

