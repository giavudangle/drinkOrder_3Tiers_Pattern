using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace drinkOrder_3Tiers_Pattern
{
    class DrinkDataProvider
    {
        private static readonly string connectionString = "Data Source=ADMIN;Initial Catalog=QLQUAN;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);
       
        public DrinkDataProvider() { }

        public DataTable FetchListDrinks()
        {
            DataTable dt = new DataTable();
            string queryString = "SELECT * FROM DRINKS";
            
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
            }
            return dt;
        }
      

        public void AddDrink(string drinkID, string drinkName, int price, int active)
        {

            string queryString =
                "INSERT INTO DRINKS(MSHH,TenHang,Gia,TinhTrang)" +
                 "VALUES(@drinkID,@drinkName,@price, @active)";

            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@drinkID", drinkID);
            command.Parameters.AddWithValue("@drinkName", drinkName);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@active", active);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
          
        public void DeleteDrink(string drinkID)
        {
          
            string queryString = "DELETE FROM DRINKS WHERE MSHH=@drinkID";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@drinkID", drinkID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();               
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
            }
        }
      
      
        public void EditDrink(string drinkID, string drinkName, int active, int price)
        {
            string queryString = "UPDATE DRINKS SET TinhTrang=@status,Gia=@price,TenHang=@drinkName " +
                  " WHERE MSHH=@drinkID";

            SqlCommand command = new SqlCommand(queryString, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@drinkName", drinkName);
            command.Parameters.AddWithValue("@status", active);
            command.Parameters.AddWithValue("@drinkID", drinkID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch 
            {
                throw;
            }
                       
        }

        public int SelectPrice_FromID(string id)
        {
            int res = 0;
            SqlCommand command = new SqlCommand("SELECT Gia FROM DRINKS WHERE MSHH=@drinkID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@drinkID", id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res = reader.GetInt32(0);
            }
            connection.Close();

            return res;
        }

        public string SelectID_FromName(string name)
        {
            string res = "";
            SqlCommand command = new SqlCommand("SELECT MSHH FROM DRINKS WHERE TenHang=@drinkName", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@drinkName", name);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res = reader["MSHH"].ToString();
            }

            connection.Close();
            return res;
        }

        public DataTable Select_ListDrinkName()
        {
            SqlCommand command = new SqlCommand("SELECT TenHang FROM DRINKS", connection);
          
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            
            try
            {
                while (reader.Read())
                {
                    
                    dt.Load(reader);
                    connection.Close();
                    return dt;
                }
            }
            catch
            {
                throw;
            }

            return dt;
        }


    }
}
