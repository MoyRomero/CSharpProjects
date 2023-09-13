using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDB_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.customersBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == (char)13)
            {
                var index = customersBindingSource.Find("CustomerID", toolStripTextBox1);

                if (index >= 1)
                {


                    customersBindingSource.Position = index;

                    MessageBox.Show($"El índice de {toolStripTextBox1.Text} es: " +
                        $"{Convert.ToInt32(index.ToString())+1}");

                }
                else{

                    MessageBox.Show($"No existe el ID: {toolStripTextBox1.Text} en la base de datos.");
                        
                 }

            }

        }
    }
}
