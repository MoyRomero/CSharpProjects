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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form7_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }

        private void RellenarTabla(object tabla)
        {
            RellenadoCmBx();

            dgvEjercicio_7.DataSource = null;

            if (tabla == null)
            {
                tabla = (from producto in BD.Products
                         join categoria in BD.Categories
                         on producto.CategoryID equals categoria.CategoryID
                         join proveedor in BD.Suppliers
                         on producto.SupplierID equals proveedor.SupplierID
                         select new
                         {
                             ID = producto.ProductID,
                             NOMBRE = producto.ProductName,
                             CATEGORÍA = categoria.CategoryName,
                             PROVEEDOR = proveedor.CompanyName,
                             PRECIO = producto.UnitPrice,
                             STOCK = producto.UnitsInStock                            

                         }).ToList();
            }          

            dgvEjercicio_7.DataSource = tabla;
        }
        private void RellenadoCmBx()
        {
            txtCategoria.DataSource = BD.Categories.ToList();
            txtCategoria.ValueMember = "CategoryID";
            txtCategoria.DisplayMember = "CategoryName";

            txtProveedor.DataSource = BD.Suppliers.ToList();
            txtProveedor.ValueMember = "SupplierID";
            txtProveedor.DisplayMember = "CompanyName";
        }
        private void RellenadoDeCampos(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvEjercicio_7.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvEjercicio_7.CurrentRow.Cells[1].Value.ToString();
            txtCategoria.Text = dgvEjercicio_7.CurrentRow.Cells[2].Value.ToString();
            txtProveedor.Text = dgvEjercicio_7.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Value = (decimal)dgvEjercicio_7.CurrentRow.Cells[4].Value;             
            short stock = (short)dgvEjercicio_7.CurrentRow.Cells[5].Value;

            if (stock > 99) stock = 99;

            txtStock.Value = (short) stock;
        }
        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtProveedor.Text = "";
            txtPrecio.Value = 0;
            txtStock.Value = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                err.SetError(txtNombre, "Debe rellenar el campo \"Nombre\"");
                MessageBox.Show("Debe rellenar el campo \"Nombre\"");
                return;
            }
            else
            {
                err.SetError(txtNombre, "");
            }

            var consulta = from producto in BD.Products
                           where producto.ProductID.Equals(txtID.Text)
                           select producto;
           
            foreach (Products cons in consulta)
            {
                cons.ProductName = txtNombre.Text;
                cons.CategoryID = int.Parse(txtCategoria.SelectedValue.ToString());
                cons.SupplierID = int.Parse(txtProveedor.SelectedValue.ToString());
                cons.UnitPrice = decimal.Parse(txtPrecio.Value.ToString());
                cons.UnitsInStock = short.Parse(txtStock.Value.ToString());
            }

            try
            {
                BD.SubmitChanges();
                MessageBox.Show("Se ha actualizado la base de datos.");
                RellenarTabla(tabla:null);
                LimpiarCampos();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

        }        
    }
}
