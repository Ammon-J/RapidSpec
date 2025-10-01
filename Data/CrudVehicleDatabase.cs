using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using RapidSpec.Models;
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
    }
}
