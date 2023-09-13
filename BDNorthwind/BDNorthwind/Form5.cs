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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form5_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
            RellenarCmBx();
        }       

        private void RellenarTabla(object tabla)
        {
            dgvEjercicio_5.DataSource = null;

            if(tabla == null) tabla = (from producto in BD.Products
                                       join cat in BD.Categories
                                       on producto.CategoryID equals cat.CategoryID
                                       join prov in BD.Suppliers
                                       on producto.SupplierID equals prov.SupplierID
                                       select new
                                       {
                                           ID = producto.ProductID,
                                           NOMBRE = producto.ProductName,
                                           CATEGORÍA = cat.CategoryName,
                                           PROVEEDOR = prov.CompanyName,
                                           DESCRIPCION  = producto.QuantityPerUnit,
                                           PRECIO = producto.UnitPrice,
                                           STOCK = producto.UnitsInStock }).ToList();

            dgvEjercicio_5.DataSource = tabla;
        }

        private void RellenarCmBx()
        {
            txtCbCategoria.DataSource = BD.Categories.ToList();
            txtCbCategoria.DisplayMember = "CategoryName";
            txtCbCategoria.ValueMember = "CategoryID";

            txtCbProveedor.DataSource = BD.Suppliers.ToList();
            txtCbProveedor.DisplayMember = "CompanyName";
            txtCbProveedor.ValueMember = "SupplierID";

        }

        private void LimpiarCampos()
        {
            txtNombre.Text = ""; 
            txtCbCategoria.Text = "";
            txtCbProveedor.Text = "";
            txtDescripcion.Text = "";
            txtNumPrecio.Value = 0;
            txtNumStock.Value = 0;
        }
       
        private int Validacion_2(string nombr)
        {
            int repetido = (from nombre in BD.Products
                                where nombre.ProductName.Equals(nombr)
                                select nombre.ProductName).Count();
            return repetido;
        }       

        private void btnAgregar_Click(object sender, EventArgs e)
        {           
            string nombre = txtNombre.Text;
            int Cat = txtCbCategoria.SelectedIndex + 1;
            int Prov = txtCbProveedor.SelectedIndex + 1;
            string descrip = txtDescripcion.Text;
            decimal precio = decimal.Parse(txtNumPrecio.Value.ToString());
            short stock = short.Parse(txtNumStock.Value.ToString());

            if (nombre == "")
            {
                errorVacio.SetError(txtNombre, "Debe llenar el campo \"Nombre\" con un máximo de 40 caracteres.");
                return;
            }
            else
            {
                errorVacio.SetError(txtNombre, "");
            }

            if (descrip == "")
            {
                errorVacio.SetError(txtDescripcion, "Debe llenar el campo \"Descripción\" con un máximo de 20 caracteres.");
                return;
            }
            else
            {
                errorVacio.SetError(txtDescripcion, "");
            }


            int repetido = Validacion_2(nombre);
            if (repetido > 0)
            {
                MessageBox.Show($"El nombre {nombre}, ya pertenece a un Producto en la tabla de productos. Por favor, introduce otro nombre para tu producto.");
                return;
            }

            Products Datos_1 = new Products
            {
                ProductName = nombre,
                CategoryID = Cat,
                SupplierID = Prov,
                QuantityPerUnit = descrip,
                UnitPrice = precio,
                UnitsInStock = stock
             };

                BD.Products.InsertOnSubmit(Datos_1);
            try
            {
                BD.SubmitChanges();
                RellenarTabla(tabla: null);
                MessageBox.Show("Se han enviado los datos al servidor, de forma correcta.");
                LimpiarCampos();               
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo el error:{ex}");
            }
        }

        private void senDescrip(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 19)
            {
                MessageBox.Show("No puede colocar más de 20 caracteres en el campo \"Descripción\"");
                return;
            }            
        }

        private void senNombre(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 40)
            {
                MessageBox.Show("No puede colocar más de 40 caracteres en el campo \"Nombre\"");
                return;
            }
        }
    }
}
