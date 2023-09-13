using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LINQ_Form_1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        List<Categoria> categorias;
        List<Proveedor> proveedores;
        List<Producto> productos;

        public void Form4_Load(object sender, EventArgs e)
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
            new Producto { idProducto = 9, idCategoria = 2, idProveedor = 6, nombreProducto = "Pinguinos"},
            new Producto { idProducto = 10, idCategoria = 1, idProveedor = 3, nombreProducto = "Tartinas"},
            new Producto { idProducto = 11, idCategoria = 3, idProveedor = 5, nombreProducto = "Rufles"},
            new Producto { idProducto = 12, idCategoria = 1, idProveedor = 4, nombreProducto = "Chokis"},
            new Producto { idProducto = 13, idCategoria = 1, idProveedor = 6, nombreProducto = "Principe"}
            };

            ActualizarTabla();
        }
        public void ActualizarTabla()
        {
            tablaCRUD.DataSource = null;

            var Tabla = (from categoria in categorias
                         join producto in productos
                         on categoria.idCategoria equals producto.idCategoria
                         join proveedor in proveedores
                         on producto.idProveedor equals proveedor.idProveedor
                         orderby producto.idProducto
                         select new
                         {
                             ID_Producto = producto.idProducto,
                             Producto = producto.nombreProducto,
                             Categoria = categoria.nombreCategoria,
                             Proveedor = proveedor.nombreProveedor
                         }).ToList();

            tablaCRUD.DataSource = Tabla;

            CombosActualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string producto = nuevoProducto.Text;
            string categoria = nuevaCategoria.Text;
            string proveedor = nuevoProveedor.Text;

            categorias.Add(new Categoria { idCategoria = categorias.Count() + 1, nombreCategoria = categoria });
            proveedores.Add(new Proveedor { idProveedor = proveedores.Count() + 1, nombreProveedor = proveedor });
            productos.Add(new Producto { idProducto = productos.Count() + 1, nombreProducto = producto, idCategoria = IDCategoria(categoria), idProveedor = IDProveedor(proveedor) });

            ActualizarTabla();
            CombosActualizar();
        }

        public int IDCategoria(string categoria)
        {
            int resultado = 0;

            if (categoria == "Galletas") resultado = 1;
            if (categoria == "Panes") resultado = 2;
            if (categoria == "Frituras") resultado = 3;

            return resultado;
        }

        public int IDProveedor(string proveedor)
        {
            int resultado = 0;

            if (proveedor == "Bimbo") resultado = 1;
            if (proveedor == "Barcel") resultado = 2;
            if (proveedor == "Tía Rosa") resultado = 3;
            if (proveedor == "Gamesa") resultado = 4;
            if (proveedor == "Sabritas") resultado = 5;
            if (proveedor == "Marinela") resultado = 6;

            return resultado;
        }

        public void CombosActualizar()
        {
            /////////Rellenado de comboBox de Actualizar datos
            ///ID's            
            cmBoxIDProductoA.DataSource = null;

            var idProductosA = (from id in productos select id.idProducto).ToList();

            cmBoxIDProductoA.DataSource = idProductosA;

            ///Categorias
            //var categoria = (from categ in categorias select categ.nombreCategoria).ToList();
            //cmBoxCategoriaA.DataSource = categoria;

            ///Proveedores
            //var provedor = (from proveedor in proveedores select proveedor.nombreProveedor).ToList();
            //cmBoxProveedorA.DataSource = provedor;

            /////////Rellenado de ComboBox de Eliminar Datos     
            ///ID's 
            cmBoxIDProductoD.DataSource = null;

            var idProductosD = (from id in productos select id.idProducto).ToList();

            cmBoxIDProductoD.DataSource = idProductosD;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ProductoID = int.Parse(cmBoxIDProductoD.Text);

            for (int i = 0; i < productos.Count(); i ++) if(ProductoID == productos[i].idProducto) productos.RemoveAt(i);

            ActualizarTabla();

        }
    }
}
