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
        public static string connectionString = "server=.;user id=root;pwd=abcde12345-;persistsecurityinfo=True;database=sdb";
        public async Task Create(StaffModel model)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO `Staff` (`firstname`, `lastname`, `phone`, `email`) VALUES (@firstname, @lastname, @phone, @email);";
                BindParams(cmd, model);
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task Delete(int staffId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@id",
                    DbType = DbType.Int32,
                    Value = staffId,
                });
                cmd.CommandText = @"DELETE FROM `BlogPost` WHERE `Id` = @id;";
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<StaffFilterResult> Filter(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task Update(StaffModel model)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"UPDATE `BlogPost` SET `firstname` = @firstname, `lastname` = @lastname, `email` = @email, `phone` = @phone WHERE `Id` = @id;";
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
