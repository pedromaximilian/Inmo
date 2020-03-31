using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class InquilinoData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        

        public InquilinoData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];
            

        }

        public int Alta(Inquilino p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO inquilinos (nombre, apellido, dni, telefono, email, lugar_trabajo, estado) " +
                        $"VALUES (@nombre, @apellido, @dni, @telefono, @email, @lugar_trabajo, 'activo');" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@nombre", p.Nombre);
                        command.Parameters.AddWithValue("@apellido", p.Apellido);
                        command.Parameters.AddWithValue("@dni", p.Dni);
                        command.Parameters.AddWithValue("@telefono", p.Telefono);
                        command.Parameters.AddWithValue("@email", p.Email);
                        command.Parameters.AddWithValue("@lugar_trabajo", p.LugarTrabajo);


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
                string sql = $"UPDATE Inquilinos SET estado='borrado' WHERE Id = @id";
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
        public int Modificacion(Inquilino p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE inquilinos SET nombre=@nombre, apellido=@apellido, dni=@dni, telefono=@telefono, email=@email, lugar_trabajo=@lugar_trabajo  WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@nombre", p.Nombre);
                    command.Parameters.AddWithValue("@apellido", p.Apellido);
                    command.Parameters.AddWithValue("@dni", p.Dni);
                    command.Parameters.AddWithValue("@telefono", p.Telefono);
                    command.Parameters.AddWithValue("@email", p.Email);
                    command.Parameters.AddWithValue("@lugar_trabajo", p.LugarTrabajo);
                    

                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inquilino> ObtenerTodos()
        {
            try
            {
                IList<Inquilino> res = new List<Inquilino>();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"SELECT * FROM Inquilinos";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        List<Contrato> contratos = null;
                        while (reader.Read())
                        {
                            Inquilino p = new Inquilino
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Dni = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Email = reader.GetString(5),
                                LugarTrabajo = reader.GetString(6),
                                Estado = reader.GetString(7),


                            };



                            res.Add(p);
                        }
                        connection.Close();
                    }
                }
                return res;
            }
            catch (MySqlException ex)
            {

                throw;
            }
        }

        public Inquilino ObtenerPorId(int id)
        {
            Inquilino p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM inquilinos" +
                    $" WHERE Id=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Inquilino
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                            LugarTrabajo = reader.GetString(6),
                            Estado = reader.GetString(7),

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }



        public IList<Inquilino> BuscarPor(string columna, string valor)
        {
            List<Inquilino> res = new List<Inquilino>();
            Inquilino p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM inquilinos WHERE @columna=@valor";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@columna", MySqlDbType.VarChar).Value = columna;
                    command.Parameters.Add("@valor", MySqlDbType.VarChar).Value = valor;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Inquilino
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                            LugarTrabajo = reader.GetString(6),
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
