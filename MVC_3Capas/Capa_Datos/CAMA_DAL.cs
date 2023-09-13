using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Capa_Datos
{
    public class CAMA_DAL:ConnectionStrings
    {
        public List<CCAMA> Get()
        {
            List<CCAMA> Lista = new List<CCAMA>();

            try
            {
                using (SqlConnection connection = new SqlConnection(CadenaConexionLenovo))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ProCama", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                CCAMA ObjetoVacio = new CCAMA()
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0: reader.GetInt32(reader.GetOrdinal("Id")),
                                    Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "Sin Nombre" : reader.GetString(reader.GetOrdinal("Nombre")),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "Sin Descripcion" : reader.GetString(reader.GetOrdinal("Descripcion")),
                                };
                                Lista.Add(ObjetoVacio);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                CCAMA ObjetoError = new CCAMA() { Nombre = ex.ToString() };
                Lista.Add(ObjetoError);
                return Lista;
            }
            
            return Lista;
        }
    }
}
