using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ETLWorker.Services
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class DatabaseService
    {
        private readonly string connectionString =
@"Server=EMIL\LOCALDB#7ED6760D;Database=SistemaOpiniones;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Comentario> ObtenerComentarios()
        {
            var comentarios = new List<Comentario>();

            string query = "SELECT * FROM dbo.fact_comentarios";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comentarios.Add(new Comentario
                            {
                                Id = Convert.ToInt32(reader["id_comentario"]),
                                Texto = reader["texto_comentario"].ToString(),
                                Fecha = DateTime.Now
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return comentarios;
        }
    }
}