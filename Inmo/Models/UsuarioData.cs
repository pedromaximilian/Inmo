using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class UsuarioData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;


        public UsuarioData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];


        }

        public int Alta(Usuario p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO usuarios (mail, pass, salt, rolId, estado) " +
                        $"VALUES (@mail, @pass, @salt, @rol, 1);" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@nombre", p.Mail);
                        command.Parameters.AddWithValue("@apellido", p.Pass);
                        command.Parameters.AddWithValue("@dni", p.Salt);
                        command.Parameters.AddWithValue("@telefono", p.RolId);

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
                string sql = $"UPDATE usuarios SET estado = 0 WHERE Id = @id";
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
        public int Modificacion(Usuario p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE usuarios SET mail=@mail, pass=@pass, salt=@salt, rolId=@rolId, estado=@estado WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@nombre", p.Mail);
                    command.Parameters.AddWithValue("@apellido", p.Pass);
                    command.Parameters.AddWithValue("@dni", p.Salt);
                    command.Parameters.AddWithValue("@telefono", p.RolId);
                    command.Parameters.AddWithValue("@email", p.Estado);
                    


                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Usuario> ObtenerTodos()
        {
            try
            {
                IList<Usuario> res = new List<Usuario>();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"SELECT * FROM usuarios";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        List<Contrato> contratos = null;
                        while (reader.Read())
                        {
                            Usuario p = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Mail = reader.GetString(1),
                                Pass = reader.GetString(2),
                                Salt = reader.GetString(3),
                                RolId = reader.GetInt16(4),
                                Estado = reader.GetInt16(5),
                                


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

        public Usuario ObtenerPorId(int id)
        {
            Usuario p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM usuarios" +
                    $" WHERE Id=@id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Usuario
                        {
                            Id = reader.GetInt32(0),
                            Mail = reader.GetString(1),
                            Pass = reader.GetString(2),
                            Salt = reader.GetString(3),
                            RolId = reader.GetInt16(4),
                            Estado = reader.GetInt16(5),

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public Usuario ObtenerPorMail(string mail)
        {
            Usuario p = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM usuarios" +
                    $" WHERE mail like @mail";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@mail", MySqlDbType.String).Value = mail;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Usuario
                        {
                            Id = reader.GetInt32(0),
                            Mail = reader.GetString(1),
                            Pass = reader.GetString(2),
                            Salt = reader.GetString(3),
                            RolId = reader.GetInt16(4),
                            Estado = reader.GetInt16(5),

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }


    }
}
