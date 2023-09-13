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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        PruebaDataContext BD = new PruebaDataContext();

        private void Form6_Load(object sender, EventArgs e)
        {

            RellenarTabla(tabla : null);

        }


        public void RellenarTabla(object tabla)
        {

            if(tabla == null)
            {
                tabla = BD.Empleado;
            }

            dvgEmpleados.DataSource = tabla;
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string opValor = cmBoxOpciones.Text;
            string txtValor = txtbValor.Text;            

            if (opValor == "Código")
            {
                var tabla = from empl in BD.Empleado
                            where empl.CODIGO.Equals(txtValor)
                            select new
                            {
                                CÓDIGO = empl.CODIGO,
                                NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                                EDAD = empl.EDAD
                            };

                RellenarTabla(tabla);
            }

            else if (opValor == "Nombre")
            {
                var tabla = from empl in BD.Empleado
                            where empl.NOMBRE.Equals(txtValor)
                            select new
                            {
                                CÓDIGO = empl.CODIGO,
                                NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                                EDAD = empl.EDAD
                            };

                RellenarTabla(tabla);
            }

            else if (opValor == "Apellido Paterno")
            {
                var tabla = from empl in BD.Empleado
                            where empl.APPATERNO.Equals(txtValor)
                            select new
                            {
                                CÓDIGO = empl.CODIGO,
                                NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                                EDAD = empl.EDAD
                            };

                RellenarTabla(tabla);
            }

            else if (opValor == "Apellido Materno")
            {
                var tabla = from empl in BD.Empleado
                            where empl.APMATERNO.Equals(txtValor)
                            select new
                            {
                                CÓDIGO = empl.CODIGO,
                                NOMBRE = $"{empl.NOMBRE} {empl.APPATERNO} {empl.APMATERNO}",
                                EDAD = empl.EDAD
                            };

                RellenarTabla(tabla);
            }

            //Código
            //Nombre
            //Apellido Paterno
            //Apellido Materno
        }
    }
}
