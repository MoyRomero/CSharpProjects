using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDEmpleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PruebaDataContext BD = new PruebaDataContext();

        private void Form1_Load(object sender, EventArgs e)
        {

            dvgEmpleados.DataSource = BD.Empleado;

        }
    }
}
