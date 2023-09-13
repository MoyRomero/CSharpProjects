namespace BDNorthwind
{
    partial class Form2
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
            this.dgvEjercicio_2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBxRegion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicio_2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEjercicio_2
            // 
            this.dgvEjercicio_2.AllowUserToAddRows = false;
            this.dgvEjercicio_2.AllowUserToDeleteRows = false;
            this.dgvEjercicio_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEjercicio_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEjercicio_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEjercicio_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjercicio_2.Location = new System.Drawing.Point(12, 80);
            this.dgvEjercicio_2.Name = "dgvEjercicio_2";
            this.dgvEjercicio_2.Size = new System.Drawing.Size(499, 358);
            this.dgvEjercicio_2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(55, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECCIONA LA REGIÓN";
            // 
            // cmBxRegion
            // 
            this.cmBxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxRegion.FormattingEnabled = true;
            this.cmBxRegion.Items.AddRange(new object[] {
            "Eastern",
            "Western",
            "Northern",
            "Southern"});
            this.cmBxRegion.Location = new System.Drawing.Point(261, 32);
            this.cmBxRegion.Name = "cmBxRegion";
            this.cmBxRegion.Size = new System.Drawing.Size(212, 21);
            this.cmBxRegion.TabIndex = 2;
            this.cmBxRegion.SelectedIndexChanged += new System.EventHandler(this.filtradoRegion);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.cmBxRegion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEjercicio_2);
            this.Name = "Form2";
            this.Text = "FILTRADO POR REGIÓN";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicio_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEjercicio_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBxRegion;
    }
}