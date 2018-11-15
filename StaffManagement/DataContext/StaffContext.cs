using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StaffManagement.Models;

namespace StaffManagement.DataContext
{
    public class StaffContext : IStaffContext
    {
        private DbConfiguration _configuration { get; set; }
        public StaffContext(DbConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task Create(StaffModel model)
        {
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO `staff` (`firstname`, `lastname`, `phone`, `email`) VALUES (@firstname, @lastname, @phone, @email);";
                BindParams(cmd, model);
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task Delete(int staffId)
        {
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@id",
                    DbType = DbType.Int32,
                    Value = staffId,
                });
                cmd.CommandText = @"DELETE FROM `staff` WHERE `Id` = @id;";
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<StaffFilterResult> Filter(int pageNumber, int pageSize)
        {
            var staffFilterResult = new StaffFilterResult()
            {
                rows = new List<StaffModel>()
            };
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT count(1) as total from `staff`";
                var result = await cmd.ExecuteReaderAsync();
                result.Read();
                staffFilterResult.total = Convert.ToInt32(result["total"]);
                connection.Close();

                await connection.OpenAsync();
                cmd.CommandText = @"SELECT * from `staff` LIMIT @from,@to";
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@from",
                    DbType = DbType.Int32,
                    Value = pageNumber * pageSize,
                });
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@to",
                    DbType = DbType.Int32,
                    Value = (pageNumber + 1) * pageSize,
                });
                var rows = await cmd.ExecuteReaderAsync();
                while (rows.Read())
                {
                    staffFilterResult.rows.Add(new StaffModel()
                    {
                        Id = Convert.ToInt32(rows["Id"]),
                        firstname = Convert.ToString(rows["firstname"]),
                        lastname = Convert.ToString(rows["lastname"]),
                        email = Convert.ToString(rows["email"]),
                        phone = Convert.ToString(rows["phone"]),
                    });
                }
                connection.Close();
            }
            return staffFilterResult;
        }

        public async Task Update(StaffModel model)
        {
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"UPDATE `staff` SET `firstname` = @firstname, `lastname` = @lastname, `email` = @email, `phone` = @phone WHERE `Id` = @id;";
                BindParams(cmd, model);
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@id",
                    DbType = DbType.Int32,
                    Value = model.Id,
                });
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        private void BindParams(MySqlCommand cmd, StaffModel model)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@firstname",
                DbType = DbType.String,
                Value = model.firstname,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@lastname",
                DbType = DbType.String,
                Value = model.lastname,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = model.email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@phone",
                DbType = DbType.String,
                Value = model.phone,
            });
        }
    }
}
