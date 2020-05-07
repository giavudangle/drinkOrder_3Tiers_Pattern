using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace drinkOrder_3Tiers_Pattern.Data_Access_Layer
{
    class OrderDataProvider
    {
        private static readonly string connectionString = "Data Source=ADMIN;Initial Catalog=QLQUAN;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public DataTable FetchListOrder()
        {
            DataTable dt = new DataTable();
            string queryString = "SELECT * FROM ORDER_DRINKS";

            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public void AddOrder(string orderID, string drinkID, int quantity, int sale)
        {         
            string queryString =
            "INSERT INTO ORDER_DRINKS(MSDH, MSHH, SoLuong, TiLeGiam)" +
            " VALUES(@orderID,@drinkID,@quantity,@sale);";
            
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@orderID", orderID);
            command.Parameters.AddWithValue("@drinkID", drinkID);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@sale", sale);
      
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Add Order Sucessfully");

        } 
    }
}
