using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class MARCA_DAL:ConnectionStrings
    {
        public List<CMARCA> Get()
        {
            List<CMARCA> Lista = new List<CMARCA>();

            using (SqlConnection connection = new SqlConnection(CadenaConexionLenovo))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("ProMarca",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader != null )
                    {
                        while (reader.Read())
                        {
                            CMARCA ObjetoVacio = new CMARCA()
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "Sin Nombre" : reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "Sin Descripcion" : reader.GetString(reader.GetOrdinal("Descripcion"))
                            };
                            Lista.Add(ObjetoVacio);
                        }
                    }                    
                }
                connection.Close();
            }
            return Lista;
        }
    }
}
