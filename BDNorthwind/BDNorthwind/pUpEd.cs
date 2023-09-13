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
    public partial class pUpEd : Form
    {
        public pUpEd()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void popUpEdit_Load(object sender, EventArgs e)
        {            
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(Object tabla)
        {
            dgvEditar.DataSource = null;

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
                         terr.TerritoryID.Contains(tabla.ToString())
                         join region in BD.Region
                         on terr.RegionID equals region.RegionID
                         select new
                         {
                             ID = terr.TerritoryID,
                             NOMBRE = terr.TerritoryDescription,
                             REGION = region.RegionDescription
                         }).ToList();
            }

            dgvEditar.DataSource = tabla;
        }
        private void RellenarComboBoxRegion()
        {
            cmBoxRegion.DataSource = BD.Region;
            cmBoxRegion.ValueMember = "RegionID";
            cmBoxRegion.DisplayMember = "RegionDescription";
        }
        private void capturarValores(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEditar.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvEditar.CurrentRow.Cells[1].Value.ToString();
            cmBoxRegion.Text = dgvEditar.CurrentRow.Cells[2].Value.ToString();

            RellenarComboBoxRegion();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Debe ingresar un id en el campo \"BUSCAR POR ID DEL TERRITORIO\" o seleccionar una fila en la tabla, para continuar y actualizar un territorio");
                return;
            }

            else if(MessageBox.Show($"¿Desea actualizar los datos del territorio {txtID.Text}?","AVISO, ESTÁ APUNTO DE ACTUALIZAR LOS DATOS",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(txtID.Text);
                
                var consulta = from terr in BD.Territories
                               where terr.TerritoryID.Equals(id)
                               select terr;

                foreach( var cons in consulta )
                {
                    cons.TerritoryDescription = txtNombre.Text;
                    cons.RegionID = int.Parse(cmBoxRegion.SelectedValue.ToString());                    
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha actualizado el territorio: {txtNombre.Text}, de forma correcta.");
                    RellenarTabla(tabla:null);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show($"Ha ocurrido un error: {ex}");
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtIDB.Text == "")
            {
                MessageBox.Show("Debe ingresar un ID al campo \"BUSCAR POR ID DEL TERRITORIO\" antes de comenzar la búsqueda.");
                return;
            }
            RellenarComboBoxRegion();

            var consulta = (from terr in BD.Territories
                            where terr.TerritoryID.Equals(txtIDB.Text)
                            join reg in BD.Region
                            on terr.RegionID equals reg.RegionID
                            select new
                            {
                                terr.TerritoryID,
                                terr.TerritoryDescription,
                                reg.RegionDescription
                            }).ToList();

            foreach( var cons in consulta ) {             
                txtID.Text = cons.TerritoryID;
                txtNombre.Text = cons.TerritoryDescription;
                cmBoxRegion.Text = cons.RegionDescription;            
            }            
        }
        private void filtrarTabla(object sender, EventArgs e)
        {
            RellenarTabla(tabla: txtIDB.Text);
        }
    }
}
