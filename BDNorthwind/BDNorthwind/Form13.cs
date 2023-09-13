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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        NorthwindDataContext BD = new NorthwindDataContext();
        private void Form13_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvEmpleados.DataSource = null;

            if (tabla == null)
            {
                tabla = (from empl in BD.Employees
                         where empl.EHabilitado.Equals(true)
                         select new
                         {
                             COD = empl.EmployeeID,
                             NOMBRE = empl.FirstName,
                             APELLIDO = empl.LastName,
                             TITULO = empl.Title,
                             FECHA_N = empl.BirthDate,
                             DIRECCION = empl.Address
                         }).ToList();                
            }
            else if(tabla != null)
            {
                tabla = (from empl in BD.Employees
                                where empl.FirstName.Contains(txtNombre.Text)
                                select new
                                {
                                    COD = empl.EmployeeID,
                                    NOMBRE = empl.FirstName,
                                    APELLIDO = empl.LastName,
                                    TITULO = empl.Title,
                                    FECHA_N = empl.BirthDate,
                                    DIRECCION = empl.Address
                                }).ToList();
            }

            dgvEmpleados.DataSource = tabla;
        }

        string id;
        private void CapturaDatos(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            PopUpEmpl popUpE = new PopUpEmpl();
            popUpE.accion = "AGREGAR";            
            popUpE.ShowDialog();
            if (popUpE.DialogResult.Equals(DialogResult.OK))
            {
                RellenarTabla(tabla: null);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            PopUpEmpl popUpE = new PopUpEmpl();
            popUpE.accion = "EDITAR";
            popUpE.ID = id;
            popUpE.ShowDialog();

            if(popUpE.DialogResult.Equals(DialogResult.OK))
            {
                RellenarTabla(tabla:null);
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            string empleado = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();

            if (MessageBox.Show($"¿Realmente desea eliminar a: {empleado} de la lista de empleados de la base de datos?","CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from empl in BD.Employees
                               where empl.EmployeeID.Equals(id)
                               select empl;

                foreach (var cons in consulta) cons.EHabilitado = false;

                try
                {
                    BD.SubmitChanges();
                    RellenarTabla(tabla: null);
                    MessageBox.Show("Se eliminó correctamente.");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }  
        }
        private void filtradoNombre(object sender, EventArgs e)
        {
            RellenarTabla(tabla:txtNombre);
        }
    }
}
