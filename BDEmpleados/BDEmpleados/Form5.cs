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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        PruebaDataContext BD = new PruebaDataContext();

        private void Form5_Load(object sender, EventArgs e)
        {

            RellenarTabla(tabla : null);

        }

        public void RellenarTabla(object tabla)
        {
            if (tabla == null)
            {
                tabla = BD.Empleado;
            }

            dvgEmpleados.DataSource = tabla;
        }

        private void leftFilter(object sender, EventArgs e)
        {
            int leftNumber = Convert.ToInt32(IntroNmbrLeft.Value);
            int rightNumber = Convert.ToInt32(IntroNmbrRight.Value);
            
            var tabla = from empl in BD.Empleado
                        where empl.EDAD > leftNumber && empl.EDAD  < rightNumber
                        select new
                        {
                            CODIGO = empl.CODIGO,
                            NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                            EDAD = empl.EDAD

                        };

            RellenarTabla(tabla);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntroNmbrLeft.Value = 0;
            IntroNmbrRight.Value = 0;

            RellenarTabla(tabla: null);

        }

        private void rightFilter(object sender, EventArgs e)
        {
            int leftNumber = Convert.ToInt32(IntroNmbrLeft.Value);
            int rightNumber = Convert.ToInt32(IntroNmbrRight.Value);

            var tabla = from empl in BD.Empleado
                        where empl.EDAD == leftNumber ||
                        empl.EDAD == rightNumber ||
                        empl.EDAD > leftNumber && 
                        empl.EDAD < rightNumber
                        select new
                        {
                            CODIGO = empl.CODIGO,
                            NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                            EDAD = empl.EDAD

                        };

            RellenarTabla(tabla);
        }
    }
}
