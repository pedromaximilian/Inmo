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
                    string sql = $"INSERT INTO usuarios (mail, pass, rolId) " +
                        $"VALUES (@mail, @pass, @rol);" +
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@mail", p.Mail);
                        command.Parameters.AddWithValue("@pass", p.Pass);
                        command.Parameters.AddWithValue("@rol", p.RolId);

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
                string sql = $"DELETE FROM usuarios WHERE usuarios.id = @id ;";
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
                string sql = $"UPDATE usuarios SET mail=@mail, rolId=@rolId, avatar=@avatar WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@mail", p.Mail);
                    
                    
                    command.Parameters.AddWithValue("@rolId", p.RolId);
                    command.Parameters.AddWithValue("@avatar", p.Avatar);



                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public int ModificacionPass(Usuario p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE usuarios SET pass=@pass WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    
                    command.Parameters.AddWithValue("@pass", p.Pass);

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
                        
                        while (reader.Read())
                        {
                            Usuario p = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Mail = reader.GetString(1),
                                Pass = reader.GetString(2),
                                RolId = reader.GetInt32(3),
                                Avatar = reader.GetString(4)

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
                    $" WHERE id = @id";
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
                            
                            RolId = reader.GetInt16(3),
                            Avatar = reader.GetString(4)

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
                            
                            RolId = reader.GetInt16(3),
                            Avatar = reader.GetString(4)
                            

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }


    }
}
