namespace LINQ_Form_1
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
            label1 = new Label();
            label2 = new Label();
            N1 = new TextBox();
            N2 = new TextBox();
            label3 = new Label();
            sumBtn = new Button();
            resBtn = new Button();
            multBtn = new Button();
            divBtn = new Button();
            resultado = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 61);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingresar Número 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 100);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Ingresar Número 2";
            // 
            // N1
            // 
            N1.Location = new Point(171, 58);
            N1.Name = "N1";
            N1.Size = new Size(45, 23);
            N1.TabIndex = 2;
            // 
            // N2
            // 
            N2.Location = new Point(171, 97);
            N2.Name = "N2";
            N2.Size = new Size(45, 23);
            N2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 16);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 4;
            label3.Text = "CALCULADORA";
            // 
            // sumBtn
            // 
            sumBtn.Location = new Point(116, 147);
            sumBtn.Name = "sumBtn";
            sumBtn.Size = new Size(91, 23);
            sumBtn.TabIndex = 6;
            sumBtn.Text = "SUMAR";
            sumBtn.UseVisualStyleBackColor = true;
            sumBtn.Click += sumBtn_Click;
            // 
            // resBtn
            // 
            resBtn.Location = new Point(116, 176);
            resBtn.Name = "resBtn";
            resBtn.Size = new Size(91, 23);
            resBtn.TabIndex = 7;
            resBtn.Text = "RESTAR";
            resBtn.UseVisualStyleBackColor = true;
            resBtn.Click += resBtn_Click;
            // 
            // multBtn
            // 
            multBtn.Location = new Point(116, 205);
            multBtn.Name = "multBtn";
            multBtn.Size = new Size(91, 23);
            multBtn.TabIndex = 8;
            multBtn.Text = "MULTIPLICAR";
            multBtn.UseVisualStyleBackColor = true;
            multBtn.Click += multBtn_Click;
            // 
            // divBtn
            // 
            divBtn.Location = new Point(116, 234);
            divBtn.Name = "divBtn";
            divBtn.Size = new Size(91, 23);
            divBtn.TabIndex = 9;
            divBtn.Text = "DIVIDIR";
            divBtn.UseVisualStyleBackColor = true;
            divBtn.Click += divBtn_Click;
            // 
            // resultado
            // 
            resultado.AutoSize = true;
            resultado.Location = new Point(234, 83);
            resultado.Name = "resultado";
            resultado.Size = new Size(0, 15);
            resultado.TabIndex = 10;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 301);
            Controls.Add(resultado);
            Controls.Add(divBtn);
            Controls.Add(multBtn);
            Controls.Add(resBtn);
            Controls.Add(sumBtn);
            Controls.Add(label3);
            Controls.Add(N2);
            Controls.Add(N1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "CALCULADORA";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox N1;
        private TextBox N2;
        private Label label3;
        private Button sumBtn;
        private Button resBtn;
        private Button multBtn;
        private Button divBtn;
        private Label resultado;
    }
}