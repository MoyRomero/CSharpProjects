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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        PruebaDataContext BD = new PruebaDataContext();

        private void Form3_Load(object sender, EventArgs e)
        {
            dvgEmpleados.DataSource = BD.Empleado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = txtBxFiltro.Text;

            dvgEmpleados.DataSource = from empleados in BD.Empleado
                                where empleados.NOMBRE.Contains(texto) ||
                                empleados.APPATERNO.Contains(texto) ||
                                empleados.APMATERNO.Contains(texto)
                                
                                select new {

                                Codigo = empleados.CODIGO,
                                Nombre = $"{empleados.NOMBRE} {empleados.APPATERNO} {empleados.APMATERNO}",
                                Edad = empleados.EDAD
                                };
        }

        private void txtBxFiltradoVacio(object sender, EventArgs e)
        {
            if(txtBxFiltro.Text == "") dvgEmpleados.DataSource = BD.Empleado;
        }

        
    }
}
