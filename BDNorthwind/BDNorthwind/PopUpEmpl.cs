using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BDNorthwind
{
    public partial class PopUpEmpl : Form
    {
        public string accion { get; set; }
        public string ID { get; set; }

        public PopUpEmpl()
        {
            InitializeComponent();
        }
        NorthwindDataContext BD = new NorthwindDataContext();
        private void PopUpEmpl_Load(object sender, EventArgs e)
        {
            int idNuevoEmp;

            if (accion == "AGREGAR")
            {
                idNuevoEmp = ((from empl in BD.Employees
                                select empl.EmployeeID).Max() + 1);
                
                lblIndicacion.Text = "NUEVO EMPLEADO";
                lblID.Text = idNuevoEmp.ToString();
                this.Text = "NUEVO EMPLEADO"; 

            }

            if (accion == "EDITAR")
            {
                lblIndicacion.Text = "EDITANDO EMPLEADO";
                this.Text = "EDITAR EMPLEADO";

                var consulta = (from empl in BD.Employees
                                where empl.EmployeeID.Equals(ID)
                                select empl).ToList();

                foreach (var cons in consulta)
                {
                    lblID.Text = cons.EmployeeID.ToString();
                    txtNombre.Text = cons.FirstName.ToString();
                    txtApellido.Text = cons.LastName.ToString();
                    txtTitulo.Text = cons.Title.ToString();
                    dtFechaN.Text = cons.BirthDate.ToString();
                    txtDireccion.Text = cons.Address.ToString();
                }
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accion == "AGREGAR")
            {
                if(MessageBox.Show($"¿Desea agregar al empleado: {txtNombre.Text} a la base de datos?","CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Employees empleado = new Employees
                    {
                        EmployeeID = (from empl in BD.Employees
                                      select empl.EmployeeID).Max() + 1,
                        FirstName = txtNombre.Text.ToString(),
                        LastName = txtApellido.Text.ToString(),
                        Title = txtTitulo.Text.ToString(),
                        BirthDate = DateTime.Parse(dtFechaN.Text.ToString()),
                        Address = txtDireccion.Text.ToString(),
                        EHabilitado = true
                    };

                    BD.Employees.InsertOnSubmit(empleado);

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se ha agregado al empleado: {txtNombre.Text} a la base de datos, de forma correcta.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ha ocurrido un error: {ex}");
                    }
                }
            }

            if (accion == "EDITAR")
            {
                var consulta = (from empl in BD.Employees
                                where empl.EmployeeID.Equals(ID)
                                select empl).ToList();
                foreach(var cons in consulta)
                {
                    //cons.EmployeeID = int.Parse(txtCodigo.Text.ToString());
                    cons.FirstName = txtNombre.Text.ToString();
                    cons.LastName = txtApellido.Text.ToString();
                    cons.Title = txtTitulo.Text.ToString();
                    cons.BirthDate = DateTime.Parse(dtFechaN.Text.ToString());
                    cons.Address = txtDireccion.Text.ToString();
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show("Se han realizado los cambios.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error: {ex}");
                }
            }
        }
    }
}
