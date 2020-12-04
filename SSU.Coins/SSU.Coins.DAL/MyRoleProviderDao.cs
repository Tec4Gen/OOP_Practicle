using SSU.Coins.DAL.Interface;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SSU.Coins.DAL
{
    public class MyRoleProviderDao : IMyRoleProviderDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FitnessCenter"].ConnectionString;

        public string GetRolesForUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetRolesForUser]";

                SqlParameter parameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@UserName",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterUserName);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Name"] as string;
                }

                return null;
            }
        }
    }
}
