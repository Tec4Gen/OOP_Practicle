using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SSU.Coins.DAL
{
    public class CountryDao : ICountryDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Country"].ConnectionString;

        public IEnumerable<Country> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertCountry";

                SqlDataReader reader;

                try
                {
                    connection.Open();

                    reader = command.ExecuteReader();

                }
                catch (Exception)
                {

                    throw;
                }

                while (reader.Read())
                {
                    yield return new Country { Title = reader["Title"] as string };
                }
                

                yield break;

            }
        }

        public Country GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCountryById";

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
                        return new Country
                        {
                            Title = reader["Title"] as string,
                        };
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void RemoveById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteCountry";

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

                }
                catch (Exception)
                { 
                    throw;
                }
            }
        }

        public void Update(Country country)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateCountry";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = country.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                SqlParameter parameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = country.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterTitle);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
