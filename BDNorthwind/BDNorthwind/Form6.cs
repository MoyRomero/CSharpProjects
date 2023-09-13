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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form6_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }

        private void RellenarTabla(object tabla)
        {
            if(tabla == null)
            {
                tabla = (from regiones in BD.Region
                         select new
                         {
                             ID = regiones.RegionID,
                             NOMBRE = regiones.RegionDescription
                         }).ToList();
            }

            dgvEjercicio_6.DataSource = tabla;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string RegionDescrip = txtNombre.Text;
            int IDRegion = int.Parse(txtID.Text);

            //Obtener el dato
            var consulta = from regionid in BD.Region 
                           where regionid.RegionID.Equals(IDRegion) 
                           select regionid;

            foreach(Region oRegion in consulta)
            {
                oRegion.RegionID = IDRegion;
                oRegion.RegionDescription = RegionDescrip;                
            }

            try
            {
                BD.SubmitChanges();
                RellenarTabla(tabla : null);
                MessageBox.Show("Se realizaron los cambios en la base de datos.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error");
            }

        }

        private void celdaSeleccionada(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_6.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvEjercicio_6.CurrentRow.Cells[1].Value.ToString();            
        }
    }
}
 