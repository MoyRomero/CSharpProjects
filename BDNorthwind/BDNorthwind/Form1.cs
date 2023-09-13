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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();

        private void Form1_Load(object sender, EventArgs e)
        {

            var tabla = from territorio in BD.Territories
                        join region in BD.Region
                        on territorio.RegionID equals region.RegionID
                        orderby region.RegionDescription
                        select new
                        {
                            ID_Territorio = territorio.TerritoryID,
                            Nombre_Territorio = territorio.TerritoryDescription,
                            Region = region.RegionDescription
                        };
            RellenarTabla(tabla);

        }

        public void RellenarTabla(object tabla)
        {            
            dvgEjercicio_1.DataSource = tabla;
        }
    }
}
