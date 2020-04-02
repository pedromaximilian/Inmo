using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class PagoData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public PagoData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];

        }

        public int Alta(Pago p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO pagos (contratoId, numero, fechaVencimiento, importe, estado) " +
                        $"VALUES (@contratoId, @numero, @fechaVencimiento, @importe, 'pendiente');" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@contratoId", p.ContratoId);
                        command.Parameters.AddWithValue("@numero", p.Numero);
                        command.Parameters.AddWithValue("@fechaVencimiento", p.FechaVencimiento);
                        
                        command.Parameters.AddWithValue("@importe", p.Importe);
                        

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

        public int Pagar(int id)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE pagos SET estado = 'pagado', fechaPago = now() WHERE id = @id";


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
        public int Baja(int id)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE pagos SET estado = 'activo' WHERE id = @id";
                

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
        public int Modificacion(Pago p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE pagos SET @contratoId=contratoId, @numero=numero, @fechaVencimiento=fechaVencimiento, @fechaPago=fechaPago, @importe=importe WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@contratoId", p.ContratoId);
                    command.Parameters.AddWithValue("@numero", p.Numero);
                    command.Parameters.AddWithValue("@fechaVencimiento", p.FechaVencimiento);
                    command.Parameters.AddWithValue("@fechaPago", p.FechaPago);
                    command.Parameters.AddWithValue("@importe", p.Importe);


                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Pago> ObtenerTodos()
        {
            IList<Pago> res = new List<Pago>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM pagos";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            Id = reader.GetInt32(0),
                            ContratoId = reader.GetInt32(1),
                            Numero = reader.GetInt32(2),
                            FechaVencimiento = reader.GetDateTime(3),
                            FechaPago = reader.GetDateTime(4),
                            Importe = reader.GetDecimal(5),
                            Estado = reader.GetString(6)

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public Pago ObtenerPorId(int id)
        {
            Pago p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM pagos WHERE Id=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Pago
                        {
                            Id = reader.GetInt32(0),
                            ContratoId = reader.GetInt32(1),
                            Numero = reader.GetInt32(2),
                            FechaVencimiento = reader.GetDateTime(3),
                            FechaPago = reader.GetDateTime(4),
                            Importe = reader.GetDecimal(5),
                            Estado = reader.GetString(6)

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public IList<Pago> ObtenerPorContrato(int id)
        {
            IList<Pago> res = new List<Pago>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM pagos Where contratoId = @ContratoId";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@contratoId", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            Id = reader.GetInt32(0),
                            ContratoId = reader.GetInt32(1),
                            Numero = reader.GetInt32(2),
                            FechaVencimiento = reader.GetDateTime(3),
                            FechaPago = reader.GetDateTime(4),
                            Importe = reader.GetDecimal(5),
                            Estado = reader.GetString(6)

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }


        public IList<Pago> ObtenerTodosHoy()
        {
            IList<Pago> res = new List<Pago>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM pagos Where fechaPago = @fechaPago";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@fechaPago", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd");
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            Id = reader.GetInt32(0),
                            ContratoId = reader.GetInt32(1),
                            Numero = reader.GetInt32(2),
                            FechaVencimiento = reader.GetDateTime(3),
                            FechaPago = reader.GetDateTime(4),
                            Importe = reader.GetDecimal(5),
                            Estado = reader.GetString(6)

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
