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
    public class CoinDao : ICoinDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Coins"].ConnectionString;

        public void Add(Coin coin)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertCoin";

                SqlParameter parameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = coin.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterTitle);

                SqlParameter parameterDate = new SqlParameter
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@Date",
                    Value = coin.Date,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDate);


                SqlParameter parameterPrice = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Price",
                    Value = coin.Price,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterPrice);


                SqlParameter parameterDescription = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Description",
                    Value = coin.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDescription);

                SqlParameter parameterIdCountry = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdCountry",
                    Value = coin.IdCountry,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdCountry);

                SqlParameter parameterIdMaterial = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdMaterial",
                    Value = coin.IdMaterial,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdMaterial);

                SqlParameter parameterPicture = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Picture",
                    Value = coin.Picture,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterPicture);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public IEnumerable<Coin> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllCoins";

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
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,   
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }
                yield break;

            }
        }

        public IEnumerable<Coin> GetByCountry(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByCountry";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdCountry",
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
                catch (Exception)
                {

                    throw;
                }

                while (reader.Read())
                {
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,                
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }

        }

        public IEnumerable<Coin> GetByDate(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByDate";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Date",
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
                catch
                {
                    throw;
                }

                while (reader.Read())
                {
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,        
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }
        }

        public Coin GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinById";

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
                        return new Coin
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"] as string,
                            Date = (DateTime)reader["Date"],
                            Price = reader["Price"] as int?,
                            Description = reader["Description"] as string,
                            IdCountry = (int)reader["IdCountry"],
                            IdMaterial = (int)reader["IdMaterial"],
                            Picture = reader["Picture"] as byte[]
                        };
                    }
                    Logs.Log.Info("Coin received");
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Coin> GetByMaterial(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByMaterial";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdMaterial",
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
                catch (Exception)
                {

                    throw;
                }

                while (reader.Read())
                {
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }
        }

        public IEnumerable<Coin> GetByPrice(int price)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByPrice";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Price",
                    Value = price,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

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
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }

        }

        public IEnumerable<Coin> GetByTitle(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByTitle";

                SqlParameter parameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterTitle);

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
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }
        }

        public IEnumerable<Coin> GetByTitleAndCountry(string title, int idCountry)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCoinByTitleAndCountry";

                SqlParameter parameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterTitle);

                SqlParameter parameterIdCountry = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdCountry",
                    Value = idCountry,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdCountry);

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
                    yield return new Coin
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Date = (DateTime)reader["Date"],
                        Price = reader["Price"] as int?,
                        Description = reader["Description"] as string,
                        IdCountry = (int)reader["IdCountry"],
                        IdMaterial = (int)reader["IdMaterial"],
                        Picture = reader["Picture"] as byte[]
                    };
                }

                yield break;
            }
        }

        public void RemoveById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteCoin";

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

        public void Update(Coin coin)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateCoin";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = coin.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                SqlParameter parameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = coin.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterTitle);

                SqlParameter parameterDate = new SqlParameter
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@Date",
                    Value = coin.Date,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDate);


                SqlParameter parameterPrice = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Price",
                    Value = coin.Price,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterPrice);

                //SqlParameter parameterAnniversary = new SqlParameter
                //{
                //    DbType = DbType.String,
                //    ParameterName = "@Anniversary",
                //    Value = coin.Anniversary,
                //    Direction = ParameterDirection.Input
                //};
                //command.Parameters.Add(parameterAnniversary);

                SqlParameter parameterDescription = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Description",
                    Value = coin.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDescription);

                SqlParameter parameterIdCountry = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdCountry",
                    Value = coin.IdCountry,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdCountry);

                SqlParameter parameterIdMaterial = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdMaterial",
                    Value = coin.IdMaterial,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdMaterial);

                SqlParameter parameterPicture = new SqlParameter
                {
                    DbType = DbType.Byte,
                    ParameterName = "@Picture",
                    Value = coin.Picture,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterPicture);

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
