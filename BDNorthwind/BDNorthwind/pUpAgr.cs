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
    public partial class popUp : Form
    {
        public popUp()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();

        private void popUp_Load(object sender, EventArgs e)
        {
            RellenarCombBx();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] Datos = { txtID.Text, txtNombre.Text };

            var idRepetido = (from id in BD.Territories
                           where id.TerritoryID == Datos[0]
                           select id).Count();

            if(idRepetido > 0 ) {
                MessageBox.Show($"El ID {Datos[0]} ya se encuentra en uso, ingresa otro ID.");
                return;
            }
            else
            {
                var consulta = from terr in BD.Territories
                               select terr;

                Territories Territorio = new Territories
                {
                    TerritoryID = txtID.Text,
                    TerritoryDescription = txtNombre.Text,
                    RegionID = int.Parse(cmBoxRegion.SelectedValue.ToString()),
                    EHabilitado = true
                };

                BD.Territories.InsertOnSubmit(Territorio);

                try
                {
                    //Form12 form = new Form12();
                    BD.SubmitChanges();
                    MessageBox.Show("Se agregó el territorio, de forma exitosa.");                    
                    //form.RellenarTabla(tabla:null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrió un error");
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {           
           
        }

        private void RellenarCombBx()
        {
            cmBoxRegion.DataSource = BD.Region;
            cmBoxRegion.ValueMember = "RegionID";
            cmBoxRegion.DisplayMember = "RegionDescription";
        }
    }
}
