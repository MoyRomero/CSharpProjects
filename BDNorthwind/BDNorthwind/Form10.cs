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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form10_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }

        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_10.DataSource = null;
            if (tabla == null)
            {
                tabla = (from region in BD.Region
                         where region.EHabilitado.Equals(1)
                         select new
                         {
                             ID = region.RegionID,
                             NOMBRE = region.RegionDescription
                         }).ToList();
            }
            dgvEjercicio_10.DataSource = tabla;
        }

        private void CapturaID(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_10.CurrentRow.Cells[0].Value.ToString();
        }

        private void LimpiarCampos()
        {
            txtID.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDReg = txtID.Text;
            string Reg = dgvEjercicio_10.CurrentRow.Cells[1].Value.ToString();

            if(IDReg == "")
            {
                err.SetError(txtID,"Debe introducir un valor en el campo \"ID REGIÓN\"");
                return;
            }
            else
            {
                err.SetError(txtID, "");
            }

            if(MessageBox.Show($"¿Desea eliminar el elemento {Reg}?","AVISO",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                var consulta = from region in BD.Region
                               where region.RegionID.Equals(int.Parse(IDReg))
                               select region;

                foreach (var cons in consulta)
                {                    
                        cons.EHabilitado = false;                    
                }

                try
                {
                    BD.SubmitChanges();
                    RellenarTabla(tabla: null);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error.");
                }
            }

        }        
    }


}
