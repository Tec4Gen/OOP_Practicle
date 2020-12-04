using Epam.FitnessCenter.CustomException;
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
    public class UserDao : IUserDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FitnessCenter"].ConnectionString;

        public void Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertUser";

                SqlParameter parameterFirstName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterFirstName);

                SqlParameter parameterLastName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@LastName",
                    Value = user.LastName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLastName);

                SqlParameter parameterMiddleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@MiddleName",
                    Value = user.MiddleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterMiddleName);

                SqlParameter parameterLogin = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLogin);

                SqlParameter parameterHashPassword = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@HashPassword",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterHashPassword);

                SqlParameter parameterRoleWebSite = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleWebSite",
                    Value = user.RoleWebSite,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterRoleWebSite);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    Logs.Log.Info("User added");

                }
                catch (SqlException ex)
                {
                    Logs.Log.Error(ex.Message);
                    if (ex.Number == 2627)
                        throw new UniqueIdentifierException("Login busy");
                    if (ex.Number == 547)
                        throw new RoleUndefinedException("Role not found in table");
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public bool Auth(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AuthUser";

                SqlParameter parameterLogin = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLogin);

                SqlParameter parameterHashPassword = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@HashPassword",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterHashPassword);

                try
                {
                    connection.Open();
                    if ((int)command.ExecuteScalar() > 0)
                    {
                        Logs.Log.Info("User auth");
                        return true;
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    return false;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";
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
                    yield return new User
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"] as string,
                        LastName = reader["LastName"] as string,
                        MiddleName = reader["MiddleName"] as string,
                        RoleWebSite = (int)reader["RoleWebSite"]
                    };
                }
                Logs.Log.Info("All user received");

                yield break;
            }
        }

        public IEnumerable<User> GetAllUserByRole(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserByRole";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdRole",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

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
                    yield return new User
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"] as string,
                        LastName = reader["LastName"] as string,
                        MiddleName = reader["MiddleName"] as string,
                        RoleWebSite = (int)reader["RoleWebSite"]
                    };
                }

                Logs.Log.Info("All user received");

                yield break;
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";

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
                        return new User
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"] as string,
                            LastName = reader["LastName"] as string,
                            MiddleName = reader["MiddleName"] as string,
                            RoleWebSite = (int)reader["RoleWebSite"]
                        };
                    }
                    Logs.Log.Info("User received");
                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public User GetByLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserByLogin";

                SqlParameter parameterLogin = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLogin);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = (int)reader["Id"],
                            RoleWebSite = (int)reader["RoleWebSite"]
                        };
                    }
                    Logs.Log.Info("User received");

                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUser";

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

                    command.ExecuteNonQuery();

                    Logs.Log.Info($"User with Id {id} deleted");
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = user.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                SqlParameter parameterFirstName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterFirstName);

                SqlParameter parameterLastName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@LastName",
                    Value = user.LastName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLastName);


                SqlParameter parameterMiddleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@MiddleName",
                    Value = user.MiddleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterMiddleName);

                SqlParameter parameterRoleWebSite = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleWebSite",
                    Value = user.RoleWebSite,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterRoleWebSite);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    Logs.Log.Info($"User with Id {user.Id} updated");
                }
                catch (SqlException ex)
                {
                    Logs.Log.Error(ex.Message);
                    if (ex.Number == 547)
                        throw new RoleUndefinedException("Role not found in table");
                    throw;
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
