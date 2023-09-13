using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDNorthwind
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();

        private void Form4_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla : null);
        }

        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_4.DataSource = null;

            if(tabla == null)
            {
                tabla = (from datos in BD.Suppliers
                         select new
                         {   ID = datos.SupplierID,
                             COMPANY_NAME = datos.CompanyName,
                             CONTACT_NAME = datos.ContactName,
                             CONTACT_TITLE = datos.ContactTitle,
                             ADDRESS = datos.Address,
                             CITY = datos.City
                         }).ToList();
            }

            dgvEjercicio_4.DataSource = tabla;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] Datos = DatosFormulario();

            int contiene = (from name in BD.Suppliers
                            where name.CompanyName.Equals(Datos[4])
                            select name.CompanyName).Count();


            if (Datos[0] == "" || Datos[1] == "" || Datos[2] == "" || Datos[3] == "" || Datos[4] == "")
            {
                MessageBox.Show("Es necesario llenar todos los campos, para enviar el formulario");
                
                return;
            }
            
            if(contiene > 0)
            {
                MessageBox.Show($"Ya existe {Datos[4]} asignado a un \" COMPANY NAME\". Por favor, introduce otro distinto.");

                return;
            }

            Suppliers suppliers = new Suppliers 
            {
                City = Datos[0],
                Address = Datos[1],
                ContactName = Datos[2],
                ContactTitle = Datos[3],
                CompanyName = Datos[4],
            };

            BD.Suppliers.InsertOnSubmit(suppliers);

            try
            {
                BD.SubmitChanges();
                
                MessageBox.Show("Se han agregado los datos, de forma satisfactoria.");
                
                LimpiarCampos();

                RellenarTabla(tabla: null);

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex}");
            }           
        }

        private string[] DatosFormulario()
        { 
            string City = txtCity.Text;
            string Address = txtAddress.Text;
            string ContactName = txtContactN.Text;
            string ContactTitle = txtContactT.Text;
            string CompanyName = txtCompanyN.Text;            

            return new string[] { City, Address, ContactName, ContactTitle, CompanyName };
        }

        private void LimpiarCampos()
        {
            txtCity.Text = "";
            txtAddress.Text = "";
            txtContactN.Text = "";
            txtContactT.Text = "";
            txtCompanyN.Text = "";
        }
    }
}
