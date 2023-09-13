using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Form_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void sumBtn_Click(object sender, EventArgs e)
        {
            int suma = Convert.ToInt32(N1.Text) + Convert.ToInt32(N2.Text);

            resultado.Text = Convert.ToString(suma);
        }

        private void resBtn_Click(object sender, EventArgs e)
        {
            int suma = Convert.ToInt32(N1.Text) - Convert.ToInt32(N2.Text);

            resultado.Text = Convert.ToString(suma);
        }

        private void multBtn_Click(object sender, EventArgs e)
        {
            int suma = Convert.ToInt32(N1.Text) * Convert.ToInt32(N2.Text);

            resultado.Text = Convert.ToString(suma);
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            double suma = Convert.ToDouble(N1.Text) / Convert.ToDouble(N2.Text);

            resultado.Text = Convert.ToString(suma);
        }
    }
}
