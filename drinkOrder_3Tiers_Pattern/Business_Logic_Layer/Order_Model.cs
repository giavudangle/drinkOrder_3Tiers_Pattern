using drinkOrder_3Tiers_Pattern.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinkOrder_3Tiers_Pattern.Business_Logic_Layer
{
    class Order_Model
    {
        public DataTable GetListOrder()
        {
            try
            {
                OrderDataProvider orderDataProvider = new OrderDataProvider();
                return orderDataProvider.FetchListOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void AddOrder(string orderID, string drinkID, int quantity, int sale)
        {
            try
            {
                OrderDataProvider orderDataProvider = new OrderDataProvider();
                orderDataProvider.AddOrder(orderID, drinkID, quantity, sale);
                return;
            }
            catch
            {
                throw;
            }
        }
    }
}
