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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form11_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_11.DataSource = null;

            if (tabla == null)
            {
                tabla = (from terr in BD.Territories
                         where terr.EHabilitado.Equals(1)
                         orderby terr.TerritoryDescription
                         select new
                         {
                             ID = terr.TerritoryID,
                             NOMBRE = terr.TerritoryDescription,
                             ID_REGION = terr.RegionID
                         }).ToList();
            }

            dgvEjercicio_11.DataSource = tabla;

        }
        private void CapturaDatos(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_11.CurrentRow.Cells[0].Value.ToString();
        }
        private void LimpiarCampos()
        {
            txtID.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string territorio = dgvEjercicio_11.CurrentRow.Cells[1].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Rellena el CAMPO DE ID TERRITORIO.");
                err.SetError(txtID, "Debe introducir el ID de algún territorio en existencia, o dar click en alguna fila de la tabla.");
                return;
            }
            else
            {
                err.SetError(txtID, "");
            }

            if(MessageBox.Show($"¿Desea eliminar el Territorio: {territorio}?","AVISO",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from terr in BD.Territories
                               where terr.TerritoryID.Equals(ID)
                               select terr;
                foreach(var cons in consulta)
                {
                    cons.EHabilitado = false;
                }

                try
                {
                    BD.SubmitChanges();
                    RellenarTabla(tabla:null);
                    LimpiarCampos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrió un error.");
                }

            }

        }
    }
}
