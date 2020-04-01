using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class PropietarioData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public PropietarioData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];

        }

        public int Alta(Propietario p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO Propietarios (nombre, apellido, dni, email, telefono) " +
                        $"VALUES (@nombre, @apellido, @dni, @email, @telefono);" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@nombre", p.Nombre);
                        command.Parameters.AddWithValue("@apellido", p.Apellido);
                        command.Parameters.AddWithValue("@dni", p.Dni);
                        command.Parameters.AddWithValue("@email", p.Email);
                        command.Parameters.AddWithValue("@telefono", p.Telefono);
                        
                        
                        connection.Open();
                        res = Convert.ToInt32(command.ExecuteScalar());
                        p.Id = res;
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
                Console.WriteLine(e.Message);
            }
            return res;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Propietarios WHERE id = @id";
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
        public int Modificacion(Propietario p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Propietarios SET Nombre=@nombre, Apellido=@apellido, dni=@dni, Email=@email, Telefono=@telefono WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@nombre", p.Nombre);
                    command.Parameters.AddWithValue("@apellido", p.Apellido);
                    command.Parameters.AddWithValue("@dni", p.Dni);
                    command.Parameters.AddWithValue("@email", p.Email);
                    command.Parameters.AddWithValue("@telefono", p.Telefono);


                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Propietario> ObtenerTodos()
        {
            IList<Propietario> res = new List<Propietario>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT *" +
                    $" FROM Propietarios";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Propietario p = new Propietario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Email = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public Propietario ObtenerPorId(int id)
        {
            Propietario p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Propietarios" +
                    $" WHERE Id=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Propietario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Email = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

    }
}

