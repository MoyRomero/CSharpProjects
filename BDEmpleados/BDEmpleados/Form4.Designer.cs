namespace BDEmpleados
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
            this.dvgEmpleados = new System.Windows.Forms.DataGridView();
            this.txtBxFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dvgEmpleados.Location = new System.Drawing.Point(12, 85);
            this.dvgEmpleados.Name = "dvgEmpleados";
            this.dvgEmpleados.ReadOnly = true;
            this.dvgEmpleados.Size = new System.Drawing.Size(438, 239);
            this.dvgEmpleados.TabIndex = 1;
            // 
            // txtBxFiltro
            // 
            this.txtBxFiltro.Location = new System.Drawing.Point(183, 36);
            this.txtBxFiltro.Name = "txtBxFiltro";
            this.txtBxFiltro.Size = new System.Drawing.Size(227, 20);
            this.txtBxFiltro.TabIndex = 2;
            this.txtBxFiltro.TextChanged += new System.EventHandler(this.txtFiltro);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(44, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ESCRIBE PARA FILTRAR";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(462, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxFiltro);
            this.Controls.Add(this.dvgEmpleados);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form4";
            this.Text = "FILTRADO SENSITIVO";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpleados;
        private System.Windows.Forms.TextBox txtBxFiltro;
        private System.Windows.Forms.Label label1;
    }
}