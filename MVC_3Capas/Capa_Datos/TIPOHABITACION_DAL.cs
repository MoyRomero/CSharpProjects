using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class TIPOHABITACION_DAL: ConnectionStrings
    {
        public List<CTIPOHABITACION> Get()
        {
            List<CTIPOHABITACION> Lista = new List<CTIPOHABITACION>();

            using (SqlConnection connection = new SqlConnection(CadenaConexionLenovo))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProTipoHabitacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            CTIPOHABITACION ObjetoVacio = new CTIPOHABITACION()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                            };
                            Lista.Add(ObjetoVacio);
                        }
                    }
                }
                connection.Close();
            }           
            return Lista;
        }

        public List<CTIPOHABITACION> SensitiveGet(string texto)
        {
            List<CTIPOHABITACION> Lista = new List<CTIPOHABITACION>();

            using (SqlConnection connection = new SqlConnection(CadenaConexionLenovo))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProFiltroSensitivoTipoHabitacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreHabitacion",texto);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            CTIPOHABITACION ObjetoVacio = new CTIPOHABITACION()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                            };
                            Lista.Add(ObjetoVacio);
                        }
                    }
                }
                connection.Close();
            }
            return Lista;
        }

        public List<CTIPOHABITACION> GetWithList()
        {
            List<CTIPOHABITACION> Lista = new List<CTIPOHABITACION>();

            CTIPOHABITACION Economica = new CTIPOHABITACION(){
                Id = 1,
                Nombre = "Económica",
                Descripcion = "Tipo de habitación económica para 2 personas"
            };

            CTIPOHABITACION Extra = new CTIPOHABITACION() {
                Id = 2,
                Nombre = "Extra",
                Descripcion = "Tipo de habitación Extra para 3 personas"
            };

            CTIPOHABITACION Deluxe = new CTIPOHABITACION() {
                Id = 3,
                Nombre = "Deluxe",
                Descripcion = "Tipo de habitación Deluxe para 5 personas"
            };

            Lista.Add(Economica);
            Lista.Add(Extra);
            Lista.Add(Deluxe);

            return Lista;
        }
    }
}
