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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form9_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }

        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_9.DataSource = null;

            if(tabla == null )
            {
                tabla = (from terr in BD.Territories
                         select new
                         {
                             ID_TERRITORIO = terr.TerritoryID,
                             NOMBRE = terr.TerritoryDescription,
                             ID_REGION = terr.RegionID,
                         }).ToList();
            }

            dgvEjercicio_9.DataSource = tabla;
        }

        private void CapturaID(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_9.CurrentRow.Cells[0].Value.ToString();
        }
        private void LimpiarCampos()
        {
            txtID.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Debe rellenar el campo \"ID TERRITORIO\", para proceder a eliminar un elemento.");
                return;
            }
            string elemento = dgvEjercicio_9.CurrentRow.Cells[1].Value.ToString();
            int idTerr = int.Parse(dgvEjercicio_9.CurrentRow.Cells[0].Value.ToString());
            
            if(MessageBox.Show($"¿Desea eliminar el elemento {elemento}?","AVISO",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                var consulta = from terr in BD.Territories where terr.TerritoryID.Equals(idTerr) select terr;

                foreach( var cons in consulta )
                {
                    BD.Territories.DeleteOnSubmit( cons );
                }
                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha eliminado el elemento {elemento}");
                    RellenarTabla(tabla:null);
                    LimpiarCampos();
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error.");
                }
            }
        }        
    }
}
