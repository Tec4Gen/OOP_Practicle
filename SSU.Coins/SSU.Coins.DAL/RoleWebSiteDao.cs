using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using SSU.Coins.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SSU.Coins.DAL
{
    public class RoleWebSiteDao : IRoleWebSiteDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Coins"].ConnectionString;
        public IEnumerable<RoleWebSite> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRole";

                SqlDataReader reader;

                try
                {
                    connection.Open();

                    reader = command.ExecuteReader();

                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }

                while (reader.Read())
                {
                    yield return new RoleWebSite
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string
                    };
                }
                Logs.Log.Info($"All Role Received");

                yield break;
            }
        }

        public RoleWebSite GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleById";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new RoleWebSite
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string,
                        };
                    }
                    Logs.Log.Info("Role received");
                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }


        public RoleWebSite GetByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleByName";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new RoleWebSite
                        {
                            Id = (int)reader["Id"],
                        };
                    }
                    Logs.Log.Info("Role received");

                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }
    }
}
