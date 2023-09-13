namespace BDEmpleados
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
            this.dvgEmpleados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IntroNmbrLeft = new System.Windows.Forms.NumericUpDown();
            this.IntroNmbrRight = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntroNmbrLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntroNmbrRight)).BeginInit();
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
            this.dvgEmpleados.Location = new System.Drawing.Point(12, 112);
            this.dvgEmpleados.Name = "dvgEmpleados";
            this.dvgEmpleados.ReadOnly = true;
            this.dvgEmpleados.Size = new System.Drawing.Size(358, 237);
            this.dvgEmpleados.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.IntroNmbrLeft);
            this.groupBox1.Controls.Add(this.IntroNmbrRight);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTRADO POR RANGO DE EDAD";
            // 
            // IntroNmbrLeft
            // 
            this.IntroNmbrLeft.Location = new System.Drawing.Point(6, 29);
            this.IntroNmbrLeft.Name = "IntroNmbrLeft";
            this.IntroNmbrLeft.Size = new System.Drawing.Size(120, 20);
            this.IntroNmbrLeft.TabIndex = 3;
            this.IntroNmbrLeft.ValueChanged += new System.EventHandler(this.leftFilter);
            // 
            // IntroNmbrRight
            // 
            this.IntroNmbrRight.Location = new System.Drawing.Point(186, 29);
            this.IntroNmbrRight.Name = "IntroNmbrRight";
            this.IntroNmbrRight.Size = new System.Drawing.Size(120, 20);
            this.IntroNmbrRight.TabIndex = 2;
            this.IntroNmbrRight.ValueChanged += new System.EventHandler(this.rightFilter);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(81, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "REESTABLECER TABLA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(382, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dvgEmpleados);
            this.Name = "Form5";
            this.Text = "FILTRO POR EDAD";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpleados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IntroNmbrLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntroNmbrRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpleados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown IntroNmbrLeft;
        private System.Windows.Forms.NumericUpDown IntroNmbrRight;
        private System.Windows.Forms.Button button1;
    }
}