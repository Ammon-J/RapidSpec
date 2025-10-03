using Microsoft.Data.SqlClient;
using RapidSpec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace RapidSpec.Data
{
    public class CrudVehicleDatabase
    {
        public static void AddVehicle(Vehicle car)
        {
            SqlConnection connection = DbHelper.GetConnection();
            string insertStatement =
                "INSERT VehicleSpecs " +
                "(Make, Model, Year, EngineName, EngineType, Price) " +
                "VALUES (@Make, @Model, @Year, @EngineName, @EngineType, @Price)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@Make", car.Make);
            insertCommand.Parameters.AddWithValue("@Model", car.Model);
            insertCommand.Parameters.AddWithValue("@Year", car.Year);
            insertCommand.Parameters.AddWithValue("@EngineName", car.EngineName);
            insertCommand.Parameters.AddWithValue("@EngineType", car.EngineType);
            insertCommand.Parameters.AddWithValue("@Price", car.Price);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("There was a problem saving the vehicle! Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static Vehicle GetVehicle(int id)
        {
            SqlConnection connection = DbHelper.GetConnection();
            string selectStatement =
                "SELECT * " +
                "FROM VehicleSpecs " +
                "WHERE Id = @ID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ID", id);
            
            Vehicle car = new Vehicle();
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    car.Id = (int)reader["id"];
                    car.Make = (string)reader["Make"];
                    car.Model = (string)reader["Model"];
                    car.Year = (int)reader["Year"];
                    car.EngineName = (string)reader["EngineName"];
                    car.EngineType = (string)reader["EngineType"];
                    car.Price = (float)reader["Price"];

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("There was a problem getting the vehicle! Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return car;
        }

        public static bool EditVehicle(Vehicle car)
        {
            SqlConnection connection = DbHelper.GetConnection();
            string updateStatement =
                "UPDATE VehicleSpecs " +
                "SET Make = @Make, " +
                "Model = @Model, " +
                "Year = @Year, " +
                "EngineName = @EngineName, " +
                "EngineType = @EngineType, " +
                "Price = @Price " +
                "WHERE Id = @ID";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@Make", car.Make);
            updateCommand.Parameters.AddWithValue("@Model", car.Model);
            updateCommand.Parameters.AddWithValue("@Year", car.Year);
            updateCommand.Parameters.AddWithValue("@EngineName", car.EngineName);
            updateCommand.Parameters.AddWithValue("@EngineType", car.EngineType);
            updateCommand.Parameters.AddWithValue("@Price", car.Price);
            updateCommand.Parameters.AddWithValue("@ID", car.Id);
            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool DeleteVehicle(int id)
        {
            SqlConnection connection = DbHelper.GetConnection();
            string deleteStatement =
                "DELETE FROM VehicleSpecs " +
                "WHERE Id = @ID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ID", id);
            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
