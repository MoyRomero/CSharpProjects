using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDNorthwind
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {

            RellenarTabla(tabla : null);

        }

        public void RellenarTabla(object tabla)
        {
            if (tabla == null)
            {
                dgvEjercicio_3.DataSource = null;

                tabla = BD.Region.ToList();

            }

            dgvEjercicio_3.DataSource = tabla;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int ID_Region = Convert.ToInt32(txtBxID.Text);

            string Name_Region = txtBxNmbrRegion.Text;

            int repetido = (from regiones in BD.Region 
                            where regiones.RegionID.Equals(ID_Region)
                            select regiones).Count();

            Region region = new Region
            {
                RegionID = ID_Region,
                RegionDescription = Name_Region
            };

            BD.Region.InsertOnSubmit(region);

            try
            {
                if(repetido > 0)
                {
                    MessageBox.Show($"El ID:{ID_Region} ya está asignado a una Region.");
                    return;
                }

                BD.SubmitChanges();

                RellenarTabla(tabla : null);

                LimpiarCajas();

                MessageBox.Show($"Se agregaron los datos {ID_Region} y {Name_Region}, a la base de datos, de forma satisfactoria.");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error de tipo {ex}.");
            } 
        }

        public void LimpiarCajas()
        {
            txtBxID.Text = "";
            txtBxNmbrRegion.Text = "";
        }
    }
}
