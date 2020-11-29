using SSU.Coins.DAL.Interface;
using SSU.Coins.Entities;
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

        public IEnumerable<Coin> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertCoin";

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

                yield return new Coin 
                {
                    Title = reader["Title"] as string,
                    Date = (DateTime)reader["Date"],
                    Price = reader["Price"] as int?,
                    Anniversary = reader["Anniversary"] as string,
                    Description = reader["Description"] as string,
                    IdCountry = (int)reader["IdCountry"],
                    IdMaterial = (int)reader["IdMaterial"],
                    Picture = reader["Picture"] as byte[]
                };

                yield break;

            }
        }

        public Coin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Coin coin)
        {
            throw new NotImplementedException();
        }
    }
}
