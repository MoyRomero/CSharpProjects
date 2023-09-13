using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Form_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        List<Categoria> categorias;
        List<Proveedor> proveedores;
        List<Producto> productos;

        public void Form3_Load(object sender, EventArgs e)
        {
            categorias = new List<Categoria>
            {
                new Categoria { idCategoria = 1, nombreCategoria = "Galletas"},
                new Categoria { idCategoria = 2, nombreCategoria = "Panes"},
                new Categoria { idCategoria = 3, nombreCategoria = "Frituras"}
            };

            proveedores = new List<Proveedor>
            {
                new Proveedor { idProveedor = 1, nombreProveedor = "Bimbo"},
                new Proveedor { idProveedor = 2, nombreProveedor = "Barcel"},
                new Proveedor { idProveedor = 3, nombreProveedor = "Tía Rosa"},
                new Proveedor { idProveedor = 4, nombreProveedor = "Gamesa"},
                new Proveedor { idProveedor = 5, nombreProveedor = "Sabritas"},
                new Proveedor { idProveedor = 6, nombreProveedor = "Marinela"}
            };

            productos = new List<Producto>
            {
            new Producto { idProducto = 1, idCategoria = 1, idProveedor = 4, nombreProducto = "Emperador"},
            new Producto { idProducto = 2, idCategoria = 2, idProveedor = 1, nombreProducto = "Colchones"},
            new Producto { idProducto = 3, idCategoria = 2, idProveedor = 1, nombreProducto = "Mantecadas"},
            new Producto { idProducto = 4, idCategoria = 3, idProveedor = 5, nombreProducto = "Cheetos"},
            new Producto { idProducto = 5, idCategoria = 3, idProveedor = 2, nombreProducto = "Takis"},
            new Producto { idProducto = 6, idCategoria = 3, idProveedor = 2, nombreProducto = "Runners"},
            new Producto { idProducto = 7, idCategoria = 2, idProveedor = 6, nombreProducto = "Gansito"},
            new Producto { idProducto = 8, idCategoria = 2, idProveedor = 3, nombreProducto = "Conchas"},
            new Producto { idProducto = 1, idCategoria = 2, idProveedor = 6, nombreProducto = "Pinguinos"},
            new Producto { idProducto = 4, idCategoria = 1, idProveedor = 3, nombreProducto = "Tartinas"},
            new Producto { idProducto = 4, idCategoria = 3, idProveedor = 5, nombreProducto = "Rufles"},
            new Producto { idProducto = 4, idCategoria = 1, idProveedor = 4, nombreProducto = "Chokis"},
            new Producto { idProducto = 4, idCategoria = 1, idProveedor = 6, nombreProducto = "Principe"}
            };

            Actualizar(JoiningTables());

        }

        public void filtrarBtn_Click(object sender, EventArgs e)
        {
            string texto = cmBoxCategoria.Text;

            //lblFiltrar.Text = texto;

            if (texto == "Selecciona Categoría")
            {
                MessageBox.Show("Selecciona una opción de las categorías existentes.");
                ErrorComboBox.SetError(cmBoxCategoria, "Selecciona una categoría");
                return;
            }
            else
            {
                ErrorComboBox.SetError(cmBoxCategoria, "");
            }

            if (texto == "Todas")
            {
                var TablaProductos = (from categoria in categorias
                                      join producto in productos
                                      on categoria.idCategoria equals producto.idCategoria
                                      join proveedor in proveedores
                                      on producto.idProveedor equals proveedor.idProveedor
                                      select new
                                      {
                                          Nombre = producto.nombreProducto,
                                          Categoria = categoria.nombreCategoria,
                                          Proveedor = proveedor.nombreProveedor
                                      }).ToList();

                Actualizar(TablaProductos);

                return;
            }

            else
            {

                var TablaProductos = (from categoria in categorias
                                      where categoria.nombreCategoria == texto
                                      join producto in productos
                                      on categoria.idCategoria equals producto.idCategoria
                                      join proveedor in proveedores
                                      on producto.idProveedor equals proveedor.idProveedor
                                      select new
                                      {
                                          Producto = producto.nombreProducto,
                                          Categoria = categoria.nombreCategoria,
                                          Proveedor = proveedor.nombreProveedor
                                      }).ToList();

                Actualizar(TablaProductos);
            }

        }

        private IEnumerable<dynamic> JoiningTables()
        {
            var TablaProductos = (from categoria in categorias
                                  join producto in productos
                                  on categoria.idCategoria equals producto.idCategoria
                                  join proveedor in proveedores
                                  on producto.idProveedor equals proveedor.idProveedor
                                  select new
                                  {
                                      Nombre = producto.nombreProducto,
                                      Categoria = categoria.nombreCategoria,
                                      Proveedor = proveedor.nombreProveedor
                                  }).ToList();

            return TablaProductos;
        }

        public void Actualizar(object TablaProductos)
        {
            ProductosTabla.DataSource = null;

            ProductosTabla.DataSource = TablaProductos;

        }

        private void txtBFiltro(object sender, EventArgs e)
        {
            var TablaSinFiltro = (from categoria in categorias
                                  join producto in productos
                                  on categoria.idCategoria equals producto.idCategoria
                                  join proveedor in proveedores
                                  on producto.idProveedor equals proveedor.idProveedor
                                  select new
                                  {
                                      Nombre = producto.nombreProducto,
                                      Categoria = categoria.nombreCategoria,
                                      Proveedor = proveedor.nombreProveedor
                                  }).ToList();

            if (txtBCategoria.Text == "") ProductosTabla.DataSource = TablaSinFiltro;

            var TablaFiltrada = (from categoria in categorias
                                 join producto in productos
                                 on categoria.idCategoria equals producto.idCategoria
                                 join proveedor in proveedores
                                 on producto.idProveedor equals proveedor.idProveedor
                                 where categoria.nombreCategoria.Contains(txtBCategoria.Text)
                                 select new
                                 {
                                     Nombre = producto.nombreProducto,
                                     Categoria = categoria.nombreCategoria,
                                     Proveedor = proveedor.nombreProveedor
                                 }).ToList();

            ProductosTabla.DataSource = TablaFiltrada;

        }
    }
}
