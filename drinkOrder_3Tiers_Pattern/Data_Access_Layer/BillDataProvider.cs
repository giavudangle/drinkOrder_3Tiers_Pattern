using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace drinkOrder_3Tiers_Pattern.Data_Access_Layer
{
    class BillDataProvider
    {
        private static readonly string connectionString = "Data Source=ADMIN;Initial Catalog=QLQUAN;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public BillDataProvider() { }

        public void AddBill(string orderID, DateTime dateTime)
        {
        
            string queryString =
               "INSERT INTO BILL_DRINKS(MSDH, NgayDat)" +
                " VALUES(@orderID,@dateTime)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@dateTime", dateTime.ToString());
            
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

    }
}
