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
                    string sql = $"INSERT INTO inmuebles (propietarioId, direccion, ambientes, uso, tipo, precio, disponible) " +
                        $"VALUES (@propietarioId, @direccion, @ambientes, @uso, @tipo, @precio, @disponible);" +
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
                        command.Parameters.AddWithValue("@disponible", p.Disponible);

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
                string sql = $"UPDATE Inmuebles SET propietarioId=@propietarioId, direccion=@direccion, ambientes=@ambientes, uso=@uso, tipo=@tipo, precio=@precio, disponible=@disponible WHERE Id = @id";
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
                    command.Parameters.AddWithValue("@disponible", p.Disponible);
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
                string sql = $"SELECT id, propietarioId, direccion, ambientes, uso, tipo, precio, disponible" +
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
                            Disponible = reader.GetBoolean(7),

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
                            Disponible = reader.GetBoolean(7),

                        };
                    }
                    connection.Close();
                }
            }

            p.Propietario = propietarioData.ObtenerPorId(p.PropietarioId);
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
                            Disponible = reader.GetBoolean(7),
                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inmueble> disponiblesPorFechas(DateTime inicio, DateTime fin)
        {

            List<Inmueble> res = new List<Inmueble>();
            Inmueble p = null;

            // Aca me llegan datetime 

            String start = inicio.ToString("yyyy-MM-dd"); // yyyy-MM-dd
            String end = fin.ToString("yyyy-MM-dd"); //dd-MM-yyyy

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql2 = "SELECT * FROM inmuebles i WHERE i.disponible = 1 and i.id NOT IN( SELECT I.id from contratos c INNER JOIN inmuebles i ON i.id = c.inmuebleId " +
                    "WHERE (@inicio <= c.fecha_fin) AND (@fin >= c.fecha_inicio) AND c.estado != 'rescindido')";
                try
                {
                    using (MySqlCommand command = new MySqlCommand(sql2, connection))
                    {
                        command.Parameters.Add("@inicio", MySqlDbType.String).Value = start;
                        command.Parameters.Add("@fin", MySqlDbType.String).Value = end;

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
                                Disponible = reader.GetBoolean(7),
                            };
                            p.Propietario = propietarioData.ObtenerPorId(p.PropietarioId);
                            res.Add(p);
                        }
                        connection.Close();
                    }
                }
                catch (MySqlException ex)
                {

                    throw;
                }
            }
            return res;
        }

        public Boolean validaFecha(string inicio, string fin, int id)
        {
            List<Inmueble> res = new List<Inmueble>();
            Inmueble p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {


                string sql2 = "SELECT * FROM inmuebles i WHERE i.id = @id AND i.id NOT IN(SELECT I.id FORM from contratos c INNER JOIN inmuebles i ON i.id = c.inmuebleId WHERE (@inicio <= c.fecha_fin) AND (@fin >= c.fecha_inicio))";

                try
                {
                    using (MySqlCommand command = new MySqlCommand(sql2, connection))
                    {
                        command.Parameters.Add("@inicio", MySqlDbType.String).Value = inicio;
                        command.Parameters.Add("@fin", MySqlDbType.String).Value = fin;
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
                                Disponible = reader.GetBoolean(7),
                            };
                            res.Add(p);
                        }
                        connection.Close();
                    }
                }
                catch (MySqlException ex)
                {

                    throw;
                }
            }

            if (res.Count<1)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
