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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        PruebaDataContext BD = new PruebaDataContext();

        private void Form4_Load(object sender, EventArgs e)
        {

            dvgEmpleados.DataSource = BD.Empleado;

        }

        private void txtFiltro(object sender, EventArgs e)
        {
            string texto = txtBxFiltro.Text;

            dvgEmpleados.DataSource = from empleados in BD.Empleado
                                      where empleados.NOMBRE.Contains(texto) ||
                                      empleados.APPATERNO.Contains(texto) ||
                                      empleados.APMATERNO.Contains(texto)                                      
                                      select new { 
                                      CODIGO = empleados.CODIGO,
                                      NOMBRE = $"{empleados.NOMBRE} {empleados.APPATERNO} {empleados.APMATERNO}",
                                      EDAD = empleados.EDAD
                                      };            

            if (texto == "") dvgEmpleados.DataSource= BD.Empleado;

        }
    }
}
