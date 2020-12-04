using SSU.Coins.DAL.Interface;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SSU.Coins.DAL
{
    public class AuthDao : IAuthDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Coins"].ConnectionString;
        public bool CanLogin(string login, byte[] password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.CheckUser";

                SqlParameter parameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterUserName);

                SqlParameter parameterHashPassword = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@HashPassword",
                    Value = password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterHashPassword);
                int result;
                try
                {
                    connection.Open();

                    result = (int)command.ExecuteScalar();

                    Logs.Log.Info("There is such a user");
                }
                catch (SqlException ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }

                return result > 0 ? true : false;
            }
        }
    }
}
