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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form2_Load(object sender, EventArgs e)
        {

            RellenarTabla(tabla: null);
            RellenarCmBoxRegion();
        }

        public void RellenarCmBoxRegion()
        {
            cmBxRegion.DataSource = BD.Region;
            cmBxRegion.DisplayMember = "RegionDescription";
            cmBxRegion.ValueMember = "RegionID";
        }

        public void RellenarTabla(object tabla)
        {
            if(tabla == null)
            {
                tabla = from territorio in BD.Territories
                                            join region in BD.Region
                                            on territorio.RegionID equals region.RegionID                                            
                                            select new
                                            {
                                                ID_Territorio = territorio.TerritoryID,
                                                Nombre_Territorio = territorio.TerritoryDescription,
                                                Región = region.RegionDescription
                                            }; ;
            }

            dgvEjercicio_2.DataSource = tabla;
        }

        private void filtradoRegion(object sender, EventArgs e)
        {
            string Region = cmBxRegion.Text;

            var tabla = from territorio in BD.Territories
                        join region in BD.Region
                        on territorio.RegionID equals region.RegionID
                        where region.RegionDescription.Equals(Region)
                        select new
                        {
                            ID_Territorio= territorio.TerritoryID,
                            Nombre_Territorio = territorio.TerritoryDescription,
                            Región = region.RegionDescription
                        };

            RellenarTabla(tabla);
        }
    }
}
