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
    public partial class pUpElim : Form
    {
        public pUpElim()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void pUpElim_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(Object tabla)
        {
            dgvEliminar.DataSource = null;

            if (tabla == null)
            {
                tabla = (from terr in BD.Territories
                         where terr.EHabilitado.Equals(1)
                         join region in BD.Region
                         on terr.RegionID equals region.RegionID
                         select new
                         {
                             ID = terr.TerritoryID,
                             NOMBRE = terr.TerritoryDescription,
                             REGION = region.RegionDescription
                         }).ToList();
            }
            else if (tabla != null)
            {
                tabla = (from terr in BD.Territories
                         where terr.EHabilitado.Equals(1) &&
                         terr.TerritoryDescription.Contains(tabla.ToString())
                         join region in BD.Region
                         on terr.RegionID equals region.RegionID
                         select new
                         {
                             ID = terr.TerritoryID,
                             NOMBRE = terr.TerritoryDescription,
                             REGION = region.RegionDescription
                         }).ToList();
            }
            dgvEliminar.DataSource = tabla;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idTerr = txtIDEliminar.Text;
            if(idTerr == "")
            {
                MessageBox.Show("Debe escribir un ID en el campo \"ID TERRITORIO\" o dar click en alguna fila de la tabla, para seleccionar un territorio y proceder a eliminar.", "AVISO");
                return;
            }

            if(MessageBox.Show($"¿Desea eliminar el territorio: {idTerr}","AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                var consulta = (from  terr in BD.Territories
                                where terr.TerritoryID.Equals(idTerr)
                                select terr).ToList();

                foreach(var cons in  consulta)
                {
                    cons.EHabilitado = false;
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha eliminado el territorio: {idTerr}.", "AVISO");
                    RellenarTabla(tabla:null);
                }

                catch(Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error: {ex}", "AVISO");
                }
            }
        }
        private void capturaID(object sender, DataGridViewCellEventArgs e)
        {
            txtIDEliminar.Text = dgvEliminar.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
