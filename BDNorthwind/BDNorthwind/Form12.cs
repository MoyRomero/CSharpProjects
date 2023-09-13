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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form12_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            popUp form = new popUp();
            form.ShowDialog();
            
            if (form.DialogResult.Equals(DialogResult.OK)) 
            { 
                RellenarTabla(tabla: null); 
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            pUpEd form = new pUpEd();
            form.ShowDialog();
            if (form.DialogResult.Equals(DialogResult.OK) || form.DialogResult.Equals(DialogResult.Cancel))
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            pUpElim form = new pUpElim();
            form.ShowDialog();
            if (form.DialogResult.Equals(DialogResult.OK) || form.DialogResult.Equals(DialogResult.Cancel))
            {
                RellenarTabla(tabla: null);
            }
        }
        private void RellenarTabla(Object tabla)
        {
            dgvAgregar.DataSource = null;

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
            dgvAgregar.DataSource = tabla;
        }
        private void buscarTerr(object sender, EventArgs e)
        {
            RellenarTabla(tabla:txtTerritorioNm.Text);
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }        
    }
}
