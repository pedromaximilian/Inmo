using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class InmuebleData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        private PropietarioData propietarioData;

        public InmuebleData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];
            propietarioData = new PropietarioData(configuration);
        }

        public int Alta(Inmueble p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO inmuebles (propietarioId, direccion, ambientes, uso, tipo, precio, estado) " +
                        $"VALUES (@propietarioId, @direccion, @ambientes, @uso, @tipo, @precio, @estado);" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@propietarioId", p.PropietarioId);
                        command.Parameters.AddWithValue("@direccion", p.Direccion);
                        command.Parameters.AddWithValue("@ambientes", p.Ambientes);
                        command.Parameters.AddWithValue("@uso", p.Uso);
                        command.Parameters.AddWithValue("@tipo", p.Tipo);
                        command.Parameters.AddWithValue("@precio", p.Precio);
                        command.Parameters.AddWithValue("@estado", p.Estado);

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
                string sql = $"DELETE FROM Inmuebles WHERE id = @id";
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
        public int Modificacion(Inmueble p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Inmuebles SET propietarioId=@propietarioId, direccion=@direccion, ambientes=@ambientes, uso=@uso, tipo=@tipo, precio=@precio, estado=@estado WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@propietarioId", p.PropietarioId);
                    command.Parameters.AddWithValue("@direccion", p.Direccion);
                    command.Parameters.AddWithValue("@ambientes", p.Ambientes);
                    command.Parameters.AddWithValue("@uso", p.Uso);
                    command.Parameters.AddWithValue("@tipo", p.Tipo);
                    command.Parameters.AddWithValue("@precio", p.Precio);
                    command.Parameters.AddWithValue("@estado", p.Estado);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inmueble> ObtenerTodos()
        {
            IList<Inmueble> res = new List<Inmueble>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT id, propietarioId, direccion, ambientes, uso, tipo, precio, estado" +
                    $" FROM Inmuebles";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inmueble i = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            PropietarioId = reader.GetInt32(1),
                            Direccion = reader.GetString(2),
                            Ambientes = reader.GetInt32(3),
                            Uso = reader.GetString(4),
                            Tipo = reader.GetString(5),
                            Precio = reader.GetFloat(6),
                            Estado = reader.GetString(7),

                        };

                        i.Propietario = propietarioData.ObtenerPorId(i.PropietarioId);

                        res.Add(i);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public Inmueble ObtenerPorId(int id)
        {
            Inmueble p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Inmuebles" +
                    $" WHERE Id=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            PropietarioId = reader.GetInt32(1),
                            Direccion = reader.GetString(2),
                            Ambientes = reader.GetInt32(3),
                            Uso = reader.GetString(4),
                            Tipo = reader.GetString(5),
                            Precio = reader.GetFloat(6),
                            Estado = reader.GetString(7),

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }



        public IList<Inmueble> obtenerPorPropietario(int id)
        {
            List<Inmueble> res = new List<Inmueble>();
            Inmueble p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Inmuebles" +
                    $" WHERE propietarioId=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            PropietarioId = reader.GetInt32(1),
                            Direccion = reader.GetString(2),
                            Ambientes = reader.GetInt32(3),
                            Uso = reader.GetString(4),
                            Tipo = reader.GetString(5),
                            Precio = reader.GetFloat(6),
                            Estado = reader.GetString(7),
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
