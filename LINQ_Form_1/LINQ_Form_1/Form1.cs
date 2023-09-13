using System.Linq;

namespace LINQ_Form_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        List<Categoria> Lista;
        private void Form1_Load(object sender, EventArgs e)
        {

            Lista = new List<Categoria> {

                new Categoria{ idCategoria = 1, nombreCategoria = "Categoria 1"},
                new Categoria{ idCategoria = 2, nombreCategoria = "Categoria 2"},
                new Categoria{ idCategoria = 3, nombreCategoria = "Categoria 3"},
                new Categoria{ idCategoria = 4, nombreCategoria = "Categoria 4"}

            };

            Actualizar();

        }

        public void Actualizar()
        {
            Grid_Categoria.DataSource = null;

            Grid_Categoria.DataSource = Lista;

            txtbidCategoria.Text = "";
            txtbCategoria.Text = "";

        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtbidCategoria.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos.");

                    errorFormulario.SetError(txtbidCategoria, "Ingresa un número entero.");

                    return;
                }
                else
                {
                    errorFormulario.SetError(txtbidCategoria, "");
                }

                if (txtbCategoria.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos.");

                    errorFormulario.SetError(txtbCategoria, "LLena el campo");

                    return;
                }
                else
                {
                    errorFormulario.SetError(txtbCategoria, "");
                }

                int idCategoria = Convert.ToInt32(txtbidCategoria.Text);
                string Categoria = txtbCategoria.Text;

                for (int i = 0; i < Lista.Count(); i++)
                {
                    if (Lista[i].idCategoria == idCategoria)
                    {
                        errorFormulario.SetError(txtbidCategoria, $"Ya existe el id {idCategoria}.");

                        return;
                    }
                    else
                    {
                        errorFormulario.SetError(txtbidCategoria, "");
                    }

                    if (Lista[i].nombreCategoria == Categoria)
                    {
                        errorFormulario.SetError(txtbCategoria, $"Ya existe \"{Categoria}\" en la Lista de Categorías.");

                        return;
                    }
                    else
                    {
                        errorFormulario.SetError(txtbCategoria, "");
                    }
                }

                Lista.Add(new Categoria { idCategoria = idCategoria, nombreCategoria = Categoria });

                Actualizar();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Se ha producido el error {ex}");
            }

        }
    }
}