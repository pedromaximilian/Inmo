using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class ContratoData
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;


        public ContratoData(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaulConnection"];
        }

        public int Alta(Contrato p)
        {
            int res = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"INSERT INTO Contratos (inmuebleId, inquilinoId, fecha_inicio, fecha_fin, monto, nombre_garante, dni_garante, telefono_garante, mail_garante, estado) " +
                        $"VALUES (@inmuebleId, @inquilinoId, @fecha_inicio, @fecha_fin, @monto, @nombre_garante, @dni_garante, @telefono_garante, @mail_garante, 'activo');" +
                        
                        $"SELECT LAST_INSERT_ID();";//devuelve el id insertado
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@inmuebleId", p.InmuebleId);
                        command.Parameters.AddWithValue("@inquilinoId", p.InquilinoId);
                        command.Parameters.AddWithValue("@fecha_inicio", p.FechaInicio);
                        command.Parameters.AddWithValue("@fecha_fin", p.FechaFin);
                        command.Parameters.AddWithValue("@monto", p.Monto);
                        command.Parameters.AddWithValue("@nombre_garante", p.NombreGarante);
                        command.Parameters.AddWithValue("@dni_garante", p.DniGarante);
                        command.Parameters.AddWithValue("@telefono_garante", p.TelefonoGarante);
                        command.Parameters.AddWithValue("@mail_garante", p.MailGarante);
                        

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
                string sql = $"UPDATE Contratos SET estado='borrado' WHERE Id = @id";
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
        public int Modificacion(Contrato p)
        {
            int res = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET inmuebleId=@inmuebleId, inquilinoId=@inquilinoId, fecha_inicio=@fecha_inicio,fecha_fin=@fecha_fin, monto=@monto, nombre_garante=@nombre_garante, dni_garante=@dni_garante, telefono_garante=@telefono_garante, mail_garante=@mail_garante WHERE Id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", p.Id);
                    command.Parameters.AddWithValue("@inmuebleId", p.InmuebleId);
                    command.Parameters.AddWithValue("@inquilinoId", p.InquilinoId);
                    command.Parameters.AddWithValue("@fecha_inicio", p.FechaInicio);
                    command.Parameters.AddWithValue("@fecha_fin", p.FechaFin);
                    command.Parameters.AddWithValue("@monto", p.Monto);
                    command.Parameters.AddWithValue("@nombre_garante", p.NombreGarante);
                    command.Parameters.AddWithValue("@dni_garante", p.DniGarante);
                    command.Parameters.AddWithValue("@telefono_garante", p.TelefonoGarante);
                    command.Parameters.AddWithValue("@mail_garante", p.MailGarante);
                    

                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Contrato> ObtenerTodos()
        {
            IList<Contrato> res = new List<Contrato>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"select * from contratos c join inquilinos i, inmuebles m WHERE c.inquilinoId = i.id AND c.inmuebleId = m.id";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Contrato c = new Contrato
                            {
                                Id = reader.GetInt32(0),
                                InmuebleId = reader.GetInt32(1),
                                InquilinoId = reader.GetInt32(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4),
                                Monto = reader.GetDecimal(5),
                                NombreGarante = reader.GetString(6),
                                DniGarante = reader.GetString(7),
                                TelefonoGarante = reader.GetString(8),
                                MailGarante = reader.GetString(9),
                                Estado = reader.GetString(10),
                                
                            };

                            Inquilino inq = new Inquilino
                            {
                                Id = reader.GetInt32(11),
                                Nombre = reader.GetString(12),
                                Apellido = reader.GetString(13),
                                Dni = reader.GetString(14),
                                Telefono = reader.GetString(15),
                                Email = reader.GetString(16),
                                LugarTrabajo = reader.GetString(17),
                                Estado = reader.GetString(18),
                            };

                            Inmueble i = new Inmueble
                            {
                                Id = reader.GetInt32(19),
                                PropietarioId = reader.GetInt32(20),
                                Direccion = reader.GetString(21),
                                Ambientes = reader.GetInt32(22),
                                Uso = reader.GetString(23),
                                Tipo = reader.GetString(24),
                                Precio = reader.GetFloat(25),
                                Estado = reader.GetString(26),

                            };

                            c.Inquilino = inq;
                            c.Inmueble = i;

                            res.Add(c);
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

        public IList<Contrato> ObtenerPorPropietario(int id)
        {
            IList<Contrato> res = new List<Contrato>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"SELECT * FROM Contratos where propietarioId=@id";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            Contrato c = new Contrato
                            

                            {
                                Id = reader.GetInt32(0),
                                InmuebleId = reader.GetInt32(1),
                                InquilinoId = reader.GetInt32(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4),
                                Monto = reader.GetDecimal(5),
                                NombreGarante = reader.GetString(6),
                                DniGarante = reader.GetString(7),
                                TelefonoGarante = reader.GetString(8),
                                MailGarante = reader.GetString(9),
                                Estado = reader.GetString(10),
                            };
                            try
                            {
                                res.Add(c);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                        connection.Close();
                    }
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<Contrato> ObtenerPorInquilino(int id)
        {
            IList<Contrato> res = new List<Contrato>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = $"SELECT * FROM Contratos where inquilinoId=@id";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Contrato c = new Contrato
                            {
                                Id = reader.GetInt32(0),
                                InmuebleId = reader.GetInt32(1),
                                InquilinoId = reader.GetInt32(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4),
                                Monto = reader.GetDecimal(5),
                                NombreGarante = reader.GetString(6),
                                DniGarante = reader.GetString(7),
                                TelefonoGarante = reader.GetString(8),
                                MailGarante = reader.GetString(9),
                                Estado = reader.GetString(10),
                            };
                            try
                            {

                                res.Add(c);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                        connection.Close();
                    }
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Contrato ObtenerPorId(int id)
        {
            Contrato c = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"select * from contratos c join inquilinos i join inmuebles m WHERE c.inquilinoId = i.id AND c.inmuebleId = m.id and c.id =@Id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        c = new Contrato
                        {
                            Id = reader.GetInt32(0),
                            InmuebleId = reader.GetInt32(1),
                            InquilinoId = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaFin = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            NombreGarante = reader.GetString(6),
                            DniGarante = reader.GetString(7),
                            TelefonoGarante = reader.GetString(8),
                            MailGarante = reader.GetString(9),
                            Estado = reader.GetString(10),

                        };
                        Inquilino inq = new Inquilino
                        {
                            Id = reader.GetInt32(11),
                            Nombre = reader.GetString(12),
                            Apellido = reader.GetString(13),
                            Dni = reader.GetString(14),
                            Telefono = reader.GetString(15),
                            Email = reader.GetString(16),
                            LugarTrabajo = reader.GetString(17),
                            Estado = reader.GetString(18),
                        };

                        Inmueble i = new Inmueble
                        {
                            Id = reader.GetInt32(19),
                            PropietarioId = reader.GetInt32(20),
                            Direccion = reader.GetString(21),
                            Ambientes = reader.GetInt32(22),
                            Uso = reader.GetString(23),
                            Tipo = reader.GetString(24),
                            Precio = reader.GetFloat(25),
                            Estado = reader.GetString(26),

                        };

                        c.Inquilino = inq;
                        c.Inmueble = i;
                    }
                    connection.Close();
                }
            }
            return c;
        }

        





    }
}
