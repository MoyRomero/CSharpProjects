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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form8_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_8.DataSource = null;

            if (tabla == null )
            {
                tabla = from region in BD.Region
                        select new
                        {
                            ID_REGION = region.RegionID,
                            REGION = region.RegionDescription
                        };
                dgvEjercicio_8.DataSource = tabla;
            }
        }
        private void CapturaDatos(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_8.CurrentRow.Cells[0].Value.ToString();
        }
        private void LimpiarCampos()
        {
            txtID.Text = "";
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if(txtID.Text == "")
            {
                MessageBox.Show("Escriba un ID o seleccione una fila de la tabla, para eliminar.");
                return;
            }

            string RegionNombre = dgvEjercicio_8.CurrentRow.Cells[1].Value.ToString();

            if (MessageBox.Show($"¿Desea eliminar: {RegionNombre}?", "Eliminacion" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from regID in BD.Region
                               where regID.RegionID.Equals(txtID.Text)
                               select regID;
                foreach( var reg in consulta )
                {
                    BD.Region.DeleteOnSubmit(reg);
                }
                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha elimnado el elemento {RegionNombre}.");
                    RellenarTabla(tabla:null);
                    LimpiarCampos();
                }
                catch( Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error.{ex}");
                }
            }    
        }        
    }
}
