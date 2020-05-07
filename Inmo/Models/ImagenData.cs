using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class ImagenData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;


        public ImagenData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];


        }

        public int Alta(Imagen p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO imagenes (inmuebleId, uri) " +
                        $"VALUES (@inmuebleId, @uri);" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@inmuebleId", p.InmuebleId);
                        command.Parameters.AddWithValue("@uri", p.Uri);
                        

                        connection.Open();
                        res = Convert.ToInt32(command.ExecuteScalar());
                        p.Id = res;
                        connection.Close();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return res;
        }


        public int Baja(int id)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM imagenes WHERE imagenes.id = @id ;";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        

        public IList<Imagen> ObtenerPorInmueble(int id)
        {
            IList<Imagen> res = new List<Imagen>();
            Imagen p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM imagenes" +
                    $" WHERE inmuebleId = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Imagen
                        {
                            Id = reader.GetInt32(0),
                            InmuebleId = reader.GetInt32(1),
                            Uri = reader.GetString(2),


                        };

                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }



    }
}
