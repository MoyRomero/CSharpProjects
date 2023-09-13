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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        PruebaDataContext BD = new PruebaDataContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            dvgEmpleados.DataSource = from empleados in BD.Empleado
                                      select new
                                      {
                                          Codigo = empleados.CODIGO,
                                          Nombre_Completo = $"{empleados.NOMBRE} {empleados.APMATERNO} {empleados.APPATERNO}",
                                          Edad_Org = empleados.EDAD,
                                          Edad_10 = empleados.EDAD + 10
                                      };
        }
    }
}
