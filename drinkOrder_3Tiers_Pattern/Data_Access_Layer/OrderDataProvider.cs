﻿using System;
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
            " VALUES(@orderID,@drinkID,@quantity,@sale)";
            
            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {

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
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine("DA CHAY QUA TANG DAL ORDER");

        }

        public void DeleteOrder(string orderID)
        {
            string queryString = "DELETE FROM ORDER_DRINKS WHERE MSDH=@orderID";
           
            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@orderID", orderID);
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

        public DataTable fetchListOrderDetail()
        {
            DataTable dt = new DataTable();
            string queryString = "SELECT T1.MSDH,T1.MSHH,T3.TenHang,T1.SoLuong,T1.TiLeGiam,T2.NgayDat" +
                                    " FROM ORDER_DRINKS AS T1 INNER JOIN BILL_DRINKS AS T2" +
                                        " ON T1.MSDH = T2.MSDH" +
                                        " JOIN DRINKS AS T3" +
                                        " ON T1.MSHH=T3.MSHH";

            
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
    }
}
